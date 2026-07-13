using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IProductAttributeRepository
{
    Task<List<ProductAttribute>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<ProductAttribute?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        ProductAttribute attribute,
        CancellationToken cancellationToken = default);
}
