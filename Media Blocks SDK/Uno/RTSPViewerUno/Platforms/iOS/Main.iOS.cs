using UIKit;
using Uno.UI.Hosting;

namespace RTSPViewerUno.Template.iOS;

public class EntryPoint
{
    // Entry point for iOS build.
        /// <summary>
        /// Main.
        /// </summary>
    public static void Main(string[] args)
    {
        App.InitializeLogging();

        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseAppleUIKit()
            .Build();

        host.Run();
    }
}
