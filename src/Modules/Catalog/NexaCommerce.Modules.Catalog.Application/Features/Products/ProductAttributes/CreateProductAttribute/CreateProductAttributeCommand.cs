using MediatR;
using NexaCommerce.Modules.Catalog.Domain.Enums;
using NexaCommerce.SharedKernel.Results;

public sealed record CreateProductAttributeCommand(
    string Name,
    ProductAttributeType Type,
    bool IsVariant,
    bool IsFilterable,
    bool IsSearchable)
    : IRequest<Result<Guid>>;
