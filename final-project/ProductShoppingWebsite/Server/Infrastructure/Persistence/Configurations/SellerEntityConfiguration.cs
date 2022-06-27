using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;
namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class SellerEntityConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers");

            builder.Property(su => su.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(su => su.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(seller => seller.UniqueSellerIdentificator)
                .IsRequired();

            builder.Property(seller => seller.SellerNickname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(seller => seller.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(seller => seller.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(seller => seller.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(seller => seller.BankAccountNumber)
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(seller => seller.IsAuthorized)
                .IsRequired();

            builder.Property(seller => seller.IsArchived)
                .IsRequired();

            builder.Property(seller => seller.IsBanned)
                .IsRequired();

            builder.HasMany(seller => seller.Products)
                .WithOne(product => product.Seller)
                .HasForeignKey(product => product.SellerId);

            builder.HasOne(cust => cust.Account)
                .WithOne(acc => (Seller) acc.AccountOwner)
                .HasForeignKey<Account>(acc => acc.AccountOwnerId);

            builder.HasIndex(seller => seller.UniqueSellerIdentificator)
                .IsUnique();
        }
    }
}
