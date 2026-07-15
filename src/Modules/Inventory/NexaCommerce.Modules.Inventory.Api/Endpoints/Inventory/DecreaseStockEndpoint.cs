using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.DecreaseStock;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class DecreaseStockEndpoint
{
    public static IEndpointRouteBuilder MapDecreaseStockEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/inventory/decrease",
            async (
                [FromBody] DecreaseStockCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        command,
                        cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok();
            });

        return app;
    }
}
