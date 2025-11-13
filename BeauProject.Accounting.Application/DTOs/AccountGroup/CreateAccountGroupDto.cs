using BeauProject.Accounting.Application.DTOs.AccountSubGroup;

namespace BeauProject.Accounting.Application.DTOs.AccountGroup
{
    public class CreateAccountGroupDto
    {
        public long AccountHeaderId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public List<CreateAccountSubGroupDto> SubGroups { get; set; } = new();
    }
}
