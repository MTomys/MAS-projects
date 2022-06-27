namespace FifthMiniProject.Domain.Entities
{
    public class Seller : Person
    {
        public int SellerId { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
