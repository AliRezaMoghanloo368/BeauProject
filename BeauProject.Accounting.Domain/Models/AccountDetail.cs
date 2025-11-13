namespace BeauProject.Accounting.Domain.Models
{
    // حساب تفصیلی
    public class AccountDetail : BaseEntity
    {
        public long AccountSubGroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;

        public AccountSubGroup SubGroup { get; set; } = null!;
        public ICollection<AccountDetailTranslation> Translations { get; set; } = new List<AccountDetailTranslation>();
    }
}
