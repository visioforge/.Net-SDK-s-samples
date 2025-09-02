using System;
using System.Windows;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for StreamUrlInputWindow.xaml
    /// </summary>
    public partial class StreamUrlInputWindow : Window
    {
        public string StreamUrl { get; private set; }

        public StreamUrlInputWindow()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            string url = tbStreamUrl.Text.Trim();
            
            // Basic validation
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a stream URL.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if it's a valid URL format
            if (!url.StartsWith("rtsp://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Please enter a valid stream URL (rtsp://, http://, or https://).", 
                    "Invalid URL", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            StreamUrl = url;
            DialogResult = true;
            Close();
        }
    }
}