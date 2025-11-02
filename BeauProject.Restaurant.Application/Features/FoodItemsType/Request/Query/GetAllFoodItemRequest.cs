using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Query
{
    public class GetAllFoodItemRequest:IRequest<Result<IQueryable<FoodItemDto>>>
    {
    }
}
