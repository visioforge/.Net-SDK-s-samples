using System;
using System.Globalization;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.GST.Output;

namespace Video_Join_Demo
{
    using System.IO;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.MediaInfoGST;
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

        private static string GetFileExt(string filename)
        {
            int k = filename.LastIndexOf('.');
            return filename.Substring(k, filename.Length - k);
        }

        private void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = OpenDialog1.FileName;

                // if resolution and output format not set we should set it the same as in added file
                MediaInfoGST mediaInfo = null;
                if (cbResize.Checked)
                {
                    VideoEdit1.Output_VideoSize = new System.Drawing.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }
                else
                {
                    mediaInfo = new MediaInfoGST();
                    if (mediaInfo.Open(filename) && mediaInfo.Info.VideoStreams.Count > 0)
                    {
                        VideoEdit1.Output_VideoSize = new System.Drawing.Size(mediaInfo.Info.VideoStreams[0].Width, mediaInfo.Info.VideoStreams[0].Height);
                    }
                }

                var frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture);
                if (frameRate == 0)
                {
                    if (mediaInfo == null)
                    {
                        mediaInfo = new MediaInfoGST();
                        mediaInfo.Open(filename);
                    }

                    if (mediaInfo.Info.VideoStreams.Count > 0)
                    {
                        VideoEdit1.Output_VideoFrameRate = mediaInfo.Info.VideoStreams[0].FrameRate;
                    }
                }
                else
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                lbFiles.Items.Add(filename);

                if ((string.Compare(GetFileExt(filename), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".PNG", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    VideoEdit1.Input_AddImageFile(filename, TimeSpan.FromMilliseconds(2000));
                }
                else if ((string.Compare(GetFileExt(filename), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(filename), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
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

        private void cbOutputVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                        break;
                    }

                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a");
                        break;
                    }
                case 7:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma");
                        break;
                    }
                case 8:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac");
                        break;
                    }
                case 10:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 11:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 12:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 13:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 14:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 15:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 16:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 17:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 18:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.Checked;
            VideoEdit1.Debug_Telemetry = cbTelemetry.Checked;

            mmLog.Clear();

            VideoEdit1.Output_Filename = edOutput.Text;

            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                    {
                        var mp4Output = new MP4Output();
                        VideoEdit1.Output_Format = mp4Output;
                        break;
                    }
                case 1:
                    {
                        var webmOutput = new WebMOutput();
                        VideoEdit1.Output_Format = webmOutput;
                        break;
                    }
                case 2:
                    {
                        var aviOutput = new AVIOutput();
                        VideoEdit1.Output_Format = aviOutput;
                        break;
                    }
                case 3:
                    {
                        var mkvOutput = new MKVOutput();
                        VideoEdit1.Output_Format = mkvOutput;
                        break;
                    }
                case 4:
                    {
                        var wmvOutput = new WMV1Output();
                        VideoEdit1.Output_Format = wmvOutput;
                        break;
                    }
                case 5:
                    {
                        var dvOutput = new DVOutput();
                        VideoEdit1.Output_Format = dvOutput;
                        break;
                    }
                case 6:
                    {
                        var acmOutput = new WAVOutput();
                        VideoEdit1.Output_Format = acmOutput;
                        break;
                    }
                case 7:
                    {
                        var mp3Output = new MP3Output();
                        VideoEdit1.Output_Format = mp3Output;
                        break;
                    }
                case 8:
                    {
                        var m4aOutput = new M4AOutput();
                        VideoEdit1.Output_Format = m4aOutput;
                        break;
                    }
                case 9:
                    {
                        var wmaOutput = new WMA1Output();
                        VideoEdit1.Output_Format = wmaOutput;
                        break;
                    }
                case 10:
                    {
                        var oggVorbisOutput = new OGGVorbisOutput();
                        VideoEdit1.Output_Format = oggVorbisOutput;
                        break;
                    }
                case 11:
                    {
                        var flacOutput = new FLACOutput();
                        VideoEdit1.Output_Format = flacOutput;
                        break;
                    }
                case 12:
                    {
                        var speexOutput = new SpeexOutput();
                        VideoEdit1.Output_Format = speexOutput;
                        break;
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
                                   }));

            if (e.Successful)
            {
                MessageBox.Show("Completed successfully", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Stopped with error", string.Empty, MessageBoxButtons.OK);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
