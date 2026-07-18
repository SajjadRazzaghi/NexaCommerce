using MediatR;

using NexaCommerce.Modules.CartModule.Domain.Entities;
using NexaCommerce.Modules.CartModule.Domain.Repositories;

namespace NexaCommerce.Modules.CartModule.Application.Features.Cart.AddToCart;

internal sealed class AddToCartCommandHandler
    : IRequestHandler<AddToCartCommand, Guid>
{
    private readonly ICartRepository _repository;

    public AddToCartCommandHandler(
        ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(
        AddToCartCommand request,
        CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByCustomerAsync(
            request.CustomerId,
            cancellationToken);

        if (cart is null)
        {
            cart = Cart.Create(request.CustomerId);

            await _repository.AddAsync(
                cart,
                cancellationToken);
        }

        cart.AddItem(
            request.ProductVariantId,
            request.Quantity,
            request.UnitPrice);

        return cart.Id;
    }
}
