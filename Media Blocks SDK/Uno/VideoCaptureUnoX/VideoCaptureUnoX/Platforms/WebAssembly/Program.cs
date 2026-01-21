using Uno.UI.Hosting;

namespace VideoCaptureUnoX;

public class Program
{
        /// <summary>
        /// Main.
        /// </summary>
    public static async Task Main(string[] args)
    {
        App.InitializeLogging();

        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseWebAssembly()
            .Build();

        await host.RunAsync();
    }
}