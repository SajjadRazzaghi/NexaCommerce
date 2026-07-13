using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Brands.CreateBrand;

public sealed record CreateBrandCommand(
    string Title,
    string Slug,
    string? Logo)
    : IRequest<Result<Guid>>;
