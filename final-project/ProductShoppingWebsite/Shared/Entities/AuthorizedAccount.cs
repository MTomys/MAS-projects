using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class AuthorizedAccount : Account
    {
        public DateTime AuthorizationDate { get; set; }
        public string AuthorizationMethod { get; set; }

        public AuthorizedAccount()
        {

        }
        
        public AuthorizedAccount(UnauthorizedAccount unauthorizedAccount)
        {

        }
    }
}
