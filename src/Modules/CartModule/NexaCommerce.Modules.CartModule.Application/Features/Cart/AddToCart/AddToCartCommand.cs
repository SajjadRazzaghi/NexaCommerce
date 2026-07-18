using MediatR;

namespace NexaCommerce.Modules.CartModule.Application.Features.Cart.AddToCart;

public sealed record AddToCartCommand(
    Guid CustomerId,
    Guid ProductVariantId,
    int Quantity,
    decimal UnitPrice)
    : IRequest<Guid>;
