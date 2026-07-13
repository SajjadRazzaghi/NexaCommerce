using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributeOptions.CreateProductAttributeOption;

internal sealed class CreateProductAttributeOptionHandler
    : IRequestHandler<
        CreateProductAttributeOptionCommand,
        Result<Guid>>
{
    private readonly IProductAttributeRepository _attributes;

    private readonly IProductAttributeOptionRepository _options;

    private readonly IUnitOfWork _unitOfWork;

    public CreateProductAttributeOptionHandler(
        IProductAttributeRepository attributes,
        IProductAttributeOptionRepository options,
        IUnitOfWork unitOfWork)
    {
        _attributes = attributes;
        _options = options;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateProductAttributeOptionCommand request,
        CancellationToken cancellationToken)
    {
        var attribute =
            await _attributes.GetByIdAsync(
                request.ProductAttributeId,
                cancellationToken);

        if (attribute is null)
        {
            return Result<Guid>.Failure(
                new Error(
                    "Catalog.Attribute.NotFound",
                    "Attribute not found."));
        }

        var option =
            ProductAttributeOption.Create(
                request.ProductAttributeId,
                request.Name,
                request.DisplayOrder);

        await _options.AddAsync(
            option,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(option.Id);
    }
}
