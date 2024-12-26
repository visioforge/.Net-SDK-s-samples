using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core.LiveVideoCompositor;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace Video_Mixer_Player
{
    public partial class Form1 : Form
    {
        private LiveVideoCompositor _compositor;

        private LVCVideoViewOutput _videoRendererOutput;

        private List<LVCInput> _inputs = new List<LVCInput>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, System.EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Text += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
        }

        private void btAddFile_Click(object sender, System.EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbSourceFiles.Items.Add(openFileDialog1.FileName);
            }
        }

        private async Task AddFileSourceAsync(string filename, Rect rect)
        {
            var name = $"File [{filename}]";

            var settings = await UniversalSourceSettings.CreateAsync(filename);
            var info = settings.GetInfo();

            VideoFrameInfoX videoInfo = null;
            if (info.VideoStreams.Count > 0)
            {
                videoInfo = new VideoFrameInfoX(info.VideoStreams[0].Width, info.VideoStreams[0].Height, info.VideoStreams[0].FrameRate);
            }

            AudioInfoX audioInfo = null;
            if (info.AudioStreams.Count > 0)
            {
                audioInfo = new AudioInfoX(AudioFormatX.S16LE, info.AudioStreams[0].SampleRate, info.AudioStreams[0].Channels);
            }


            var src = new LVCVideoAudioInput(name, _compositor, new UniversalSourceBlock(settings), videoInfo, audioInfo, rect, true);
            src.Pipeline.PauseOnStop = true;

            if (await _compositor.Input_AddAsync(src))
            {
                _inputs.Add(src);
            }
            else
            {
                src.Dispose();
            }
        }

        private async Task<TimeSpan> GetSourcePositionAsync()
        {
            TimeSpan pos = TimeSpan.Zero;

            foreach (var input in _inputs)
            {
                var p = await input.Pipeline.Position_GetAsync();
                if (p > pos)
                {
                    pos = p;
                }
            }

            return pos;
        }

        private async Task<TimeSpan> GetSourceDurationAsync()
        {
            TimeSpan duration = TimeSpan.Zero;

            foreach (var input in _inputs)
            {
                var d = await input.Pipeline.DurationAsync();
                if (d > duration)
                {
                    duration = d;
                }
            }

            return duration;
        }

        private async Task SetSourcePositionAsync(TimeSpan position)
        {
            foreach (var input in _inputs)
            {
                await input.Pipeline.Position_SetAsync(position);
            }
        }

        private async void tmPosition_Tick(object sender, EventArgs e)
        {
            var position = await GetSourcePositionAsync();
            var duration = await GetSourceDurationAsync();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTimeline.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                tbTimeline.Value = (int)position.TotalSeconds;
            }
        }

        private async void btStart_Click(object sender, System.EventArgs e)
        {
            if (lbSourceFiles.Items.Count < 2)
            {
                MessageBox.Show("Please add at least 2 files.");
                return;
            }

            _compositor = new LiveVideoCompositor(new LiveVideoCompositorSettings(1920, 1080, VideoFrameRate.FPS_25));

            _compositor.OnError += (senderX, args) =>
            {
                Debug.WriteLine(args.Message);
            };

            await AddFileSourceAsync(lbSourceFiles.Items[0].ToString(), new Rect(0, 0, 1920, 1080));
            await AddFileSourceAsync(lbSourceFiles.Items[1].ToString(), new Rect(0, 0, 640, 480));

            // add video renderer
            var name = "[VideoView] Preview";
            _videoRendererOutput = new LVCVideoViewOutput(name, _compositor, videoView1, true);
            await _compositor.Output_AddAsync(_videoRendererOutput);

            await _compositor.StartAsync();

            tmPosition.Start();
        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            await SetSourcePositionAsync(TimeSpan.FromSeconds(tbTimeline.Value));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
