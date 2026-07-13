using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface ICategoryAttributeRepository
{
    Task AddAsync(
        CategoryAttribute entity,
        CancellationToken cancellationToken = default);

    Task<List<CategoryAttribute>> GetByCategoryAsync(
        Guid categoryId,
        CancellationToken cancellationToken = default);
}
