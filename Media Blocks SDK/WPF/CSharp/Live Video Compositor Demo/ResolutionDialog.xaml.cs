using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VisioForge.Core.LiveVideoCompositorV2;
using VisioForge.Core.Types;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for ResolutionDialog.xaml
    /// </summary>
    public partial class ResolutionDialog : Window
    {
        public int GetWidth() => Convert.ToInt32(edWidth.Text);

        public int GetHeight() => Convert.ToInt32(edHeight.Text);

        public LVCMixerType GetMixerType()
        {
            switch (cbMixerEngine.SelectedIndex)
            {
                case 0:
                    return LVCMixerType.CPU;
                case 1:
                    return LVCMixerType.D3D11;
                default:
                    return LVCMixerType.OpenGL;
            }
        }

        public VideoFrameRate GetFrameRate()
        {
            var frameRate = Convert.ToInt32(edFrameRate.Text);
            return new VideoFrameRate(frameRate);
        }

        public ResolutionDialog()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
