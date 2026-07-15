using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.DecreaseStock;

public sealed record DecreaseStockCommand(
    Guid WarehouseId,
    Guid ProductVariantId,
    int Quantity,
    string Description)
    : IRequest<Result>;
