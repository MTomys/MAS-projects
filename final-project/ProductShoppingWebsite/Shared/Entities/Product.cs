using ProductShoppingWebsite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShoppingWebsite.Shared.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public int UniqueProductIdentificator { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; }
        public string QuantityType { get; set; }
        public string ServicePerformer { get; set; }
        public string ServiceType { get; set; }
        public string ServicePerformerContactInfo { get; set; }
        public ISet<ProductTypeEnum> ProductTypes { get; set; }
        public string ProductTypesInString { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public ProductRating ProductRating { get; set; }
    }
}
