namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    public class AccountSubGroupTranslation : BaseEntity
    {
        public int AccountSubGroupId { get; set; }
        public string Language { get; set; } = "fa";
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public AccountSubGroup AccountSubGroup { get; set; } = null!;
    }
}
