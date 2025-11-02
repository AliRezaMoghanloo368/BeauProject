using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Query;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.FoodItemsType.Handler.Query
{
    public class GetAllFoodItemHandler : IRequestHandler<GetAllFoodItemRequest, Result<IQueryable<FoodItemDto>>>
    {
        private readonly IFoodItemRepository _repo;
        private readonly IMapper _mapper;
        public GetAllFoodItemHandler(IFoodItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IQueryable<FoodItemDto>>> Handle(GetAllFoodItemRequest request, CancellationToken cancellationToken)
        {
            var foods = await _repo.GetAllFoodItemAsync();
            //var foodDto = foods.Select(x => new FoodItemDto
            //{
            //    Name = x.Name,
            //    Description = x.Description,
            //    Id = x.Id,
            //    Calories = x.Calories,
            //    CategoryId = x.CategoryId,
            //    Currency = x.Currency,
            //    IsAvailable = x.IsAvailable,
            //    Price = x.Price,   
            //});

            var dto = _mapper.Map<IQueryable<FoodItemDto>>(foods);
            return Result<IQueryable<FoodItemDto>>.SuccessResult(dto, "عملیات با موفقیت انجام شد.");
        }
    }
}
