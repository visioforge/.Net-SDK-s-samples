using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Controls.MediaPlayer;
using VisioForge.Controls.UI.Avalonia;
using VisioForge.Tools.MediaInfo;
using VisioForge.Types.Events;

namespace Simple_Video_Player_Avalonia
{
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _tmPosition;

        private bool _initialized;

        private MediaPlayerCore _player;

        private VideoView VideoView1;

        private Button btSelectFile;

        private TextBox edFilenameOrURL;

        private Slider tbTimeline;

        private TextBlock lbTimeline;

        private Slider tbSpeed;

        private Button btStart;

        private Button btStop;

        private Button btResume;

        private Button btPause;

        private Button btNextFrame;

        private Slider tbVolume;

        private Button btReadTags;

        private Button btReadInfo;

        private CheckBox cbDebugMode;

        private CheckBox cbPlayAudio;

        private ComboBox cbAudioOutputDevice;

        private Button btSaveSnapshot;

        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> Info { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioOutputDevices { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            InitControls();
            Activated += MainWindow_Activated;

            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ShowMessage(string message)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Message", message);

            messageBoxStandardWindow.Show(this);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            InitPlayer();

            Title += $" (SDK v{_player.SDK_Version})";
            _player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            foreach (var item in _player.Audio_OutputDevices)
            {
                AudioOutputDevices.Add(item);
            }

            if (AudioOutputDevices.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
        }

        private void InitPlayer()
        {
            _player = new MediaPlayerCore(VideoView1);
            _player.OnStop += Player_OnStop;
            _player.OnError += Player_OnError;
            _player.Video_Sample_Grabber_UseForVideoEffects = true;
        }

        private bool _tbTimelineApplyingValue;

        private void InitControls()
        {
            VideoView1 = this.FindControl<VideoView>("VideoView1");

            lbTimeline = this.FindControl<TextBlock>("lbTimeline");

            btSelectFile = this.FindControl<Button>("btSelectFile");
            btSelectFile.Click += btSelectFile_Click;

            edFilenameOrURL = this.FindControl<TextBox>("edFilenameOrURL");

            tbTimeline = this.FindControl<Slider>("tbTimeline");
            tbTimeline.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbTimeline_Scroll());

            tbSpeed = this.FindControl<Slider>("tbSpeed");
            tbSpeed.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbSpeed_Scroll());

            btStart = this.FindControl<Button>("btStart");
            btStart.Click += btStart_Click;

            btStop = this.FindControl<Button>("btStop");
            btStop.Click += btStop_Click;

            btResume = this.FindControl<Button>("btResume");
            btResume.Click += btResume_Click;

            btPause = this.FindControl<Button>("btPause");
            btPause.Click += btPause_Click;

            btNextFrame = this.FindControl<Button>("btNextFrame");
            btNextFrame.Click += btNextFrame_Click;

            tbVolume = this.FindControl<Slider>("tbVolume");
            tbVolume.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbVolume_Scroll());

            btReadTags = this.FindControl<Button>("btReadTags");
            btReadTags.Click += btReadTags_Click;

            btReadInfo = this.FindControl<Button>("btReadInfo");
            btReadInfo.Click += btReadInfo_Click;

            btSaveSnapshot = this.FindControl<Button>("btSaveSnapshot");
            btSaveSnapshot.Click += btSaveSnapshot_Click;

            cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");
            cbPlayAudio = this.FindControl<CheckBox>("cbPlayAudio");

            cbAudioOutputDevice = this.FindControl<ComboBox>("cbAudioOutputDevice");

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;
        }

        private async void btSaveSnapshot_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialFileName = "frame.jpg";
            sfd.DefaultExtension = ".jpg";

            var filter = new FileDialogFilter();
            filter.Name = "JPEG image";
            filter.Extensions.Add("jpg");
            sfd.Filters.Add(filter);

            var file = await sfd.ShowAsync(this);
            if (!string.IsNullOrEmpty(file))
            {
                _player.Frame_Save(file, ImageFormat.Jpeg);
            }
        }

        private async void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            string[] files = await ofd.ShowAsync(this);
            if (files?.Length > 0)
            {
                edFilenameOrURL.Text = files[0];
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            tbSpeed.Value = 10;
            _player.Debug_Mode = cbDebugMode.IsChecked == true;

            string source = edFilenameOrURL.Text;
            _player.FilenamesOrURL.Clear();
            _player.FilenamesOrURL.Add(source);

            _player.Audio_PlayAudio = cbPlayAudio.IsChecked == true;

            _player.Audio_OutputDevice = cbAudioOutputDevice.SelectedItem.ToString();

            _player.Play();

            _tmPosition.Start();
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            _tmPosition.Stop();

            _player.Stop();

            tbTimeline.Value = 0;
            lbTimeline.Text = "00:00:00 / 00:00:00";
        }

        private void btResume_Click(object sender, RoutedEventArgs e)
        {
            _player.Resume();
        }

        private void btPause_Click(object sender, RoutedEventArgs e)
        {
            _player.Pause();
        }

        private void btNextFrame_Click(object sender, RoutedEventArgs e)
        {
            _player.NextFrame();
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Add(e.Message);
        }

        private void Player_OnStop(object sender, StopEventArgs e)
        {
            _tmPosition.Stop();
            ShowMessage("Playback complete.");
        }

        private void tbTimeline_Scroll()
        {
            if (_tbTimelineApplyingValue)
            {
                _player?.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                var position = _player.Position_Get_Time();
                var duration = _player.Duration_Time();

                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTimeline.Text = position.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture) + " / " + duration.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    _tbTimelineApplyingValue = false;
                    tbTimeline.Value = position.TotalSeconds;
                    _tbTimelineApplyingValue = true;
                }
            }));
        }

        private void tbSpeed_Scroll()
        {
            _player?.SetSpeed(tbSpeed.Value / 10.0);
        }

        private void tbVolume_Scroll()
        {
            if (_player == null)
            {
                return;
            }

            _player.Audio_OutputDevice_Volume_Set(-1, (int)(tbVolume.Value / 100.0));
        }

        private void btReadTags_Click(object sender, RoutedEventArgs e)
        {
            var tags = _player.Tags_Read(edFilenameOrURL.Text);
            Info.Clear();
            Info.Add(tags?.ToString());
        }

        private void btReadInfo_Click(object sender, RoutedEventArgs e)
        {
            Info.Clear();

            var infoReader = new MediaInfoReader();
            infoReader.Filename = edFilenameOrURL.Text;
            infoReader.ReadFileInfo(true);

            if (infoReader.VideoStreams.Count > 0)
            {
                Info.Add("Video streams:");
                foreach (var video in infoReader.VideoStreams)
                {
                    Info.Add($"{video.Width}x{video.Height}, {video.FrameRate:F2} fps, Duration: {video.Duration.ToString()}");
                }
            }

            if (infoReader.AudioStreams.Count > 0)
            {
                Info.Add("Audio streams:");
                foreach (var audio in infoReader.AudioStreams)
                {
                    Info.Add($"{audio.SampleRate} Hz, {audio.Channels} channels, Duration: {audio.Duration.ToString()}");
                }
            }
        }
    }
}
