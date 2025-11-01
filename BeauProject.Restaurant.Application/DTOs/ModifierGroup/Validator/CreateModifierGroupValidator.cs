using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.ModifierGroup.Validator
{
    public class CreateModifierGroupValidator : AbstractValidator<CreateModifierGroupRequest>
    {
        public CreateModifierGroupValidator()
        {

        }
    }
}
