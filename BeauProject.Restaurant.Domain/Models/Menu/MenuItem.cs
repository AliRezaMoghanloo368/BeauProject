namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class MenuItem
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string? Code { get; set; }
        public string? SKU { get; set; }
        public bool IsActive { get; set; } = true;
        public bool TrackInventory { get; set; } = false;
        public List<MenuItemTranslation> Translations { get; set; } = new();
        public List<MenuItemPrice> Prices { get; set; } = new();
        public List<ModifierGroup> ModifierGroups { get; set; } = new();
    }
}
