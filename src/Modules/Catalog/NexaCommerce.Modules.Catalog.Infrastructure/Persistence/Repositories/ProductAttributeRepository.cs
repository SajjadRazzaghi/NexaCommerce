using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductAttributeRepository
    : IProductAttributeRepository
{
    private readonly CatalogDbContext _context;

    public ProductAttributeRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductAttribute>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.ProductAttributes
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductAttribute?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.ProductAttributes
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task AddAsync(
        ProductAttribute attribute,
        CancellationToken cancellationToken)
    {
        await _context.ProductAttributes.AddAsync(
            attribute,
            cancellationToken);
    }
}
