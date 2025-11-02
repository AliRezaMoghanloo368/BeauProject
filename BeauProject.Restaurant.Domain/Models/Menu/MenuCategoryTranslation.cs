namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuCategoryTranslation : BaseEntity
    {
        public long CategoryId { get; set; }
        public string Locale { get; set; } = "fa-IR"; // کد زبان و منطقه
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // 🔗 Navigation
        public MenuCategory Category { get; set; } = null!;
    }
}
