// ReSharper disable InconsistentNaming

using System;
using System.Drawing;
using System.Windows.Forms;
using VisioForge.Core.UI;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
// ReSharper disable RedundantArgumentDefaultValue

namespace Video_From_Images
{
    using System.Diagnostics;

    using VisioForge.Core.Types;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.VideoEffects;
    using System.IO;
    using VisioForge.Core.VideoEditX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.VideoEdit;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using System.Globalization;

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
                if (cbResize.Checked)
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                foreach (var s in OpenDialog1.FileNames)
                {
                    lbFiles.Items.Add(s);

                    if (FilenameHelper.IsImageFile(s))
                    {
                        VideoEdit1.Input_AddImageFile(s, TimeSpan.FromMilliseconds(2000));
                    }
                }
            }
        }

        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 7;

            cbOutputFormat.SelectedIndex = 0;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoEdit1.Debug_Mode = cbDebugMode.Checked;

            // apply capture parameters
            if (rbPreview.Checked)
            {
                VideoEdit1.Output_Filename = null;
                VideoEdit1.Output_Format = null;
            }
            else
            {
                VideoEdit1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output();
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 1:
                        {
                            var aviOutput = new AVIOutput();
                            VideoEdit1.Output_Format = aviOutput;

                            break;
                        }
                    case 2:
                        {
                            var mkvOutput = new MKVOutput();
                            VideoEdit1.Output_Format = mkvOutput;

                            break;
                        }
                    case 3:
                        {
                            var wmvOutput = new WMV1Output();
                            VideoEdit1.Output_Format = wmvOutput;

                            break;
                        }
                    case 4:
                        {
                            var webmOutput = new WebMOutput();
                            VideoEdit1.Output_Format = webmOutput;

                            break;
                        }
                }
            }

            VideoEdit1.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            VideoEdit1.Stop();
            ProgressBar1.Value = 0;

            VideoEdit1.Input_Clear_List();
            lbFiles.Items.Clear();
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

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming