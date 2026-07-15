using MediatR;

using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetVariantInventory;

internal sealed class GetVariantInventoryQueryHandler
    : IRequestHandler<
        GetVariantInventoryQuery,
        List<VariantInventoryDto>>
{
    private readonly IInventoryItemRepository _items;

    public GetVariantInventoryQueryHandler(
        IInventoryItemRepository items)
    {
        _items = items;
    }

    public async Task<List<VariantInventoryDto>> Handle(
        GetVariantInventoryQuery request,
        CancellationToken cancellationToken)
    {
        var items =
            await _items.GetByVariantAsync(
                request.ProductVariantId,
                cancellationToken);

        return items
            .Select(x =>
                new VariantInventoryDto(
                    x.WarehouseId,
                    x.Id,
                    x.Quantity,
                    x.ReservedQuantity,
                    x.AvailableQuantity))
            .ToList();
    }
}
