using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class ProductRating
    {
        public double RatingScore { get; set; }
        public string RatingDescription { get; set; }

        public Customer RatedBy { get; set; }
        public int RatedById { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
