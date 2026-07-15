using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Warehouses.CreateWarehouse;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Warehouses;

public static class CreateWarehouseEndpoint
{
    public static IEndpointRouteBuilder MapCreateWarehouseEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/inventory/warehouses",
            async (
                [FromBody] CreateWarehouseCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        command,
                        cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Value);
            });

        return app;
    }
}
