using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierItemType.Handler.Command
{
    public class DeleteModifierItemHandler : IRequestHandler<DeleteModifierItemRequest, Result<bool>>
    {
        private readonly IModifierItemRepository _repo;
        public DeleteModifierItemHandler(IModifierItemRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteModifierItemRequest request, CancellationToken cancellationToken)
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
