namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class FoodItem : BaseEntity
    {
        public long CategoryId { get; set; }
        public long RestaurantId { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "IRR";
        public bool IsAvailable { get; set; } = true;
        public string? ImageUrl { get; set; }
        public int? Calories { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Navigation
        public MenuCategory Category { get; set; } = null!;
        public RestaurantEntity Restaurant { get; set; } = null!;
        public ICollection<FoodAddonOption> AddonOptions { get; set; } = new List<FoodAddonOption>();
        public ICollection<ModifierGroup> ModifierGroups { get; set; } = new List<ModifierGroup>();
    }
}
