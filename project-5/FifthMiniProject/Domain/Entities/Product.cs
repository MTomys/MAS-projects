namespace FifthMiniProject.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Order? Order { get; set; }
        public Seller? Seller { get; set; }
    }
}
