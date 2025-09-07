using BeauProject.UI.MAUI.Shared.Services;

namespace BeauProject.UI.MAUI.Web.Services
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
