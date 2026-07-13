using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductAttributeOptionRepository
    : IProductAttributeOptionRepository
{
    private readonly CatalogDbContext _context;

    public ProductAttributeOptionRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ProductAttributeOption entity,
        CancellationToken cancellationToken)
    {
        await _context.ProductAttributeOptions
            .AddAsync(entity, cancellationToken);
    }

    public async Task<ProductAttributeOption?>
        GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken)
    {
        return await _context.ProductAttributeOptions
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<ProductAttributeOption>>
        GetByAttributeAsync(
            Guid attributeId,
            CancellationToken cancellationToken)
    {
        return await _context.ProductAttributeOptions
            .Where(x =>
                x.ProductAttributeId == attributeId &&
                x.IsActive)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }
}
