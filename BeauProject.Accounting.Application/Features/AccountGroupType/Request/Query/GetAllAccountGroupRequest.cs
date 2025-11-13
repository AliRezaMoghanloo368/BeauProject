using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Request.Query
{
    public class GetAllAccountGroupRequest : IRequest<Result<IQueryable<AccountGroupDto>>>
    {
    }
}
