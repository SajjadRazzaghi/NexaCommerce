using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributeOptions.CreateProductAttributeOption;

public sealed record CreateProductAttributeOptionCommand(
    Guid ProductAttributeId,
    string Name,
    int DisplayOrder)
    : IRequest<Result<Guid>>;
