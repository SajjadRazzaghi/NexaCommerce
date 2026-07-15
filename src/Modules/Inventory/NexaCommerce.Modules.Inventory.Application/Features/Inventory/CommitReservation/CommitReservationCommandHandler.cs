using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Inventory.Application.Features.Inventory.CommitReservation;

internal sealed class CommitReservationCommandHandler
    : IRequestHandler<CommitReservationCommand, Result>
{
    private readonly IInventoryService _inventory;

    public CommitReservationCommandHandler(
        IInventoryService inventory)
    {
        _inventory = inventory;
    }

    public async Task<Result> Handle(
        CommitReservationCommand request,
        CancellationToken cancellationToken)
    {
        await _inventory.CommitReservationAsync(
            request.ReservationId,
            cancellationToken);

        return Result.Success();
    }
}
