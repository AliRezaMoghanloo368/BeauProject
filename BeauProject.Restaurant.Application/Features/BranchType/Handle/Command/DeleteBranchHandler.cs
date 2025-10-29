using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.BranchType.Handle.Command
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, Result<bool>>
    {
        private readonly IBranchRepository _repo;
        public DeleteBranchHandler(IBranchRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetAsync(request.Id);
            if (entity is null) return Result<bool>.ErrorResult("Branch not found.");
            await _repo.Delete(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
