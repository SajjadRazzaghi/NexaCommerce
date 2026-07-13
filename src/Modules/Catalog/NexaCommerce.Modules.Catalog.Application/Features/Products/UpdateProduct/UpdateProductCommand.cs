using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid ProductId,
    Guid CategoryId,
    Guid BrandId,
    string Title,
    string Slug,
    string Description)
    : IRequest<Result>;
