using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Infrastructure.Persistence.Configurations;

internal sealed class InventoryTransactionConfiguration
    : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(
        EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.ToTable("InventoryTransactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }
}
