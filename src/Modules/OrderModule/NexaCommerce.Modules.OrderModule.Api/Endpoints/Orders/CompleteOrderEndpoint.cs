using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.CompleteOrder;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class CompleteOrderEndpoint
{
    public static IEndpointRouteBuilder MapCompleteOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/api/orders/{id:guid}/complete",
            async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                await sender.Send(
                    new CompleteOrderCommand(id),
                    cancellationToken);

                return Results.Ok();
            });

        return app;
    }
}
