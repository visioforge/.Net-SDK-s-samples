using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using VisioForge.VirtualCamera;

namespace Virtual_Camera_Push_Demo
{
    public partial class MainWindow : Window
    {
        private const int FrameWidth = 1280;
        private const int FrameHeight = 720;
        private const int FrameRate = 30;
        private const int SampleRate = 48000;
        private const int Channels = 2;

        // CLSIDs of the virtual camera and virtual audio card source filters.
        private const string VideoFilterClsid = "{AA4DA14E-644B-487A-A7CB-517A390B4BB8}";
        private const string AudioFilterClsid = "{B5A463DF-4016-4C34-AA4F-48EC1B51C73F}";

        private static readonly Brush FrameBackground = new LinearGradientBrush(Color.FromRgb(20, 40, 90), Color.FromRgb(140, 198, 63), 0);
        private static readonly Typeface Font = new Typeface("Segoe UI");

        private readonly RenderTargetBitmap _canvas = new RenderTargetBitmap(FrameWidth, FrameHeight, 96, 96, PixelFormats.Pbgra32);
        private readonly byte[] _pixels = new byte[FrameWidth * FrameHeight * 4];
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / FrameRate) };
        private readonly Stopwatch _clock = new Stopwatch();

        private VirtualVideoWriter _video;
        private VirtualAudioWriter _audio;
        private long _samplesSent;
        private double _phase;

        public MainWindow()
        {
            InitializeComponent();
            imgPreview.Source = _canvas;
            _timer.Tick += Timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRegistrationStatus();
        }

        private void UpdateRegistrationStatus()
        {
            bool registered = IsRegistered(VideoFilterClsid) && IsRegistered(AudioFilterClsid);
            statusIndicator.Fill = registered ? Brushes.LimeGreen : Brushes.OrangeRed;
            lbRegistrationStatus.Text = registered ? "Registered" : "Not registered";
            btRegister.IsEnabled = !registered;
        }

        private static bool IsRegistered(string clsid)
        {
            using var key = Registry.ClassesRoot.OpenSubKey($@"CLSID\{clsid}\InprocServer32");
            return key != null;
        }

        private async void btRegister_Click(object sender, RoutedEventArgs e)
        {
            // The filters come with the Redist.VirtualCamera package; registering them needs one UAC prompt.
            var dir = AppContext.BaseDirectory;
            var args = $"/s \"{Path.Combine(dir, "VisioForge_Virtual_Camera_x64.ax")}\" \"{Path.Combine(dir, "VisioForge_Virtual_Audio_Card_x64.ax")}\"";
            var info = new ProcessStartInfo(Path.Combine(Environment.SystemDirectory, "regsvr32.exe"), args)
            {
                UseShellExecute = true,
                Verb = "runas",
            };

            try
            {
                using var process = Process.Start(info);
                await process.WaitForExitAsync();
                if (process.ExitCode != 0)
                {
                    lbStatus.Text = $"regsvr32 failed with exit code {process.ExitCode}.";
                }
            }
            catch (Win32Exception)
            {
                lbStatus.Text = "Registration cancelled.";
            }

            UpdateRegistrationStatus();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            string licenseKey = string.IsNullOrWhiteSpace(edLicenseKey.Text) ? null : edLicenseKey.Text.Trim();

            try
            {
                _video = new VirtualVideoWriter(FrameWidth, FrameHeight, FrameRate, "VideoStream1", null, licenseKey);
                _audio = new VirtualAudioWriter(SampleRate, Channels, 16, "AudioStream1", null);
                _video.Start();
                _audio.Start();
            }
            catch (Exception ex)
            {
                StopStreaming();
                lbStatus.Text = $"Cannot start: {ex.Message}";
                return;
            }

            _samplesSent = 0;
            _clock.Restart();
            _timer.Start();

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            StopStreaming();
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            StopStreaming();
        }

        private void StopStreaming()
        {
            _timer.Stop();
            _video?.Dispose();
            _audio?.Dispose();
            _video = null;
            _audio = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DrawFrame(_clock.Elapsed.TotalSeconds);

            try
            {
                // A WPF bitmap is BGRA, top row first: pushed as it is.
                _canvas.CopyPixels(_pixels, FrameWidth * 4, 0);
                _video.PushFrameBgra(_pixels, FrameWidth * 4);

                PushTone();
            }
            catch (Exception ex)
            {
                // E.g. VisioForge_MFPX64.dll (Redist.Shared) is missing.
                btStop_Click(this, null);
                lbStatus.Text = $"Streaming stopped: {ex.Message}";
                return;
            }

            lbStatus.Text = $"Streaming: {_video.FrameCount} frames, {_audio.BytesWritten / 1024} KB of audio.";
        }

        private void DrawFrame(double seconds)
        {
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(FrameBackground, null, new Rect(0, 0, FrameWidth, FrameHeight));

                double x = 120 + (Math.Sin(seconds) + 1) / 2 * (FrameWidth - 240);
                dc.DrawEllipse(Brushes.White, null, new Point(x, FrameHeight / 2.0), 80, 80);

                var text = new FormattedText(DateTime.Now.ToString("HH:mm:ss.f"), CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight, Font, 72, Brushes.White, 1.0);
                dc.DrawText(text, new Point(40, 40));
            }

            _canvas.Clear();
            _canvas.Render(visual);
        }

        // A 440 Hz tone for the virtual microphone, as many samples as the clock says are due
        // (at most one second, the size of one audio buffer).
        private void PushTone()
        {
            long due = (long)(_clock.Elapsed.TotalSeconds * SampleRate);
            int count = (int)Math.Min(due - _samplesSent, SampleRate);
            if (count <= 0)
            {
                return;
            }

            var pcm = new byte[count * Channels * 2];
            double phase = _phase;
            for (int i = 0; i < count; i++)
            {
                short sample = (short)(Math.Sin(phase) * 3000);
                phase = (phase + 2 * Math.PI * 440 / SampleRate) % (2 * Math.PI);
                for (int c = 0; c < Channels; c++)
                {
                    BitConverter.TryWriteBytes(pcm.AsSpan((i * Channels + c) * 2), sample);
                }
            }

            // Not written: the same samples are pushed again on the next tick.
            if (_audio.PushSamples(pcm))
            {
                _samplesSent += count;
                _phase = phase;
            }
        }
    }
}
