using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command
{
    public class CreateModifierItemRequest : IRequest<Result<bool>>
    {
        public CreateModifierItemDto CreateModifierItemDto { get; set; }
    }
}
