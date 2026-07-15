using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using NexaCommerce.Modules.Catalog.Application.Features.ProductAttributeOptions.CreateProductAttributeOption;
using NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.CreateProductAttribute;
using NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.GetProductAttributes;

namespace NexaCommerce.Api.Endpoints.Catalog;

public static class ProductAttributeEndpoints
{
    public static void MapProductAttributeEndpoints(
        this WebApplication app)
    {
        app.MapPost(
            "/api/catalog/attributes",
            async (
                CreateProductAttributeCommand command,
                ISender sender) =>
            {
                var result =
                    await sender.Send(command);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : Results.BadRequest(result.Error);
            });

        app.MapGet(
            "/api/catalog/attributes",
            async (
                ISender sender) =>
            {
                var result =
                    await sender.Send(
                        new GetProductAttributesQuery());

                return Results.Ok(result);
            });
        app.MapPost(
    "/api/catalog/attribute-options",
    async (
        CreateProductAttributeOptionCommand command,
        ISender sender) =>
    {
        var result =
            await sender.Send(command);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : Results.BadRequest(result.Error);
    });
    }


}
