using BeauProject.CRM.Application.Interfaces;
using BeauProject.Shared.Patterns.ResultPattern;

namespace BeauProject.CRM.Application.Features
{
    public class SPService
    {
        private readonly ISPAccountingRepository _sPAccountingRepository;
        public SPService(ISPAccountingRepository sPAccountingRepository)
        {
            _sPAccountingRepository = sPAccountingRepository;
        }

        #region ListAsnad
        public async Task<Result<List<Dictionary<string, object>>>> Function()
        {
            return await _sPAccountingRepository.GetDataAsync("sp_name");
        }
        #endregion
    }
}
