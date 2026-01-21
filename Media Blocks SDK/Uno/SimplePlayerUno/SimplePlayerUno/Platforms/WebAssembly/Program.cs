namespace SimplePlayerUno.Template;

public class Program
{
    private static App? _app;

        /// <summary>
        /// Main.
        /// </summary>
    public static int Main(string[] args)
    {
        App.InitializeLogging();

        Microsoft.UI.Xaml.Application.Start(_ => _app = new App());

        return 0;
    }
}
