using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.Modules.OrderModule.Infrastructure.Persistence;
using NexaCommerce.Modules.OrderModule.Infrastructure.Persistence.Repositories;

namespace NexaCommerce.Modules.OrderModule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddOrderInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
