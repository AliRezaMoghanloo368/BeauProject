using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command
{
    public class UpdateFoodItemRequest : IRequest<Result<bool>>
    {
        public UpdateFoodItemDto UpdateFoodItemDto { get; set; }
    }
}
