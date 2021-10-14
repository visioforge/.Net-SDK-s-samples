using System;
using System.Windows.Forms;
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming

namespace read_file_info
{
    using VisioForge.Shared;
    using VisioForge.Tools.MediaInfo;
    using VisioForge.Types;
    using VisioForge.Tools.TagLib;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CustomRedist.ConfigureLocalRedist(out var _);
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            mmInfo.Text = string.Empty;

            string filename = openFileDialog1.FileName;
            var infoReader = new MediaInfoReader();

            // check file playable
            if (cbIsPlayable.Checked)
            {
                VFFilePlaybackError ErrorCode;
                string ErrorText;

                if (MediaInfoReader.IsFilePlayable(filename, out ErrorCode, out ErrorText))
                {
                    mmInfo.Text += "This file is playable" + Environment.NewLine;
                }
                else
                {
                    mmInfo.Text += "This file is not playable" + Environment.NewLine;
                }
            }

            // read file info
            if (cbReadInfo.Checked)
            {
                infoReader.Filename = filename;
                infoReader.ReadFileInfo(true);

                for (int i = 0; i < infoReader.Video_Streams_Count(); i++)
                {
                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Video #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + infoReader.Video_Codec(i) + Environment.NewLine;
                    mmInfo.Text += "Duration: " + infoReader.Video_Duration(i) + Environment.NewLine;
                    mmInfo.Text += "Width: " + infoReader.Video_Width(i) + Environment.NewLine;
                    mmInfo.Text += "Height: " + infoReader.Video_Height(i) + Environment.NewLine;
                    mmInfo.Text += "FOURCC: " + infoReader.Video_FourCC(i) + Environment.NewLine;
                    mmInfo.Text += "Aspect Ratio: " + infoReader.Video_AspectRatioStr(i) + Environment.NewLine;
                    mmInfo.Text += "Frame rate: " + infoReader.Video_FrameRate(i) + Environment.NewLine;
                    mmInfo.Text += "Bitrate: " + infoReader.Video_Bitrate(i) + Environment.NewLine;
                    mmInfo.Text += "Frames count: " + infoReader.Video_FramesCount(i) + Environment.NewLine;
                }

                for (int i = 0; i < infoReader.Audio_Streams_Count(); i++)
                {
                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Audio #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + infoReader.Audio_Codec(i) + Environment.NewLine;
                    mmInfo.Text += "Codec info: " + infoReader.Audio_CodecInfo(i) + Environment.NewLine;
                    mmInfo.Text += "Duration: " + infoReader.Audio_Duration(i) + Environment.NewLine;
                    mmInfo.Text += "Bitrate: " + infoReader.Audio_Bitrate(i) + Environment.NewLine;
                    mmInfo.Text += "Channels: " + infoReader.Audio_Channels(i) + Environment.NewLine;
                    mmInfo.Text += "Sample rate: " + infoReader.Audio_SampleRate(i) + Environment.NewLine;
                    mmInfo.Text += "BPS: " + infoReader.Audio_BPS(i) + Environment.NewLine;
                }

                for (int i = 0; i < infoReader.Text_Streams_Count(); i++)
                {
                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Text #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + infoReader.Text_Codec(i) + Environment.NewLine;
                    mmInfo.Text += "Name: " + infoReader.Text_Name(i) + Environment.NewLine;
                    mmInfo.Text += "Language: " + infoReader.Text_Language(i) + Environment.NewLine;
                }
            }

            // read tags
            if (cbReadTags.Checked)
            {
                var tags = VFTagLibHelper.ReadTags(filename, null);
                mmInfo.Text += tags?.ToString();
            }
        }
    }
}
