using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(acc => acc.AccountId);

            builder.Property(acc => acc.UniqueAccountIdentificator)
                .IsRequired();

            builder.Property(acc => acc.Login)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(acc => acc.Password)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(acc => acc.CreationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(acc => acc.AccountOwnerId)
                .IsRequired();

            builder.HasDiscriminator<string>("account_type")
                .HasValue<Account>("account_base")
                .HasValue<UnauthorizedAccount>("unauthorized_account")
                .HasValue<AuthorizedAccount>("authorized_account")
                .HasValue<AdminAccount>("admin_account");

            builder.HasIndex(acc => acc.UniqueAccountIdentificator)
                .IsUnique();
        }
    }
}
