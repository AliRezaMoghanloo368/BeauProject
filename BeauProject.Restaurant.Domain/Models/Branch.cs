namespace BeauProject.Restaurant.Domain.Models
{
    public class Branch
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Locale { get; set; } // fa-IR, ar-SA, en-US
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
