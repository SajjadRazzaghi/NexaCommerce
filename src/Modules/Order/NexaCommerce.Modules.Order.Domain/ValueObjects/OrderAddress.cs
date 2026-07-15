namespace NexaCommerce.Modules.Order.Domain.ValueObjects;

public sealed class OrderAddress
{
    public string Province { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;
    public string ReceiverName { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;

    private OrderAddress()
    {
    }

    public OrderAddress(
        string province,
        string city,
        string address,
        string postalCode,
        string receiverName,
        string phoneNumber)
    {
        Province = province;
        City = city;
        Address = address;
        PostalCode = postalCode;
        ReceiverName = receiverName;
        PhoneNumber = phoneNumber;
    }
}
