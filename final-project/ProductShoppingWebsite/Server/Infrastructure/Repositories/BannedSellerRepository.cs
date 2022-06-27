using Microsoft.EntityFrameworkCore;
using ProductShoppingWebsite.Server.Infrastructure.Persistence;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Repositories
{
    public class BannedSellerRepository : IBannedSellerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BannedSellerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<BannedSeller> GetBannedSellers()
        {
            return _applicationDbContext.BannedSellers.ToList();
        }

        public BannedSeller GetBannedSellerById(int bannedSellerId)
        {
            return _applicationDbContext.BannedSellers.Find(bannedSellerId);
        }

        public void InsertBannedSeller(BannedSeller bannedSeller)
        {
            _applicationDbContext.BannedSellers.Add(bannedSeller);
        }

        public void UpdateBannedSeller(BannedSeller bannedSeller)
        {
            _applicationDbContext.Entry(bannedSeller).State = EntityState.Modified;
        }

        public void DeleteBannedSeller(int bannedSellerId)
        {
            var bannedSeller = _applicationDbContext.BannedSellers.Find(bannedSellerId);
            _applicationDbContext.BannedSellers.Remove(bannedSeller);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
