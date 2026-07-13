using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.CreateProduct;

public sealed record CreateProductCommand(
    Guid CategoryId,
    Guid BrandId,
    string Title,
    string Slug,
    string Description)
    : IRequest<Result<Guid>>;
