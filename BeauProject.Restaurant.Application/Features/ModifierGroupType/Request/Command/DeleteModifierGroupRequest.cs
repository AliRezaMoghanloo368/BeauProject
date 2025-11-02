using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command
{
    public record DeleteModifierGroupRequest(long Id) : IRequest<Result<bool>>
    {
    }
}
