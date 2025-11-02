namespace BeauProject.Restaurant.Application.DTOs.Food
{
    public class UpdateFoodItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "IRR";
        public bool IsAvailable { get; set; } = true;
        public int? Calories { get; set; }
        public long CategoryId { get; set; }
        public long RestaurantId { get; set; }
    }
}
