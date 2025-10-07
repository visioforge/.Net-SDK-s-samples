using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;

namespace LibVisual_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This demo shows the WPF project building with net8.0-windows target framework.
    /// LibVisual visualizers will be available when the new MediaBlocks are included in NuGet packages.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Initialize the first visualizer selection
            cbVisualizer.SelectedIndex = 0;
            
            // Subscribe to the closed event to cleanup
            this.Closed += MainWindow_Closed;
            
            UpdateStatus("Ready. LibVisual demo project builds successfully with net8.0-windows target.");
            
            // Disable functionality since LibVisual blocks are not yet in NuGet packages
            btStart.IsEnabled = false;
            cbVisualizer.IsEnabled = false;
            btSelectFile.IsEnabled = false;
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("LibVisual visualizers will be available in future NuGet package releases.");
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("LibVisual functionality not yet available - blocks are in development.");
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("LibVisual functionality not yet available - blocks are in development.");
        }

        private void btPause_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("LibVisual functionality not yet available - blocks are in development.");
        }

        private void btResume_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("LibVisual functionality not yet available - blocks are in development.");
        }

        private void UpdateStatus(string message)
        {
            tbStatus.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // Cleanup if needed
        }
    }
}