using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.OrderModule.Domain.Entities;

namespace NexaCommerce.Modules.OrderModule.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration
    : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.CreatedOnUtc)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.Property(x => x.PaymentStatus)
            .HasConversion<string>();

        builder.Property(x => x.ShippingStatus)
            .HasConversion<string>();

        builder.OwnsOne(x => x.ShippingAddress, address =>
        {
            address.Property(x => x.FullName)
                .HasMaxLength(200);

            address.Property(x => x.Phone)
                .HasMaxLength(50);

            address.Property(x => x.Province)
                .HasMaxLength(100);

            address.Property(x => x.City)
                .HasMaxLength(100);

            address.Property(x => x.Address)
                .HasMaxLength(500);

            address.Property(x => x.PostalCode)
                .HasMaxLength(30);
        });
        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
