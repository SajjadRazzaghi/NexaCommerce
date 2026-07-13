namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class Category
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public Guid? ParentId { get; private set; }

    public Category? Parent { get; private set; }

    private readonly List<Category> _children = [];

    public IReadOnlyCollection<Category> Children => _children;

    private Category()
    {
    }

    private Category(
        Guid id,
        string title,
        string slug,
        Guid? parentId)
    {
        Id = id;
        Title = title;
        Slug = slug;
        ParentId = parentId;
    }

    public static Category Create(
        string title,
        string slug,
        Guid? parentId)
    {
        return new Category(
            Guid.NewGuid(),
            title,
            slug,
            parentId);
    }

    public void Rename(
        string title,
        string slug)
    {
        Title = title;
        Slug = slug;
    }
}
