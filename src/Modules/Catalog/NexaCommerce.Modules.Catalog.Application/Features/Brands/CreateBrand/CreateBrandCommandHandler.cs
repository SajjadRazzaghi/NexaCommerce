using MediatR;

using NexaCommerce.Modules.Catalog.Domain.Entities;
using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Catalog.Application.Features.Brands.CreateBrand;

internal sealed class CreateBrandCommandHandler
    : IRequestHandler<CreateBrandCommand, Result<Guid>>
{
    private readonly IBrandRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(
        IBrandRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateBrandCommand request,
        CancellationToken cancellationToken)
    {
        var exists =
            await _repository.GetByNameAsync(
                request.Slug,
                cancellationToken);

        if (exists is not null)
        {
            return Result<Guid>.Failure(
                new Error(
                    "Catalog.BrandExists",
                    "Brand already exists."));
        }

        var brand =
            Brand.Create(
                request.Title,
                              request.Logo);

        await _repository.AddAsync(
            brand,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(
            brand.Id);
    }
}
