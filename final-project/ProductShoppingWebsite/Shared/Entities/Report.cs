using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Report
    {
        public int ReportId { get; set; }

        public int UniqueReportIdentificator { get; set; }
        public string ReportDescription { get; set; }
        public DateTime ReportDate { get; set; }

        public Customer Issuer { get; set; }
        public int IssuerId { get; set; }

        public Seller ReportedSeller { get; set; }
        public int ReportedSellerId { get; set; }
    }
}
