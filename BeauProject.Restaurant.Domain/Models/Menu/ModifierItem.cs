namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class ModifierItem
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public bool TrackInventory { get; set; } = false;
    }
}
