namespace NexaCommerce.Modules.OrderModule.Application.DTOs;

public sealed record CreateOrderAddressDto(
    string Province,
    string City,
    string Address,
    string PostalCode,
    string ReceiverName,
    string PhoneNumber);
