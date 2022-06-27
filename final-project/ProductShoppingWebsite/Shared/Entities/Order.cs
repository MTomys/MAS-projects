using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UniqueOrderIdentificator { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int BuyerId { get; set; }
        public Customer Buyer { get; set; }
    }
}
