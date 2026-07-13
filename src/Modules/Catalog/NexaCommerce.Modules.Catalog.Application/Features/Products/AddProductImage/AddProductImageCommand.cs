using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddProductImage;

public sealed record AddProductImageCommand(
    Guid ProductId,
    string ImageUrl,
    int DisplayOrder,
    bool IsMain)
    : IRequest<Result>;
