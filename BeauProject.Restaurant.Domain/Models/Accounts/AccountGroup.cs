namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    // حساب کل
    public class AccountGroup : BaseEntity
    {
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public ICollection<AccountGroupTranslation> Translations { get; set; } = new List<AccountGroupTranslation>();
        public ICollection<AccountSubGroup> SubGroups { get; set; } = new List<AccountSubGroup>();
    }
}
