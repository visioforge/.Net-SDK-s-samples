using System;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X._Windows.VideoEffects;

namespace vr360_media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VR360ProcessorBlock _view;

        private int _x = 0;

        private int _y = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            // Create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // Add file source
            var fileSourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.Text);
            var info = fileSourceSettings.GetInfo();
            var videoStreamAvailable = info.VideoStreams.Count > 0;
            var audioStreamAvailable = info.AudioStreams.Count > 0;

            var fileSource = new UniversalSourceBlock(fileSourceSettings);

            // Add video renderer
            if (videoStreamAvailable)
            {
                _view = new VR360ProcessorBlock(new D3D11VR360RendererSettings());

                var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                _pipeline.Connect(fileSource.VideoOutput, _view.Input);
                _pipeline.Connect(_view.Output, videoRenderer.Input);
            }

            // Add audio output
            if (audioStreamAvailable)
            {
                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));
                _pipeline.Connect(fileSource, audioOutput);
            }

            // Start playback
            await _pipeline.StartAsync();

            timer1.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline.StopAsync(force: true);

            await _pipeline.DisposeAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        private void bt360Left_Click(object sender, EventArgs e)
        {
            _view.Settings.Yaw -= 5.0f;
            _view.Update();
        }

        private void bt360Right_Click(object sender, EventArgs e)
        {
            _view.Settings.Yaw += 5.0f;
            _view.Update();
        }

        private void bt360Up_Click(object sender, EventArgs e)
        {
            _view.Settings.Pitch -= 2.0f;
            _view.Update();
        }

        private void bt360Down_Click(object sender, EventArgs e)
        {
            _view.Settings.Pitch += 2.0f;
            _view.Update();
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            _view.Settings.FOV -= 5.0f;
            _view.Update();
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            _view.Settings.FOV += 5.0f;
            _view.Update();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)(await _pipeline.DurationAsync()).TotalSeconds;

            int value = (int)(await _pipeline.Position_GetAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = TimeSpan.FromSeconds(tbTimeline.Value).ToString("hh\\:mm\\:ss") + "/" + TimeSpan.FromSeconds(tbTimeline.Maximum).ToString("hh\\:mm\\:ss");

            timer1.Tag = 0;
        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void VideoView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                _x = e.X;
                _y = e.Y;
            }
        }

        private void VideoView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_view is null)
            {
                return;
            }

            if (e.Button.HasFlag(MouseButtons.Left))
            {
                _view.Settings.Yaw += (e.X - _x) * 2;
                _x = e.X;

                _view.Settings.Pitch += (e.Y - _y) * 2;
                _y = e.Y;

                _view.Update();
            }
        }
    }
}
