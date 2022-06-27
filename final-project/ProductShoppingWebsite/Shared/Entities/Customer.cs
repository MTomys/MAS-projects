using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Customer : ServiceUser
    {
        public int CustomerId { get; set; }

        public int UniqueCustomerIdentificator { get; set; }
        public string CustomerNickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; } = null;
        public bool IsAuthorized { get; set; }

        public override string GetContactInfo()
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
