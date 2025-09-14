using System.ComponentModel.DataAnnotations.Schema;

namespace BeauProject.Shared.Domain.Models
{
    public class Products
    {
        public Products()
        {
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int GroupProductsId { get; set; }

        // Navigation property
        public GroupProducts GroupProducts { get; set; }
    }
}
