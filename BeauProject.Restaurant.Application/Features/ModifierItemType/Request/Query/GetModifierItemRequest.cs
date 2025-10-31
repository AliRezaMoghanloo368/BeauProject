using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Query
{
    public record GetModifierItemRequest(long Id) : IRequest<Result<ModifierItemDto>>
    {

    }
}
