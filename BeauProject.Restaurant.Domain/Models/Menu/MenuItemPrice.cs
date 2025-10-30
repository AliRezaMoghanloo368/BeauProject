namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuItemPrice : BaseEntity
    {
        public long MenuItemId { get; set; }
        public string CurrencyCode { get; set; } = "IRR";
        public decimal Price { get; set; }
        public DateTime StartAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndAt { get; set; }
    }
}
