using Avalonia.Controls;
using Simple_Player_MVVM.ViewModels;
using System;
using VisioForge.Core.Types;

namespace Simple_Player_MVVM.Views
{
    /// <summary>
    /// The main window class.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Get video view.
        /// </summary>
        public IVideoView GetVideoView()
        {
            return (Content as MainView).GetVideoView();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Closing += async (sender, e) =>
            {
                if (DataContext is MainViewModel viewModel)
                {
                    viewModel.WindowClosingCommand.Execute()
                        .Subscribe(_ => { }, // No action on success
                        ex => Console.WriteLine($"Error: {ex.Message}")); // Optional error handling

                }
            };
        }
    }
}