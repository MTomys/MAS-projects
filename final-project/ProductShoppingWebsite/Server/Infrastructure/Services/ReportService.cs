using ProductShoppingWebsite.Server.Infrastructure.Repositories;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<Report> GetAllReports()
        {
            return _reportRepository
                .GetReports()
                .ToList();
        }

        public List<Report> GetReportsForSeller(int sellerId)
        {
            return GetAllReports()
                .Where(report => report.ReportedSellerId.Equals(sellerId))
                .ToList();
        }

        public List<Report> GetReportsForSellerByUniqueId(int uniqueSellerId)
        {
            return GetAllReports()
                .Where(report => report.ReportedSeller.UniqueSellerIdentificator.Equals(uniqueSellerId))
                .ToList();
        }
    }
}
