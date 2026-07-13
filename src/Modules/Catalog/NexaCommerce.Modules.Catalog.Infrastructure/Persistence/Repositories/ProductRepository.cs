using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductRepository
    : IProductRepository
{
    private readonly CatalogDbContext _context;

    public ProductRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(x => x.Images)
            .Include(x => x.Variants)
            .Include(x => x.Specifications)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Product?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .FirstOrDefaultAsync(
                x => x.Slug == slug,
                cancellationToken);
    }

    public async Task AddAsync(
        Product product,
        CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(
            product,
            cancellationToken);
    }

   
    public Task DeleteAsync(
    Product product,
    CancellationToken cancellationToken = default)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }
    public async Task<Product?> GetWithImagesAsync(
    Guid id,
    CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Include(x => x.Images)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}
