namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class InventoryItem
{
    public Guid Id { get; private set; }

    public Guid WarehouseId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public int Quantity { get; private set; }

    public int ReservedQuantity { get; private set; }

    public Warehouse Warehouse { get; private set; } = null!;

    private readonly List<InventoryReservation> _reservations = new();

    public IReadOnlyCollection<InventoryReservation> Reservations
        => _reservations;
    private readonly List<InventoryTransaction> _transactions = new();

    public IReadOnlyCollection<InventoryTransaction> Transactions
        => _transactions;
    private InventoryItem()
    {
    }

    private InventoryItem(
        Guid warehouseId,
        Guid productVariantId)
    {
        Id = Guid.NewGuid();

        WarehouseId = warehouseId;

        ProductVariantId = productVariantId;

        Quantity = 0;

        ReservedQuantity = 0;
    }

    public static InventoryItem Create(
        Guid warehouseId,
        Guid productVariantId,
        int quantity)
    {
        return new InventoryItem(
            warehouseId,
            productVariantId);
    }

    public int AvailableQuantity
        => Quantity - ReservedQuantity;

    public void Increase(int quantity)
    {
        Quantity += quantity;
    }

    public void Decrease(int quantity)
    {
        Quantity -= quantity;
    }

    public void Reserve(int quantity)
    {
        ReservedQuantity += quantity;
    }

    public void Release(int quantity)
    {
        ReservedQuantity -= quantity;
    }
    public void AddReservation(
    InventoryReservation reservation)
    {
        _reservations.Add(reservation);
    }

    public void AddTransaction(
        InventoryTransaction transaction)
    {
        _transactions.Add(transaction);
    }
}
