using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Catalog.Domain.Entities;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Persistence.Configurations;

internal sealed class CategoryAttributeConfiguration
    : IEntityTypeConfiguration<CategoryAttribute>
{
    public void Configure(
        EntityTypeBuilder<CategoryAttribute> builder)
    {
        builder.ToTable("CategoryAttributes");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x =>
            new
            {
                x.CategoryId,
                x.ProductAttributeId
            })
            .IsUnique();

        builder.Property(x => x.DisplayOrder);

        builder.Property(x => x.IsRequired);
    }
}
