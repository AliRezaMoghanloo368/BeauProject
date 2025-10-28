using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.Branch.Validator
{
    public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه شعبه معتبر نیست.");

            RuleFor(x => x.Name)
                .NotEmpty().MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty().MaximumLength(250);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().MaximumLength(20);

            RuleFor(x => x.City)
                .NotEmpty().MaximumLength(100);
        }
    }
}
