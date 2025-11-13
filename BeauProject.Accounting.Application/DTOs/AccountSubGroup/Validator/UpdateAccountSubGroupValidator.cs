using BeauProject.Accounting.Application.Features.AccountSubGroupType.Request.Command;
using FluentValidation;

namespace BeauProject.Accounting.Application.DTOs.AccountSubGroup.Validator
{
    public class UpdateAccountGroupValidator : AbstractValidator<UpdateAccountSubGroupRequest>
    {
        public UpdateAccountGroupValidator()
        {
            //RuleFor(x => x.Id)
            //    .GreaterThan(0).WithMessage("شناسه شعبه معتبر نیست.");

            //RuleFor(x => x.Name)
            //    .NotEmpty().MaximumLength(100);

            //RuleFor(x => x.Address)
            //    .NotEmpty().MaximumLength(250);

            //RuleFor(x => x.PhoneNumber)
            //    .NotEmpty().MaximumLength(20);

            //RuleFor(x => x.City)
            //    .NotEmpty().MaximumLength(100);
        }
    }
}
