namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

using NexaCommerce.Modules.Catalog.Domain.Entities;

public interface IProductSpecificationRepository
{
    Task AddAsync(
        ProductSpecification specification,
        CancellationToken cancellationToken);

    Task<ProductSpecification?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task<List<ProductSpecification>> GetByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken);

    void Remove(
        ProductSpecification specification);
}
