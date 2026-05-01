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
            TraceLog("CreateWindow enter");
            var window = new Window(new AppShell());
            window.Destroying += Window_Destroying;
            TraceLog("CreateWindow exit; Window.Destroying subscribed");
            return window;
        }

        private static async void Window_Destroying(object sender, EventArgs e)
        {
            TraceLog("App Window_Destroying enter");

            try
            {
                if (sender is Window window)
                {
                    TraceLog($"App Window_Destroying window.Page={window.Page?.GetType().FullName ?? "<null>"}");
                    await ShutdownPageAsync(window.Page);
                    TraceLog("App Window_Destroying page shutdown complete");
                    return;
                }

                TraceLog("App Window_Destroying sender is not Window; calling DestroySDK fallback");
                VisioForgeX.DestroySDK();
                TraceLog("App Window_Destroying DestroySDK fallback complete");
            }
            catch (Exception ex)
            {
                TraceLog($"App Window_Destroying failed: {ex}");
                Debug.WriteLine($"Error during app cleanup: {ex.Message}");
            }
            finally
            {
                TraceLog("App Window_Destroying exit");
            }
        }

        private static async Task ShutdownPageAsync(Page page)
        {
            TraceLog($"ShutdownPageAsync enter; page={page?.GetType().FullName ?? "<null>"}");

            if (page is MainPage mainPage)
            {
                TraceLog("ShutdownPageAsync found MainPage directly");
                await mainPage.ShutdownAsync();
                return;
            }

            if (page is Shell shell && shell.CurrentPage is MainPage shellMainPage)
            {
                TraceLog($"ShutdownPageAsync found Shell.CurrentPage={shell.CurrentPage.GetType().FullName}");
                await shellMainPage.ShutdownAsync();
                return;
            }

            TraceLog("ShutdownPageAsync did not find MainPage; calling DestroySDK fallback");
            VisioForgeX.DestroySDK();
            TraceLog("ShutdownPageAsync DestroySDK fallback complete");
        }

        private static void TraceLog(string message)
        {
            var line = $"[NDIPlayer][App][{DateTime.Now:O}][T{Environment.CurrentManagedThreadId}] {message}";
            Trace.WriteLine(line);
            Debug.WriteLine(line);
        }
    }
}
