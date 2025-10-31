using BeauProject.Restaurant.Domain.Models.Menu;
using BeauProject.Shared.Domain.Interfaces;

namespace BeauProject.Restaurant.Domain.Interfaces
{
    public interface IModifierGroupRepository : IGenericRepository<ModifierGroup>
    {
        Task<ModifierGroup?> GetModifierGroupByIdAsync(long id);
        Task<IQueryable<ModifierGroup?>> GetAllModifierGroupAsync();
    }
}
