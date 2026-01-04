Imports System.IO
Imports System.Timers
Imports System.Linq
Imports VisioForge.Core
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.MediaBlocks
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.AudioRenderers
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.Types.X.Sources
Imports VisioForge.Core.VideoCaptureX
Imports VisioForge.Core.UI

Public Class Form1
    Private VideoCapture1 As VideoCaptureCoreX
    Private WithEvents tmRecording As New Timer(1000)

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += " [INITIALIZING SDK...]"
        Me.Enabled = False
        Await VisioForgeX.InitSDKAsync()
        Me.Enabled = True
        Me.Text = Me.Text.Replace(" [INITIALIZING SDK...]", "")

        VideoCapture1 = New VideoCaptureCoreX(VideoView1)
        AddHandler VideoCapture1.OnError, AddressOf VideoCapture1_OnError
        AddHandler VideoCapture1.OnStop, AddressOf VideoCapture1_OnStop

        Me.Text += $" (SDK v{VideoCaptureCoreX.SDK_Version})"

        ' Set default capture mode
        rbScreenFullScreen.Checked = True

        ' Enumerate actual displays
        cbScreenCaptureDisplayIndex.Items.Clear()
        For i As Integer = 0 To System.Windows.Forms.Screen.AllScreens.Length - 1
            Dim scr = System.Windows.Forms.Screen.AllScreens(i)
            cbScreenCaptureDisplayIndex.Items.Add($"{i}: {scr.DeviceName} ({scr.Bounds.Width}x{scr.Bounds.Height})")
        Next
        If cbScreenCaptureDisplayIndex.Items.Count > 0 Then
            cbScreenCaptureDisplayIndex.SelectedIndex = 0
        End If

        ' Enumerate audio sources
        Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()
        For Each source In audioSources
            cbAudioInputDevice.Items.Add(source.DisplayName)
            If cbAudioInputDevice.Items.Count = 1 Then cbAudioInputDevice.SelectedIndex = 0
        Next

        ' Enumerate audio loopback devices
        Dim audioOutputs = Await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)
        For Each audioOutput In audioOutputs
            cbAudioLoopbackDevice.Items.Add(audioOutput.Name)
            If cbAudioLoopbackDevice.Items.Count = 1 Then cbAudioLoopbackDevice.SelectedIndex = 0
        Next

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "screen_capture.mp4")
    End Sub

    Private Async Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Try
            mmLog.Clear()

            VideoCapture1.Debug_Mode = cbDebugMode.Checked
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

            ' Configure screen capture source
            Dim screenSource As IScreenCaptureSourceSettings

            Dim frameRateValue As Integer
            If Not Integer.TryParse(edScreenFrameRate.Text, frameRateValue) OrElse frameRateValue <= 0 Then
                frameRateValue = 10
            End If

            If rbScreenFullScreen.Checked Then
                screenSource = New ScreenCaptureD3D11SourceSettings() With {
                    .MonitorIndex = cbScreenCaptureDisplayIndex.SelectedIndex,
                    .FrameRate = New VideoFrameRate(frameRateValue, 1),
                    .CaptureCursor = cbScreenCapture_GrabMouseCursor.Checked
                }
            ElseIf rbScreenCustomArea.Checked Then
                screenSource = New ScreenCaptureD3D11SourceSettings() With {
                    .Rectangle = New Rect(CInt(edScreenLeft.Text), CInt(edScreenTop.Text), CInt(edScreenRight.Text), CInt(edScreenBottom.Text)),
                    .FrameRate = New VideoFrameRate(frameRateValue, 1),
                    .CaptureCursor = cbScreenCapture_GrabMouseCursor.Checked
                }
            Else
                MessageBox.Show("Window capture not yet implemented in this demo", "Info")
                Return
            End If

            VideoCapture1.Video_Source = screenSource
            VideoCapture1.Video_Play = True

            ' Audio source
            If cbRecordAudio.Checked Then
                If rbSystemAudio.Checked Then
                    Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()
                    Dim audioDevice = audioSources.FirstOrDefault(Function(d) d.DisplayName = cbAudioInputDevice.Text)
                    If audioDevice IsNot Nothing Then
                        VideoCapture1.Audio_Source = audioDevice.CreateSourceSettingsVC(Nothing)
                    End If
                Else
                    Dim audioOutputs = Await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)
                    Dim audioDevice = audioOutputs.FirstOrDefault(Function(d) d.Name = cbAudioLoopbackDevice.Text)
                    If audioDevice IsNot Nothing Then
                        VideoCapture1.Audio_Source = New LoopbackAudioCaptureDeviceSourceSettings(audioDevice)
                    End If
                End If

                VideoCapture1.Audio_Record = True
            End If

            ' Output
            VideoCapture1.Outputs_Clear()
            If rbCapture.Checked Then
                VideoCapture1.Outputs_Add(New MP4Output(edOutput.Text), True)
            End If

            Await VideoCapture1.StartAsync()
            tmRecording.Start()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btStop_Click(sender As Object, e As EventArgs) Handles btStop.Click
        Try
            tmRecording.Stop()
            Await VideoCapture1.StopAsync()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tmRecording_Elapsed(sender As Object, e As ElapsedEventArgs) Handles tmRecording.Elapsed
        Dim ts = VideoCapture1.Duration()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() lbTimestamp.Text = "Duration: " & ts.ToString("hh\:mm\:ss"))
        Else
            lbTimestamp.Text = "Duration: " & ts.ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub Log(txt As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() mmLog.Text &= txt & Environment.NewLine)
        Else
            mmLog.Text &= txt & Environment.NewLine
        End If
    End Sub

    Private Sub VideoCapture1_OnError(sender As Object, e As ErrorsEventArgs)
        Log("Error: " & e.Message)
    End Sub

    Private Sub VideoCapture1_OnStop(sender As Object, e As EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() lbTimestamp.Text = "Duration: 00:00:00")
        Else
            lbTimestamp.Text = "Duration: 00:00:00"
        End If
    End Sub

    Private Sub btSelectOutput_Click(sender As Object, e As EventArgs) Handles btSelectOutput.Click
        Using dlg As New SaveFileDialog()
            dlg.Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*"
            dlg.DefaultExt = "mp4"
            dlg.AddExtension = True

            Dim currentPath = edOutput.Text
            If Not String.IsNullOrWhiteSpace(currentPath) Then
                Try
                    dlg.InitialDirectory = Path.GetDirectoryName(currentPath)
                    dlg.FileName = Path.GetFileName(currentPath)
                Catch
                    ' ignore invalid paths
                End Try
            Else
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
                dlg.FileName = "screen_capture.mp4"
            End If

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                edOutput.Text = dlg.FileName
            End If
        End Using
    End Sub

    Private Async Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If VideoCapture1 IsNot Nothing Then
            Await VideoCapture1.DisposeAsync()
            VideoCapture1 = Nothing
        End If
        VisioForgeX.DestroySDK()
    End Sub
End Class
