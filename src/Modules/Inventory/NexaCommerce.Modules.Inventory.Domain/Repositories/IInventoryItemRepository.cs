using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Domain.Repositories;

public interface IInventoryItemRepository
{
    Task AddAsync(
        InventoryItem item,
        CancellationToken cancellationToken = default);

    Task<InventoryItem?> GetAsync(
        Guid warehouseId,
        Guid productVariantId,
        CancellationToken cancellationToken = default);

    Task<List<InventoryItem>> GetByWarehouseAsync(
        Guid warehouseId,
        CancellationToken cancellationToken = default);

    Task<List<InventoryItem>> GetByVariantAsync(
        Guid productVariantId,
        CancellationToken cancellationToken = default);
}
