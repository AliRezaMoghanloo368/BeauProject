using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command
{
    public record DeleteModifierItemRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
