namespace BeauProject.Accounting.Application.DTOs.AccountDetails
{
    public class CreateAccountDetailDto
    {
        public long SubGroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;
    }
}
