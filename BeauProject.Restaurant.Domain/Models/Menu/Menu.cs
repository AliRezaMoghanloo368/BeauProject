using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Domain.Models.Menu
{
    public class Menu
    {
        public int Id { get; set; }
        public long RestaurantId { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Navigation
        public RestaurantEntity Restaurant { get; set; } = null!;
        public ICollection<MenuCategory> Categories { get; set; } = new List<MenuCategory>();
    }
}
