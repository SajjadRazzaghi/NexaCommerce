using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NexaCommerce.Modules.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}