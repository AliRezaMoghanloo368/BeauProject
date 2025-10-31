using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Domain.Interfaces;

namespace BeauProject.Restaurant.Domain.Interfaces
{
    public interface IFoodItemRepository : IGenericRepository<FoodItem>
    {
        Task<FoodItem?> GetFoodItemByIdAsync(long id);
        Task<IQueryable<FoodItem?>> GetAllFoodItemAsync();
    }
}
