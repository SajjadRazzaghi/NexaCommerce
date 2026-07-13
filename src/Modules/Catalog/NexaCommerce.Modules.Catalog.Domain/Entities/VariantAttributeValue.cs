namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class VariantAttributeValue
{
    public Guid Id { get; private set; }

    public Guid VariantId { get; private set; }

    public Guid AttributeId { get; private set; }

    public string Value { get; private set; } = null!;

    private VariantAttributeValue()
    {
    }

    private VariantAttributeValue(
        Guid id,
        Guid variantId,
        Guid attributeId,
        string value)
    {
        Id = id;
        VariantId = variantId;
        AttributeId = attributeId;
        Value = value;
    }

    public static VariantAttributeValue Create(
        Guid variantId,
        Guid attributeId,
        string value)
    {
        return new VariantAttributeValue(
            Guid.NewGuid(),
            variantId,
            attributeId,
            value);
    }
}
