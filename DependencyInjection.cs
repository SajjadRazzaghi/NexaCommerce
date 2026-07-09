using Microsoft.Extensions.DependencyInjection;

namespace NexaCommerce.Modules.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services)
    {
        return services;
    }
}