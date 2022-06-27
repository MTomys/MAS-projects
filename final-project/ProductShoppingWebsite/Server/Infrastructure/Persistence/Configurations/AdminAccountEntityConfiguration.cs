using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class AdminAccountEntityConfiguration : IEntityTypeConfiguration<AdminAccount>
    {
        public void Configure(EntityTypeBuilder<AdminAccount> builder)
        {
        }
    }
}
