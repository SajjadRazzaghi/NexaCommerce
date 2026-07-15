using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReserveStock;

internal sealed class ReserveStockCommandHandler
    : IRequestHandler<ReserveStockCommand, Result>
{
    private readonly IInventoryService _inventory;

    public ReserveStockCommandHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<Result> Handle(
        ReserveStockCommand request,
        CancellationToken cancellationToken)
    {
        var success =
            await _inventory.ReserveStockAsync(
                request.WarehouseId,
                request.ProductVariantId,
                request.OrderId,
                request.Quantity,
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
