using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Handler.Command
{
    public class DeleteFoodItemHandler : IRequestHandler<DeleteFoodItemRequest, Result<bool>>
    {
        private readonly IFoodItemRepository _repo;
        public DeleteFoodItemHandler(IFoodItemRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(DeleteFoodItemRequest request, CancellationToken cancellationToken)
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
