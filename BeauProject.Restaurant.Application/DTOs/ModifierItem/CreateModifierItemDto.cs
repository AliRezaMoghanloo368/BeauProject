namespace BeauProject.Restaurant.Application.DTOs.ModifierItem
{
    public class CreateModifierItemDto
    {
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public bool TrackInventory { get; set; } = false;
    }
}
