using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Catalog.Application.Features.Categories.CreateCategory;
using NexaCommerce.Modules.Catalog.Application.Features.Categories.GetCategories;

namespace NexaCommerce.Modules.Catalog.Api.Endpoints;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/catalog/categories",
            async (
                CreateCategoryCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(
                        command,
                        cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Created(
                    $"/api/catalog/categories/{result.Value}",
                    result.Value);
            });

        app.MapGet(
            "/api/catalog/categories",
            async (
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                return await sender.Send(
                    new GetCategoriesQuery(),
                    cancellationToken);
            });

        return app;
    }
}
