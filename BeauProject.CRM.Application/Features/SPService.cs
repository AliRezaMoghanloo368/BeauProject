using BeauProject.CRM.Application.Interfaces;
using BeauProject.CRM.Domain.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;

namespace BeauProject.CRM.Application.Features
{
    public class SPService : ISPService
    {
        private readonly ISPCRMRepository _sPCRMRepository;
        public SPService(ISPCRMRepository sPCRMRepository)
        {
            _sPCRMRepository = sPCRMRepository;
        }

        #region ListAsnad
        public async Task<Result<List<Dictionary<string, object>>>> Function()
        {
            return await _sPCRMRepository.GetDataAsync("sp_name");
        }
        #endregion
    }
}
