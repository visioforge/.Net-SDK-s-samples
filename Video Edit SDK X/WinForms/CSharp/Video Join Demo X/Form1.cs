namespace Video_Join_Demo
{
    using System.IO;
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    using VisioForge.Core.Types;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.VideoEditX;

    public partial class Form1 : Form
    {
        private VideoEditCoreX VideoEdit1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        private void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = OpenDialog1.FileName;

                if (cbResize.Checked)
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                lbFiles.Items.Add(filename);

                if (FilenameHelper.IsImageFile(filename))
                {
                    VideoEdit1.Input_AddImageFile(filename, TimeSpan.FromMilliseconds(2000));
                }
                else if (FilenameHelper.IsAudioFile(filename))
                {
                    VideoEdit1.Input_AddAudioFile(filename);
                }
                else
                {
                    VideoEdit1.Input_AddAudioVideoFile(filename);
                }
            }
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.Checked;
            VideoEdit1.Debug_Telemetry = cbTelemetry.Checked;

            mmLog.Clear();

            if (rbPreview.Checked)
            {
                VideoEdit1.Output_Format = null;
            }
            else
            {
                switch (cbOutputVideoFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp4Output;
                            break;
                        }
                    case 1:
                        {
                            var webmOutput = new WebMOutput(edOutput.Text);
                            VideoEdit1.Output_Format = webmOutput;
                            break;
                        }
                    case 2:
                        {
                            var aviOutput = new AVIOutput(edOutput.Text);
                            VideoEdit1.Output_Format = aviOutput;
                            break;
                        }
                    case 3:
                        {
                            var mkvOutput = new MKVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = mkvOutput;
                            break;
                        }
                    case 4:
                        {
                            var wmvOutput = new WMVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmvOutput;
                            break;
                        }
                    case 5:
                        {
                            var dvOutput = new DVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = dvOutput;
                            break;
                        }
                    case 6:
                        {
                            var acmOutput = new WAVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = acmOutput;
                            break;
                        }
                    case 7:
                        {
                            var mp3Output = new MP3Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp3Output;
                            break;
                        }
                    case 8:
                        {
                            var m4aOutput = new M4AOutput(edOutput.Text);
                            VideoEdit1.Output_Format = m4aOutput;
                            break;
                        }
                    case 9:
                        {
                            var wmaOutput = new WMAOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmaOutput;
                            break;
                        }
                    case 10:
                        {
                            var oggVorbisOutput = new OGGVorbisOutput(edOutput.Text);
                            VideoEdit1.Output_Format = oggVorbisOutput;
                            break;
                        }
                    case 11:
                        {
                            var flacOutput = new FLACOutput(edOutput.Text);
                            VideoEdit1.Output_Format = flacOutput;
                            break;
                        }
                    case 12:
                        {
                            var speexOutput = new SpeexOutput(edOutput.Text);
                            VideoEdit1.Output_Format = speexOutput;
                            break;
                        }
                }
            }

            VideoEdit1.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            VideoEdit1.Stop();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
                                   }));
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() => { ProgressBar1.Value = e.Progress; }));
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       ProgressBar1.Value = 0;
                                       lbFiles.Items.Clear();

                                         if (e.Successful)
            {
                MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButtons.OK);
            }
                                   }));          
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Text += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();

            VisioForgeX.DestroySDK();
        }
    }
}
