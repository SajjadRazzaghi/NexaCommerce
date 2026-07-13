using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Application.Features.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler
    : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoriesQueryHandler(
        ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryResponse>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories =
            await _repository.GetAllAsync(cancellationToken);

        return categories
            .Select(x =>
                new CategoryResponse(
                    x.Id,
                    x.Title,
                    x.Slug,
                    x.ParentId))
            .ToList();
    }
}
