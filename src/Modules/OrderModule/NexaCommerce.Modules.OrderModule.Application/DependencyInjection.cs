using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace NexaCommerce.Modules.OrderModule.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddOrderModuleApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(DependencyInjection).Assembly));

        return services;
    }
}
