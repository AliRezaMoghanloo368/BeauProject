using BeauProject.Shared.Domain.Models;

namespace BeauProject.Shared.Application.Interfaces
{
    public interface IFilesRepository : IGenericRepository<Files>
    {
        Task<List<Files>> GetFilesAsync(string entityName, string entityId);
    }
}
