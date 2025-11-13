namespace BeauProject.Accounting.Domain.Models
{
    public class AccountGroupTranslation : BaseEntity
    {
        public long AccountGroupId { get; set; }
        public string Language { get; set; } = "fa"; // مثال: fa یا en
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public AccountGroup AccountGroup { get; set; } = null!;
    }
}
