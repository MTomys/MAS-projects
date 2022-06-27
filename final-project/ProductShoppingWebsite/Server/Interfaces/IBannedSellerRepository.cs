using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface IBannedSellerRepository
    {
        IEnumerable<BannedSeller> GetBannedSellers();
        BannedSeller GetBannedSellerById(int bannedSellerId);
        void InsertBannedSeller(BannedSeller bannedSeller);
        void DeleteBannedSeller(int bannedSellerId);
        void UpdateBannedSeller(BannedSeller bannedSeller);
        void Save();
    }
}
