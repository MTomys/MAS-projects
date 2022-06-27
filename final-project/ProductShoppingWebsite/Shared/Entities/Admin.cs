using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Admin : ServiceUser
    {
        public int AdminId { get; set; }

        public int UniqueAdminIdentificator { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }

        public AdminAccount AdminAccount { get; set; }

        public override string GetContactInfo()
        {
            throw new NotImplementedException();
        }
    }
}
