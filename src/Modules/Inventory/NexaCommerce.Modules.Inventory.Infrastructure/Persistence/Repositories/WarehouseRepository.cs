using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;

internal sealed class WarehouseRepository
    : IWarehouseRepository
{
    private readonly InventoryDbContext _context;

    public WarehouseRepository(
        InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Warehouse warehouse,
        CancellationToken cancellationToken = default)
    {
        await _context.Warehouses.AddAsync(
            warehouse,
            cancellationToken);
    }

    public async Task<Warehouse?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Warehouses
            .Include(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Warehouse?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        return await _context.Warehouses
            .FirstOrDefaultAsync(
                x => x.Code == code,
                cancellationToken);
    }

    public async Task<List<Warehouse>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Warehouses
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
