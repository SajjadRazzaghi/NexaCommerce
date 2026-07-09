using Microsoft.EntityFrameworkCore;

namespace NexaCommerce.Modules.Identity.Infrastructure.Persistence;

public sealed class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

        base.OnModelCreating(builder);
    }
    public DbSet<User> Users => Set<User>();
}