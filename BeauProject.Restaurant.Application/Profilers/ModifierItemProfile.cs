using AutoMapper;
using BeauProject.Restaurant.Application.DTOs.ModifierItem;
using BeauProject.Restaurant.Application.Features.ModifierItemType.Request.Command;
using BeauProject.Restaurant.Domain.Models.Menu;

namespace BeauProject.Restaurant.Application.Profilers
{
    public class ModifierItemProfile : Profile
    {
        public ModifierItemProfile()
        {
            CreateMap<ModifierItem, ModifierItemDto>().ReverseMap();
            CreateMap<ModifierItem, CreateModifierItemRequest>().ReverseMap();
        }
    }
}
