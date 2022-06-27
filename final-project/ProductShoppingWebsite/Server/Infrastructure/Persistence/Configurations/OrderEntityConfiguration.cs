using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(order => order.UniqueOrderIdentificator)
                .IsRequired();

            builder.Property(order => order.ProductId)
                .IsRequired();

            builder.Property(order => order.BuyerId)
                .IsRequired();

            builder.Property(order => order.PaymentMethod)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(order => order.ShippingAddress)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(order => order.BuyerPhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(order => order.OrderDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(order => order.OrderStatus)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(order => order.Product)
                .WithOne()
                .HasForeignKey<Order>(order => order.ProductId);

            builder.HasIndex(order => order.UniqueOrderIdentificator)
                .IsUnique();
        }
    }
}
