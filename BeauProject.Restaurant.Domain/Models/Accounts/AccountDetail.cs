namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    // حساب تفصیلی
    public class AccountDetail
    {
        public int Id { get; set; }
        public int SubGroupId { get; set; }
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public AccountSubGroup SubGroup { get; set; } = null!;
        public ICollection<AccountDetailTranslation> Translations { get; set; } = new List<AccountDetailTranslation>();
    }
}
