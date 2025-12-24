using UIKit;

namespace RTSPViewerUno.Template.MacCatalyst;

public class EntryPoint
{
    // Entry point for Mac Catalyst build.
    public static void Main(string[] args)
    {
        App.InitializeLogging();
        UIApplication.Main(args, null, typeof(App));
    }
}
