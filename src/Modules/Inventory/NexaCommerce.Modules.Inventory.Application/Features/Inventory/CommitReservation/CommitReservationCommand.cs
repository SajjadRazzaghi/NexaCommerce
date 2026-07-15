using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.CommitReservation;

public sealed record CommitReservationCommand(
    Guid ReservationId)
    : IRequest<Result>;
