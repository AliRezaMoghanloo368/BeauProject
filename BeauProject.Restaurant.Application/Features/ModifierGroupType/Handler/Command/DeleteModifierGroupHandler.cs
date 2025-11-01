using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Handler.Command
{
    public class DeleteModifierGroupHandler : IRequestHandler<DeleteModifierGroupRequest, Result<bool>>
    {
        private readonly IModifierGroupRepository _repo;
        public DeleteModifierGroupHandler(IModifierGroupRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteModifierGroupRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetAsync(request.Id);
            if (entity == null)
            {
                return Result<bool>.ErrorResult("غذای مورد نظر یافت نشد!");
            }

            await _repo.Delete(entity);
            return Result<bool>.SuccessResult(true, "عملیات حذف انجام شد.");
        }
    }
}
