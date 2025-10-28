using BeauProject.Restaurant.Application.DTOs.Restaurant;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Request.Query
{
    public record GetRestaurantsRequest() : IRequest<Result<List<RestaurantDto>>>
    {
    }
}
