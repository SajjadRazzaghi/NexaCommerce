using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Product?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(
    Product product,
    CancellationToken cancellationToken = default);
    Task<Product?> GetWithImagesAsync(
     Guid id,
     CancellationToken cancellationToken = default);
}
