using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.ShipOrder;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class ShipOrderEndpoint
{
    public static IEndpointRouteBuilder MapShipOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/orders/{id:guid}/ship",
            async (
                Guid id,
                ISender sender) =>
            {
                await sender.Send(
                    new ShipOrderCommand(id));

                return Results.NoContent();
            });

        return app;
    }
}
