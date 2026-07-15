namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetVariantInventory;

public sealed record VariantInventoryDto(
    Guid WarehouseId,
    Guid InventoryItemId,
    int Quantity,
    int ReservedQuantity,
    int AvailableQuantity);
