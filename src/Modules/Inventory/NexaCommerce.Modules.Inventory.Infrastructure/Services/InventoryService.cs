using NexaCommerce.Modules.Inventory.Application.Abstractions;
using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Services;

internal sealed class InventoryService : IInventoryService
{
    private readonly IInventoryItemRepository _items;
    private readonly IStockMovementRepository _movements;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStockReservationRepository _reservations;

    public InventoryService(
        IInventoryItemRepository items,
        IStockMovementRepository movements,
        IUnitOfWork unitOfWork,
        IStockReservationRepository reservations)
    {
        _items = items;
        _movements = movements;
        _unitOfWork = unitOfWork;
        _reservations = reservations;
    }

    public async Task IncreaseStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        int quantity,
        string description,
        CancellationToken cancellationToken = default)
    {
        var item = await _items.GetAsync(
            warehouseId,
            productVariantId,
            cancellationToken);

        if (item == null)
        {
            item = InventoryItem.Create(
                warehouseId,
                productVariantId,
                quantity);

            await _items.AddAsync(
                item,
                cancellationToken);
        }
        else
        {
            item.Increase(quantity);
        }

        await _movements.AddAsync(
            StockMovement.Create(
                warehouseId,
                productVariantId,
                quantity,
                "IN",
                description),
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DecreaseStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        int quantity,
        string description,
        CancellationToken cancellationToken = default)
    {
        var item = await _items.GetAsync(
            warehouseId,
            productVariantId,
            cancellationToken);

        if (item == null)
            return false;

        if (item.AvailableQuantity < quantity)
            return false;

        item.Decrease(quantity);

        await _movements.AddAsync(
            StockMovement.Create(
                warehouseId,
                productVariantId,
                -quantity,
                "OUT",
                description),
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<int> GetAvailableStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        CancellationToken cancellationToken = default)
    {
        var item = await _items.GetAsync(
            warehouseId,
            productVariantId,
            cancellationToken);

        return item?.AvailableQuantity ?? 0;
    }
    public async Task<bool> ReserveStockAsync(
    Guid warehouseId,
    Guid productVariantId,
    Guid orderId,
    int quantity,
    CancellationToken cancellationToken = default)
    {
        var item = await _items.GetAsync(
            warehouseId,
            productVariantId,
            cancellationToken);

        if (item == null)
            return false;

        if (item.AvailableQuantity < quantity)
            return false;

        item.Reserve(quantity);

        var reservation =
            StockReservation.Create(
                warehouseId,
                productVariantId,
                orderId,
                quantity,
                DateTime.UtcNow.AddMinutes(30));

        await _reservations.AddAsync(
            reservation,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return true;
    }

    public async Task ReleaseReservationAsync(
    Guid reservationId,
    CancellationToken cancellationToken = default)
    {
        var reservation =
            await _reservations.GetByIdAsync(
                reservationId,
                cancellationToken);

        if (reservation == null)
            return;

        if (reservation.IsReleased)
            return;

        var item =
            await _items.GetAsync(
                reservation.WarehouseId,
                reservation.ProductVariantId,
                cancellationToken);

        if (item != null)
        {
            item.Release(reservation.Quantity);
        }

        reservation.Release();

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }

    public async Task CommitReservationAsync(
    Guid reservationId,
    CancellationToken cancellationToken = default)
    {
        var reservation =
            await _reservations.GetByIdAsync(
                reservationId,
                cancellationToken);

        if (reservation == null)
            return;

        if (reservation.IsReleased)
            return;

        var item =
            await _items.GetAsync(
                reservation.WarehouseId,
                reservation.ProductVariantId,
                cancellationToken);

        if (item == null)
            return;

        item.Release(reservation.Quantity);

        item.Decrease(reservation.Quantity);

        reservation.Release();

        await _movements.AddAsync(
            StockMovement.Create(
                reservation.WarehouseId,
                reservation.ProductVariantId,
                -reservation.Quantity,
                "SALE",
                "Order Completed"),
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
    public async Task ReleaseExpiredReservationsAsync(
    CancellationToken cancellationToken = default)
    {
        var expired =
            await _reservations.GetExpiredAsync(
                cancellationToken);

        foreach (var reservation in expired)
        {
            var item =
                await _items.GetAsync(
                    reservation.WarehouseId,
                    reservation.ProductVariantId,
                    cancellationToken);

            if (item == null)
                continue;

            item.Release(
                reservation.Quantity);

            reservation.Release();
        }

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}
