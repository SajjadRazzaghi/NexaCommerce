using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductRepository _products;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        IProductRepository products,
        IUnitOfWork unitOfWork)
    {
        _products = products;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var exists =
            await _products.GetBySlugAsync(
                request.Slug,
                cancellationToken);

        if (exists is not null)
        {
            return Result<Guid>.Failure(
                new Error(
                    "Catalog.ProductExists",
                    "Slug already exists."));
        }

        var product =
            Product.Create(
                request.CategoryId,
                request.BrandId,
                request.Title,
                request.Slug,
                request.Description);

        await _products.AddAsync(
            product,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(product.Id);
    }
}
