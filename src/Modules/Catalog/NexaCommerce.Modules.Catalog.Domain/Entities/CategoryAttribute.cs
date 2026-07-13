namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class CategoryAttribute
{
    public Guid Id { get; private set; }

    public Guid CategoryId { get; private set; }

    public Guid ProductAttributeId { get; private set; }

    public bool IsRequired { get; private set; }

    public int DisplayOrder { get; private set; }

    private CategoryAttribute()
    {
    }

    private CategoryAttribute(
        Guid id,
        Guid categoryId,
        Guid productAttributeId,
        bool isRequired,
        int displayOrder)
    {
        Id = id;
        CategoryId = categoryId;
        ProductAttributeId = productAttributeId;
        IsRequired = isRequired;
        DisplayOrder = displayOrder;
    }

    public static CategoryAttribute Create(
        Guid categoryId,
        Guid productAttributeId,
        bool isRequired,
        int displayOrder)
    {
        return new CategoryAttribute(
            Guid.NewGuid(),
            categoryId,
            productAttributeId,
            isRequired,
            displayOrder);
    }
}
