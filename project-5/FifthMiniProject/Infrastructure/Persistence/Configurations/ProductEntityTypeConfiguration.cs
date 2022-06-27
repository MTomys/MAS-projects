using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductName).IsRequired();

            builder.HasOne(p => p.Order)
                .WithMany(order => order.Products);

            builder.HasOne(p => p.Seller)
                .WithMany(seller => seller.Products);
        }
    }
}
