using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.ModifierItem.Validator
{
    public class CreateModifierItemValidator : AbstractValidator<CreateModifierItemRequest>
    {
        public CreateModifierItemValidator()
        {

        }
    }
}
