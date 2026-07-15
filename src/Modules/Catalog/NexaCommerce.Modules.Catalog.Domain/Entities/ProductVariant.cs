namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductVariant
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public string Sku { get; private set; } = null!;

    public decimal Price { get; private set; }

    public decimal? OldPrice { get; private set; }

    public bool IsActive { get; private set; }

    public Product Product { get; private set; } = null!;

    private readonly List<ProductVariantOption> _options = new();

    public IReadOnlyCollection<ProductVariantOption> Options
        => _options;

    private ProductVariant()
    {
    }

    private ProductVariant(
        Guid productId,
        string sku,
        decimal price,
        decimal? oldPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Sku = sku;
        Price = price;
        OldPrice = oldPrice;
        IsActive = true;
    }

    public static ProductVariant Create(
        Guid productId,
        string sku,
        decimal price,
        decimal? oldPrice)
    {
        return new ProductVariant(
            productId,
            sku,
            price,
            oldPrice);
    }

    public void ChangePrice(
        decimal price,
        decimal? oldPrice)
    {
        Price = price;
        OldPrice = oldPrice;
    }

    public void Disable()
    {
        IsActive = false;
    }

    public void Enable()
    {
        IsActive = true;
    }

    public void AddOption(
        ProductVariantOption option)
    {
        _options.Add(option);
    }
}
