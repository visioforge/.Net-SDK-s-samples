using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core.VideoEncryption;

namespace Encrypted_Memory_Playback_Demo
{
    public partial class EncDecForm : Form
    {
        private EncryptionProgressCallback _progressCallback;

        private const string _iv = "1234567890123456";
        private byte[] _ivBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

        public EncDecForm()
        {
            InitializeComponent();
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edSourceFile.Text = openFileDialog1.FileName;
            }
        }

        private void btSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edDestFile.Text = saveFileDialog1.FileName;
            }
        }

        private void EncDecForm_Load(object sender, EventArgs e)
        {
            _progressCallback = new EncryptionProgressCallback(OnProgress);
        }

        private void OnProgress(int progress)
        {
            Invoke((Action)(() =>
            {
                pbProgress.Value = progress;
            }));
        }

        private async void btEncrypt_Click(object sender, EventArgs e)
        {
            await VideoEncryptor.EncryptAsync(edSourceFile.Text, edDestFile.Text, edKey.Text, _ivBytes, _progressCallback);

            pbProgress.Value = 0;

            MessageBox.Show("Complete");
        }

        private async void btDecrypt_Click(object sender, EventArgs e)
        {
            await VideoDecryptor.DecryptAsync(edSourceFile.Text, edDestFile.Text, edKey.Text, _ivBytes, _progressCallback);

            pbProgress.Value = 0;

            MessageBox.Show("Complete");
        }
    }
}
