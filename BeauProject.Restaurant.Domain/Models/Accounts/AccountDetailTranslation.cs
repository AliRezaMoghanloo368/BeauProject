using BeauProject.Restaurant.Domain.Models;

namespace BeauProject.Accounting.Domain.Models
{
    public class AccountDetailTranslation : BaseEntity
    {
        public long AccountDetailId { get; set; }
        public string Language { get; set; } = "fa";
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public AccountDetail AccountDetail { get; set; } = null!;
    }
}
