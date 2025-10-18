namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuCategoryTranslation
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Locale { get; set; } = "fa-IR";
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
