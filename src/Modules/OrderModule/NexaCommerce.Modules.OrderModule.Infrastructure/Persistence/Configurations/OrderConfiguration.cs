using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.OrderModule.Domain.Entities;

namespace NexaCommerce.Modules.OrderModule.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId).IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.Property(x => x.PaymentStatus)
            .HasConversion<int>();

        builder.Property(x => x.ShippingStatus)
            .HasConversion<int>();

        builder.OwnsOne(x => x.ShippingAddress);

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.OrderId);
    }
}
