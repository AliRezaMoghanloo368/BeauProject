using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command
{
    public class UpdateAccountGroupRequest : IRequest<Result<bool>>
    {
        public UpdateAccountGroupDto UpdateAccountGroupDto { get; set; }
    }
}
