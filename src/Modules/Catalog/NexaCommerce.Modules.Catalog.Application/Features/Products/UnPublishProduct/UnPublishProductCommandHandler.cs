using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.UnPublishProduct;

internal sealed class UnPublishProductCommandHandler
    : IRequestHandler<UnPublishProductCommand, Result>
{
    private readonly IProductRepository _products;
    private readonly IUnitOfWork _unitOfWork;

    public UnPublishProductCommandHandler(
        IProductRepository products,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UnPublishProductCommand request,
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

        product.UnPublish();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
