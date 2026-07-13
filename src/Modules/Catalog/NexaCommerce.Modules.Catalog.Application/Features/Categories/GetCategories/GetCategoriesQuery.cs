using MediatR;

namespace NexaCommerce.Modules.Catalog.Application.Features.Categories.GetCategories;

public sealed record GetCategoriesQuery()
    : IRequest<List<CategoryResponse>>;
