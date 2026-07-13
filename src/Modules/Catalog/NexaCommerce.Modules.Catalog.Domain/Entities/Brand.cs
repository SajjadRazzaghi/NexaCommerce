namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class Brand
{
    private Brand()
    {
    }

    public Brand(
        Guid id,
        string name,
        string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime CreatedOnUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? ModifiedOnUtc { get; private set; }

    public static Brand Create(
        string name,
        string? description)
    {
        return new Brand(
            Guid.NewGuid(),
            name,
            description);
    }

    public void Update(
        string name,
        string? description)
    {
        Name = name;
        Description = description;
        ModifiedOnUtc = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        ModifiedOnUtc = DateTime.UtcNow;
    }
}
