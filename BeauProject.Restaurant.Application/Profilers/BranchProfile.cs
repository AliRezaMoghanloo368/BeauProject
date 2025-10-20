using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch;
using BeauProject.Restaurant.Domain.Models;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDto>().ReverseMap();
        }
    }
}
