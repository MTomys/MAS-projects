using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;
namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class BannedSellerEntityConfiguration : IEntityTypeConfiguration<BannedSeller>
    {
        public void Configure(EntityTypeBuilder<BannedSeller> builder)
        {
            builder.HasKey(bs => bs.BannedSellerEntityId);

            builder.Property(bs => bs.DecisionAdmin)
                .IsRequired();

            builder.Property(bs => bs.DateOfBan)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(bs => bs.BanReasonDescription)
                .HasMaxLength(1500)
                .IsRequired();

            builder.Property(bs => bs.BannedSellerId)
                .IsRequired();

            builder.HasOne(bs => bs.Seller)
                .WithOne()
                .HasForeignKey<BannedSeller>(bs => bs.BannedSellerId);

            builder.HasIndex(bs => bs.BannedSellerId)
                .IsUnique();
        }
    }
}
