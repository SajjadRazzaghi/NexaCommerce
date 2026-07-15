using NexaCommerce.Modules.Order.Domain.Enums;
using NexaCommerce.Modules.Order.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Primitives;

namespace NexaCommerce.Modules.Order.Domain.Entities;

public sealed class Order : Entity<Guid>
{
    public Guid CustomerId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public OrderStatus Status { get; private set; }

    public PaymentStatus PaymentStatus { get; private set; }

    public ShippingStatus ShippingStatus { get; private set; }

    public OrderAddress ShippingAddress { get; private set; } = null!;

    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items;

    public decimal TotalAmount =>
        _items.Sum(x => x.TotalPrice);

    private Order()
    {
    }

    private Order(
        Guid customerId,
        OrderAddress shippingAddress)
    {
        Id = Guid.NewGuid();

        CustomerId = customerId;

        ShippingAddress = shippingAddress;

        CreatedOnUtc = DateTime.UtcNow;

        Status = OrderStatus.Pending;

        PaymentStatus = PaymentStatus.Pending;

        ShippingStatus = ShippingStatus.Pending;
    }

    public static Order Create(
        Guid customerId,
        OrderAddress shippingAddress)
    {
        return new(
            customerId,
            shippingAddress);
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    public void MarkPaid()
    {
        PaymentStatus = PaymentStatus.Paid;
        Status = OrderStatus.Paid;
    }

    public void Ship()
    {
        ShippingStatus = ShippingStatus.Shipped;
        Status = OrderStatus.Shipped;
    }

    public void Deliver()
    {
        ShippingStatus = ShippingStatus.Delivered;
        Status = OrderStatus.Delivered;
    }

    public void Cancel()
    {
        Status = OrderStatus.Cancelled;
    }
}
