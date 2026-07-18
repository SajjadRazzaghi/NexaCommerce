using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.PayOrder;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class PayOrderEndpoint
{
    public static IEndpointRouteBuilder MapPayOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPut(
            "/orders/{id:guid}/pay",
            async (
                Guid id,
                ISender sender) =>
            {
                await sender.Send(
                    new PayOrderCommand(id));

                return Results.NoContent();
            });

        return app;
    }
}
