using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Domain.Repositories;

public interface IStockMovementRepository
{
    Task AddAsync(
        StockMovement movement,
        CancellationToken cancellationToken = default);

    Task<List<StockMovement>> GetByVariantAsync(
     Guid productVariantId,
     CancellationToken cancellationToken = default);

    Task<List<StockMovement>> GetByWarehouseAsync(
        Guid warehouseId,
        CancellationToken cancellationToken = default);
}
