using ProductShoppingWebsite.Shared.Dtos;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface IBannedSellerService
    {
        public BannedSellerDto AddBannedSeller(SellerBanDto sellerBanDto);
    }
}
