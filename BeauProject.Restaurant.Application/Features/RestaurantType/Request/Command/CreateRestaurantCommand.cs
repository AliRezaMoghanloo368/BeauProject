using BeauProject.Restaurant.Application.DTOs.Restaurant;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command
{
    public record CreateRestaurantCommand(string Code, string Name, string DefaultCurrency, string? TimeZone)
        : IRequest<Result<RestaurantDto>>;
}
