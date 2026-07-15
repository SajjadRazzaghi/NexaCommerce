using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReleaseReservation;

internal sealed class ReleaseReservationCommandHandler
    : IRequestHandler<ReleaseReservationCommand, Result>
{
    private readonly IInventoryService _inventory;

    public ReleaseReservationCommandHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<Result> Handle(
        ReleaseReservationCommand request,
        CancellationToken cancellationToken)
    {
        await _inventory.ReleaseReservationAsync(
            request.ReservationId,
            cancellationToken);

        return Result.Success();
    }
}
