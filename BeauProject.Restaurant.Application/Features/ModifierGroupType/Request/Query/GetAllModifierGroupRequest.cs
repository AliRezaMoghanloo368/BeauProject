using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query
{
    public class GetAllModifierGroupRequest : IRequest<Result<IQueryable<ModifierGroup>>>
    {
    }
}
