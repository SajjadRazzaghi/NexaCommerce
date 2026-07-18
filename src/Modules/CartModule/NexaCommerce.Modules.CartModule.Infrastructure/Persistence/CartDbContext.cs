using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.CartModule.Domain.Entities;

namespace NexaCommerce.Modules.CartModule.Infrastructure.Persistence;

public sealed class CartDbContext : DbContext
{
    public CartDbContext(
        DbContextOptions<CartDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cart> Carts => Set<Cart>();

    public DbSet<CartItem> CartItems => Set<CartItem>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CartDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}