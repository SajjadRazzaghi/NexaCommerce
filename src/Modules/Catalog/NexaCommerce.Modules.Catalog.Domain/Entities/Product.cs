namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class Product
{
    private readonly List<ProductVariant> _variants = new();
    private readonly List<ProductImage> _images = new();
    private readonly List<ProductSpecification> _specifications = new();

    public Guid Id { get; private set; }

    public Guid CategoryId { get; private set; }

    public Guid BrandId { get; private set; }

    public string Title { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public bool IsPublished { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public IReadOnlyCollection<ProductVariant> Variants
        => _variants;

    public IReadOnlyCollection<ProductImage> Images
        => _images;

    public IReadOnlyCollection<ProductSpecification> Specifications
        => _specifications;

    private Product()
    {
    }

    private Product(
        Guid id,
        Guid categoryId,
        Guid brandId,
        string title,
        string slug,
        string description)
    {
        Id = id;
        CategoryId = categoryId;
        BrandId = brandId;
        Title = title;
        Slug = slug;
        Description = description;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public static Product Create(
        Guid categoryId,
        Guid brandId,
        string title,
        string slug,
        string description)
    {
        return new Product(
            Guid.NewGuid(),
            categoryId,
            brandId,
            title,
            slug,
            description);
    }

   

    public void AddVariant(ProductVariant variant)
    {
        _variants.Add(variant);
    }

    public void AddImage(ProductImage image)
    {
        _images.Add(image);
    }

    public void AddSpecification(ProductSpecification item)
    {
        _specifications.Add(item);
    }
    public void Update(
    Guid categoryId,
    Guid brandId,
    string title,
    string slug,
    string description)
    {
        CategoryId = categoryId;
        BrandId = brandId;
        Title = title;
        Slug = slug;
        Description = description;
    }

    public void Publish()
    {
        IsPublished = true;
    }

    public void UnPublish()
    {
        IsPublished = false;
    }

  


}
