using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Configurations;

internal sealed class WarehouseConfiguration
    : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Warehouse)
            .HasForeignKey(x => x.WarehouseId);
    }
}
