using BeauProject.Accounting.Application.Features.AccountDetailType.Request.Command;
using FluentValidation;

namespace BeauProject.Accounting.Application.DTOs.AccountDetail.Validator
{
    public class CreateAccountDetailValidator : AbstractValidator<CreateAccountDetailRequest>
    {
        public CreateAccountDetailValidator()
        {
            //RuleFor(x => x.RestaurantId).GreaterThan(0);
            //RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
