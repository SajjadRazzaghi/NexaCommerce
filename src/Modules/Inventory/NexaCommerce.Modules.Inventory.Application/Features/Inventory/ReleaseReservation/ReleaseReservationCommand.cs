using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReleaseReservation;

public sealed record ReleaseReservationCommand(
    Guid ReservationId)
    : IRequest<Result>;
