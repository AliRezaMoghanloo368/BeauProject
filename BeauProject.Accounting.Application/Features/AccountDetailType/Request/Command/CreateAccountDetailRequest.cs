using BeauProject.Accounting.Application.DTOs.AccountDetails;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Accounting.Application.Features.AccountDetailType.Request.Command
{
    public class CreateAccountDetailRequest : IRequest<Result<bool>>
    {
        public CreateAccountDetailDto CreateAccountDetailDto { get; set; }
    }
}
