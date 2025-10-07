using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;


namespace MediaBlocks_SMPTE_Effects_Demo_WPF
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

        private SMPTEBlock _smpteBlock;

        private SMPTEAlphaBlock _smpteAlphaBlock;

        private bool _isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            cbDebugMode.IsChecked = true;

            // Populate transition type combo box
            PopulateTransitionTypes();

            UpdateUI();
        }

        private void PopulateTransitionTypes()
        {
            comboTransitionType.Items.Clear();
            foreach (SMPTETransitionType transitionType in Enum.GetValues(typeof(SMPTETransitionType)))
            {
                comboTransitionType.Items.Add(new { Value = transitionType, Display = GetTransitionTypeDisplayName(transitionType) });
            }
            comboTransitionType.DisplayMemberPath = "Display";
            comboTransitionType.SelectedValuePath = "Value";
            comboTransitionType.SelectedIndex = 0; // Select first item (LeftToRight)
        }

        private string GetTransitionTypeDisplayName(SMPTETransitionType type)
        {
            switch (type)
            {
                case SMPTETransitionType.BarWipeLeftToRight: return "Bar Wipe Left to Right";
                case SMPTETransitionType.BarWipeTopToBottom: return "Bar Wipe Top to Bottom";
                case SMPTETransitionType.BoxWipeTopLeft: return "Box Wipe from Top-Left";
                case SMPTETransitionType.BoxWipeTopRight: return "Box Wipe from Top-Right";
                case SMPTETransitionType.BoxWipeBottomRight: return "Box Wipe from Bottom-Right";
                case SMPTETransitionType.BoxWipeBottomLeft: return "Box Wipe from Bottom-Left";
                case SMPTETransitionType.FourBoxWipeCornerIn: return "Four Box Wipe (Corner In)";
                case SMPTETransitionType.FourBoxWipeCornerOut: return "Four Box Wipe (Corner Out)";
                case SMPTETransitionType.BarnDoorVertical: return "Barn Door Vertical";
                case SMPTETransitionType.BarnDoorHorizontal: return "Barn Door Horizontal";
                case SMPTETransitionType.BoxWipeTopCenter: return "Box Wipe from Top Center";
                case SMPTETransitionType.BoxWipeRightCenter: return "Box Wipe from Right Center";
                case SMPTETransitionType.BoxWipeBottomCenter: return "Box Wipe from Bottom Center";
                case SMPTETransitionType.BoxWipeLeftCenter: return "Box Wipe from Left Center";
                case SMPTETransitionType.DiagonalTopLeft: return "Diagonal Top-Left";
                case SMPTETransitionType.DiagonalTopRight: return "Diagonal Top-Right";
                case SMPTETransitionType.BowtieVertical: return "Bowtie Vertical";
                case SMPTETransitionType.BowtieHorizontal: return "Bowtie Horizontal";
                case SMPTETransitionType.BarnDoorDiagonalBottomLeft: return "Barn Door Diagonal Bottom-Left";
                case SMPTETransitionType.BarnDoorDiagonalTopLeft: return "Barn Door Diagonal Top-Left";
                case SMPTETransitionType.MiscDiagonalDoubleBarnDoor: return "Diagonal Double Barn Door";
                case SMPTETransitionType.MiscDiagonalDiamond: return "Diagonal Diamond";
                case SMPTETransitionType.VeeDown: return "V-Shape Down";
                case SMPTETransitionType.VeeLeft: return "V-Shape Left";
                case SMPTETransitionType.VeeUp: return "V-Shape Up";
                case SMPTETransitionType.VeeRight: return "V-Shape Right";
                case SMPTETransitionType.BarnVeeDown: return "Barn V-Shape Down";
                case SMPTETransitionType.BarnVeeLeft: return "Barn V-Shape Left";
                case SMPTETransitionType.BarnVeeUp: return "Barn V-Shape Up";
                case SMPTETransitionType.BarnVeeRight: return "Barn V-Shape Right";
                case SMPTETransitionType.IrisRectangular: return "Iris Rectangular";
                case SMPTETransitionType.ClockwiseFrom12: return "Clock from 12 o'clock";
                case SMPTETransitionType.ClockwiseFrom3: return "Clock from 3 o'clock";
                case SMPTETransitionType.ClockwiseFrom6: return "Clock from 6 o'clock";
                case SMPTETransitionType.ClockwiseFrom9: return "Clock from 9 o'clock";
                case SMPTETransitionType.PinwheelTopBottomVertical: return "Pinwheel Top-Bottom Vertical";
                case SMPTETransitionType.PinwheelTopBottomHorizontal: return "Pinwheel Top-Bottom Horizontal";
                case SMPTETransitionType.PinwheelFourBlade: return "Pinwheel Four Blade";
                case SMPTETransitionType.FanCenterTop: return "Fan Center Top";
                case SMPTETransitionType.FanCenterRight: return "Fan Center Right";
                case SMPTETransitionType.DoubleFanFoldOutVertical: return "Double Fan Fold Out Vertical";
                case SMPTETransitionType.DoubleFanFoldOutHorizontal: return "Double Fan Fold Out Horizontal";
                case SMPTETransitionType.SingleSweepClockwiseTop: return "Single Sweep Clockwise Top";
                case SMPTETransitionType.SingleSweepClockwiseRight: return "Single Sweep Clockwise Right";
                case SMPTETransitionType.SingleSweepClockwiseBottom: return "Single Sweep Clockwise Bottom";
                case SMPTETransitionType.SingleSweepClockwiseLeft: return "Single Sweep Clockwise Left";
                case SMPTETransitionType.DoubleSweepParallelVertical: return "Double Sweep Parallel Vertical";
                case SMPTETransitionType.DoubleSweepParallelDiagonal: return "Double Sweep Parallel Diagonal";
                case SMPTETransitionType.DoubleSweepOppositeVertical: return "Double Sweep Opposite Vertical";
                case SMPTETransitionType.DoubleSweepOppositeHorizontal: return "Double Sweep Opposite Horizontal";
                case SMPTETransitionType.FanTop: return "Fan Top";
                case SMPTETransitionType.FanRight: return "Fan Right";
                case SMPTETransitionType.FanBottom: return "Fan Bottom";
                case SMPTETransitionType.FanLeft: return "Fan Left";
                case SMPTETransitionType.DoubleFanFoldInVertical: return "Double Fan Fold In Vertical";
                case SMPTETransitionType.DoubleFanFoldInHorizontal: return "Double Fan Fold In Horizontal";
                case SMPTETransitionType.SingleSweepClockwiseTopLeft: return "Single Sweep Clockwise Top-Left";
                case SMPTETransitionType.SingleSweepCounterClockwiseBottomLeft: return "Single Sweep Counter-Clockwise Bottom-Left";
                case SMPTETransitionType.SingleSweepClockwiseBottomRight: return "Single Sweep Clockwise Bottom-Right";
                case SMPTETransitionType.SingleSweepCounterClockwiseTopRight: return "Single Sweep Counter-Clockwise Top-Right";
                default: return type.ToString();
            }
        }

        private void UpdateUI()
        {
            btStart.IsEnabled = !_isPlaying;
            btStop.IsEnabled = _isPlaying;
            btPause.IsEnabled = _isPlaying;
            btResume.IsEnabled = _isPlaying;
        }

        private void AddToLog(string txt)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + txt + Environment.NewLine;

                edLog.ScrollToEnd();
            }));
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            AddToLog($"Error: {e.Message}");
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            _isPlaying = false;

            Dispatcher.Invoke((Action)(() =>
            {
                _timer.Stop();
                tbTimeline.Value = 0;
                UpdateUI();
            }));
        }

        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text), ignoreMediaInfoReader: true));

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // Create SMPTE effects
            var selectedTransitionType = (SMPTETransitionType)(comboTransitionType.SelectedValue ?? SMPTETransitionType.BarWipeLeftToRight);
            
            var smpteSettings = new SMPTEVideoEffect()
            {
                Type = selectedTransitionType,
                Border = (int)sliderBorder.Value,
                Depth = sliderDepth.Value,
                Invert = cbInvert.IsChecked ?? false
            };

            var smpteAlphaSettings = new SMPTEAlphaVideoEffect()
            {
                Type = selectedTransitionType,
                Border = (int)sliderBorder.Value,
                Position = sliderDepth.Value,
                Invert = cbInvert.IsChecked ?? false
            };

            _smpteBlock = new SMPTEBlock(smpteSettings);
            _smpteAlphaBlock = new SMPTEAlphaBlock(smpteAlphaSettings);

            // Connect pipeline based on SMPTE settings
            if (cbEnableSMPTE.IsChecked == true)
            {
                if (cbUseSMPTEAlpha.IsChecked == true)
                {
                    // Use SMPTE Alpha
                    _pipeline.Connect(_fileSource.VideoOutput, _smpteAlphaBlock.Input);
                    _pipeline.Connect(_smpteAlphaBlock.Output, _videoRenderer.Input);
                }
                else
                {
                    // Use regular SMPTE
                    _pipeline.Connect(_fileSource.VideoOutput, _smpteBlock.Input);
                    _pipeline.Connect(_smpteBlock.Output, _videoRenderer.Input);
                }
            }
            else
            {
                // Direct connection (no SMPTE effect)
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            // Audio connection (always direct)
            var audioDevices = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound);
            if (audioDevices.Any())
            {
                _audioRenderer = new AudioRendererBlock(audioDevices.First());
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_timerFlag || _pipeline == null) return;

            _timerFlag = true;

            try
            {
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
            }
            catch (Exception ex)
            {
                AddToLog($"Timer error: {ex.Message}");
            }

            _timerFlag = false;
        }

        private async Task StopEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _smpteBlock?.Dispose();
            _smpteAlphaBlock?.Dispose();
            _smpteBlock = null;
            _smpteAlphaBlock = null;
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                _pipeline.Stop(true);
                _pipeline.Dispose();
                _pipeline = null;
            }

            _smpteBlock?.Dispose();
            _smpteAlphaBlock?.Dispose();
            _smpteBlock = null;
            _smpteAlphaBlock = null;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Text = "";

            await StopEngineAsync();

            await CreateEngineAsync();

            await _pipeline.StartAsync();

            _isPlaying = true;
            _timer.Start();

            UpdateUI();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await StopEngineAsync();

            _isPlaying = false;
            _timer.Stop();

            UpdateUI();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.PauseAsync();
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.ResumeAsync();
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_timerFlag || _pipeline == null) return;

            await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
        }

        private async void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                await _audioRenderer.Volume_SetAsync(tbVolume.Value / 100.0);
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Media files|*.avi;*.mp4;*.wmv;*.mov;*.mkv;*.webm;*.mp3;*.wav;*.wma;*.ogg;*.flac|All files|*.*";

            if (dlg.ShowDialog() == true)
            {
                edFilename.Text = dlg.FileName;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
            _timer?.Dispose();

            await StopEngineAsync();
        }

        private async void cbEnableSMPTE_Changed(object sender, RoutedEventArgs e)
        {
            await RestartIfPlaying();
        }

        private async void cbUseSMPTEAlpha_Changed(object sender, RoutedEventArgs e)
        {
            await RestartIfPlaying();
        }

        private async void comboTransitionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await UpdateSMPTESettings();
        }

        private async void sliderBorder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lblBorderValue != null)
            {
                lblBorderValue.Text = ((int)sliderBorder.Value).ToString();
                await UpdateSMPTESettings();
            }
        }

        private async void sliderDepth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lblDepthValue != null)
            {
                lblDepthValue.Text = sliderDepth.Value.ToString("F2");
                await UpdateSMPTESettings();
            }
        }

        private async void cbInvert_Changed(object sender, RoutedEventArgs e)
        {
            await UpdateSMPTESettings();
        }

        private async Task UpdateSMPTESettings()
        {
            if (_smpteBlock != null && comboTransitionType.SelectedValue != null)
            {
                _smpteBlock.Settings.Type = (SMPTETransitionType)comboTransitionType.SelectedValue;
                _smpteBlock.Settings.Border = (int)sliderBorder.Value;
                _smpteBlock.Settings.Depth = sliderDepth.Value;
                _smpteBlock.Settings.Invert = cbInvert.IsChecked ?? false;
            }

            if (_smpteAlphaBlock != null && comboTransitionType.SelectedValue != null)
            {
                _smpteAlphaBlock.Settings.Type = (SMPTETransitionType)comboTransitionType.SelectedValue;
                _smpteAlphaBlock.Settings.Border = (int)sliderBorder.Value;
                _smpteAlphaBlock.Settings.Position = sliderDepth.Value;
                _smpteAlphaBlock.Settings.Invert = cbInvert.IsChecked ?? false;
            }
        }

        private async Task RestartIfPlaying()
        {
            if (_isPlaying)
            {
                await btStop_Click(null, null);
                await Task.Delay(500); // Give time for stop to complete
                await btStart_Click(null, null);
            }
        }
    }
}