using UIKit;

namespace RTSPViewerUno.Template.iOS;

public class EntryPoint
{
    // Entry point for iOS build.
    public static void Main(string[] args)
    {
        App.InitializeLogging();
        UIApplication.Main(args, null, typeof(App));
    }
}
