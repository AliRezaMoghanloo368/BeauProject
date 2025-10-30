using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Handler.Query
{
    public class GetFoodItemHandler : IRequestHandler<GetFoodItemRequest, Result<FoodItemDto>>
    {
        private readonly IFoodItemRepository _repo;
        private readonly IMapper _mapper;
        public GetFoodItemHandler(IFoodItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<FoodItemDto>> Handle(GetFoodItemRequest request, CancellationToken cancellationToken)
        {
            var food = await _repo.GetFoodItemAsync(request.Id);
            if (food == null)
            {
                food = new FoodItem();
            }

            var dto = _mapper.Map<FoodItemDto>(food);
            return Result<FoodItemDto>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
