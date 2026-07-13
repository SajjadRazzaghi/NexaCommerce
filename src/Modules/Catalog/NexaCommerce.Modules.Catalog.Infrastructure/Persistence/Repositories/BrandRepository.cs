using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class BrandRepository
    : IBrandRepository
{
    private readonly CatalogDbContext _context;

    public BrandRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Brand brand,
        CancellationToken cancellationToken = default)
    {
        await _context.Brands.AddAsync(
            brand,
            cancellationToken);
    }

    public async Task<Brand?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Brands
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Brand?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        return await _context.Brands
            .FirstOrDefaultAsync(
                x => x.Name == name,
                cancellationToken);
    }

    public async Task<List<Brand>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Brands
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
