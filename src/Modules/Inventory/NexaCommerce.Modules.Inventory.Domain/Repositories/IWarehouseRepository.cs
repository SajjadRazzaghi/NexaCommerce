using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Domain.Repositories;

public interface IWarehouseRepository
{
    Task AddAsync(
        Warehouse warehouse,
        CancellationToken cancellationToken = default);

    Task<Warehouse?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Warehouse?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default);

    Task<List<Warehouse>> GetAllAsync(
        CancellationToken cancellationToken = default);
}
