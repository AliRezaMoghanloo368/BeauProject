namespace BeauProject.Accounting.Application.DTOs.AccountGroup
{
    public class AccountGroupDto
    {
        public int Id { get; set; }
        public long GroupHeaderId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
