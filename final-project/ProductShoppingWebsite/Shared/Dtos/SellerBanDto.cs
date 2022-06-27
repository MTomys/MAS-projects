using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Dtos
{
    public class SellerBanDto
    {
        public SellerDto SellerDto { get; set; }
        public int DecisionAdmin { get; set; }
        public DateTime DateOfBan { get; set; }
        public string BanReasonDescription { get; set; }
        public DateTime ArchivizationDate { get; set; }
        public int BannedSellerId { get; set; }
    }
}
