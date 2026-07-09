using NexaCommerce.Modules.Identity.Application;
using NexaCommerce.Modules.Identity.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddIdentityInfrastructure(builder.Configuration);

builder.Services.AddIdentityApplication();
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
