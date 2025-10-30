using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command
{
    public class CreateFoodItemRequest : IRequest<Result<bool>>
    {
        public CreateFoodItemDto CreateFoodItemDto { get; set; }
    }
}
