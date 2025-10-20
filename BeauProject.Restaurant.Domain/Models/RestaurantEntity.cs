namespace BeauProject.Restaurant.Domain.Models
{
    public class RestaurantEntity
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string DefaultCurrency { get; set; } = "IRR";
        public string? TimeZone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // soft delete
        public bool IsDeleted { get; set; } = false;

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}
