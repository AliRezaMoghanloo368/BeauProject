namespace BeauProject.Restaurant.Domain.Models.Orders
{
    public enum OrderType
    {
        DineIn,
        Takeaway,
        Delivery
    }

    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public class Order : BaseEntity
    {
        public long BranchId { get; set; }
        public long? CustomerId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public OrderType OrderType { get; set; }
        public long? TableId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<OrderItem> Items { get; set; } = new();
        public List<Payment> Payments { get; set; } = new();
    }
}
