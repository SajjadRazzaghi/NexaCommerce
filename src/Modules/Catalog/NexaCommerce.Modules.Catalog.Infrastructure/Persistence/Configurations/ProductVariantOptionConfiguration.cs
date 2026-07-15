using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class ProductVariantOptionConfiguration
    : IEntityTypeConfiguration<ProductVariantOption>
{
    public void Configure(
        EntityTypeBuilder<ProductVariantOption> builder)
    {
        builder.ToTable("ProductVariantOptions");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.Options)
            .HasForeignKey(x => x.VariantId);
    }
}
