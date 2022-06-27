using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(report => report.UniqueReportIdentificator)
                .IsRequired();

            builder.Property(report => report.ReportDescription)
                .HasMaxLength(1500)
                .IsRequired();

            builder.Property(report => report.ReportDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(report => report.IssuerId)
                .IsRequired();

            builder.HasOne(report => report.ReportedSeller)
                .WithMany()
                .HasForeignKey(report => report.ReportedSellerId)
                .IsRequired();

            builder.HasIndex(report => report.UniqueReportIdentificator)
                .IsUnique();

        }
    }
}
