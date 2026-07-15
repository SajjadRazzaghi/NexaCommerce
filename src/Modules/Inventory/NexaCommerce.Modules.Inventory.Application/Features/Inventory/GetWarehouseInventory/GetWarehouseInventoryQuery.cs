using MediatR;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetWarehouseInventory;

public sealed record GetWarehouseInventoryQuery(
    Guid WarehouseId)
    : IRequest<List<WarehouseInventoryDto>>;
