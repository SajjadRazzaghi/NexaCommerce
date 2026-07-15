using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NexaCommerce.Modules.Inventory.Application.Abstractions;

namespace NexaCommerce.Modules.Inventory.Infrastructure.BackgroundServices;

internal sealed class ExpiredReservationWorker
    : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ExpiredReservationWorker(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope =
                _scopeFactory.CreateScope();

            var inventory =
                scope.ServiceProvider
                    .GetRequiredService<IInventoryService>();

            await inventory.ReleaseExpiredReservationsAsync(
                stoppingToken);

            await Task.Delay(
                TimeSpan.FromMinutes(1),
                stoppingToken);
        }
    }
}
