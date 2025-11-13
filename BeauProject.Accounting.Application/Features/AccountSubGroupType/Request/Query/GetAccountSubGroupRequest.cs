using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Query
{
    public record GetAccountSubGroupRequest(long Id) : IRequest<Result<AccountSubGroupDto>>
    {

    }
}
