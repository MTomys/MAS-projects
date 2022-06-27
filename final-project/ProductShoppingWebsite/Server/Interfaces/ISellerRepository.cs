using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetSellers();
        Seller GetSellerById(int sellerId);
        void InsertSeller(Seller seller);
        void DeleteSeller(int sellerId);
        void UpdateSeller(Seller seller);
        void Save();
    }
}
