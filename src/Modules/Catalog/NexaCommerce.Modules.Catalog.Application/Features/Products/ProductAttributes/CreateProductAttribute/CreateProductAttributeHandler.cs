using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.CreateProductAttribute;

internal sealed class CreateProductAttributeHandler
    : IRequestHandler<CreateProductAttributeCommand, Result<Guid>>
{
    private readonly IProductAttributeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductAttributeHandler(
        IProductAttributeRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateProductAttributeCommand request,
        CancellationToken cancellationToken)
    {
        var attribute =
        ProductAttribute.Create(
            request.Name,
            request.Type,
            request.IsVariant,
            request.IsFilterable,
            request.IsSearchable);

        await _repository.AddAsync(
            attribute,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(attribute.Id);
    }
}
