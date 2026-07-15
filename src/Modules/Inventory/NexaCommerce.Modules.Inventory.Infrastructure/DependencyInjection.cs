using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexaCommerce.Modules.Inventory.Infrastructure.BackgroundServices;
using NexaCommerce.Infrastructure.Persistence;
using NexaCommerce.Modules.Inventory.Application.Abstractions;
using NexaCommerce.Modules.Inventory.Domain.Repositories;
using NexaCommerce.Modules.Inventory.Infrastructure.Persistence;
using NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Repositories;
using NexaCommerce.Modules.Inventory.Infrastructure.Services;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.Inventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInventoryInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("Database"));
        });

        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
        services.AddScoped<
    IStockMovementRepository,
    StockMovementRepository>();
        services.AddScoped<
            IUnitOfWork,
            UnitOfWork<InventoryDbContext>>();
        services.AddScoped<
    IStockReservationRepository,
    StockReservationRepository>();
        services.AddHostedService<ExpiredReservationWorker>();
        return services;
    }
}
