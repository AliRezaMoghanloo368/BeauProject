namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    public class AccountDetailTranslation
    {
        public int Id { get; set; }
        public int AccountDetailId { get; set; }
        public string Language { get; set; } = "fa";
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public AccountDetail AccountDetail { get; set; } = null!;
    }
}
