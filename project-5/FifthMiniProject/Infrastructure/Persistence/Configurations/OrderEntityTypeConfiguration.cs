using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.ShippingAddress).IsRequired();

            builder.HasOne(o => o.Buyer)
                .WithMany(buyer => buyer.Orders);

            builder.HasMany(o => o.Products)
                .WithOne(product => product.Order);
        }
    }
}
