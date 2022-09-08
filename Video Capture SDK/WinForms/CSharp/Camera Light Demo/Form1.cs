using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisioForge.Core.VideoCapture;
using VisioForge.Core.WindowsExtensions;

namespace Camera_Light_Demo
{
    public partial class Form1 : Form
    {
        private VideoCaptureCore VideoCapture1 = new VideoCaptureCore();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private async void btTurnOn_Click(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_LightAsync(true);
        }

        private async void btTurnOff_Click(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_LightAsync(false);
        }
    }
}
