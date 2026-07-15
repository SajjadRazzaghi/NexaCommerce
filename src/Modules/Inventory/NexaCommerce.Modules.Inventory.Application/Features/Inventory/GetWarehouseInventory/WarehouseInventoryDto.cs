namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetWarehouseInventory;

public sealed record WarehouseInventoryDto(
    Guid InventoryItemId,
    Guid ProductVariantId,
    int Quantity,
    int ReservedQuantity,
    int AvailableQuantity);
