using ProductShoppingWebsite.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Dtos
{
    public class SellerDto
    {
        public int TableUtilNumber { get; set; }
        public bool ShowDetails { get; set; }

        public ICollection<Report> ReportsforSeller { get; set; }

        public int UniqueSellerIdentificator { get; set; }
        public string SellerNickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsArchived { get; set; }
        public bool IsBanned { get; set; }
    }
}
