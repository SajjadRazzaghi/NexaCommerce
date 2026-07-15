using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence;

public sealed class CatalogDbContext : DbContext
{
    public CatalogDbContext(
        DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Brand> Brands => Set<Brand>();
   
    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();

    public DbSet<ProductImage> ProductImages => Set<ProductImage>();

    public DbSet<ProductSpecification> ProductSpecifications => Set<ProductSpecification>();
    public DbSet<ProductAttribute> ProductAttributes
    => Set<ProductAttribute>();

  
    public DbSet<CategoryAttribute> CategoryAttributes
    => Set<CategoryAttribute>();
    public DbSet<ProductAttributeOption>
    ProductAttributeOptions
    => Set<ProductAttributeOption>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
