namespace FifthMiniProject.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ShippingAddress { get; set; }
        public Buyer Buyer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
