using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using FluentValidation;

namespace BeauProject.Restaurant.Application.DTOs.Food.Validator
{
    public class CreateFoodItemValidator : AbstractValidator<CreateFoodItemRequest>
    {
        public CreateFoodItemValidator()
        {

        }
    }
}
