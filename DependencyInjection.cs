using Microsoft.Extensions.DependencyInjection;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Infrastructure.Persistence.Repositories;

namespace NexaCommerce.Modules.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}