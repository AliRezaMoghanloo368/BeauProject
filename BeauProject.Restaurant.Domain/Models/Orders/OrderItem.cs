namespace BeauProject.Restaurant.Domain.Models.Orders
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long MenuItemId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Note { get; set; }
        public List<OrderItemModifier> Modifiers { get; set; } = new();
    }
}
