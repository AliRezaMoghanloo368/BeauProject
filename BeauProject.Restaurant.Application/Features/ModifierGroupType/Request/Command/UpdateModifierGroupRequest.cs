using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command
{
    public class UpdateModifierGroupRequest : IRequest<Result<bool>>
    {
        public UpdateModifierGroupDto UpdateModifierGroupDto { get; set; }
    }
}
