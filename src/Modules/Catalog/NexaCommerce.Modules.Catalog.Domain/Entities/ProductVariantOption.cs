namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductVariantOption
{
    public Guid Id { get; private set; }

    public Guid VariantId { get; private set; }

    public Guid ProductAttributeId { get; private set; }

    public Guid ProductAttributeOptionId { get; private set; }

    public ProductVariant Variant { get; private set; } = null!;

    private ProductVariantOption()
    {
    }

    private ProductVariantOption(
        Guid variantId,
        Guid attributeId,
        Guid optionId)
    {
        Id = Guid.NewGuid();
        VariantId = variantId;
        ProductAttributeId = attributeId;
        ProductAttributeOptionId = optionId;
    }

    public static ProductVariantOption Create(
        Guid variantId,
        Guid attributeId,
        Guid optionId)
    {
        return new ProductVariantOption(
            variantId,
            attributeId,
            optionId);
    }
}
