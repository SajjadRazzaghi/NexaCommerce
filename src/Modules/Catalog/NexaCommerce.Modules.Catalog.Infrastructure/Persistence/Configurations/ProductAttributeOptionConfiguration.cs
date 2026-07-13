using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class ProductAttributeOptionConfiguration
    : IEntityTypeConfiguration<ProductAttributeOption>
{
    public void Configure(
        EntityTypeBuilder<ProductAttributeOption> builder)
    {
        builder.ToTable("ProductAttributeOptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DisplayOrder);

        builder.Property(x => x.IsActive);

        builder.HasIndex(x =>
            new
            {
                x.ProductAttributeId,
                x.Name
            })
            .IsUnique();

        builder.HasOne<ProductAttribute>()
            .WithMany()
            .HasForeignKey(x => x.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
