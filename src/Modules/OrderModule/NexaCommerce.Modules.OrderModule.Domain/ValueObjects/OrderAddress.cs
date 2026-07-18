namespace NexaCommerce.Modules.OrderModule.Domain.ValueObjects;

public sealed class OrderAddress
{
    public string FullName { get; private set; } = null!;

    public string Phone { get; private set; } = null!;

    public string Province { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string Address { get; private set; } = null!;

    public string PostalCode { get; private set; } = null!;

    private OrderAddress()
    {
    }

    private OrderAddress(
        string fullName,
        string phone,
        string province,
        string city,
        string address,
        string postalCode)
    {
        FullName = fullName;
        Phone = phone;
        Province = province;
        City = city;
        Address = address;
        PostalCode = postalCode;
    }

    public static OrderAddress Create(
        string fullName,
        string phone,
        string province,
        string city,
        string address,
        string postalCode)
    {
        return new OrderAddress(
            fullName,
            phone,
            province,
            city,
            address,
            postalCode);
    }
}
