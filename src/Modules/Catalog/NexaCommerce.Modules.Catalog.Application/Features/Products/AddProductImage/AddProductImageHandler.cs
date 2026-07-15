using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddProductImage;

internal sealed class AddProductImageCommandHandler
    : IRequestHandler<AddProductImageCommand, Result>
{
    private readonly IProductRepository _products;

    private readonly IUnitOfWork _unitOfWork;

    public AddProductImageCommandHandler(
        IProductRepository products,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        AddProductImageCommand request,
        CancellationToken cancellationToken)
    {
        var product =
            await _products.GetWithImagesAsync(
                request.ProductId,
                cancellationToken);

        if (product is null)
        {
            return Result.Failure(
                new Error(
                    "Catalog.NotFound",
                    "Product not found."));
        }

        if (request.IsMain)
        {
            foreach (var item in product.Images)
            {
                item.RemoveMain();
            }
        }

        var image =
      ProductImage.Create(
          request.ProductId,
          request.ImageUrl,
          request.IsMain,
          request.DisplayOrder);

        product.AddImage(image);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success();
    }
}
