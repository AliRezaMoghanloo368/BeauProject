using BeauProject.Accounting.Application.DTOs.AccountDetails;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountDetailType.Request.Command
{
    public class UpdateAccountDetailRequest : IRequest<Result<bool>>
    {
        public AccountDetailDto AccountDetailDto { get; set; }
    }
}
