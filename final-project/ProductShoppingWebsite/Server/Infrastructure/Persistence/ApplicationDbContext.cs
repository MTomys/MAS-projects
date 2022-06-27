using Microsoft.EntityFrameworkCore;
using ProductShoppingWebsite.Shared.Entities;
using System.Reflection;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<AuthorizedAccount> AuthorizedAccounts { get; set; }
        public DbSet<BannedSeller> BannedSellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<UnauthorizedAccount> UnauthorizedAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ServiceUser>();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
