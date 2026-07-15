using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Reservations.GetReservations;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Reservations;

public static class GetReservationsEndpoint
{
    public static IEndpointRouteBuilder MapGetReservationsEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/inventory/reservations/{warehouseId:guid}",
            async (
                Guid warehouseId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        new GetReservationsQuery(
                            warehouseId),
                        cancellationToken);

                return Results.Ok(result);
            });

        return app;
    }
}
