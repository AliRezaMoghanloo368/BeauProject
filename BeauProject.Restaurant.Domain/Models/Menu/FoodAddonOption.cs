namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class FoodAddonOption : BaseEntity
    {
        public long FoodItemId { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Navigation
        public FoodItem FoodItem { get; set; } = null!;
    }
}
