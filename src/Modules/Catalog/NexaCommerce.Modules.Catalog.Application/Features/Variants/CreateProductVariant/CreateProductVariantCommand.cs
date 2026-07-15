using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Variants.CreateProductVariant;

public sealed record CreateProductVariantCommand(
    Guid ProductId,
    string Sku,
    decimal Price,
    decimal? OldPrice)
    : IRequest<Result<Guid>>;
