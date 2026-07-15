namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class InventoryReservation
{
    public Guid Id { get; private set; }

    public Guid InventoryItemId { get; private set; }

    public Guid OrderId { get; private set; }

    public int Quantity { get; private set; }

    public bool IsReleased { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public InventoryItem InventoryItem { get; private set; } = null!;

    private InventoryReservation()
    {
    }

    private InventoryReservation(
        Guid inventoryItemId,
        Guid orderId,
        int quantity)
    {
        Id = Guid.NewGuid();

        InventoryItemId = inventoryItemId;

        OrderId = orderId;

        Quantity = quantity;

        CreatedOnUtc = DateTime.UtcNow;
    }

    public static InventoryReservation Create(
        Guid inventoryItemId,
        Guid orderId,
        int quantity)
    {
        return new InventoryReservation(
            inventoryItemId,
            orderId,
            quantity);
    }

    public void Release()
    {
        IsReleased = true;
    }
}
