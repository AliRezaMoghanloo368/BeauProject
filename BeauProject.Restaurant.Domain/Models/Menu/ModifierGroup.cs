namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class ModifierGroup
    {
        public long Id { get; set; }
        public long MenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public int MinSelection { get; set; } = 0;
        public int MaxSelection { get; set; } = 0;
        public List<ModifierItem> Modifiers { get; set; } = new();
    }
}
