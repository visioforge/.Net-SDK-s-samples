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
using VisioForge.Core.ONVIFX;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class ONVIFDiscovery : Form
    {
        private ONVIFDiscoveryX _onvifDiscoveryX = new ONVIFDiscoveryX();

        public ONVIFDiscovery()
        {
            InitializeComponent();
        }

        private async void btSearch_Click(object sender, EventArgs e)
        {
            cbSources.Items.Clear();

            _onvifDiscoveryX.OnDeviceFound += async (senderx, args) =>
            {
                Invoke((Action)(() =>
                {
                    cbSources.Items.Add(args.Address);

                    if (cbSources.Items.Count == 1)
                    {
                        cbSources.SelectedIndex = 0;
                    }
                }));
            };
            _onvifDiscoveryX.Start();
        }

        private async void btReadProfiles_Click(object sender, EventArgs e)
        {
            var onvifDevice = new ONVIFDeviceX();
            var result = await onvifDevice.ConnectAsync(cbSources.Text, edUsername.Text, edPassword.Text);
            if (!result)
            {
                MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                return;
            }

            Debug.WriteLine($"Name {onvifDevice.Model}, s/n {onvifDevice.SerialNumber}");
            
            cbProfiles.Items.Clear();
            var profiles = onvifDevice.GetProfiles();
            for (int i = 0; i < profiles.Length; i++)
            {
                var url = profiles[i].RTSPUrl;
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
