using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class SellerEntityTypeConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.Property(s => s.Address).IsRequired();

            builder.HasMany(s => s.Products)
                .WithOne(product => product.Seller);
        }
    }
}
