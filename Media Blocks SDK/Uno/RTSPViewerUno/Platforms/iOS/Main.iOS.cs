using UIKit;

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
        UIApplication.Main(args, null, typeof(App));
    }
}
