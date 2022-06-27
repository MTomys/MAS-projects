using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetReports();
        Report GetReportById(int reportId);
        void InsertReport(Report report);
        void DeleteReport(int reportId);
        void UpdateReport(Report report);
        void Save();

    }
}
