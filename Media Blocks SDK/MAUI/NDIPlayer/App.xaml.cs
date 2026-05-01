using System.Diagnostics;
using VisioForge.Core;

namespace NDIPlayer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = new Window(new AppShell());
            window.Destroying += Window_Destroying;
            return window;
        }

        private static async void Window_Destroying(object sender, EventArgs e)
        {
            try
            {
                if (sender is Window window)
                {
                    await ShutdownPageAsync(window.Page);
                    return;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during app cleanup: {ex.Message}");
            }
        }

        private static async Task ShutdownPageAsync(Page page)
        {
            if (page is MainPage mainPage)
            {
                await mainPage.ShutdownAsync();
                return;
            }

            if (page is Shell shell && shell.CurrentPage is MainPage shellMainPage)
            {
                await shellMainPage.ShutdownAsync();
                return;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
