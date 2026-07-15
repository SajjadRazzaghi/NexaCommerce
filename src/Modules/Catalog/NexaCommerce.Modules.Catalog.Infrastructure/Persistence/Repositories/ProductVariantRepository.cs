using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductVariantRepository
    : IProductVariantRepository
{
    private readonly CatalogDbContext _context;

    public ProductVariantRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ProductVariant variant,
        CancellationToken cancellationToken = default)
    {
        await _context.ProductVariants.AddAsync(
            variant,
            cancellationToken);
    }

    public async Task<ProductVariant?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.ProductVariants
            .Include(x => x.Options)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<ProductVariant>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        return await _context.ProductVariants
            .Where(x => x.ProductId == productId)
            .Include(x => x.Options)
            .ToListAsync(cancellationToken);
    }
}
