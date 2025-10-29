using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Domain.Interfaces;

namespace BeauProject.Restaurant.Domain.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        //Task<Branch?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<Branch?> GetByCodeAsync(string code);
    }
}
