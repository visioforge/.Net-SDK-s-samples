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
using VisioForge.Core.ONVIFDiscovery;
using VisioForge.Core.ONVIFDiscovery.Models;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class ONVIFDiscovery : Form
    {
        private Discovery _onvifDiscovery = new Discovery();
        private CancellationTokenSource _cts;

        public ONVIFDiscovery()
        {
            InitializeComponent();
        }

        private async void btSearch_Click(object sender, EventArgs e)
        {
            cbSources.Items.Clear();

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                await _onvifDiscovery.Discover(5, (device) =>
                {
                    if (device.XAdresses?.Any() == true)
                    {
                        Invoke((Action)(() =>
                        {
                            var address = device.XAdresses.FirstOrDefault();
                            if (!string.IsNullOrEmpty(address))
                            {
                                cbSources.Items.Add(address);

                                if (cbSources.Items.Count == 1)
                                {
                                    cbSources.SelectedIndex = 0;
                                }
                            }
                        }));
                    }
                }, _cts.Token);
            }
            catch (OperationCanceledException)
            {
                // Discovery cancelled
            }
        }

        private async void btReadProfiles_Click(object sender, EventArgs e)
        {
            var onvifClient = new ONVIFClientX();
            var result = await onvifClient.ConnectAsync(cbSources.Text, edUsername.Text, edPassword.Text);
            if (!result)
            {
                MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                return;
            }

            Debug.WriteLine($"Name {onvifClient.DeviceInformation?.Model}, s/n {onvifClient.DeviceInformation?.SerialNumber}");
            
            cbProfiles.Items.Clear();
            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null)
            {
                foreach (var profile in profiles)
                {
                    var mediaUri = await onvifClient.GetStreamUriAsync(profile);
                    if (mediaUri != null && !string.IsNullOrEmpty(mediaUri.Uri))
                    {
                        cbProfiles.Items.Add(mediaUri.Uri);
                        Debug.WriteLine($"{profile.Name} {mediaUri.Uri}");
                    }
                }
            }

            if (cbProfiles.Items.Count > 0)
            {
                cbProfiles.SelectedIndex = 0;
            }
        }
    }
}
