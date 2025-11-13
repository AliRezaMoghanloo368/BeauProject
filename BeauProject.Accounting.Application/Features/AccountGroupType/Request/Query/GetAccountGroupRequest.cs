using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Request.Query
{
    public record GetAccountGroupRequest(long Id) : IRequest<Result<AccountGroupDto>>
    {

    }
}
