using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IProductRepository _products;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(
        IProductRepository products,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateProductCommand request,
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

        product.Update(
            request.CategoryId,
            request.BrandId,
            request.Title,
            request.Slug,
            request.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
