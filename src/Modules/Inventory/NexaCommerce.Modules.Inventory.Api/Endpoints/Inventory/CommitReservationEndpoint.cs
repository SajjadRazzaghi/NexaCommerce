using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.CommitReservation;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class CommitReservationEndpoint
{
    public static IEndpointRouteBuilder MapCommitReservationEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/inventory/commit",
            async (
                [FromBody] CommitReservationCommand command,
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
