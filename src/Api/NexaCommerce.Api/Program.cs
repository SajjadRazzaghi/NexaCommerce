using NexaCommerce.Api.Endpoints.Identity;
using NexaCommerce.Modules.Identity.Application;
using NexaCommerce.Modules.Identity.Infrastructure;
using NexaCommerce.Modules.Identity.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));
var app = builder.Build();

app.MapLoginEndpoint();
app.MapRegisterEndpoint();
app.MapRefreshTokenEndpoint();
app.MapForgotPasswordEndpoint();
app.MapResetPasswordEndpoint();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
