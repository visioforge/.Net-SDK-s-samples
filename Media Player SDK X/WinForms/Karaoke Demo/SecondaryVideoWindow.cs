namespace Karaoke_Demo
{
    using System.Windows.Forms;
    using VisioForge.Core.UI.WinForms;

    /// <summary>
    /// Secondary window for displaying duplicate video output.
    /// </summary>
    public partial class SecondaryVideoWindow : Form
    {
        /// <summary>
        /// Gets the video view control.
        /// </summary>
        public VideoView VideoView { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryVideoWindow"/> class.
        /// </summary>
        public SecondaryVideoWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize component.
        /// </summary>
        private void InitializeComponent()
        {
            VideoView = new VideoView();
            SuspendLayout();
            // 
            // VideoView
            // 
            VideoView.BackColor = System.Drawing.Color.Black;
            VideoView.Dock = DockStyle.Fill;
            VideoView.Location = new System.Drawing.Point(0, 0);
            VideoView.Name = "VideoView";
            VideoView.StatusOverlay = null;
            VideoView.TabIndex = 0;
            // 
            // SecondaryVideoWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(VideoView);
            Name = "SecondaryVideoWindow";
            Text = "Karaoke - Secondary Display";
            FormClosing += SecondaryVideoWindow_FormClosing;
            ResumeLayout(false);
        }

        /// <summary>
        /// Secondary video window form closing.
        /// </summary>
        private void SecondaryVideoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prevent closing, just hide the window
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
