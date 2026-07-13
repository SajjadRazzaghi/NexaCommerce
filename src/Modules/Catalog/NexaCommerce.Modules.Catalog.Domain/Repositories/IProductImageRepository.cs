using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IProductImageRepository
{
    Task AddAsync(
        ProductImage image,
        CancellationToken cancellationToken);

    Task<List<ProductImage>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken);

    Task<ProductImage?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    void Remove(ProductImage image);
}
