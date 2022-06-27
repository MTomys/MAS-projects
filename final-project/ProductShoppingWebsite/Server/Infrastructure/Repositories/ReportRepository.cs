using Microsoft.EntityFrameworkCore;
using ProductShoppingWebsite.Server.Infrastructure.Persistence;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReportRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Report> GetReports()
        {
            return _applicationDbContext.Reports.ToList();
        }

        public Report GetReportById(int reportId)
        {
            return _applicationDbContext.Reports.Find(reportId);
        }

        public void InsertReport(Report report)
        {
            _applicationDbContext.Reports.Add(report);
        }

        public void UpdateReport(Report report)
        {
            _applicationDbContext.Entry(report).State = EntityState.Modified;
        }

        public void DeleteReport(int reportId)
        {
            var report = _applicationDbContext.Reports.Find(reportId);
            _applicationDbContext.Reports.Remove(report);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
