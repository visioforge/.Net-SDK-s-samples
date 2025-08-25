using Microsoft.Extensions.Logging;
using DVS_MAUI.Services;

namespace DVS_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register pages
            builder.Services.AddTransient<MainPage>();

            // Register platform-specific services
#if WINDOWS
            builder.Services.AddSingleton<IFolderPicker, Platforms.Windows.FolderPickerImplementation>();
#elif MACCATALYST
            builder.Services.AddSingleton<IFolderPicker, Platforms.MacCatalyst.FolderPickerImplementation>();
#elif ANDROID
            builder.Services.AddSingleton<IFolderPicker, Platforms.Android.FolderPickerImplementation>();
#elif IOS
            builder.Services.AddSingleton<IFolderPicker, Platforms.iOS.FolderPickerImplementation>();
#endif

            return builder.Build();
        }
    }
}
