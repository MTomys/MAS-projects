using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface IReportService
    {
        List<Report> GetAllReports();
        List<Report> GetReportsForSeller(int sellerId);
        List<Report> GetReportsForSellerByUniqueId(int uniqueSellerId);
    }
}
