using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming

namespace speaker_capture
{
    using VisioForge.Core.VideoCaptureX;
    using VisioForge.Core;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoCapture;
    using System.IO;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.Sinks;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();

            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var sink in audioSinks)
            {
                if (sink.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioLoopbackSource.Items.Add(sink.Name);

                    if (cbAudioLoopbackSource.Items.Count == 1)
                    {
                        cbAudioLoopbackSource.SelectedIndex = 0;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            _pipeline = new MediaBlocksPipeline();

            // audio input
            var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).First(device => device.Name == cbAudioLoopbackSource.Text);
            if (deviceItem == null)
            {
                return;
            }

            var audioSourceSettingd = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
            var audioSource = new SystemAudioSourceBlock(audioSourceSettingd);
                     
            // output
            var output = new M4AOutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.m4a"));

            // connect
            _pipeline.Connect(audioSource, output);

            await _pipeline.StartAsync();
        }
    }
}
