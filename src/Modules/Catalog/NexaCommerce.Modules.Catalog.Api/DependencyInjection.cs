using Microsoft.AspNetCore.Routing;

using NexaCommerce.Modules.Catalog.Api.Endpoints;
using NexaCommerce.Modules.Catalog.Api.Endpoints.Variants;

namespace NexaCommerce.Modules.Catalog.Api;

public static class DependencyInjection
{
    public static IEndpointRouteBuilder MapCatalogModule(
        this IEndpointRouteBuilder app)
    {
        app.MapCategoryEndpoints();
        app.MapCreateProductVariantEndpoint();
        return app;
    }
}
