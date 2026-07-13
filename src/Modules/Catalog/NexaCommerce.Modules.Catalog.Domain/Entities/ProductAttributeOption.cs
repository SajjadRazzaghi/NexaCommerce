namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductAttributeOption
{
    public Guid Id { get; private set; }

    public Guid ProductAttributeId { get; private set; }

    public string Name { get; private set; } = null!;

    public int DisplayOrder { get; private set; }

    public bool IsActive { get; private set; }

    private ProductAttributeOption()
    {
    }

    private ProductAttributeOption(
        Guid id,
        Guid productAttributeId,
        string name,
        int displayOrder)
    {
        Id = id;
        ProductAttributeId = productAttributeId;
        Name = name;
        DisplayOrder = displayOrder;
        IsActive = true;
    }

    public static ProductAttributeOption Create(
        Guid productAttributeId,
        string name,
        int displayOrder)
    {
        return new ProductAttributeOption(
            Guid.NewGuid(),
            productAttributeId,
            name,
            displayOrder);
    }

    public void Rename(string name)
    {
        Name = name;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
