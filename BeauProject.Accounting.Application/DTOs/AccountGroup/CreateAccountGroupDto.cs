using BeauProject.Accounting.Application.DTOs.AccountSubGroup;

namespace BeauProject.Accounting.Application.DTOs.AccountGroup
{
    public class CreateAccountGroupDto
    {
        public long HeaderId { get; set; }
        public string Code { get; set; } = null!;
        public string Title { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public List<CreateAccountSubGroupDto> SubGroups { get; set; } = new();
    }
}
