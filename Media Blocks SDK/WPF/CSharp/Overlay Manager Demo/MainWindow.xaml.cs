﻿using System;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private UniversalSourceBlock _fileSource;

        private OverlayManagerBlock _overlayManager;

        private DeviceEnumerator _deviceEnumerator;

        public MainWindow()
        {
            InitializeComponent();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            _overlayManager = new OverlayManagerBlock();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }

        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new UniversalSourceBlock(edFilename.Text);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            //_overlayManager.Elements.Add(new OverlayManagerImage(@"c:\samples\!rgb2.png", 100, 100));
            //_overlayManager.Elements.Add(new OverlayManagerImage(@"c:\samples\!logo.png", 0, 100));
            //_overlayManager.Elements.Add(new OverlayManagerImage(@"c:\samples\!logo.png", 100, 0));
            //_overlayManager.Elements.Add(new OverlayManagerImage(@"c:\samples\!logo.png", 0, 0));

            // _overlayManager.Elements.Add(new OverlayManagerSVG(@"c:\samples\!logo.svg", 100, 200));

            //var txt = new OverlayManagerText(@"Hello world", 100, 200) { Color = SKColors.IndianRed };
            //txt.Font.Size = 72;
            //txt.Font.Style = VisioForge.Core.Types.X.VideoEffects.FontStyle.Italic;
            //_overlayManager.Elements.Add(txt);

            //_overlayManager.Elements.Add(new OverlayManagerLine());
            //_overlayManager.Elements.Add(new OverlayManagerRectangle());
            //_overlayManager.Elements.Add(new OverlayManagerTriangle());
            //_overlayManager.Elements.Add(new OverlayManagerCircle());

            //_overlayManager.Elements.Add(new OverlayManagerGIF(@"C:\samples\!anim.gif"));
            //_overlayManager.Elements.Add(new OverlayManagerImage(@"c:\samples\!rgb.png", 100, 100));

            _pipeline.Connect(_fileSource.VideoOutput, _overlayManager.Input);
            _pipeline.Connect(_overlayManager.Output, _videoRenderer.Input);

            //_pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);

            var audioOutputs = await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound);
            _audioRenderer = new AudioRendererBlock(audioOutputs[0]);
            _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    tbTimeline.Value = (int)position.TotalSeconds;
                }
            }));

            _timerFlag = false;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await CreateEngineAsync();

            //_pipeline.Loop = cbLoop.Checked;
            //_pipeline.Audio_PlayAudio = true;
            //_pipeline.Info_UseLibMediaInfo = true;
            //_pipeline.Audio_OutputDevice = "Default DirectSound Device";

            //if (FilterHelpers.Filter_Supported_EVR())
            //{
            //    _pipeline.Video_Renderer.VideoRenderer = VideoRendererMode.EVR;
            //}
            //else if (FilterHelpers.Filter_Supported_VMR9())
            //{
            //    _pipeline.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9;
            //}
            //else
            //{
            //    _pipeline.Video_Renderer.VideoRenderer = VideoRendererMode.VideoRenderer;
            //}

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            // set audio volume for each stream
            // _pipeline.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            // _pipeline.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            //var res = new GIFDecoder(@"C:\samples\!anim.gif");

            //int i = 0;
            //foreach (var frame in res.Frames)
            //{
            //    using var image = SKImage.FromBitmap(frame.Image);
            //    using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            //    using var stream = File.OpenWrite("C:\\samples\\!anim_" + i + ".png");
            //    data.SaveTo(stream);

            //    i++;
            //}

            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            tbTimeline.Value = 0;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btStop_Click(null, null);

            await DestroyEngineAsync();

            _deviceEnumerator.Dispose();
        }

        private void btAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                if (dlg.FileName.ToLowerInvariant().EndsWith(".gif"))
                {
                    _overlayManager.Elements.Add(new OverlayManagerGIF(dlg.FileName, new SkiaSharp.SKPoint(150, 150)));
                    lbOverlays.Items.Add($"[GIF] {dlg.FileName}");
                }
                else
                {
                    _overlayManager.Elements.Add(new OverlayManagerImage(dlg.FileName, 100, 100));
                    lbOverlays.Items.Add($"[Image] {dlg.FileName}");
                }
            }
        }

        private void btAddText_Click(object sender, RoutedEventArgs e)
        {
            var text = new OverlayManagerText("Hello world!", 100, 100);
            text.Color = SkiaSharp.SKColors.Red;
            text.Font.Size = 32;
            text.Font.Style = VisioForge.Core.Types.X.VideoEffects.FontStyle.Italic;
            _overlayManager.Elements.Add(text);
            lbOverlays.Items.Add($"[Text] {text.Text}");
        }

        private void btAddLine_Click(object sender, RoutedEventArgs e)
        {
            var line = new OverlayManagerLine(new SkiaSharp.SKPoint(100, 100), new SkiaSharp.SKPoint(200, 200));
            line.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Elements.Add(line);
            lbOverlays.Items.Add($"[Line] {line.Start.X}x{line.Start.Y} - {line.End.X}x{line.End.Y}");
        }

        private void btAddRectangle_Click(object sender, RoutedEventArgs e)
        {
            var rect = new OverlayManagerRectangle(new SkiaSharp.SKRect(100, 100, 200, 200));
            rect.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Elements.Add(rect);
            lbOverlays.Items.Add($"[Rectangle] {rect.Rectangle.Left}x{rect.Rectangle.Top} - {rect.Rectangle.Right}x{rect.Rectangle.Bottom}");
        }

        private void btAddCircle_Click(object sender, RoutedEventArgs e)
        {
            var circle = new OverlayManagerCircle(new SkiaSharp.SKPoint(150, 150), 50);
            circle.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Elements.Add(circle);
            lbOverlays.Items.Add($"[Circle] {circle.Center.X}x{circle.Center.Y} - {circle.Radius}");
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbOverlays.SelectedIndex != -1)
            {
                _overlayManager.Elements.RemoveAt(lbOverlays.SelectedIndex);
                lbOverlays.Items.RemoveAt(lbOverlays.SelectedIndex);
            }
        }
    }
}