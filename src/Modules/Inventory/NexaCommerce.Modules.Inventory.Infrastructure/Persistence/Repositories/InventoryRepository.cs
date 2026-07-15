using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;

internal sealed class InventoryRepository
    : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(
        InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        InventoryItem item,
        CancellationToken cancellationToken = default)
    {
        await _context.InventoryItems.AddAsync(
            item,
            cancellationToken);
    }

    public async Task<InventoryItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .Include(x => x.Reservations)
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<InventoryItem?> GetByVariantAsync(
        Guid warehouseId,
        Guid variantId,
        CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .Include(x => x.Reservations)
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync(
                x => x.WarehouseId == warehouseId &&
                     x.ProductVariantId == variantId,
                cancellationToken);
    }

    public async Task<List<InventoryItem>> GetWarehouseInventoryAsync(
        Guid warehouseId,
        CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .Where(x => x.WarehouseId == warehouseId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
