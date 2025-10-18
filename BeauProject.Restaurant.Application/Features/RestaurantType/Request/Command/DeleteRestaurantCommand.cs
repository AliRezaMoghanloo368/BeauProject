using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command
{
    public record DeleteRestaurantCommand(long Id) : IRequest<Result<bool>>
    {
    }
}
