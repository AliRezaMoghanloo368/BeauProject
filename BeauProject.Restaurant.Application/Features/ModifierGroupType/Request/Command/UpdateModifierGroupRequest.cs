using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGItemType.Request.Command
{
    public class UpdateModifierGItemRequest : IRequest<Result<bool>>
    {
        public UpdateModifierItemDto UpdateModifierItemDto { get; set; }
    }
}
