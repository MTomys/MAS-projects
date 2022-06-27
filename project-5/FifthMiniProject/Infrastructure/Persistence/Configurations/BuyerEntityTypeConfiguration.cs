using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class BuyerEntityTypeConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.Property(b => b.Email).HasColumnType("EMAIL").IsRequired();

            builder.OwnsOne(b => b.CreditCard);

            builder.HasMany(b => b.Orders)
                .WithOne(order => order.Buyer);
        }
    }
}
