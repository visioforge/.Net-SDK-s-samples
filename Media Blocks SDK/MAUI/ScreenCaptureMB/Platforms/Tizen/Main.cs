using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace ScreenCaptureMB
{
    internal class Program : MauiApplication
    {
        /// <summary>
        /// Create maui app.
        /// </summary>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /// <summary>
        /// Main.
        /// </summary>
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
