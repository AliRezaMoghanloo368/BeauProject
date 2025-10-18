namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuItemTranslation
    {
        public long Id { get; set; }
        public long MenuItemId { get; set; }
        public string Locale { get; set; } = "fa-IR";
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
