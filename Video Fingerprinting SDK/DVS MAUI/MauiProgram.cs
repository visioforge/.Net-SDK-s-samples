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

            // Register platform-specific services
#if WINDOWS
            builder.Services.AddSingleton<IFolderPicker, Platforms.Windows.FolderPickerImplementation>();
#elif MACCATALYST
            builder.Services.AddSingleton<IFolderPicker, Platforms.MacCatalyst.FolderPickerImplementation>();
#endif

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
