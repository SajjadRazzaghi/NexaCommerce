using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;

internal sealed class StockMovementRepository
    : IStockMovementRepository
{
    private readonly InventoryDbContext _context;

    public StockMovementRepository(
        InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        StockMovement movement,
        CancellationToken cancellationToken = default)
    {
        await _context.StockMovements.AddAsync(
            movement,
            cancellationToken);
    }

    public async Task<List<StockMovement>> GetByVariantAsync(
     Guid productVariantId,
     CancellationToken cancellationToken = default)
    {
        return await _context.StockMovements
            .Where(x => x.ProductVariantId == productVariantId)
            .OrderByDescending(x => x.CreatedOnUtc)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<StockMovement>> GetByWarehouseAsync(
        Guid warehouseId,
        CancellationToken cancellationToken = default)
    {
        return await _context.StockMovements
            .Where(x => x.WarehouseId == warehouseId)
            .OrderByDescending(x => x.CreatedOnUtc)
            .ToListAsync(cancellationToken);
    }
}
