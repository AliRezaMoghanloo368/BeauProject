using BeauProject.Restaurant.Domain.Models.Menu;

namespace BeauProject.Restaurant.Domain.Models
{
    public class RestaurantEntity : BaseEntity
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string DefaultCurrency { get; set; } = "IRR";
        public string? TimeZone { get; set; }
        public DateTime CreatedAt { get; set; }

        // soft delete
        public bool IsDeleted { get; set; } = false;

        // Navigation
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<MenuCategory> Categories { get; set; } = new List<MenuCategory>();
        public ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

        public RestaurantEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
