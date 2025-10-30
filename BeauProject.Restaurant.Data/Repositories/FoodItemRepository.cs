using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Repositories
{
    public class FoodItemRepository : GenericRepository<FoodItem>, IFoodItemRepository
    {
        private readonly RestaurantContext _ctx;
        public FoodItemRepository(RestaurantContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<FoodItem?> GetFoodItemAsync(long id)
        {
            return await _ctx.FoodItems.Include(f => f.AddonOptions)
                                       .Include(f => f.Category)
                                       .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IQueryable<FoodItem?>> GetAllFoodItem()
        {
            IQueryable<FoodItem?> result = null!;
            await Task.Run(() =>
            {
                result = _ctx.FoodItems.Include(f => f.AddonOptions)
                                       .Include(f => f.Category)
                                       .AsQueryable().AsNoTracking();
            });
            return result;
        }
    }
}
