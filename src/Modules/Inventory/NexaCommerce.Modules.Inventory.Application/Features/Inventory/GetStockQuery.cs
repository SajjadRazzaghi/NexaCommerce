using MediatR;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetStock;

public sealed record GetStockQuery(
    Guid WarehouseId,
    Guid ProductVariantId)
    : IRequest<int>;
