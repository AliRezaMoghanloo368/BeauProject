using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command
{
    public class CreateModifierGroupRequest : IRequest<Result<bool>>
    {
        public CreateModifierGroupDto CreateModifierGroupDto { get; set; }
    }
}
