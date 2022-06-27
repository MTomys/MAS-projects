using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class CreditCardEntityTypeConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(c => c.CreditCardNumber).HasColumnType("CREDIT_CARD_NUMBER").IsRequired();

            builder.Property(c => c.CvcNumber).HasColumnType("CVC_CARD_NUMBER").IsRequired();

            builder.Property(c => c.ExpirationDate).HasColumnType("Date").IsRequired();
        }
    }
}
