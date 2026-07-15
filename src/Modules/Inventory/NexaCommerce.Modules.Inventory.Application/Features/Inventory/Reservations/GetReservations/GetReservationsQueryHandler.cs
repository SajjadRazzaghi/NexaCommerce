using MediatR;

using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Application.Features.Reservations.GetReservations;

internal sealed class GetReservationsQueryHandler
    : IRequestHandler<GetReservationsQuery, List<ReservationDto>>
{
    private readonly IStockReservationRepository _repository;

    public GetReservationsQueryHandler(
        IStockReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ReservationDto>> Handle(
        GetReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var reservations =
            await _repository.GetByWarehouseAsync(
                request.WarehouseId,
                cancellationToken);

        return reservations
            .Select(x =>
                new ReservationDto(
                    x.Id,
                    x.ProductVariantId,
                    x.OrderId,
                    x.Quantity,
                    x.IsReleased,
                    x.ExpiresOnUtc))
            .ToList();
    }
}
