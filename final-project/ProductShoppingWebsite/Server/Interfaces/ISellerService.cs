using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Dtos;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface ISellerService
    {
        Seller GetSellerByUniqueSellerId(int uniqueSellerId);
        SellerDto GetSellerDtoByUniqueSellerId(int uniqueSellerId);
        List<Seller> GetReportedSellers();
        public List<SellerDto> GetReportedSellersDtoWithReports();
        public SellerDto BanSeller(int uniqueSellerId);
    }
}
