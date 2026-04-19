using Avalonia.Controls;
using VideoMixerMVVM.ViewModels;
using VisioForge.Core.Types;
using System;

namespace VideoMixerMVVM.Views
{
    public partial class MainWindow : Window
    {
        private bool _cleanupDone;

        public IVideoView GetVideoView()
        {
            return (Content as MainView).GetVideoView();
        }

        public MainWindow()
        {
            InitializeComponent();

            Loaded += async (sender, e) =>
            {
                if (DataContext is MainViewModel viewModel)
                {
                    await viewModel.InitAsync();
                }
            };

            Closing += async (sender, e) =>
            {
                if (_cleanupDone)
                    return;

                _cleanupDone = true;
                e.Cancel = true;

                if (DataContext is MainViewModel viewModel)
                {
                    try
                    {
                        await viewModel.StopAndCleanupAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Cleanup error: {ex.Message}");
                    }
                }

                Close();
            };
        }
    }
}
