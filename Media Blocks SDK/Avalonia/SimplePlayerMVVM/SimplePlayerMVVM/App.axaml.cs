using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Simple_Player_MVVM.ViewModels;
using Simple_Player_MVVM.Views;
using VisioForge.Core.Types;

namespace Simple_Player_MVVM
{
    /// <summary>
    /// Represents the application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// On framework initialization completed.
        /// </summary>
        public override void OnFrameworkInitializationCompleted()
        {
            IVideoView videoView = null;
            var model = new MainViewModel();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = model
                };

                videoView = (desktop.MainWindow as MainWindow).GetVideoView();
                model.VideoViewIntf = videoView;
                model.TopLevel = desktop.MainWindow;
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = model
                };

                videoView = (singleViewPlatform.MainView as MainView).GetVideoView();
                model.VideoViewIntf = videoView;
                model.TopLevel = TopLevel.GetTopLevel(singleViewPlatform.MainView);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}