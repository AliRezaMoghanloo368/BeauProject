using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Request.Command
{
    public record DeleteBranchCommand(long Id) : IRequest<Result<bool>>
    {

    }
}
