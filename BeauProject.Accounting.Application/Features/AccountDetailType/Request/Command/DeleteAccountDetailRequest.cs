using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountDetailType.Request.Command
{
    public record DeleteAccountDetailRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
