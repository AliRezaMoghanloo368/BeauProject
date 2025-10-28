using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.Branch;
using BeauProject.Restaurant.Application.Features.BranchType.Request.Command;
using BeauProject.Restaurant.Domain.Models;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchCommand>().ReverseMap();
        }
    }
}
