using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Repositories
{
    public class ModifierGroupRepository : GenericRepository<ModifierGroup>, IModifierGroupRepository
    {
        private readonly RestaurantContext _ctx;
        public ModifierGroupRepository(RestaurantContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<ModifierGroup?> GetModifierGroupByIdAsync(long id)
        {
            return await _ctx.ModifierGroups.Include(f => f.Modifiers)
                                            .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IQueryable<ModifierGroup?>> GetAllModifierGroupAsync()
        {
            IQueryable<ModifierGroup?> result = null!;
            await Task.Run(() =>
            {
                result = _ctx.ModifierGroups.Include(f => f.Modifiers)
                                            .AsQueryable()
                                            .AsNoTracking();
            });
            return result;
        }
    }
}
