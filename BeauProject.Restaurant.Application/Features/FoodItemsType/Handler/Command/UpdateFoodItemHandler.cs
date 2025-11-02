using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food.Validator;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Handler.Command
{
    public class UpdateFoodItemHandler : IRequestHandler<UpdateFoodItemRequest, Result<bool>>
    {
        private readonly IFoodItemRepository _repo;
        public UpdateFoodItemHandler(IFoodItemRepository repo) => _repo = repo;

        public async Task<Result<bool>> Handle(UpdateFoodItemRequest request, CancellationToken cancellationToken)
        {
            var valid = new UpdateFoodItemValidator();
            var isValid = await valid.ValidateAsync(request);
            if (!isValid.IsValid)
            {
                return Result<bool>.ErrorResult(isValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var entity = await _repo.GetFoodItemByIdAsync(request.UpdateFoodItemDto.Id);
            entity.Currency = request.UpdateFoodItemDto.Currency;
            entity.Price = request.UpdateFoodItemDto.Price;
            entity.Name = request.UpdateFoodItemDto.Name;
            entity.UpdatedAt = DateTime.UtcNow;

            await _repo.Update(entity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
