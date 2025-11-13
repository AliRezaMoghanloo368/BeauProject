using AutoMapper;
using BeauProject.Accounting.Domain.Models;

namespace BeauProject.Accounting.Application.Profilers
{
    public class AccountGroupProfile : Profile
    {
        public AccountGroupProfile()
        {
            CreateMap<AccountGroup, AccountGroupDto>().ReverseMap();
            CreateMap<AccountGroup, CreateAccountGroupCommand>().ReverseMap();
        }
    }
}
