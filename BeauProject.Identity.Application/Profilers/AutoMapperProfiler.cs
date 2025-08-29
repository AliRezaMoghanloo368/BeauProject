using AutoMapper;
using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Identity.Domain.Models;

namespace BeauProject.Identity.Application.Profilers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
