using BeauProject.Shared.Patterns.ResultPattern;

namespace BeauProject.CRM.Application.Interfaces
{
    public interface ISPService
    {
        Task<Result<List<Dictionary<string, object>>>> Function();
    }
}
