namespace BeauProject.Restaurant.Domain.Models.Orders
{
    public class Payment : BaseEntity
    {
        public long OrderId { get; set; }
        public string PaymentProvider { get; set; } = null!;
        public string? ProviderReference { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "IRR";
        public string Method { get; set; } = "Cash";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
