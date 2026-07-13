using NexaCommerce.Api.Endpoints.Catalog;
using NexaCommerce.Modules.Catalog.Api;
using NexaCommerce.Modules.Catalog.Application;
using NexaCommerce.Modules.Catalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
builder.Services.AddCatalogApplication();

builder.Services.AddCatalogInfrastructure(
    builder.Configuration);
app.MapGet("/", () => "Hello World!");
app.MapCatalogModule();
app.MapProductAttributeEndpoints();
app.Run();
