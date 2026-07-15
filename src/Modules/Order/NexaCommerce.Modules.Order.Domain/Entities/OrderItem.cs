using NexaCommerce.SharedKernel.Primitives;

namespace NexaCommerce.Modules.Order.Domain.Entities;

public sealed class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; private set; }

    public Guid ProductVariantId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice =>
        UnitPrice * Quantity;

    private OrderItem()
    {
    }

    private OrderItem(
        Guid orderId,
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        Id = Guid.NewGuid();

        OrderId = orderId;

        ProductVariantId = productVariantId;

        Quantity = quantity;

        UnitPrice = unitPrice;
    }

    public static OrderItem Create(
        Guid orderId,
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        return new(
            orderId,
            productVariantId,
            quantity,
            unitPrice);
    }
}
