using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Command;
using BeauProject.Restaurant.Domain.Models.Menu;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class ModifierGroupProfile : Profile
    {
        public ModifierGroupProfile()
        {
            CreateMap<ModifierGroup, ModifierGroupDto>().ReverseMap();
            CreateMap<ModifierGroup, CreateModifierGroupDto>().ReverseMap();
            CreateMap<ModifierItem, CreateModifierItemDto>().ReverseMap();
        }
    }
}
