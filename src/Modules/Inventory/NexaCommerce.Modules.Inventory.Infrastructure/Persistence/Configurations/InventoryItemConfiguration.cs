using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Configurations;

internal sealed class InventoryItemConfiguration
    : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(
        EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductVariantId)
          .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.ReservedQuantity)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.WarehouseId,
            x.ProductVariantId
        })
  .IsUnique();
    }
}
