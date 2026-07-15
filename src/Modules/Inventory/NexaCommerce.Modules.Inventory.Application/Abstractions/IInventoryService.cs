namespace NexaCommerce.Modules.Inventory.Application.Abstractions;

public interface IInventoryService
{
    Task IncreaseStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        int quantity,
        string description,
        CancellationToken cancellationToken = default);

    Task<bool> DecreaseStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        int quantity,
        string description,
        CancellationToken cancellationToken = default);

    Task<int> GetAvailableStockAsync(
        Guid warehouseId,
        Guid productVariantId,
        CancellationToken cancellationToken = default);

    Task<bool> ReserveStockAsync(
    Guid warehouseId,
    Guid productVariantId,
    Guid orderId,
    int quantity,
    CancellationToken cancellationToken = default);

    Task ReleaseReservationAsync(
        Guid reservationId,
        CancellationToken cancellationToken = default);

    Task CommitReservationAsync(
        Guid reservationId,
        CancellationToken cancellationToken = default);
    Task ReleaseExpiredReservationsAsync(
        CancellationToken cancellationToken = default);
}
