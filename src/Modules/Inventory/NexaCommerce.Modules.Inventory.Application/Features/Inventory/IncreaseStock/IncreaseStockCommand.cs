using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.IncreaseStock;

public sealed record IncreaseStockCommand(
    Guid WarehouseId,
    Guid ProductVariantId,
    int Quantity,
    string Description)
    : IRequest<Result>;
