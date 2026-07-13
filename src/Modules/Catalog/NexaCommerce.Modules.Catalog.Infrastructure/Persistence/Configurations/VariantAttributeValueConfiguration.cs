using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class VariantAttributeValueConfiguration
    : IEntityTypeConfiguration<VariantAttributeValue>
{
    public void Configure(
        EntityTypeBuilder<VariantAttributeValue> builder)
    {
        builder.ToTable("VariantAttributeValues");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne<ProductVariant>()
            .WithMany(x => x.Attributes)
            .HasForeignKey(x => x.VariantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ProductAttribute>()
            .WithMany()
            .HasForeignKey(x => x.AttributeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
