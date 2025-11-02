using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Restaurant;
using BeauProject.Restaurant.Application.Features.RestaurantType.Request.Command;
using BeauProject.Restaurant.Domain.Models;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantEntity, CreateRestaurantCommand>().ReverseMap();
            CreateMap<RestaurantEntity, RestaurantDto>().ReverseMap();
        }
    }
}
