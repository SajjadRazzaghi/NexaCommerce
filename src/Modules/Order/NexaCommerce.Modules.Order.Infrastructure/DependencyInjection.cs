using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NexaCommerce.Modules.Order.Domain.Repositories;
using NexaCommerce.Modules.Order.Infrastructure.Persistence;
using NexaCommerce.Modules.Order.Infrastructure.Persistence.Repositories;

namespace NexaCommerce.Modules.Order.Infrastructure;

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
