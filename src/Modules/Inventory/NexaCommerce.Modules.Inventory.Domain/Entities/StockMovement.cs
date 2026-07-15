namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class StockMovement
{
    public Guid Id { get; private set; }

    public Guid WarehouseId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public int Quantity { get; private set; }

    public string Type { get; private set; } = null!;

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    private StockMovement()
    {
    }

    private StockMovement(
        Guid warehouseId,
        Guid productvariantId,
        int quantity,
        string type,
        string? description)
    {
        Id = Guid.NewGuid();
        WarehouseId = warehouseId;
        ProductVariantId = productvariantId;
        Quantity = quantity;
        Type = type;
        Description = description;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public static StockMovement Create(
        Guid warehouseId,
        Guid productVariantId,
        int quantity,
        string type,
        string? description)
    {
        return new StockMovement(
            warehouseId,
            productVariantId,
            quantity,
            type,
            description);
    }
}
