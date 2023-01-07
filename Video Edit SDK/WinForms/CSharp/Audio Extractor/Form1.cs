using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.VideoEdit;

namespace Audio_Extractor
{
    public partial class Form1 : Form
    {
        private VideoEditCore _core;

        public Form1()
        {
            InitializeComponent();
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFile.Text = SaveDialog1.FileName;
            }
        }

        private void btSelectInput_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                edSourceFile.Text = OpenDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp3");

            _core = new VideoEditCore();
            _core.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            _core.OnProgress += _core_OnProgress;
            _core.OnError += _core_OnError;
            _core.OnStop += _core_OnStop;
        }

        private void _core_OnStop(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                btStart.Enabled = true;
                btStop.Enabled = false;

                pbProgress.Value = 0;

                MessageBox.Show("Finished!");
            }));
        }

        private void _core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);

            Invoke(new Action(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        private void _core_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (e.Progress > 0)
                {
                    pbProgress.Value = e.Progress;
                }
            }));
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = true;

            if (rbExtract.Checked)
            {
                await _core.FastEdit_ExtractAudioStreamAsync(edSourceFile.Text, TimeSpan.Zero, TimeSpan.Zero, edOutputFile.Text);
            }
            else
            {
                await _core.Input_AddAudioFileAsync(edSourceFile.Text);

                _core.Output_Filename = edOutputFile.Text;

                if (rbReencodeMP3.Checked)
                {
                    _core.Output_Format = new MP3Output();
                }
                else if (rbReencodeM4A.Checked)
                {
                    _core.Output_Format = new M4AOutput();
                }
                
                await _core.StartAsync();
            }
        }
    }
}