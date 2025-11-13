namespace BeauProject.Accounting.Domain.Models
{
    // حساب معین
    public class AccountSubGroup : BaseEntity
    {
        public long AccountGroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;

        public AccountGroup Groups { get; set; } = null!;
        public ICollection<AccountSubGroupTranslation> Translations { get; set; } = new List<AccountSubGroupTranslation>();
        public ICollection<AccountDetail> Details { get; set; } = new List<AccountDetail>();
    }
}
