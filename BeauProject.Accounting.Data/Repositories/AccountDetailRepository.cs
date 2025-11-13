using BeauProject.Accounting.Data.Context;
using BeauProject.Accounting.Domain.Interfaces;
using BeauProject.Accounting.Domain.Models;
using BeauProject.Shared.Data.Repositories;

namespace BeauProject.Accounting.Data.Repositories
{
    public class AccountDetailRepository : GenericRepository<AccountDetail>, IAccountDetailRepository
    {
        private readonly AccountingContext _ctx;
        public AccountDetailRepository(AccountingContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
