using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class BrandConfiguration
    : IEntityTypeConfiguration<Brand>
{
    public void Configure(
        EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);
    }
}
