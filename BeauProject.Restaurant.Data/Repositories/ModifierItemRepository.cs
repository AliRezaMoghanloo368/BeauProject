using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Data.Repositories;

namespace BeauProject.Restaurant.Data.Repositories
{
    public class ModifierItemRepository : GenericRepository<ModifierItem>, IModifierItemRepository
    {
        private readonly RestaurantContext _ctx;
        public ModifierItemRepository(RestaurantContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
