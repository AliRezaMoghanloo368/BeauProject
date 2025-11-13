using BeauProject.Accounting.Application.DTOs.AccountSubGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command
{
    public class CreateAccountSubGroupRequest : IRequest<Result<bool>>
    {
        public CreateAccountSubGroupDto CreateAccountSubGroupDto { get; set; }
    }
}
