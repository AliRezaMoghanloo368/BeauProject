namespace BeauProject.Shared.Application.Interfaces
{
    public interface ISMSService
    {
        Task SendPoliceSMS(string phoneNumber, string message);
        Task SendLookupSMS(string phoneNumber, string templateName, string token1, string? token2="", string? token3="");
    }
}
