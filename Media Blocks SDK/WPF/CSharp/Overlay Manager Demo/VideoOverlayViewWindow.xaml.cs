using System.Windows;
using VisioForge.Core.Types;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// External window for displaying video overlay with a VideoView control.
    /// </summary>
    public partial class VideoOverlayViewWindow : Window
    {
        /// <summary>
        /// Gets the VideoView control for rendering video overlay.
        /// </summary>
        public IVideoView VideoView => VideoViewControl;

        public VideoOverlayViewWindow(string title = "Video Overlay View")
        {
            InitializeComponent();
            Title = title;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Prevent closing - just hide the window
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Closes the window for real (used during cleanup).
        /// </summary>
        public void ForceClose()
        {
            // Remove the closing event handler to allow actual close
            Closing -= Window_Closing;
            Close();
        }
    }
}
