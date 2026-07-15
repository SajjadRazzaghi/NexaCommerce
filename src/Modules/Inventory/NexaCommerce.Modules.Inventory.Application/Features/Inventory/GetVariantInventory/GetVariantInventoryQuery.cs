using MediatR;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetVariantInventory;

public sealed record GetVariantInventoryQuery(
    Guid ProductVariantId)
    : IRequest<List<VariantInventoryDto>>;
