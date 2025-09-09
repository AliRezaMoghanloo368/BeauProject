namespace BeauProject.Site.Domain.Models
{
    public class Tickets
    {
        public Tickets()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public Guid Id { get; set; }
        public int MessageCode { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

    }
}
