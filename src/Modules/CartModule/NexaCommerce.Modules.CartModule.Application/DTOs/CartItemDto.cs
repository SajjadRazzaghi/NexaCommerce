namespace NexaCommerce.Modules.CartModule.Application.DTOs;

public sealed record CartItemDto(
    Guid ProductVariantId,
    int Quantity,
    decimal UnitPrice,
    decimal TotalPrice);
