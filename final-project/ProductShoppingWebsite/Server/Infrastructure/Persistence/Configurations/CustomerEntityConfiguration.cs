using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.Property(su => su.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(cust => cust.UniqueCustomerIdentificator)
                .IsRequired();

            builder.Property(cust => cust.CustomerNickname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(cust => cust.Email)
                .HasMaxLength(319)
                .IsRequired();

            builder.Property(cust => cust.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(cust => cust.BankAccountNumber)
                .HasMaxLength(18);

            builder.HasMany(cust => cust.Orders)
                .WithOne(order => order.Buyer)
                .HasForeignKey(order => order.BuyerId);

            builder.HasMany(cust => cust.Reports)
                .WithOne(report => report.Issuer)
                .HasForeignKey(report => report.IssuerId);

            builder.HasOne(cust => cust.Account)
                .WithOne(acc => (Customer)acc.AccountOwner)
                .HasForeignKey<Account>(acc => acc.AccountOwnerId);

            builder.HasIndex(cust => cust.UniqueCustomerIdentificator)
                .IsUnique();
        }
    }
}
