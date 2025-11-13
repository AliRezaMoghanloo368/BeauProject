namespace BeauProject.Accounting.Application.DTOs.AccountDetails
{
    public class AccountDetailDto
    {
        public long Id { get; set; }
        public long SubGroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;
    }
}
