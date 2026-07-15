using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;

internal sealed class InventoryItemRepository
    : IInventoryItemRepository
{
    private readonly InventoryDbContext _context;

    public InventoryItemRepository(
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

    public async Task<InventoryItem?> GetAsync(
        Guid warehouseId,
        Guid productVariantId,
        CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .FirstOrDefaultAsync(
                x =>
                    x.WarehouseId == warehouseId &&
                   x.ProductVariantId == productVariantId,
                cancellationToken);
    }

    public async Task<List<InventoryItem>> GetByWarehouseAsync(
     Guid warehouseId,
     CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .Where(x => x.WarehouseId == warehouseId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<InventoryItem>> GetByVariantAsync(
        Guid productVariantId,
        CancellationToken cancellationToken = default)
    {
        return await _context.InventoryItems
            .Where(x => x.ProductVariantId == productVariantId)
            .ToListAsync(cancellationToken);
    }
}
