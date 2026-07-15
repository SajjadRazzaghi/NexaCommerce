using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReserveStock;

public sealed record ReserveStockCommand(
    Guid WarehouseId,
    Guid ProductVariantId,
    Guid OrderId,
    int Quantity)
    : IRequest<Result>;
