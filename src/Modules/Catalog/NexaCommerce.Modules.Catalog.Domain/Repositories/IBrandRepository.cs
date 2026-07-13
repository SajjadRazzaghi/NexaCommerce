using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Domain.Repositories;

public interface IBrandRepository
{
    Task AddAsync(
        Brand brand,
        CancellationToken cancellationToken = default);

    Task<Brand?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Brand?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default);

    Task<List<Brand>> GetAllAsync(
        CancellationToken cancellationToken = default);
}
