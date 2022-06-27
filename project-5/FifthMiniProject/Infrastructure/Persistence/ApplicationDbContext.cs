using FifthMiniProject.Domain.Entities;
using FifthMiniProject.Infrastructure.Persistence.Configurations;

namespace FifthMiniProject.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<CreditCard>();
            new PersonEntityTypeConfiguration().Configure(builder.Entity<Person>());
            new SellerEntityTypeConfiguration().Configure(builder.Entity<Seller>());
            new BuyerEntityTypeConfiguration().Configure(builder.Entity<Buyer>());
            new ProductEntityTypeConfiguration().Configure(builder.Entity<Product>());
            new OrderEntityTypeConfiguration().Configure(builder.Entity<Order>());
        }
    }
}
