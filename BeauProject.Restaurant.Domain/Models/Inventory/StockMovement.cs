namespace BeauProject.Restaurant.Domain.Models.Inventory
{
    public class StockMovement : BaseEntity
    {
        public long InventoryItemId { get; set; }
        public decimal Quantity { get; set; }
        public string MovementType { get; set; } = null!; // Purchase, Consumption
        public long? ReferenceId { get; set; } // e.g., OrderId
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
