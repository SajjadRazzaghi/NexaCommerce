using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NexaCommerce.Modules.Catalog.Domain.Repositories;
using NexaCommerce.Modules.Catalog.Infrastructure.Persistence;
using NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Repositories;
using NexaCommerce.Infrastructure.Persistence;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("Database"));
        });

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IUnitOfWork,
            UnitOfWork<CatalogDbContext>>();

        return services;
    }
}
