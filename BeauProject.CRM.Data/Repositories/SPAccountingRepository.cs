using BeauProject.CRM.Domain.Interfaces;
using BeauProject.Identity.Data.Context;
using BeauProject.Shared.Data.Repositories;

namespace BeauProject.CRM.Data.Repositories
{
    public class SPCRMRepository : SPGenericRepository, ISPCRMRepository
    {
        private readonly CRMContext _context;
        public SPCRMRepository(CRMContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<TEntity>> ExecuteListAsync(string parameters)
        //{
        //    return await _context.Set<TEntity>()
        //        .FromSqlRaw(parameters)
        //        .ToListAsync();
        //}

        //public async Task<List<TEntity>> ExecuteListAsync(string storedProcedure, params SqlParameter[] parameters)
        //{
        //    // اطمینان از اینکه TEntity در DbContext به عنوان Keyless ثبت شده
        //    return await _context.Set<TEntity>()
        //        .FromSqlRaw(CreateSqlCommand(storedProcedure, parameters))
        //        .ToListAsync();
        //}

        //private string CreateSqlCommand(string storedProcedure, SqlParameter[] parameters)
        //{
        //    if (parameters == null || parameters.Length == 0)
        //        return $"EXEC {storedProcedure}";

        //    var paramNames = string.Join(", ", parameters.Select(p => p.ParameterName));
        //    return $"EXEC {storedProcedure} {paramNames}";
        //}
    }
}
