namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductSpecification
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public string Title { get; private set; } = null!;

    public string Value { get; private set; } = null!;

    public int DisplayOrder { get; private set; }

    public Product Product { get; private set; } = null!;

    private ProductSpecification()
    {
    }

    private ProductSpecification(
        Guid productId,
        string title,
        string value,
        int displayOrder)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Title = title;
        Value = value;
        DisplayOrder = displayOrder;
    }

    public static ProductSpecification Create(
        Guid productId,
        string title,
        string value,
        int displayOrder)
    {
        return new ProductSpecification(
            productId,
            title,
            value,
            displayOrder);
    }

    public void Update(
        string title,
        string value,
        int displayOrder)
    {
        Title = title;
        Value = value;
        DisplayOrder = displayOrder;
    }
}
