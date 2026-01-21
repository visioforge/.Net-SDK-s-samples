using System;
using System.Windows.Forms;

using VisioForge.Core.VideoCapture;
using VisioForge.Core.WindowsExtensions;

namespace Camera_Light_Demo
{
    /// <summary>
    /// Camera light demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video capture core instance.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The devices list.
        /// </summary>
        private string[] _devices;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the bt turn on click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btTurnOn_Click(object sender, EventArgs e)
        {
            if (_devices.Length > 0)
            {
                await VideoCapture1.TorchControl_EnableAsync(_devices[0], true);
            }
        }

        /// <summary>
        /// Handles the bt turn off click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btTurnOff_Click(object sender, EventArgs e)
        {
            if (_devices.Length > 0)
            {
                await VideoCapture1.TorchControl_EnableAsync(_devices[0], false);
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync();

            _devices = await VideoCapture1.TorchControl_GetDevicesAsync();
            lbDeviceCount.Text = $"Devices found: {_devices.Length}.";
        }
    }
}
