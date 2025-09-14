namespace BeauProject.Shared.Domain.Models
{
    public class Products
    {
        public Products()
        {
        }
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int GroupProducts { get; set; }
    }
}
