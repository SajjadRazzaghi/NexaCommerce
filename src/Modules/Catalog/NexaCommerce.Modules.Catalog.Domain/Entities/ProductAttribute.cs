using NexaCommerce.Modules.Catalog.Domain.Enums;

namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class ProductAttribute
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public ProductAttributeType Type { get; private set; }

    public bool IsVariant { get; private set; }

    public bool IsFilterable { get; private set; }

    public bool IsSearchable { get; private set; }

    private ProductAttribute()
    {
    }

    private ProductAttribute(
        Guid id,
        string name,
        ProductAttributeType type,
        bool isVariant,
        bool isFilterable,
        bool isSearchable)
    {
        Id = id;
        Name = name;
        Type = type;
        IsVariant = isVariant;
        IsFilterable = isFilterable;
        IsSearchable = isSearchable;
    }

    public static ProductAttribute Create(
        string name,
        ProductAttributeType type,
        bool isVariant,
        bool isFilterable,
        bool isSearchable)
    {
        return new ProductAttribute(
            Guid.NewGuid(),
            name,
            type,
            isVariant,
            isFilterable,
            isSearchable);
    }
}
