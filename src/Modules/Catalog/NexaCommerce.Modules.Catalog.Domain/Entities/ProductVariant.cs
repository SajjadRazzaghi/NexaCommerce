namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductVariant
{
    private readonly List<VariantAttributeValue> _attributes = new();

    public IReadOnlyCollection<VariantAttributeValue> Attributes
        => _attributes;
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public string Sku { get; private set; } = null!;

   
    public decimal Price { get; private set; }

    public decimal? DiscountPrice { get; private set; }

    public int Stock { get; private set; }

    public bool IsActive { get; private set; }

    private ProductVariant()
    {
    }
    public void AddAttribute(
    VariantAttributeValue attribute)
    {
        _attributes.Add(attribute);
    }
    private ProductVariant(
        Guid id,
        Guid productId,
        string sku,
      
        decimal price,
        decimal? discountPrice,
        int stock)
    {
        Id = id;
        ProductId = productId;
        Sku = sku;   
        Price = price;
        DiscountPrice = discountPrice;
        Stock = stock;
        IsActive = true;
    }

    public static ProductVariant Create(
        Guid productId,
        string sku,
        decimal price,
        decimal? discountPrice,
        int stock)
    {
        return new ProductVariant(
            Guid.NewGuid(),
            productId,
            sku,
            
            price,
            discountPrice,
            stock);
    }

    public void UpdatePrice(decimal price)
    {
        Price = price;
    }

    public void UpdateDiscount(decimal? discount)
    {
        DiscountPrice = discount;
    }

    public void IncreaseStock(int quantity)
    {
        Stock += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        Stock -= quantity;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
