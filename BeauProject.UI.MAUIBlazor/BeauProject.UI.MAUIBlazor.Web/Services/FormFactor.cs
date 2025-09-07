using BeauProject.UI.MAUIBlazor.Shared.Services;

namespace BeauProject.UI.MAUIBlazor.Web.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Web";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
