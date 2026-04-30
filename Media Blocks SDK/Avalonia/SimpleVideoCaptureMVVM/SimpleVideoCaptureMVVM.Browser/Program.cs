using Avalonia;
using Avalonia.Browser;
using ReactiveUI.Avalonia;
using SimpleVideoCaptureMVVM;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
        /// <summary>
        /// Main.
        /// </summary>
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .UseReactiveUI(_ => { })
            .StartBrowserAppAsync("out");

        /// <summary>
        /// Build avalonia app.
        /// </summary>
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}