using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class ProductVariantConfiguration
    : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(
        EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("ProductVariants");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Sku)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Sku)
            .IsUnique();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DiscountPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Stock);

        builder.Property(x => x.IsActive);

        builder.HasOne<Product>()
     .WithMany(x => x.Variants)
     .HasForeignKey(x => x.ProductId);

        builder.Navigation(x => x.Attributes)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
