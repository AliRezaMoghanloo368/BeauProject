using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command
{
    public record DeleteFoodItemRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
