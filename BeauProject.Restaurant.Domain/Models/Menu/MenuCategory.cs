namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuCategory : BaseEntity
    {
        public long MenuId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 1;

        public Menu Menu { get; set; } = null!;
        public ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

        // 🔗 Navigation برای ترجمه
        public ICollection<MenuCategoryTranslation> Translations { get; set; } = new List<MenuCategoryTranslation>();
    }
}
