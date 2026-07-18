using NexaCommerce.SharedKernel.Primitives;

namespace NexaCommerce.Modules.CartModule.Domain.Entities;

public sealed class CartItem : Entity<Guid>
{
    public Guid CartId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice =>
        UnitPrice * Quantity;

    private CartItem()
    {
    }

    private CartItem(
        Guid cartId,
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        Id = Guid.NewGuid();

        CartId = cartId;

        ProductVariantId = productVariantId;

        Quantity = quantity;

        UnitPrice = unitPrice;
    }

    public static CartItem Create(
        Guid cartId,
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        return new CartItem(
            cartId,
            productVariantId,
            quantity,
            unitPrice);
    }

    public void Increase(int quantity)
    {
        Quantity += quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void UpdatePrice(decimal unitPrice)
    {
        UnitPrice = unitPrice;
    }
}
