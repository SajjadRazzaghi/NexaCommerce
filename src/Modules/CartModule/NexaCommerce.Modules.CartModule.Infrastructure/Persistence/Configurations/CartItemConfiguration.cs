using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.CartModule.Domain.Entities;

namespace NexaCommerce.Modules.CartModule.Infrastructure.Persistence.Configurations;

internal sealed class CartItemConfiguration
    : IEntityTypeConfiguration<CartItem>
{
    public void Configure(
        EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductVariantId)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasPrecision(18,2);

        builder.HasIndex(x => new
        {
            x.CartId,
            x.ProductVariantId
        }).IsUnique();
    }
}