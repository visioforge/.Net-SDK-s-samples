using Avalonia.Controls;
using VisioForge.Core.Types;

namespace Simple_Player_MVVM.Views
{
    /// <summary>
    /// The main view class.
    /// </summary>
    public partial class MainView : UserControl
    {
        /// <summary>
        /// Get video view.
        /// </summary>
        public IVideoView GetVideoView()
        {
            return videoView1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }
    }
}