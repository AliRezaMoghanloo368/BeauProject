using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food.Validator;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Handler.Command
{
    public class CreateFoodItemHandler : IRequestHandler<CreateFoodItemRequest, Result<bool>>
    {
        private readonly IFoodItemRepository _repo;
        private readonly IMapper _mapper;
        public CreateFoodItemHandler(IFoodItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(CreateFoodItemRequest request, CancellationToken cancellationToken)
        {
            var valid = new CreateFoodItemValidator();
            var foodsIsValid = await valid.ValidateAsync(request);
            if (!foodsIsValid.IsValid)
            {
                return Result<bool>.ErrorResult(foodsIsValid.Errors.Select(x => x.ErrorMessage).ToList());
            }

            var foodsEntity = _mapper.Map<FoodItem>(request.CreateFoodItemDto);
            await _repo.Create(foodsEntity);
            return Result<bool>.SuccessResult(true);
        }
    }
}
