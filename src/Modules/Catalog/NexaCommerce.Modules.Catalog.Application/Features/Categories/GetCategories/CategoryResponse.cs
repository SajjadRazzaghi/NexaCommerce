namespace NexaCommerce.Modules.Catalog.Application.Features.Categories.GetCategories;

public sealed record CategoryResponse(
    Guid Id,
    string Title,
    string Slug,
    Guid? ParentId);
