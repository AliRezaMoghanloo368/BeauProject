namespace BeauProject.Shared.Domain.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int CustomerId { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public Tickets()
        {
            Date = DateTime.Now;
        }
    }
}
