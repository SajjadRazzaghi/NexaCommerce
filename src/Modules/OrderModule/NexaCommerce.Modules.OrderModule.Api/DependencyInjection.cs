using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NexaCommerce.Modules.OrderModule.Application;
using NexaCommerce.Modules.OrderModule.Infrastructure;

namespace NexaCommerce.Modules.OrderModule.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddOrderModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOrderModuleApplication();

        services.AddOrderModuleInfrastructure(configuration);

        return services;
    }
}
