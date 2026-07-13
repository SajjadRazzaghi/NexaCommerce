using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NexaCommerce.Modules.Identity.Domain.Entities;

namespace NexaCommerce.Modules.Identity.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(
            x => x.PhoneNumber,
            phone =>
            {
                phone.Property(x => x.Value)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(11)
                    .IsRequired();

                phone.HasIndex(x => x.Value)
                    .IsUnique();
            });


        builder.OwnsOne(
            x => x.FullName,
            fullName =>
            {
                fullName.Property(x => x.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(100)
                    .IsRequired();

                fullName.Property(x => x.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(100)
                    .IsRequired();
            });


        builder.OwnsOne(
            x => x.PasswordHash,
            password =>
            {
                password.Property(x => x.Value)
                    .HasColumnName("PasswordHash")
                    .HasMaxLength(500)
                    .IsRequired();
            });

        builder.Property(x => x.RefreshToken)
    .HasMaxLength(500);

        builder.Property(x => x.RefreshTokenExpiresOnUtc);
    }
}
