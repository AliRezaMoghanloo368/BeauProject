namespace BeauProject.Accounting.Domain.Models
{
    // حساب معین
    public class AccountSubGroup : BaseEntity
    {
        public long GroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public AccountGroup Group { get; set; } = null!;
        public ICollection<AccountSubGroupTranslation> Translations { get; set; } = new List<AccountSubGroupTranslation>();
        public ICollection<AccountDetail> Details { get; set; } = new List<AccountDetail>();
    }
}
