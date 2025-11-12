namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    // حساب تفصیلی
    public class AccountDetail : BaseEntity
    {
        public long SubGroupId { get; set; }
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public AccountSubGroup SubGroup { get; set; } = null!;
        public ICollection<AccountDetailTranslation> Translations { get; set; } = new List<AccountDetailTranslation>();
    }
}
