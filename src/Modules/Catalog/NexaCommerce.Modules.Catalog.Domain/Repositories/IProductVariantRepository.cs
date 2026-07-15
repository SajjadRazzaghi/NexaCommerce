using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IProductVariantRepository
{
    Task AddAsync(
        ProductVariant variant,
        CancellationToken cancellationToken = default);

    Task<ProductVariant?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<ProductVariant>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default);
}
