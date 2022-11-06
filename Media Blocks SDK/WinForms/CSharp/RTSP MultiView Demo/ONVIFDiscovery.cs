using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core.ONVIFDiscovery;
using VisioForge.Core.VideoCapture;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class ONVIFDiscovery : Form
    {
        public ONVIFDiscovery()
        {
            InitializeComponent();
        }

        private async void btSearch_Click(object sender, EventArgs e)
        {
            cbSources.Items.Clear();

            // Create a Discovery instance
            var onvifDiscovery = new Discovery();

            // Call the asynchronous method Discover with a timeout of 1 second
            var list = await onvifDiscovery.Discover(2);
            foreach (var item in list)
            {
                if (item.XAdresses.Any())
                {
                    cbSources.Items.Add(item.XAdresses.FirstOrDefault());
                }
            }

            if (cbSources.Items.Count > 0)
            {
                cbSources.SelectedIndex = 0;
            }
        }

        private async void btReadProfiles_Click(object sender, EventArgs e)
        {
            var onvifControl = new ONVIFControl();
            var result = await onvifControl.ConnectAsync(cbSources.Text, edUsername.Text, edPassword.Text);
            if (!result)
            {
                MessageBox.Show("Unable to connect to ONVIF camera.");
                return;
            }

            var deviceInfo = await onvifControl.GetDeviceInformationAsync();
            if (deviceInfo != null)
            {
                Debug.WriteLine($"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}");
            }

            cbProfiles.Items.Clear();
            var profiles = await onvifControl.GetProfilesAsync();
            for (int i = 0; i < profiles.Length; i++)
            {
                var url = await onvifControl.GetVideoURLAsync(i);
                cbProfiles.Items.Add(url);
                Debug.WriteLine($"{profiles[i].Name} {url}");
            }

            if (cbProfiles.Items.Count > 0)
            {
                cbProfiles.SelectedIndex = 0;
            }
        }
    }
}
