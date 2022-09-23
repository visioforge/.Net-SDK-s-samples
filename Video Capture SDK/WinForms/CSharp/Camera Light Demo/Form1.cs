using System;
using System.Windows.Forms;

using VisioForge.Core.VideoCapture;
using VisioForge.Core.WindowsExtensions;

namespace Camera_Light_Demo
{
    public partial class Form1 : Form
    {
        private VideoCaptureCore VideoCapture1 = new VideoCaptureCore();

        private string[] _devices;

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
            if (_devices.Length > 0)
            {
                await VideoCapture1.TorchControl_EnableAsync(_devices[0], true);
            }
        }

        private async void btTurnOff_Click(object sender, EventArgs e)
        {
            if (_devices.Length > 0)
            {
                await VideoCapture1.TorchControl_EnableAsync(_devices[0], false);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _devices = await VideoCapture1.TorchControl_GetDevicesAsync();
            lbDeviceCount.Text = $"Devices found: {_devices.Length}.";
        }
    }
}
