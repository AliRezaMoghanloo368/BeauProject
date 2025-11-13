namespace BeauProject.Accounting.Domain.Models
{
    public class AccountSubGroupTranslation : BaseEntity
    {
        public long AccountSubGroupId { get; set; }
        public string Language { get; set; } = "fa";
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public AccountSubGroup AccountSubGroup { get; set; } = null!;
    }
}
