using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Categories.CreateCategory;

public sealed record CreateCategoryCommand(
    string Title,
    string Slug,
    Guid? ParentId)
    : IRequest<Result<Guid>>;
