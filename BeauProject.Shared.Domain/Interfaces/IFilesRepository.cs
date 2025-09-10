using BeauProject.Shared.Domain.Models;
using BeauProject.Shared.Interfaces;

namespace BeauProject.Shared.Domain.Interfaces
{
    public interface IFilesRepository : IGenericRepository<Files>
    {
        Task<List<Files>> GetFilesAsync(string entityName, string entityId);
    }
}
