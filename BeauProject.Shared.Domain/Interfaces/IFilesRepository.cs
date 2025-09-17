using BeauProject.Shared.Domain.Models;

namespace BeauProject.Shared.Domain.Interfaces
{
    public interface IFilesRepository : IGenericRepository<Files>
    {
        Task<List<Files>> GetFilesAsync(string entityName, string entityId);
    }
}
