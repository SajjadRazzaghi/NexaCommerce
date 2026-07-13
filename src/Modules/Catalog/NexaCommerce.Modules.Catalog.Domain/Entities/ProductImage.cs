namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductImage
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public string Url { get; private set; } = null!;

    public bool IsMain { get; private set; }

    public int DisplayOrder { get; private set; }

    public Product Product { get; private set; } = null!;

    private ProductImage()
    {
    }

    private ProductImage(
        Guid productId,
        string url,
        bool isMain,
        int displayOrder)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Url = url;
        IsMain = isMain;
        DisplayOrder = displayOrder;
    }

    public static ProductImage Create(
        Guid productId,
        string url,
        bool isMain,
        int displayOrder)
    {
        return new ProductImage(
            productId,
            url,
            isMain,
            displayOrder);
    }

    public void SetMain()
    {
        IsMain = true;
    }

    public void RemoveMain()
    {
        IsMain = false;
    }
}
