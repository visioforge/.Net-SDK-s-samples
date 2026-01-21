using UIKit;

namespace Simple_Player_MVVM.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        /// <summary>
        /// Main.
        /// </summary>
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
