using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.VideoEdit;

namespace MuxStreams;

public partial class Form1 : Form
{
    private VideoEditCore videoEdit1;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        videoEdit1 = new VideoEditCore();

        // Show SDK errors in the title bar
        videoEdit1.OnError += (_, args) => BeginInvoke(() => Text = args.Message);

        edOutput.Text = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
    }

    private void btVideo_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK) edVideo.Text = openFileDialog1.FileName;
    }

    private void btAudio_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK) edAudio.Text = openFileDialog1.FileName;
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        // The first video stream of one file and the first audio stream of another
        var streams = new List<FFMPEGStream>
        {
            new FFMPEGStream { Filename = edVideo.Text, ID = "v:0" },
            new FFMPEGStream { Filename = edAudio.Text, ID = "a:0" },
        };

        btStart.Enabled = false;
        Text = "Saving...";
        try
        {
            // Copies the streams into one file as they are, without re-encoding
            var saved = await videoEdit1.FastEdit_MuxStreamsAsync(streams, cbShortest.Checked, edOutput.Text);
            if (saved) Text = "Saved: " + edOutput.Text; // on failure the title keeps the error
        }
        finally
        {
            btStart.Enabled = true;
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Let the file be finished before the window goes away
        if (!btStart.Enabled)
        {
            e.Cancel = true;
            return;
        }

        videoEdit1.Dispose();
    }
}
