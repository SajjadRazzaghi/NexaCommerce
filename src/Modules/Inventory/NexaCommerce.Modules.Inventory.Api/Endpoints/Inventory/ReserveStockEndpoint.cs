using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.ReserveStock;

public static class ReserveStockEndpoint
{
    public static IEndpointRouteBuilder MapReserveStockEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/inventory/reserve",
            async (
                [FromBody] ReserveStockCommand command,
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
