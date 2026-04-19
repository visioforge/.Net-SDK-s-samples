using Avalonia.Controls;
using VisioForge.Core.Types;

namespace VideoMixerMVVM.Views
{
    public partial class MainView : UserControl
    {
        public IVideoView GetVideoView()
        {
            return videoView1;
        }

        public MainView()
        {
            InitializeComponent();
        }
    }
}
