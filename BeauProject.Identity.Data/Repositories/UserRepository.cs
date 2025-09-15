using BeauProject.Identity.Data.Context;
using BeauProject.Identity.Domain.Interfaces;
using BeauProject.Identity.Domain.Models;
using BeauProject.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Identity.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IdentityContext _context;
        public UserRepository(IdentityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserExist(string id)
        {
            return await _context.Users.AnyAsync(x => x.Id.ToString() == id);
        }

        public async Task<bool> CheckWithUserName(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<User> GetUserForLogin(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
        }

        public async Task<User> GetWithUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
