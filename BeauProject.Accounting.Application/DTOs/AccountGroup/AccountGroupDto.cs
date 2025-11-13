namespace BeauProject.Accounting.Application.DTOs.AccountGroup
{
    public class AccountGroupDto
    {
        public long Id { get; set; }
        public long AccountHeaderId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
