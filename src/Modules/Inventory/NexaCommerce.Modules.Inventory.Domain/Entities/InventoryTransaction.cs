namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class InventoryTransaction
{
    public Guid Id { get; private set; }

    public Guid InventoryItemId { get; private set; }

    public int Quantity { get; private set; }

    public string Type { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; private set; }

    public InventoryItem InventoryItem { get; private set; } = null!;

    private InventoryTransaction()
    {
    }

    private InventoryTransaction(
        Guid inventoryItemId,
        int quantity,
        string type,
        string description)
    {
        Id = Guid.NewGuid();

        InventoryItemId = inventoryItemId;

        Quantity = quantity;

        Type = type;

        Description = description;

        CreatedOnUtc = DateTime.UtcNow;
    }

    public static InventoryTransaction Create(
        Guid inventoryItemId,
        int quantity,
        string type,
        string description)
    {
        return new InventoryTransaction(
            inventoryItemId,
            quantity,
            type,
            description);
    }
}
