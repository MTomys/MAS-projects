using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShoppingWebsite.Shared.Entities;
namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.Configurations
{
    public class UnauthorizedAccountEntityConfiguration : IEntityTypeConfiguration<UnauthorizedAccount>
    {
        public void Configure(EntityTypeBuilder<UnauthorizedAccount> builder)
        {
        }    
    }
}
