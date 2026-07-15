using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Configurations;

internal sealed class InventoryReservationConfiguration
    : IEntityTypeConfiguration<InventoryReservation>
{
    public void Configure(
        EntityTypeBuilder<InventoryReservation> builder)
    {
        builder.ToTable("InventoryReservations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity);

        builder.Property(x => x.IsReleased);
    }
}
