using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.UniqueProductIdentificator)
                .IsRequired();

            builder.Property(product => product.ProductName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(product => product.ProductDescription)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(product => product.Price)
                .HasColumnType("decimal(19, 4)")
                .IsRequired();

            builder.Property(product => product.QuantityType)
                .HasMaxLength(200);

            builder.Property(product => product.ServicePerformer)
                .HasMaxLength(300);

            builder.Property(product => product.ServiceType)
                .HasMaxLength(300);

            builder.Property(product => product.ServicePerformerContactInfo)
                .HasMaxLength(300);

            builder.Ignore(product => product.ProductTypes);

            builder.Property(product => product.ProductTypesInString)
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(product => product.ProductRating, ownedBuilder =>
            {
                ownedBuilder.Property(rating => rating.RatingScore)
                .IsRequired();

                ownedBuilder.Property(rating => rating.RatingDescription)
                .HasMaxLength(1500)
                .IsRequired();

                ownedBuilder.Property(rating => rating.RatingDate)
                .HasColumnType("datetime")
                .IsRequired();

                ownedBuilder.HasOne(rating => rating.RatedBy)
                .WithMany()
                .HasForeignKey(rating => rating.RatedById);

                ownedBuilder.ToTable("ProductRatings");
            });

            builder.HasIndex(product => product.UniqueProductIdentificator)
                .IsUnique();
        }
    }
}
