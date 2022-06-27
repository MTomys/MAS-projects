using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class BannedSeller
    {
        public int BannedSellerEntityId { get; set; }

        public int DecisionAdmin { get; set; }
        public DateTime DateOfBan { get; set; }
        public string BanReasonDescription { get; set; }
        public DateTime ArchivizationDate { get; set; }

        public int BannedSellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
