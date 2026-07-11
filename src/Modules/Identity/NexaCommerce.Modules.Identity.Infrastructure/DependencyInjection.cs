using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexaCommerce.Modules.Identity.Application.Abstractions.Security;
using NexaCommerce.Modules.Identity.Infrastructure.Security;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Infrastructure.Persistence;
using NexaCommerce.Modules.Identity.Infrastructure.Persistence.Repositories;

namespace NexaCommerce.Modules.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}
