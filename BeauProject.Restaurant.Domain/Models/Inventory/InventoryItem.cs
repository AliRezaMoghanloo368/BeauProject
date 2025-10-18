namespace BeauProject.Restaurant.Domain.Models.Inventory
{
    public class InventoryItem
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Name { get; set; } = null!;
        public string? Unit { get; set; }
        public decimal? ReorderLevel { get; set; }
        public List<StockMovement> StockMovements { get; set; } = new();
    }
}
