namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class Menu : BaseEntity
    {
        public long RestaurantId { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Navigation
        public RestaurantEntity Restaurant { get; set; } = null!;
        public ICollection<MenuCategory> Categories { get; set; } = new List<MenuCategory>();
    }
}
