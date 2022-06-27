using ProductShoppingWebsite.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class AdminAccount : AuthorizedAccount, IUnauthorizedAccount
    {
    }
}

