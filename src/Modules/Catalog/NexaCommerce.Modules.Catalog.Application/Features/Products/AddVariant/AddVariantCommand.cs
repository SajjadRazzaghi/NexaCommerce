using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddVariant;

public sealed record AddVariantCommand(
    Guid ProductId,
    string Sku,
    decimal Price,
    decimal? DiscountPrice,
    int Stock,
    List<VariantAttributeRequest> Attributes)
    : IRequest<Result>;

public sealed record VariantAttributeRequest(
    Guid AttributeId,
    string Value);
