using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Query
{
    public record GetFoodItemRequest(long Id) : IRequest<Result<FoodItemDto>>
    {

    }
}
