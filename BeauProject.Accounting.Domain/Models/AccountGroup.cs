namespace BeauProject.Accounting.Domain.Models
{
    // حساب کل
    public class AccountGroup : BaseEntity
    {
        public long HeaderId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public ICollection<AccountGroupTranslation> Translations { get; set; } = new List<AccountGroupTranslation>();
        public ICollection<AccountSubGroup> SubGroups { get; set; } = new List<AccountSubGroup>();
    }
}
