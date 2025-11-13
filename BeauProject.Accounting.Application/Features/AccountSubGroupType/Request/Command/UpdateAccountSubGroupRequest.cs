using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command
{
    public class UpdateAccountSubGroupRequest : IRequest<Result<bool>>
    {
        public UpdateAccountSubGroupDto UpdateAccountSubGroupDto { get; set; }
    }
}
