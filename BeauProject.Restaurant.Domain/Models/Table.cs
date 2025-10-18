namespace BeauProject.Restaurant.Domain.Models
{
    public class Table
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public string TableCode { get; set; } = null!;
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
