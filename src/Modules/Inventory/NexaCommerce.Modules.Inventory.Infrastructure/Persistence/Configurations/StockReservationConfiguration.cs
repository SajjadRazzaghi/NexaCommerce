using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Configurations;

internal sealed class StockReservationConfiguration
    : IEntityTypeConfiguration<StockReservation>
{
    public void Configure(
        EntityTypeBuilder<StockReservation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.ExpiresOnUtc)
            .IsRequired();

        builder.Property(x => x.IsReleased)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.OrderId);

        builder.HasIndex(x => new
        {
            x.ProductVariantId,
            x.WarehouseId
        });
    }
}
