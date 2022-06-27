using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public abstract class ServiceUser
    {
        public static int MinimumAge = 18;

        public int ServiceUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public abstract string GetContactInfo();

        public int GetAge()
        {
            var now = DateTime.Now;
            return (now.Year - BirthDate.Year) +
                ((now.Month > BirthDate.Month) || 
                (now.Month == BirthDate.Month && now.Day > BirthDate.Day) ? 1 : 0);
        }

        public Account Account { get; set; }
    }
}
