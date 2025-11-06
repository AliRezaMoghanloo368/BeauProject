namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    // حساب معین
    public class AccountSubGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public AccountGroup Group { get; set; } = null!;
        public ICollection<AccountSubGroupTranslation> Translations { get; set; } = new List<AccountSubGroupTranslation>();
        public ICollection<AccountDetail> Details { get; set; } = new List<AccountDetail>();
    }
}
