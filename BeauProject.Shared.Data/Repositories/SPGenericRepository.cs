using BeauProject.Shared.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BeauProject.Shared.Data.Repositories
{
    public class SPGenericRepository : ISPGenericRepository
    {
        private readonly DbContext _context;
        public SPGenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Dictionary<string, object>>>> GetDataAsync(string query)
        {
            DataTable dt = new DataTable();
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = query;
                dt.Load(await command.ExecuteReaderAsync());

                // تبدیل DataTable به List<Dictionary<string, object>> برای JSON
                var list = new List<Dictionary<string, object>>();
                foreach (DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        dict[col.ColumnName] = row[col];
                    }
                    list.Add(dict);
                }

                return Result<List<Dictionary<string, object>>>.SuccessResult(list);
            }
        }

        //public async Task<List<TEntity>> ExecuteListAsync(string parameters)
        //{
        //    return await _context.Set<TEntity>()
        //        .FromSqlRaw($"EXEC {parameters}")
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
