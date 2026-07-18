using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.CancelOrder;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class CancelOrderEndpoint
{
    public static IEndpointRouteBuilder MapCancelOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/api/orders/{id:guid}/cancel",
            async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                await sender.Send(
                    new CancelOrderCommand(id),
                    cancellationToken);

                return Results.Ok();
            });

        return app;
    }
}
