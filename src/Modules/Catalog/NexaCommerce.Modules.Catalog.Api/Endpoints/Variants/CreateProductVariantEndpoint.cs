using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Catalog.Application.Features.Variants.CreateProductVariant;

namespace NexaCommerce.Modules.Catalog.Api.Endpoints.Variants;

public static class CreateProductVariantEndpoint
{
    public static IEndpointRouteBuilder MapCreateProductVariantEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/catalog/variants",
            async (
                CreateProductVariantCommand command,
                ISender sender) =>
            {
                var result =
                    await sender.Send(command);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : Results.BadRequest(result.Error);
            });

        return app;
    }
}
