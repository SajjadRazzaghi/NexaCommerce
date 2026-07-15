using MediatR;

using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetWarehouseInventory;

internal sealed class GetWarehouseInventoryQueryHandler
    : IRequestHandler<
        GetWarehouseInventoryQuery,
        List<WarehouseInventoryDto>>
{
    private readonly IInventoryItemRepository _items;

    public GetWarehouseInventoryQueryHandler(
        IInventoryItemRepository items)
    {
        _items = items;
    }

    public async Task<List<WarehouseInventoryDto>> Handle(
        GetWarehouseInventoryQuery request,
        CancellationToken cancellationToken)
    {
        var items =
            await _items.GetByWarehouseAsync(
                request.WarehouseId,
                cancellationToken);

        return items
            .Select(x =>
                new WarehouseInventoryDto(
                    x.Id,
                    x.ProductVariantId,
                    x.Quantity,
                    x.ReservedQuantity,
                    x.AvailableQuantity))
            .ToList();
    }
}
