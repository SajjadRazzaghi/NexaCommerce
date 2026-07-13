using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddVariant;

internal sealed class AddVariantCommandHandler
    : IRequestHandler<AddVariantCommand, Result>
{
    private readonly IProductRepository _products;

    private readonly IUnitOfWork _unitOfWork;

    public AddVariantCommandHandler(
        IProductRepository products,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        AddVariantCommand request,
        CancellationToken cancellationToken)
    {
        var product =
            await _products.GetByIdAsync(
                request.ProductId,
                cancellationToken);

        if (product is null)
        {
            return Result.Failure(
                new Error(
                    "Catalog.NotFound",
                    "Product not found."));
        }

        var variant =
     ProductVariant.Create(
         request.ProductId,
         request.Sku,
         request.Price,
         request.DiscountPrice,
         request.Stock);

        foreach (var item in request.Attributes)
        {
            variant.AddAttribute(
                VariantAttributeValue.Create(
                    variant.Id,
                    item.AttributeId,
                    item.Value));
        }

        product.AddVariant(variant);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success();
    }
}
