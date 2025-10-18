namespace BeauProject.Restaurant.Domain.Models.Orders
{
    public class OrderItemModifier
    {
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public long ModifierId { get; set; }
        public decimal? Price { get; set; }
    }
}
