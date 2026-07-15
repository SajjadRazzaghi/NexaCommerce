using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;

internal sealed class StockReservationRepository
    : IStockReservationRepository
{
    private readonly InventoryDbContext _context;

    public StockReservationRepository(
        InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        StockReservation reservation,
        CancellationToken cancellationToken = default)
    {
        await _context.StockReservations.AddAsync(
            reservation,
            cancellationToken);
    }

    public async Task<StockReservation?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.StockReservations
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<StockReservation>> GetByOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default)
    {
        return await _context.StockReservations
            .Where(x =>
                x.OrderId == orderId &&
                !x.IsReleased)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<StockReservation>> GetExpiredAsync(
        DateTime utcNow,
        CancellationToken cancellationToken = default)
    {
        return await _context.StockReservations
            .Where(x =>
                !x.IsReleased &&
                x.ExpiresOnUtc <= utcNow)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<StockReservation>> GetByWarehouseAsync(
    Guid warehouseId,
    CancellationToken cancellationToken = default)
    {
        return await _context.StockReservations
            .Where(x => x.WarehouseId == warehouseId)
            .OrderByDescending(x => x.ExpiresOnUtc)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<StockReservation>> GetExpiredAsync(
    CancellationToken cancellationToken = default)
    {
        return await _context.StockReservations
            .Where(x =>
                !x.IsReleased &&
                x.ExpiresOnUtc <= DateTime.UtcNow)
            .ToListAsync(cancellationToken);
    }

    public Task UpdateAsync(
        StockReservation reservation,
        CancellationToken cancellationToken = default)
    {
        _context.StockReservations.Update(reservation);

        return Task.CompletedTask;
    }
}
