using BeauProject.Restaurant.Domain.Models;

namespace BeauProject.Restaurant.Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<RestaurantEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<RestaurantEntity?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
        Task AddAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default);
        Task UpdateAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default);
        Task DeleteAsync(RestaurantEntity restaurant, CancellationToken cancellationToken = default);
        Task<List<RestaurantEntity>> ListAllAsync(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
