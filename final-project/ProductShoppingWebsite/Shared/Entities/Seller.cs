using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Seller : ServiceUser
    {
        public int SellerId { get; set; }

        public int UniqueSellerIdentificator { get; set; }
        public string SellerNickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsArchived { get; set; }
        public bool IsBanned { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string GetContactInfo()
        {
            throw new NotImplementedException();
        }
    }
}
