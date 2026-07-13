using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class ProductSpecificationRepository
    : IProductSpecificationRepository
{
    private readonly CatalogDbContext _context;

    public ProductSpecificationRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ProductSpecification specification,
        CancellationToken cancellationToken)
    {
        await _context.ProductSpecifications.AddAsync(
            specification,
            cancellationToken);
    }

    public async Task<ProductSpecification?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.ProductSpecifications
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<List<ProductSpecification>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken)
    {
        return await _context.ProductSpecifications
            .Where(x => x.ProductId == productId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public void Remove(
        ProductSpecification specification)
    {
        _context.ProductSpecifications.Remove(specification);
    }
}
