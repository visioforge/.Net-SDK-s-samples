using Uno.UI.Hosting;

namespace VideoCaptureUnoX;

internal class Program
{
    [STAThread]
        /// <summary>
        /// Main.
        /// </summary>
    public static void Main(string[] args)
    {
        App.InitializeLogging();

        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseX11()
            .UseLinuxFrameBuffer()
            .UseMacOS()
            .UseWin32()
            .Build();

        host.Run();
    }
}
