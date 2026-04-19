using Avalonia;
using Avalonia.ReactiveUI;
using System;

namespace VideoMixerMVVM.Desktop
{
    internal sealed class Program
    {
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .UseReactiveUI()
                .LogToTrace();
    }
}
