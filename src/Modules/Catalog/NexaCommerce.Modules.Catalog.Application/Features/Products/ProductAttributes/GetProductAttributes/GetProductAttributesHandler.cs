using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Repositories;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.GetProductAttributes;

internal sealed class GetProductAttributesHandler
    : IRequestHandler<
        GetProductAttributesQuery,
        List<ProductAttributeResponse>>
{
    private readonly IProductAttributeRepository _repository;

    public GetProductAttributesHandler(
        IProductAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductAttributeResponse>> Handle(
        GetProductAttributesQuery request,
        CancellationToken cancellationToken)
    {
        var list =
            await _repository.GetAllAsync(
                cancellationToken);

        return list
            .Select(x =>
                new ProductAttributeResponse(
                    x.Id,
                    x.Name))
            .ToList();
    }
}
