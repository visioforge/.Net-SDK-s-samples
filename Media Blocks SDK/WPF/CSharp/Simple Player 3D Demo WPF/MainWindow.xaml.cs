using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;


namespace MediaBlocks_Simple_Player_3D_Demo_WPF
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

        private ModelVisual3D _cubeModel;

        private ContainerUIElement3D _cubeContainer;

        private DispatcherTimer _animationTimer;

        private double _rotationAngle = 0;

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

            var audioOutputDevices = (await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound)).ToArray();
            cbAudioOutput.Items.Clear();
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item.DisplayName);
                }

                cbAudioOutput.SelectedIndex = 0;
            }

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            // Initialize 3D scene
            Initialize3DScene();
        }

        private void Initialize3DScene()
        {
            // Create light sources
            var lightGroup = new Model3DGroup();
            lightGroup.Children.Add(new AmbientLight(Colors.White));
            lightGroup.Children.Add(new DirectionalLight(Colors.White, new Vector3D(-1, -1, -1)));

            var lightModel = new ModelVisual3D();
            lightModel.Content = lightGroup;
            Viewport3D1.Children.Add(lightModel);

            // Create rainbow cube (hidden initially)
            _cubeModel = CreateRainbowCube();
            _cubeContainer = new ContainerUIElement3D();
            _cubeContainer.Children.Add(_cubeModel);
            _cubeContainer.Visibility = Visibility.Hidden;
            Viewport3D1.Children.Add(_cubeContainer);

            // Setup animation timer (but don't start it yet)
            _animationTimer = new DispatcherTimer();
            _animationTimer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Rotate the cube
            _rotationAngle += 2;
            if (_rotationAngle >= 360)
                _rotationAngle = 0;

            var rotateTransform = new RotateTransform3D();
            var axisAngleRotation = new AxisAngleRotation3D(new Vector3D(1, 1, 0), _rotationAngle);
            rotateTransform.Rotation = axisAngleRotation;
            _cubeModel.Transform = rotateTransform;
        }

        private ModelVisual3D CreateRainbowCube()
        {
            var model = new ModelVisual3D();
            var meshGroup = new Model3DGroup();

            // Define the 6 faces of the cube with rainbow colors
            var faces = new[]
            {
                new { Normal = new Vector3D(0, 0, 1), Color = Colors.Red },      // Front - Red
                new { Normal = new Vector3D(0, 0, -1), Color = Colors.Orange },  // Back - Orange
                new { Normal = new Vector3D(0, 1, 0), Color = Colors.Yellow },   // Top - Yellow
                new { Normal = new Vector3D(0, -1, 0), Color = Colors.Green },   // Bottom - Green
                new { Normal = new Vector3D(1, 0, 0), Color = Colors.Blue },     // Right - Blue
                new { Normal = new Vector3D(-1, 0, 0), Color = Colors.Violet }   // Left - Violet
            };

            // Create each face
            foreach (var face in faces)
            {
                var mesh = CreateCubeFace(face.Normal);
                var material = new DiffuseMaterial(new SolidColorBrush(face.Color));
                var geometryModel = new GeometryModel3D(mesh, material);
                meshGroup.Children.Add(geometryModel);
            }

            model.Content = meshGroup;
            return model;
        }

        private MeshGeometry3D CreateCubeFace(Vector3D normal)
        {
            var mesh = new MeshGeometry3D();
            
            // Determine which face we're creating based on the normal
            // Using 0.3 scale to make cube smaller
            double scale = 0.3;
            if (normal.Z > 0.5) // Front face
            {
                mesh.Positions.Add(new Point3D(-scale, -scale, scale));
                mesh.Positions.Add(new Point3D(scale, -scale, scale));
                mesh.Positions.Add(new Point3D(scale, scale, scale));
                mesh.Positions.Add(new Point3D(-scale, scale, scale));
            }
            else if (normal.Z < -0.5) // Back face
            {
                mesh.Positions.Add(new Point3D(scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(-scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(-scale, scale, -scale));
                mesh.Positions.Add(new Point3D(scale, scale, -scale));
            }
            else if (normal.Y > 0.5) // Top face
            {
                mesh.Positions.Add(new Point3D(-scale, scale, scale));
                mesh.Positions.Add(new Point3D(scale, scale, scale));
                mesh.Positions.Add(new Point3D(scale, scale, -scale));
                mesh.Positions.Add(new Point3D(-scale, scale, -scale));
            }
            else if (normal.Y < -0.5) // Bottom face
            {
                mesh.Positions.Add(new Point3D(-scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(scale, -scale, scale));
                mesh.Positions.Add(new Point3D(-scale, -scale, scale));
            }
            else if (normal.X > 0.5) // Right face
            {
                mesh.Positions.Add(new Point3D(scale, -scale, scale));
                mesh.Positions.Add(new Point3D(scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(scale, scale, -scale));
                mesh.Positions.Add(new Point3D(scale, scale, scale));
            }
            else // Left face
            {
                mesh.Positions.Add(new Point3D(-scale, -scale, -scale));
                mesh.Positions.Add(new Point3D(-scale, -scale, scale));
                mesh.Positions.Add(new Point3D(-scale, scale, scale));
                mesh.Positions.Add(new Point3D(-scale, scale, -scale));
            }

            // Add triangle indices (two triangles per face)
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);

            return mesh;
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
                _timer.Stop();
                tbTimeline.Value = 0;
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

            VideoView1.SetNativeRendering(false);            

            _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);

            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());
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
            if (!_timerFlag && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await CreateEngineAsync();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            _timer.Start();

            // Show and start cube rotation animation when playback starts
            _cubeContainer.Visibility = Visibility.Visible;
            _animationTimer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _animationTimer.Stop();
            _cubeContainer.Visibility = Visibility.Hidden;

            if (_pipeline != null)
            {
                await StopEngineAsync();
            }

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
            _animationTimer.Stop();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
            _animationTimer.Start();
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
            _animationTimer?.Stop();

            if (_pipeline != null)
            {
                DestroyEngine();
            }

            VisioForgeX.DestroySDK();
        }
    }
}
