﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace HTTP_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private HTTPSourceBlock _source;

        private DecodeBinBlock _demuxer;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            //_pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var settings = new HTTPSourceSettings(new Uri(edURL.Text))
            {
                UserID = edUserName.Text,
                UserPassword = edPassword.Text
            };

            // You can add custom headers using the following code:
            // settings.ExtraHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

            _source = new HTTPSourceBlock(settings);
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            _demuxer = new DecodeBinBlock(renderAudio: false);

            _pipeline.Connect(_source.Output, _demuxer.Input);
            _pipeline.Connect(_demuxer.VideoOutput, _videoRenderer.Input);

            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await DestroyEngineAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
