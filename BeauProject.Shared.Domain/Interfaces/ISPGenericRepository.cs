using BeauProject.Shared.Patterns.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Shared.Domain.Interfaces
{
    public interface ISPGenericRepository
    {
        Task<Result<List<Dictionary<string, object>>>> GetDataAsync(string query);
    }
}
