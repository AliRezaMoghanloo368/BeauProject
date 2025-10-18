using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command
{
    public record UpdateRestaurantCommand(long Id, string Name, string DefaultCurrency, string? TimeZone)
        : IRequest<Result<bool>>
    {

    }
}
