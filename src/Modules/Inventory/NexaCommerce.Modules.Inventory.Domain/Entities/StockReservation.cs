namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class StockReservation
{
    public Guid Id { get; private set; }

    public Guid WarehouseId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public Guid OrderId { get; private set; }

    public int Quantity { get; private set; }

    public bool IsReleased { get; private set; }

    public DateTime ExpiresOnUtc { get; private set; }

    private StockReservation()
    {
    }

    private StockReservation(
        Guid warehouseId,
        Guid productvariantId,
        Guid orderId,
        int quantity,
        DateTime expiresOnUtc)
    {
        Id = Guid.NewGuid();
        WarehouseId = warehouseId;
        ProductVariantId = productvariantId;
        OrderId = orderId;
        Quantity = quantity;
        ExpiresOnUtc = expiresOnUtc;
    }

    public static StockReservation Create(
        Guid warehouseId,
        Guid productvariantId,
        Guid orderId,
        int quantity,
        DateTime expiresOnUtc)
    {
        return new(
            warehouseId,
            productvariantId,
            orderId,
            quantity,
            expiresOnUtc);
    }

    public void Release()
    {
        IsReleased = true;
    }
}
