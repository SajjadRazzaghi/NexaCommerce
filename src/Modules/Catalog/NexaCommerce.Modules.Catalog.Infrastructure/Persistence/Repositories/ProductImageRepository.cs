using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductImageRepository
    : IProductImageRepository
{
    private readonly CatalogDbContext _context;

    public ProductImageRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ProductImage image,
        CancellationToken cancellationToken)
    {
        await _context.ProductImages.AddAsync(
            image,
            cancellationToken);
    }

    public async Task<List<ProductImage>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken)
    {
        return await _context.ProductImages
            .Where(x => x.ProductId == productId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductImage?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.ProductImages
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public void Remove(ProductImage image)
    {
        _context.ProductImages.Remove(image);
    }
}
