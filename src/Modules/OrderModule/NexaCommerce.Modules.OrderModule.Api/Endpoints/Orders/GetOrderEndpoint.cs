using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrder;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.OrderModule.Api.Endpoints.Orders;

public static class GetOrderEndpoint
{
    public static IEndpointRouteBuilder MapGetOrderEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/orders/{id:guid}",
            async (
                Guid id,
                ISender sender) =>
            {
                var order =
                    await sender.Send(
                        new GetOrderQuery(id));
                return order is null
                ? Results.NotFound()
                    : Results.Ok(order);
            });

        return app;
    }
}
