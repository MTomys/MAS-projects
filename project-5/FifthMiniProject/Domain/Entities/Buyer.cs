namespace FifthMiniProject.Domain.Entities
{
    public class Buyer : Person
    {
        public int BuyerId { get; set; }
        public string Email { get; set; }
        public CreditCard CreditCard { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
