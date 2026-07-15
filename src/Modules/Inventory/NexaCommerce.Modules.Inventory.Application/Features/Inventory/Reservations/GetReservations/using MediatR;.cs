using MediatR;

namespace NexaCommerce.Modules.Inventory.Application.Features.Reservations.GetReservations;

public sealed record GetReservationsQuery(
    Guid WarehouseId)
    : IRequest<List<ReservationDto>>;
