namespace FifthMiniProject.Domain.Entities
{
    public class CreditCard 
    {
        public string CreditCardNumber { get; set; }
        public string CvcNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
