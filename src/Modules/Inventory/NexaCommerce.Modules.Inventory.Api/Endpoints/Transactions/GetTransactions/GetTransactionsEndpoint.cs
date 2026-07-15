using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Inventory.Application.Features.Transactions.GetTransactions;

namespace NexaCommerce.Modules.Inventory.Api.Endpoints.Transactions;

public static class GetTransactionsEndpoint
{
    public static IEndpointRouteBuilder MapGetTransactionsEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/api/inventory/transactions/{variantId:guid}",
            async (
                Guid variantId,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        new GetTransactionsQuery(
                            variantId),
                        cancellationToken);

                return Results.Ok(result);
            });

        return app;
    }
}
