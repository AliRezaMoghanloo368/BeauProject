using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly RestaurantContext _ctx;

        public BranchRepository(RestaurantContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Branch?> GetByCodeAsync(string code)
        {
            return await _ctx.Branches.FirstOrDefaultAsync(x => x.Code == code);
        }

        //public async Task<Branch?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        //{
        //    return await _ctx.Branches.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        //}
    }
}
