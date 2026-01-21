using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DecklinkFillKeyDemo
{
    /// <summary>
    /// Professional broadcast lower third control with animations
    /// </summary>
    public partial class LowerThirdControl : UserControl
    {
        private DispatcherTimer _clockTimer;
        private Storyboard _slideInStoryboard;
        private Storyboard _slideOutStoryboard;
        private Storyboard _highlightStoryboard;

        public LowerThirdControl()
        {
            InitializeComponent();
            InitializeAnimations();
            InitializeClock();
        }

        /// <summary>
        /// Initialize animations.
        /// </summary>
        private void InitializeAnimations()
        {
            _slideInStoryboard = (Storyboard)Resources["SlideIn"];
            _slideOutStoryboard = (Storyboard)Resources["SlideOut"];
            _highlightStoryboard = (Storyboard)Resources["HighlightSweep"];
            
            // Set initial transform for animations
            LowerThirdContainer.RenderTransform = new System.Windows.Media.TranslateTransform();
        }

        /// <summary>
        /// Initialize clock.
        /// </summary>
        private void InitializeClock()
        {
            _clockTimer = new DispatcherTimer();
            _clockTimer.Interval = TimeSpan.FromSeconds(1);
            _clockTimer.Tick += (s, e) => UpdateClock();
            _clockTimer.Start();
        }

        /// <summary>
        /// Update clock.
        /// </summary>
        private void UpdateClock()
        {
            ClockText.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Update the title text
        /// </summary>
        public void SetTitle(string title)
        {
            TitleText.Text = title;
        }

        /// <summary>
        /// Update the subtitle text
        /// </summary>
        public void SetSubtitle(string subtitle)
        {
            SubtitleText.Text = subtitle;
        }

        /// <summary>
        /// Update the info text
        /// </summary>
        public void SetInfo(string info)
        {
            InfoText.Text = info;
        }

        /// <summary>
        /// Show the lower third with animation
        /// </summary>
        public void Show()
        {
            Visibility = Visibility.Visible;
            _slideInStoryboard?.Begin();
        }

        /// <summary>
        /// Hide the lower third with animation
        /// </summary>
        public void Hide()
        {
            _slideOutStoryboard?.Begin();
            _slideOutStoryboard.Completed += (s, e) => Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Play highlight animation
        /// </summary>
        public void Highlight()
        {
            _highlightStoryboard?.Begin();
        }

        /// <summary>
        /// Toggle live indicator visibility
        /// </summary>
        public void SetLiveIndicatorVisible(bool visible)
        {
            LiveIndicator.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Toggle clock visibility
        /// </summary>
        public void SetClockVisible(bool visible)
        {
            ClockDisplay.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Toggle network logo visibility
        /// </summary>
        public void SetNetworkLogoVisible(bool visible)
        {
            NetworkLogo.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Set network logo text
        /// </summary>
        public void SetNetworkLogoText(string text)
        {
            if (NetworkLogo.Child is TextBlock textBlock)
            {
                textBlock.Text = text;
            }
        }

        /// <summary>
        /// Clean up resources
        /// </summary>
        public void Dispose()
        {
            _clockTimer?.Stop();
            _clockTimer = null;
        }
    }
}