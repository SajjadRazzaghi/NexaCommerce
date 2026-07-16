using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.CreateOrder;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class CreateOrderEndpoint
{
    public static IEndpointRouteBuilder MapCreateOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/orders",
            async (
                [FromBody] CreateOrderCommand command,
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
