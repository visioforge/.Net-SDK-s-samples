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
using System.Diagnostics;

namespace Encrypted_Memory_Playback_Demo
{
    /// <summary>
    /// EncDec demo form.
    /// </summary>
    public partial class EncDecForm : Form
    {
        /// <summary>
        /// The progress callback.
        /// </summary>
        private EncryptionProgressCallback _progressCallback;

        /// <summary>
        /// The initialization vector string.
        /// </summary>
        // WARNING: This IV is hardcoded for demonstration purposes only.
        // In production, use a cryptographically random IV for each encryption operation.
        private const string _iv = "1234567890123456";
        /// <summary>
        /// The initialization vector bytes.
        /// </summary>
        private byte[] _ivBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

        /// <summary>
        /// Initializes a new instance of the <see cref="EncDecForm"/> class.
        /// </summary>
        public EncDecForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edSourceFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt save file click event.
        /// </summary>
        private void btSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edDestFile.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the enc dec form load event.
        /// </summary>
        private void EncDecForm_Load(object sender, EventArgs e)
        {
            _progressCallback = new EncryptionProgressCallback(OnProgress);
        }

        /// <summary>
        /// On progress.
        /// </summary>
        private void OnProgress(int progress)
        {
            Invoke((Action)(() =>
            {
                pbProgress.Value = progress;
            }));
        }

        /// <summary>
        /// Handles the bt encrypt click event.
        /// </summary>
        private async void btEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                await VideoEncryptor.EncryptAsync(edSourceFile.Text, edDestFile.Text, edKey.Text, _ivBytes, _progressCallback);

                pbProgress.Value = 0;

                MessageBox.Show(this, "Complete");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt decrypt click event.
        /// </summary>
        private async void btDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                await VideoDecryptor.DecryptAsync(edSourceFile.Text, edDestFile.Text, edKey.Text, _ivBytes, _progressCallback);

                pbProgress.Value = 0;

                MessageBox.Show(this, "Complete");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
