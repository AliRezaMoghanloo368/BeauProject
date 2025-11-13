using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountGroupType.Request.Command
{
    public record DeleteAccountGroupRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
