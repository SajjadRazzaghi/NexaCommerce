using NexaCommerce.SharedKernel.Primitives;

namespace NexaCommerce.Modules.CartModule.Domain.Entities;

public sealed class Cart : Entity<Guid>
{
    private readonly List<CartItem> _items = new();

    public Guid CustomerId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public IReadOnlyCollection<CartItem> Items => _items;

    public decimal TotalAmount =>
        _items.Sum(x => x.TotalPrice);

    private Cart()
    {
    }

    private Cart(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public static Cart Create(Guid customerId)
    {
        return new Cart(customerId);
    }

    public void AddItem(
        Guid productVariantId,
        int quantity,
        decimal unitPrice)
    {
        var item = _items.FirstOrDefault(x =>
            x.ProductVariantId == productVariantId);

        if (item is null)
        {
            _items.Add(
                CartItem.Create(
                    Id,
                    productVariantId,
                    quantity,
                    unitPrice));

            return;
        }

        item.Increase(quantity);
    }

    public void UpdateItem(
        Guid productVariantId,
        int quantity)
    {
        var item = _items.FirstOrDefault(x =>
            x.ProductVariantId == productVariantId);

        if (item is null)
            return;

        item.UpdateQuantity(quantity);
    }

    public void RemoveItem(Guid productVariantId)
    {
        var item = _items.FirstOrDefault(x =>
            x.ProductVariantId == productVariantId);

        if (item is null)
            return;

        _items.Remove(item);
    }

    public void Clear()
    {
        _items.Clear();
    }
}
