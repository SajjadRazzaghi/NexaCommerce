using MediatR;

using NexaCommerce.Modules.Inventory.Domain.Entities;
using NexaCommerce.Modules.Inventory.Domain.Repositories;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Warehouses.CreateWarehouse;

internal sealed class CreateWarehouseCommandHandler
    : IRequestHandler<CreateWarehouseCommand, Result<Guid>>
{
    private readonly IWarehouseRepository _warehouseRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateWarehouseCommandHandler(
        IWarehouseRepository warehouseRepository,
        IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateWarehouseCommand request,
        CancellationToken cancellationToken)
    {
        var exists =
            await _warehouseRepository.GetByCodeAsync(
                request.Code,
                cancellationToken);

        if (exists is not null)
        {
            return Result<Guid>.Failure(
                new Error(
                    "Inventory.DuplicateCode",
                    "Warehouse code already exists."));
        }

        var warehouse =
            Warehouse.Create(
                request.Name,
                request.Code);

        await _warehouseRepository.AddAsync(
            warehouse,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(
      warehouse.Id);
    }
}
