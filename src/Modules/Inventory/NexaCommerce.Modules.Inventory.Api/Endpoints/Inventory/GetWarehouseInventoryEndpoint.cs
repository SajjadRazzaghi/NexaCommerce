using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetWarehouseInventory;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class GetWarehouseInventoryEndpoint
{
    public static IEndpointRouteBuilder MapGetWarehouseInventoryEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/inventory/warehouse/{warehouseId:guid}",
            async (
                Guid warehouseId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        new GetWarehouseInventoryQuery(
                            warehouseId),
                        cancellationToken);

                return Results.Ok(result);
            });

        return app;
    }
}
