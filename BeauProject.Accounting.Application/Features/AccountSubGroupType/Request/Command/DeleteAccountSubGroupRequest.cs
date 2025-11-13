using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command
{
    public record DeleteAccountSubGroupRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
