using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Warehouses.CreateWarehouse;

public sealed record CreateWarehouseCommand(
    string Name,
    string Code)
    : IRequest<Result<Guid>>;
