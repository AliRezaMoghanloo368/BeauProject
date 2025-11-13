using BeauProject.Accounting.Data.Context;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Data.Repositories;

namespace BeauProject.Accounting.Data.Repositories
{
    public class AccountGroupRepository : GenericRepository<AccountGroup>, IAccountGroupRepository
    {
        private readonly AccountingContext _ctx;
        public AccountGroupRepository(AccountingContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
