using BeauProject.Restaurant.Application.DTOs;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Request.Query
{
    public record GetRestaurantsQuery() : IRequest<Result<List<RestaurantDto>>>
    {
    }
}
