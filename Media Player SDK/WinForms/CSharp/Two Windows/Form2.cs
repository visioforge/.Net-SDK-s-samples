

namespace Two_Windows_Demo
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Form2 class.
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// Gets the debug mode.
        /// </summary>
        public bool Debug_Mode
        {
            get
            {
                return cbDebugMode.Checked;
            }
        }

        /// <summary>
        /// Gets the screen.
        /// </summary>
        public Control Screen
        {
            get
            {
                return pnScreen;
            }
        }

        /// <summary>
        /// Occurs when [on window size changed].
        /// </summary>
        public event EventHandler<EventArgs> OnWindowSizeChanged;

        /// <summary>
        /// Logs the license.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogLicense(string message)
        {
            if (cbLicensing.Checked)
            {
                mmError.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + message + Environment.NewLine;
            }
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(string message)
        {
            mmError.Text = mmError.Text + message + Environment.NewLine;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form2"/> class.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form 2 load event.
        /// </summary>
        private void Form2_Load(object sender, EventArgs e)
        {
            mmError.Clear();
        }

        /// <summary>
        /// Handles the form 2 size changed event.
        /// </summary>
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            OnWindowSizeChanged?.Invoke(this, new EventArgs());
        }
    }
}


