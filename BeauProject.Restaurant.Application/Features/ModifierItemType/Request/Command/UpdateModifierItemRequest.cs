using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command
{
    public class UpdateModifierItemRequest : IRequest<Result<bool>>
    {
        public UpdateModifierItemDto UpdateModifierItemDto { get; set; }
    }
}
