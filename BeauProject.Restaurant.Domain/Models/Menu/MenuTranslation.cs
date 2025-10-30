namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuTranslation
    {
        public long Id { get; set; }

        public string EntityType { get; set; } = null!;   // Menu, MenuCategory, FoodItem
        public long EntityId { get; set; }                // آیتمی که ترجمه شده
        public string LanguageCode { get; set; } = null!; // مثل "fa", "en", "ar"

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
