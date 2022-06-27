using FifthMiniProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FifthMiniProject.Infrastructure.Persistence.Configurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.PersonName).IsRequired();

            builder.Property(p => p.PeselNumber).HasColumnType("PESEL").IsRequired();

            builder.HasIndex(p => p.PeselNumber).IsUnique();

            builder.HasDiscriminator<string>("person_type")
                .HasValue<Person>("person_base")
                .HasValue<Buyer>("person_buyer")
                .HasValue<Seller>("person_seller");
        }
    }
}
