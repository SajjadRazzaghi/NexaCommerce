using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence;

public sealed class InventoryDbContext : DbContext
{
    public InventoryDbContext(
        DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Warehouse> Warehouses
        => Set<Warehouse>();

    public DbSet<InventoryItem> InventoryItems
        => Set<InventoryItem>();

    public DbSet<InventoryReservation> InventoryReservations
        => Set<InventoryReservation>();

    public DbSet<InventoryTransaction> InventoryTransactions
        => Set<InventoryTransaction>();
    public DbSet<StockReservation> StockReservations
      => Set<StockReservation>();
    
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(InventoryDbContext).Assembly);
    }
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
}
