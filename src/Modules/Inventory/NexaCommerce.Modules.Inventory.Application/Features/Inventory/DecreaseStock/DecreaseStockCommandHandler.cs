using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.DecreaseStock;

internal sealed class DecreaseStockCommandHandler
    : IRequestHandler<DecreaseStockCommand, Result>
{
    private readonly IInventoryService _inventory;

    public DecreaseStockCommandHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<Result> Handle(
        DecreaseStockCommand request,
        CancellationToken cancellationToken)
    {
        var success =
            await _inventory.DecreaseStockAsync(
                request.WarehouseId,
                request.ProductVariantId,
                request.Quantity,
                request.Description,
                cancellationToken);

        if (!success)
        {
            return Result.Failure(
                new Error(
                    "Inventory.NotEnoughStock",
                    "Not enough stock."));
        }

        return Result.Success();
    }
}
