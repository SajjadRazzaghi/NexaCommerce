using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Inventory.GetVariantInventory;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;

public static class GetVariantInventoryEndpoint
{
    public static IEndpointRouteBuilder MapGetVariantInventoryEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/inventory/variant/{variantId:guid}",
            async (
                Guid variantId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        new GetVariantInventoryQuery(
                            variantId),
                        cancellationToken);

                return Results.Ok(result);
            });

        return app;
    }
}
