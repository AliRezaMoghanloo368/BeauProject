using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query
{
    public record GetAccountGroupRequest(long Id) : IRequest<Result<ModifierGroupDto>>
    {

    }
}
