using BeauProject.Restaurant.Application.DTOs.ModifierItem;

namespace BeauProject.Restaurant.Application.DTOs.ModifierGroup
{
    public class ModifierGroupDto
    {
        public long Id { get; set; }
        public long MenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public int MinSelection { get; set; }
        public int MaxSelection { get; set; }
        public List<ModifierItemDto> Modifiers { get; set; } = new();
    }
}
