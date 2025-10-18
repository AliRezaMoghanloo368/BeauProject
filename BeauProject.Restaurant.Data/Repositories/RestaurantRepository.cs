using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext _ctx;

        public RestaurantRepository(RestaurantContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default)
        {
            await _ctx.Restaurants.AddAsync(restaurant, cancellationToken);
        }

        public async Task DeleteAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default)
        {
            // soft delete handled by caller
            _ctx.Restaurants.Update(restaurant);
        }

        public async Task<RestaurantEntity?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _ctx.Restaurants.FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }

        public async Task<RestaurantEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _ctx.Restaurants.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public async Task<List<RestaurantEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _ctx.Restaurants.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default)
        {
            _ctx.Restaurants.Update(restaurant);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}
