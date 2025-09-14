using System.Collections.Generic;

namespace BeauProject.Shared.Domain.Models
{
    public class GroupProducts
    {
        public GroupProducts()
        {
            Products = new HashSet<Products>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property (یک گروه می‌تواند چند محصول داشته باشد)
        public ICollection<Products> Products { get; set; }
    }
}
