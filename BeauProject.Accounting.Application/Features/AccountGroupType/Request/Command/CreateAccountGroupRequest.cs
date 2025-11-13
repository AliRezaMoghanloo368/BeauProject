using BeauProject.Accounting.Application.DTOs.AccountGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command
{
    public class CreateAccountGroupRequest : IRequest<Result<bool>>
    {
        public CreateAccountGroupDto CreateAccountGroupDto { get; set; }
    }
}
