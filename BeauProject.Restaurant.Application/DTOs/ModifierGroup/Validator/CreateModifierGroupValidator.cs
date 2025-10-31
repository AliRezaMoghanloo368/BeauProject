using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
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
