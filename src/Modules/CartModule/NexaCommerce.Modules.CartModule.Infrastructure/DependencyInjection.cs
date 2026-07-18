using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NexaCommerce.Modules.CartModule.Domain.Repositories;
using NexaCommerce.Modules.CartModule.Infrastructure.Persistence;
using NexaCommerce.Modules.CartModule.Infrastructure.Persistence.Repositories;

namespace NexaCommerce.Modules.CartModule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCartModuleInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<CartDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ICartRepository, CartRepository>();

        return services;
    }
}