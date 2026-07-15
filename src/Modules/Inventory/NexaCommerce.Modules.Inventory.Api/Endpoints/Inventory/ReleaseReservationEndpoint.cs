using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReleaseReservation;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class ReleaseReservationEndpoint
{
    public static IEndpointRouteBuilder MapReleaseReservationEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/inventory/release",
            async (
                [FromBody] ReleaseReservationCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok();
            });

        return app;
    }
}
