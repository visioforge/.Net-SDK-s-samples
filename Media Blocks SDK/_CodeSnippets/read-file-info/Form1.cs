using System;
using System.Windows.Forms;
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming

namespace read_file_info
{
    using VisioForge.Core;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.Types.MediaPlayer;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            mmInfo.Text = string.Empty;

            string filename = openFileDialog1.FileName;
            var infoReader = new MediaInfoReaderX();

            // read file info
            if (!(await infoReader.OpenAsync(filename)))
            {
                MessageBox.Show("Failed to read file info.");
                return;
            }

            var info = infoReader.Info;

            for (int i = 0; i < info.VideoStreams.Count; i++)
            {
                var videoStream = info.VideoStreams[i];

                mmInfo.Text += string.Empty + Environment.NewLine;
                mmInfo.Text += "Video #" + Convert.ToString(i + 1) + Environment.NewLine;
                mmInfo.Text += "Codec: " + videoStream.Codec + Environment.NewLine;
                mmInfo.Text += "Duration: " + videoStream.Duration.ToString() + Environment.NewLine;
                mmInfo.Text += "Width: " + videoStream.Width + Environment.NewLine;
                mmInfo.Text += "Height: " + videoStream.Height + Environment.NewLine;
                mmInfo.Text += "Aspect Ratio: " + $"{videoStream.AspectRatio.Item1}:{videoStream.AspectRatio.Item2}" + Environment.NewLine;
                mmInfo.Text += "Frame rate: " + videoStream.FrameRate + Environment.NewLine;
                mmInfo.Text += "Bitrate: " + videoStream.Bitrate + Environment.NewLine;
            }

            for (int i = 0; i < info.AudioStreams.Count; i++)
            {
                var audioStream = info.AudioStreams[i];

                mmInfo.Text += string.Empty + Environment.NewLine;
                mmInfo.Text += "Audio #" + Convert.ToString(i + 1) + Environment.NewLine;
                mmInfo.Text += "Codec: " + audioStream.Codec + Environment.NewLine;
                mmInfo.Text += "Duration: " + audioStream.Duration.ToString() + Environment.NewLine;
                mmInfo.Text += "Bitrate: " + audioStream.Bitrate + Environment.NewLine;
                mmInfo.Text += "Channels: " + audioStream.Channels + Environment.NewLine;
                mmInfo.Text += "Sample rate: " + audioStream.SampleRate + Environment.NewLine;
                mmInfo.Text += "BPS: " + audioStream.BPS + Environment.NewLine;
                mmInfo.Text += "Language: " + audioStream.Language + Environment.NewLine;
            }

            for (int i = 0; i < info.SubtitleStreams.Count; i++)
            {
                var textStream = info.SubtitleStreams[i];

                mmInfo.Text += string.Empty + Environment.NewLine;
                mmInfo.Text += "Text #" + Convert.ToString(i + 1) + Environment.NewLine;
                mmInfo.Text += "Codec: " + textStream.Codec + Environment.NewLine;
                mmInfo.Text += "Name: " + textStream.Name + Environment.NewLine;
                mmInfo.Text += "Language: " + textStream.Language + Environment.NewLine;
            }

            // read tags
            var tags = TagLibHelper.ReadTags(filename);
            mmInfo.Text += string.Empty + Environment.NewLine;
            mmInfo.Text += "Tags: " + Environment.NewLine;
            mmInfo.Text += tags?.ToString();
        }
    }
}
