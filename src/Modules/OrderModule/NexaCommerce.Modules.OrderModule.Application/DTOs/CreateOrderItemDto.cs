namespace NexaCommerce.Modules.OrderModule.Application.DTOs;

public sealed record CreateOrderItemDto(
    Guid ProductVariantId,
    int Quantity,
    decimal UnitPrice);
