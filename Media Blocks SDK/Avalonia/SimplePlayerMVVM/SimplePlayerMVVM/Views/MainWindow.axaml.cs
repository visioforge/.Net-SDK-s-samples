using Avalonia.Controls;
using Simple_Player_MVVM.ViewModels;
using System;
using VisioForge.Core.Types;

namespace Simple_Player_MVVM.Views
{
    public partial class MainWindow : Window
    {
        public IVideoView GetVideoView()
        {
            return (Content as MainView).GetVideoView();
        }

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