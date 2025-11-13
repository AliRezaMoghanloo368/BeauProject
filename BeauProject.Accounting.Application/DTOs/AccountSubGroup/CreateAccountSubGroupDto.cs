using BeauProject.Accounting.Application.DTOs.AccountDetails;

namespace BeauProject.Accounting.Application.DTOs.AccountSubGroup
{
    public class CreateAccountSubGroupDto
    {
        public long GroupId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FullCode { get; set; } = null!;
        public List<CreateAccountDetailDto> Details { get; set; } = new();
    }
}
