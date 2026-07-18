using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrders;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class GetOrdersEndpoint
{
    public static IEndpointRouteBuilder MapGetOrdersEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/customers/{customerId:guid}/orders",
            async (
                Guid customerId,
                ISender sender) =>
            {
                var orders =
                    await sender.Send(
                        new GetOrdersQuery(customerId));

                return Results.Ok(orders);
            });

        return app;
    }
}
