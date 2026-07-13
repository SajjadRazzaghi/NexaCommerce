using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IProductAttributeOptionRepository
{
    Task AddAsync(
        ProductAttributeOption entity,
        CancellationToken cancellationToken = default);

    Task<ProductAttributeOption?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<ProductAttributeOption>>
        GetByAttributeAsync(
            Guid attributeId,
            CancellationToken cancellationToken = default);
}
