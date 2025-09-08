using AutoMapper;
using BeauProject.Shared.Application.DTOs.Files;
using BeauProject.Shared.Domain.Models;

namespace BeauProject.Shared.Application.Profilers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Files, CreateFilesDto>().ReverseMap();
            CreateMap<Files, UpdateFilesDto>().ReverseMap();
        }
    }
}
