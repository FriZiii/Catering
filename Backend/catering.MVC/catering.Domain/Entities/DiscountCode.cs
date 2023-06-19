namespace catering.Domain.Entities
{
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime Expiration { get; set; }
    }
}
