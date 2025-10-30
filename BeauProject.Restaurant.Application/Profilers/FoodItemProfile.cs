using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Food;
using BeauProject.Restaurant.Application.Features.FoodItemsType.Request.Command;
using BeauProject.Restaurant.Domain.Models.Menu;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class FoodItemProfile : Profile
    {
        public FoodItemProfile()
        {
            CreateMap<FoodItem, FoodItemDto>().ReverseMap();
            CreateMap<FoodItem, CreateFoodItemRequest>().ReverseMap();
        }
    }
}
