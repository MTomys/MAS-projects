using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Account : AccountBase
    {
        protected Account() { }

        public int AccountId { get; set; }

        public int AccountOwnerId { get; set; }
        public ServiceUser AccountOwner { get; set; }
    }
}
