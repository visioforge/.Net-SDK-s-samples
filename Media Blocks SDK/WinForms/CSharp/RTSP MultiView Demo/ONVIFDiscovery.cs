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

        /// <summary>
        /// Lists ONVIF sources.
        /// </summary>
        /// <param name="timeout">
        /// Timeout.
        /// </param>
        /// <param name="cts">
        /// Cancellation token (optional).
        /// </param>
        /// <returns>
        /// The <see cref="Uri"/>.
        /// </returns>
        private async Task<Uri[]> ListSourcesAsync(TimeSpan? timeout, CancellationTokenSource? cts)
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromSeconds(2);
            }

            var list = new List<Uri>();

            bool ctsExternal = cts != null;
            if (cts == null)
            {
                cts = new CancellationTokenSource();
            }

            var discovery = new VisioForge.Core.ONVIFDiscovery.Discovery();
            //await discovery.Discover((int)timeout.Value.TotalSeconds, (device) =>
            //{
            //    if (!device.XAdresses.Any())
            //    {
            //        return;
            //    }

            //    list.Add(new Uri(device.XAdresses.FirstOrDefault()));
            //}, cts.Token);

            var res = await discovery.Discover((int)timeout.Value.TotalSeconds, cts.Token);
            foreach (var device in res)
            {
                if (!device.XAdresses.Any())
                {
                    continue;
                }

                list.Add(new Uri(device.XAdresses.FirstOrDefault()));
            }

            if (!ctsExternal)
            {
                cts.Dispose();
            }

            return list.ToArray();
        }

        private async void btSearch_Click(object sender, EventArgs e)
        {
            cbSources.Items.Clear();

            //var list = await ListSourcesAsync(TimeSpan.FromSeconds(5), null);
            //foreach (var item in list)
            //{
            //    cbSources.Items.Add(item.ToString());
            //}

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
