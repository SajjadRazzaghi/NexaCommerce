namespace NexaCommerce.Modules.Inventory.Application.Features.Reservations.GetReservations;

public sealed record ReservationDto(
    Guid Id,
    Guid ProductVariantId,
    Guid OrderId,
    int Quantity,
    bool IsReleased,
    DateTime ExpiresOnUtc);
