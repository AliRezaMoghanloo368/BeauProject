namespace BeauProject.Shared.Domain.Models
{
    public class Tikets
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int CustomerId { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public Tikets()
        {
            Date = DateTime.Now;
        }
    }
}
