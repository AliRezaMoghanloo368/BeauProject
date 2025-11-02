using BeauProject.Restaurant.Application.DTOs.ModifierItem;

namespace BeauProject.Restaurant.Application.DTOs.ModifierGroup
{
    public class CreateModifierGroupDto
    {
        public long MenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public int MinSelection { get; set; } = 0;
        public int MaxSelection { get; set; } = 0;
        public List<CreateModifierItemDto> Modifiers { get; set; } = new();
    }
}
