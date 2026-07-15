using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Domain.Repositories;

public interface IInventoryRepository
{
    Task AddAsync(
        InventoryItem item,
        CancellationToken cancellationToken = default);

    Task<InventoryItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<InventoryItem?> GetByVariantAsync(
        Guid warehouseId,
        Guid variantId,
        CancellationToken cancellationToken = default);

    Task<List<InventoryItem>> GetWarehouseInventoryAsync(
        Guid warehouseId,
        CancellationToken cancellationToken = default);
}
