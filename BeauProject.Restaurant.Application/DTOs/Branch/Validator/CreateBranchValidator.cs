using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.Branch.Validator
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator()
        {
            RuleFor(x => x.RestaurantId).GreaterThan(0);
            RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
