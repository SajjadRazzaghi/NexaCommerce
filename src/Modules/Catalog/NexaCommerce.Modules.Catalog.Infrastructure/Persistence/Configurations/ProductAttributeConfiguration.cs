using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class ProductAttributeConfiguration
    : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(
        EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasIndex(x => x.Name)
            .IsUnique();
        builder.Property(x => x.Type);

        builder.Property(x => x.IsVariant);

        builder.Property(x => x.IsFilterable);

        builder.Property(x => x.IsSearchable);
    }
}
