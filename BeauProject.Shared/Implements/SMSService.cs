using BeauProject.Shared.Interfaces;
using BeauProject.Shared.Models.SmsKaveneghar;
using Kavenegar;
using Microsoft.Extensions.Options;

namespace BeauProject.Shared.Implements
{
    public class SMSService : ISMSService
    {
        private readonly KavenegarInfoViewModel _kavenegarInfo;
        public SMSService(IOptions<KavenegarInfoViewModel> kavenegarInfo)
        {
            _kavenegarInfo = kavenegarInfo.Value;
        }

        public async Task SendPoliceSMS(string phoneNumber, string message)
        {
            try
            {
                KavenegarApi api = new KavenegarApi(_kavenegarInfo.ApiKey);
                await api.Send(_kavenegarInfo.Sender, phoneNumber, message);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendLookupSMS(string phoneNumber, string templateName
            , string token1, string? token2 = "", string? token3 = "")
        {
            try
            {
                KavenegarApi api = new KavenegarApi(_kavenegarInfo.ApiKey);
                var result = await api.VerifyLookup(phoneNumber, token1, token2
                    , token3, templateName);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
