namespace NexaCommerce.Modules.Catalog.Domain.Entities;

public sealed class Category
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = null!;

    public string Slug { get; private set; } = null!;

    public Guid? ParentId { get; private set; }

    public Category? Parent { get; private set; }

    private readonly List<Category> _children = new();

    public IReadOnlyCollection<Category> Children
        => _children;

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
            title.Trim(),
            slug.Trim().ToLower(),
            parentId);
    }

    public void Update(
        string title,
        string slug)
    {
        Title = title.Trim();

        Slug = slug.Trim().ToLower();
    }
}
