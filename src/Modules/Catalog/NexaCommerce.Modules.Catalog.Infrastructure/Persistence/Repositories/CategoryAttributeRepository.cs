using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;

internal sealed class CategoryAttributeRepository
    : ICategoryAttributeRepository
{
    private readonly CatalogDbContext _context;

    public CategoryAttributeRepository(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        CategoryAttribute entity,
        CancellationToken cancellationToken)
    {
        await _context.CategoryAttributes
            .AddAsync(entity, cancellationToken);
    }

    public async Task<List<CategoryAttribute>>
        GetByCategoryAsync(
            Guid categoryId,
            CancellationToken cancellationToken)
    {
        return await _context.CategoryAttributes
            .Where(x => x.CategoryId == categoryId)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }
}
