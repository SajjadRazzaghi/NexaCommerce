namespace NexaCommerce.Modules.Inventory.Domain.Entities;

public sealed class Warehouse
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string Code { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    private readonly List<InventoryItem> _items = new();

    public IReadOnlyCollection<InventoryItem> Items
        => _items;

    private Warehouse()
    {
    }

    private Warehouse(
        Guid id,
        string name,
        string code)
    {
        Id = id;
        Name = name;
        Code = code;
        IsActive = true;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public static Warehouse Create(
        string name,
        string code)
    {
        return new Warehouse(
            Guid.NewGuid(),
            name,
            code);
    }

    public void Disable()
    {
        IsActive = false;
    }

    public void Enable()
    {
        IsActive = true;
    }
}
