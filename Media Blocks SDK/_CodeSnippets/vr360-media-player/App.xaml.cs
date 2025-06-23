using System.Windows;
using VisioForge.Core;

namespace vr360_media_player
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Initialize VisioForge SDK
            await VisioForgeX.InitSDKAsync();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Cleanup VisioForge SDK
            VisioForgeX.DestroySDK();
            
            base.OnExit(e);
        }
    }
} 