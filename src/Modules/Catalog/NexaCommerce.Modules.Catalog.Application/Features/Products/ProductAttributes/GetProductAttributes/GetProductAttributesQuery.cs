using MediatR;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.GetProductAttributes;

public sealed record GetProductAttributesQuery()
    : IRequest<List<ProductAttributeResponse>>;
