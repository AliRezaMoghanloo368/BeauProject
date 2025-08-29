using BeauProject.Identity.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace BeauProject.Identity.Application.Interfaces
{
    public interface IJwtHandler
    {
        public string CreateToken(User user);
    }
}
