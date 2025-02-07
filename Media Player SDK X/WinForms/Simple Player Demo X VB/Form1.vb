Imports System.ComponentModel
Imports System.Threading
Imports VisioForge.Core
Imports VisioForge.Core.MediaPlayerX
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.AudioRenderers
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.Types.X.Sources
Imports VisioForge.Core.Types.X.VideoEffects
Imports VisioForge.Libs.MediaInfoNET.Model

Public Class Form1
    Private WithEvents _timer As System.Timers.Timer

    Private _timerFlag As Boolean

    Private _player As MediaPlayerCoreX

    Private _isClosing As Boolean

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]"
        Me.Enabled = False
        Await VisioForgeX.InitSDKAsync()
        Me.Enabled = True
        Text = Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "")

        _timer = New System.Timers.Timer(500)
        AddHandler _timer.Elapsed, AddressOf _timer_Elapsed

        Text += $" (SDK v{MediaPlayerCoreX.SDK_Version})"

        Await VisioForgeX.InitSDKAsync()

        CreateEngine()

        For Each device In Await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)
            cbAudioOutput.Items.Add(device.Name)
        Next

        If cbAudioOutput.Items.Count > 0 Then
            cbAudioOutput.SelectedIndex = 0
        End If
    End Sub

    Private Sub Player_OnError(sender As Object, e As ErrorsEventArgs)
        Invoke(Sub()
                   edLog.Text = edLog.Text + e.Message + Environment.NewLine
               End Sub)
    End Sub

    Private Sub Player_OnStop(sender As Object, e As StopEventArgs)
        If _isClosing Then
            Return
        End If

        Invoke(Sub()
                   tbTimeline.Value = 0
               End Sub)
    End Sub

    Private Sub CreateEngine()
        _player = New MediaPlayerCoreX(VideoView1)
        AddHandler _player.OnError, AddressOf Player_OnError
        AddHandler _player.OnStop, AddressOf Player_OnStop

        _player.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        _player.Debug_Mode = cbDebugMode.Checked
    End Sub

    Private Async Sub _timer_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs)
        _timerFlag = True

        If _player Is Nothing Then
            Return
        End If

        Dim position = Await _player.Position_GetAsync()
        Dim duration = Await _player.DurationAsync()

        Invoke(Sub()
                   tbTimeline.Maximum = CInt(duration.TotalSeconds)
                   lbTime.Text = position.ToString("hh\:mm\:ss") + " | " + duration.ToString("hh\:mm\:ss")

                   If tbTimeline.Maximum >= position.TotalSeconds Then
                       tbTimeline.Value = CInt(position.TotalSeconds)
                   End If
               End Sub)

        _timerFlag = False
    End Sub

    Private Async Function DestroyEngineAsync() As Task
        If _player IsNot Nothing Then
            RemoveHandler _player.OnError, AddressOf Player_OnError
            RemoveHandler _player.OnStop, AddressOf Player_OnStop
            Thread.Sleep(500)
            Await _player.DisposeAsync()
            _player = Nothing
        End If
    End Function

    Private Sub btSelectFile_Click(sender As Object, e As EventArgs) Handles btSelectFile.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Filter = "Video Files|*.mp4;*.ts;*.mts;*.mov;*.avi;*.mkv;*.wmv;*.webm|Audio Files|*.mp3;*.aac;*.wav;*.wma|All Files|*.*"
        If ofd.ShowDialog() = DialogResult.OK Then
            edFilename.Text = ofd.FileName
        End If
    End Sub

    Private Async Sub tbTimeline_Scroll(sender As Object, e As EventArgs) Handles tbTimeline.Scroll
        If Not _timerFlag AndAlso _player IsNot Nothing Then
            Await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        End If
    End Sub

    Private Async Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        edLog.Clear()

        Await DestroyEngineAsync()

        CreateEngine()

        Dim audioOutputDevice = (Await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).First(Function(x) x.Name = cbAudioOutput.Text)
        _player.Audio_OutputDevice = New AudioRendererSettings(audioOutputDevice)

        Dim source = Await UniversalSourceSettings.CreateAsync(New Uri(edFilename.Text))
        Await _player.OpenAsync(source)

        Await _player.PlayAsync()

        _timer.Start()
    End Sub

    Private Async Sub btStop_Click(sender As Object, e As EventArgs) Handles btStop.Click
        _timer.Stop()

        If _player IsNot Nothing Then
            Await _player.StopAsync()
            Await DestroyEngineAsync()
            _player = Nothing
        End If

        tbTimeline.Value = 0
    End Sub

    Private Async Sub btResume_Click(sender As Object, e As EventArgs) Handles btResume.Click
        Await _player.ResumeAsync()
    End Sub

    Private Async Sub btPause_Click(sender As Object, e As EventArgs) Handles btPause.Click
        Await _player.PauseAsync()
    End Sub

    Private Sub tbVolume1_Scroll(sender As Object, e As EventArgs) Handles tbVolume1.Scroll
        If _player IsNot Nothing Then
            _player.Audio_OutputDevice_Volume = tbVolume1.Value / 100.0
        End If
    End Sub

    Private Async Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        _timer.Stop()

        _isClosing = True

        Await DestroyEngineAsync()

        VisioForgeX.DestroySDK()
    End Sub

    Private Async Sub tbSpeed_Scroll(sender As Object, e As EventArgs) Handles tbSpeed.Scroll
        Await _player.Rate_SetAsync(tbSpeed.Value / 10.0)
    End Sub
End Class
