namespace BeauProject.Shared.Domain.Models
{
    public class Opportunities
    {
        public Opportunities()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Stage { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
