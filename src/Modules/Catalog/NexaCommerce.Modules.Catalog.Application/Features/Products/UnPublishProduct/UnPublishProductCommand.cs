using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.UnPublishProduct;

public sealed record UnPublishProductCommand(
    Guid ProductId)
    : IRequest<Result>;
