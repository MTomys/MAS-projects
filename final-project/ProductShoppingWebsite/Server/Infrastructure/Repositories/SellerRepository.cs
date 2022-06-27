using Microsoft.EntityFrameworkCore;
using ProductShoppingWebsite.Server.Infrastructure.Persistence;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SellerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Seller> GetSellers()
        {
            return _applicationDbContext.Sellers.ToList();
        }

        public Seller GetSellerById(int sellerId)
        {
            return _applicationDbContext.Sellers.Find(sellerId);
        }

        public void InsertSeller(Seller seller)
        {
            _applicationDbContext.Sellers.Add(seller);
        }

        public void UpdateSeller(Seller seller)
        {
            _applicationDbContext.Entry(seller).State = EntityState.Modified;
        }

        public void DeleteSeller(int sellerId)
        {
            var seller = _applicationDbContext.Sellers.Find(sellerId);
            _applicationDbContext.Sellers.Remove(seller);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
