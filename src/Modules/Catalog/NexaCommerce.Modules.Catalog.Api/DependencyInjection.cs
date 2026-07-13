using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Catalog.Api.Endpoints;

namespace NexaCommerce.Modules.Catalog.Api;

public static class DependencyInjection
{
    public static IEndpointRouteBuilder MapCatalogModule(
        this IEndpointRouteBuilder app)
    {
        app.MapCategoryEndpoints();

        return app;
    }
}
