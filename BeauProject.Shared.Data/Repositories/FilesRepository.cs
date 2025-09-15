using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Data.Context;
using BeauProject.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Shared.Data.Repositories
{
    public class FilesRepository : GenericRepository<Files>, IFilesRepository
    {
        private readonly SharedContext _context;
        public FilesRepository(SharedContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Files>> GetFilesAsync(string entityName, string entityId)
        {
            return await _context.Files
                .Where(x => x.EntityName == entityName && x.EntityId == entityId).ToListAsync();
        }
    }
}
