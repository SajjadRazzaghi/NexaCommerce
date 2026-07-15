using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.IncreaseStock;

internal sealed class IncreaseStockCommandHandler
    : IRequestHandler<IncreaseStockCommand, Result>
{
    private readonly IInventoryService _inventory;

    public IncreaseStockCommandHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<Result> Handle(
        IncreaseStockCommand request,
        CancellationToken cancellationToken)
    {
        await _inventory.IncreaseStockAsync(
            request.WarehouseId,
            request.ProductVariantId,
            request.Quantity,
            request.Description,
            cancellationToken);

        return Result.Success();
    }
}
