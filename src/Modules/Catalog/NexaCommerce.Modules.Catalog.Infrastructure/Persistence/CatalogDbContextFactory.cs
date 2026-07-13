using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence;

public sealed class CatalogDbContextFactory
    : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<CatalogDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=.;Database=NexaCommerce;Trusted_Connection=True;TrustServerCertificate=True");

        return new CatalogDbContext(
            optionsBuilder.Options);
    }
}
