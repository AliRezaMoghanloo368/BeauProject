using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Query
{
    public class GetAllAccountSubGroupRequest : IRequest<Result<IQueryable<AccountSubGroupDto>>>
    {
    }
}
