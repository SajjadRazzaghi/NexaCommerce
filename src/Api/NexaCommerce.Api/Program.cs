using NexaCommerce.Api.Endpoints.Catalog;
using NexaCommerce.Api.Endpoints.Identity;
using NexaCommerce.Modules.Identity.Application;
using NexaCommerce.Modules.Identity.Infrastructure;
using NexaCommerce.Modules.Identity.Infrastructure.Security;
using NexaCommerce.Modules.Inventory.Api.Endpoints.Inventory;
using NexaCommerce.Modules.Inventory.Api.Endpoints.Reservations;
using NexaCommerce.Modules.Inventory.Api.Endpoints.Transactions;
using NexaCommerce.Modules.Inventory.Api.Endpoints.Warehouses;
using NexaCommerce.Modules.Order.Application;
using NexaCommerce.Modules.Order.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));
builder.Services.AddOrderApplication();

builder.Services.AddOrderInfrastructure(
    builder.Configuration);
var app = builder.Build();

app.MapLoginEndpoint();
app.MapRegisterEndpoint();
app.MapRefreshTokenEndpoint();
app.MapForgotPasswordEndpoint();
app.MapResetPasswordEndpoint();
app.MapCreateWarehouseEndpoint();
app.MapProductAttributeEndpoints();
app.MapIncreaseStockEndpoint();
app.MapDecreaseStockEndpoint();
app.MapReserveStockEndpoint();
app.MapReleaseReservationEndpoint();
app.MapReleaseReservationEndpoint();
app.MapCommitReservationEndpoint();
app.MapGetWarehouseInventoryEndpoint();
app.MapGetVariantInventoryEndpoint();
app.MapGetStockEndpoint();
app.MapGetReservationsEndpoint();
app.MapGetTransactionsEndpoint();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
