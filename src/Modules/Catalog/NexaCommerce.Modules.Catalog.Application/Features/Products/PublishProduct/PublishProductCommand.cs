using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.PublishProduct;

public sealed record PublishProductCommand(
    Guid ProductId)
    : IRequest<Result>;
