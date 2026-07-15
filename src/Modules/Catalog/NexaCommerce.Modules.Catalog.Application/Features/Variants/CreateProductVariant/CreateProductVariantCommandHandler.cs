using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Variants.CreateProductVariant;

internal sealed class CreateProductVariantCommandHandler
    : IRequestHandler<CreateProductVariantCommand, Result<Guid>>
{
    private readonly IProductRepository _products;
    private readonly IProductVariantRepository _variants;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductVariantCommandHandler(
        IProductRepository products,
        IProductVariantRepository variants,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _variants = variants;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateProductVariantCommand request,
        CancellationToken cancellationToken)
    {
        var product =
            await _products.GetByIdAsync(
                request.ProductId,
                cancellationToken);

        if (product is null)
        {
            return Result<Guid>.Failure(
                new Error(
                    "Catalog.Product.NotFound",
                    "Product not found."));
        }

        var variant =
            ProductVariant.Create(
                request.ProductId,
                request.Sku,
                request.Price,
                request.OldPrice);

        await _variants.AddAsync(
            variant,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(
            variant.Id);
    }
}
