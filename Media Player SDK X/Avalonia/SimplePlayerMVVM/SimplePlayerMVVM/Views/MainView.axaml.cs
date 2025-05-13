using Avalonia.Controls;
using VisioForge.Core.Types;

namespace Simple_Player_MVVM.Views
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