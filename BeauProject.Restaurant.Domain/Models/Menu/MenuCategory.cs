namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuCategory
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string? Code { get; set; }
        public int SortOrder { get; set; } = 0;
        public List<MenuCategoryTranslation> Translations { get; set; } = new();
        public List<MenuItem> MenuItems { get; set; } = new();
    }
}
