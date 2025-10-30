namespace BeauProject.Restaurant.Domain.Models
{
    public class Branch
    {
        public long Id { get; set; }

        public long RestaurantId { get; set; }   // FK به Restaurant
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Locale { get; set; }      // مثلاً "fa-IR" یا "en-US"
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string City { get; set; } = null!;
        public bool IsMainBranch { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // soft delete
        public bool IsDeleted { get; set; } = false;

        // Navigation Property
        public RestaurantEntity Restaurant { get; set; } = null!;
        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
