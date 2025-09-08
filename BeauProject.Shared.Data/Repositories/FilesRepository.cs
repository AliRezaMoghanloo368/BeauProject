using BeauProject.Shared.Data.Context;
using BeauProject.Shared.Domain.Interfaces;
using BeauProject.Shared.Domain.Models;
using BeauProject.Shared.Implements;
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
    }
}
