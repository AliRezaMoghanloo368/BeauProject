using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace BeauProject.Identity.MAUI
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "BeauProject.Identity.MAUI" };
        }
    }
}
