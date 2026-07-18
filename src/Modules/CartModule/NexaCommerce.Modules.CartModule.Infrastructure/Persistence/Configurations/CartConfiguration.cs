using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.CartModule.Domain.Entities;

namespace NexaCommerce.Modules.CartModule.Infrastructure.Persistence.Configurations;

internal sealed class CartConfiguration
    : IEntityTypeConfiguration<Cart>
{
    public void Configure(
        EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.CreatedOnUtc)
            .IsRequired();

        builder.Property(x => x.UpdatedOnUtc)
            .IsRequired();

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.CustomerId)
            .IsUnique();
    }
}