using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetStock;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class GetStockEndpoint
{
    public static IEndpointRouteBuilder MapGetStockEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/inventory/stock/{warehouseId:guid}/{productVariantId:guid}",
            async (
                Guid warehouseId,
                Guid productVariantId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var stock =
                    await sender.Send(
                        new GetStockQuery(
                            warehouseId,
                            productVariantId),
                        cancellationToken);

                return Results.Ok(stock);
            });

        return app;
    }
}
