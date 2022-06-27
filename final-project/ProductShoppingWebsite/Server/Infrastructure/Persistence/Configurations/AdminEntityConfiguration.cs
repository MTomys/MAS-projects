using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.Property(su => su.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(admin => admin.UniqueAdminIdentificator)
                .IsRequired();

            builder.Property(admin => admin.AdminName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(admin => admin.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(admin => admin.UniqueAdminIdentificator)
                .IsUnique();
        }
    }
}
