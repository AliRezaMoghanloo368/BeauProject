using BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command;
using FluentValidation;

namespace BeauProject.Accounting.Application.DTOs.AccountGroup.Validator
{
    public class CreateAccountGroupValidator : AbstractValidator<CreateAccountSubGroupRequest>
    {
        public CreateAccountGroupValidator()
        {
            //RuleFor(x => x.RestaurantId).GreaterThan(0);
            //RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
