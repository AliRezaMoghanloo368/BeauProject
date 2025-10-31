namespace BeauProject.Restaurant.Application.DTOs.ModifierItem
{
    public class UpdateModifierItemDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public bool TrackInventory { get; set; }
    }
}
