using BeauProject.Accounting.Application.DTOs.AccountDetails;

namespace BeauProject.Accounting.Application.DTOs.AccountSubGroup
{
    public class AccountSubGroupDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public List<AccountDetailDto> Details { get; set; } = new();
    }
}
