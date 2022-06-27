using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;
namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class AuthorizedAccountEntityConfiguration : IEntityTypeConfiguration<AuthorizedAccount>
    {
        public void Configure(EntityTypeBuilder<AuthorizedAccount> builder)
        {
            builder.Property(acc => acc.AuthorizationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(acc => acc.AuthorizationMethod)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
