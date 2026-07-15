using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetStock;

internal sealed class GetStockQueryHandler
    : IRequestHandler<GetStockQuery, int>
{
    private readonly IInventoryService _inventory;

    public GetStockQueryHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<int> Handle(
        GetStockQuery request,
        CancellationToken cancellationToken)
    {
        return await _inventory.GetAvailableStockAsync(
            request.WarehouseId,
            request.ProductVariantId,
            cancellationToken);
    }
}
