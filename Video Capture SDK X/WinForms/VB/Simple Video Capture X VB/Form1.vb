Imports System.IO
Imports System.Timers
Imports System.Drawing.Imaging
Imports System.Linq
Imports System.Globalization
Imports SkiaSharp
Imports VisioForge.Core
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.AudioRenderers
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.Types.X.Sources
Imports VisioForge.Core.Types.X.VideoEffects
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

        ' Enumerate video sources
        Dim videoSources = Await DeviceEnumerator.Shared.VideoSourcesAsync()
        For Each source In videoSources
            cbVideoInputDevice.Items.Add(source.DisplayName)
            If cbVideoInputDevice.Items.Count = 1 Then cbVideoInputDevice.SelectedIndex = 0
        Next

        ' Enumerate audio sources
        Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()
        For Each source In audioSources
            cbAudioInputDevice.Items.Add(source.DisplayName)
            If cbAudioInputDevice.Items.Count = 1 Then cbAudioInputDevice.SelectedIndex = 0
        Next

        ' Enumerate audio outputs
        Dim audioOutputs = Await DeviceEnumerator.Shared.AudioOutputsAsync()
        For Each audioOutput In audioOutputs
            cbAudioOutputDevice.Items.Add(audioOutput.DisplayName)
            If cbAudioOutputDevice.Items.Count = 1 Then cbAudioOutputDevice.SelectedIndex = 0
        Next

        rbPreview.Checked = True
        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "capture.mp4")
    End Sub

    Private Async Sub cbVideoInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVideoInputDevice.SelectedIndexChanged
        If cbVideoInputDevice.SelectedIndex = -1 Then Return

        cbVideoInputFormat.Items.Clear()
        cbVideoInputFrameRate.Items.Clear()

        Dim videoSources = Await DeviceEnumerator.Shared.VideoSourcesAsync()
        Dim device = videoSources.FirstOrDefault(Function(d) d.DisplayName = cbVideoInputDevice.Text)
        If device IsNot Nothing Then
            For Each videoFormat In device.VideoFormats
                cbVideoInputFormat.Items.Add(videoFormat.Name)
            Next
            If cbVideoInputFormat.Items.Count > 0 Then cbVideoInputFormat.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub cbVideoInputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVideoInputFormat.SelectedIndexChanged
        If cbVideoInputFormat.SelectedIndex = -1 Then Return

        cbVideoInputFrameRate.Items.Clear()

        Dim videoSources = Await DeviceEnumerator.Shared.VideoSourcesAsync()
        Dim device = videoSources.FirstOrDefault(Function(d) d.DisplayName = cbVideoInputDevice.Text)
        If device IsNot Nothing Then
            Dim selectedVideoFormatInfo = device.VideoFormats.FirstOrDefault(Function(f) f.Name = cbVideoInputFormat.Text)
            If selectedVideoFormatInfo IsNot Nothing Then
                For Each frameRateItem In selectedVideoFormatInfo.FrameRateList
                    cbVideoInputFrameRate.Items.Add(frameRateItem.ToString())
                Next
                If cbVideoInputFrameRate.Items.Count > 0 Then cbVideoInputFrameRate.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Async Sub cbAudioInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAudioInputDevice.SelectedIndexChanged
        If cbAudioInputDevice.SelectedIndex = -1 Then Return

        cbAudioInputFormat.Items.Clear()

        Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()
        Dim device = audioSources.FirstOrDefault(Function(d) d.DisplayName = cbAudioInputDevice.Text)
        If device IsNot Nothing Then
            For Each audioFormat In device.Formats
                cbAudioInputFormat.Items.Add(audioFormat.Name)
            Next
            If cbAudioInputFormat.Items.Count > 0 Then cbAudioInputFormat.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Try
            mmLog.Clear()

            VideoCapture1.Debug_Mode = cbDebugMode.Checked
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

            ' Video source
            Dim videoSources = Await DeviceEnumerator.Shared.VideoSourcesAsync()
            Dim videoDevice = videoSources.FirstOrDefault(Function(d) d.DisplayName = cbVideoInputDevice.Text)
            If videoDevice IsNot Nothing Then
                Dim videoSourceSettings As New VideoCaptureDeviceSourceSettings(videoDevice)

                Dim selectedVideoFormatInfo = videoDevice.VideoFormats.FirstOrDefault(Function(f) f.Name = cbVideoInputFormat.Text)
                If selectedVideoFormatInfo IsNot Nothing Then
                    Dim selectedFormat = selectedVideoFormatInfo.ToFormat()

                    Dim fps As Double
                    If Double.TryParse(cbVideoInputFrameRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture, fps) OrElse Double.TryParse(cbVideoInputFrameRate.Text, fps) Then
                        If fps > 0 Then
                            selectedFormat.FrameRate = New VideoFrameRate(fps)
                            selectedFormat.ForceFrameRate = True
                        End If
                    End If

                    videoSourceSettings.Format = selectedFormat
                End If

                VideoCapture1.Video_Source = videoSourceSettings
            End If

            ' Audio source and output
            If cbRecordAudio.Checked Then
                Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()
                Dim audioDevice = audioSources.FirstOrDefault(Function(d) d.DisplayName = cbAudioInputDevice.Text)
                If audioDevice IsNot Nothing Then
                    VideoCapture1.Audio_Source = audioDevice.CreateSourceSettingsVC(Nothing)
                End If

                Dim audioOutputs = Await DeviceEnumerator.Shared.AudioOutputsAsync()
                Dim audioOutput = audioOutputs.FirstOrDefault(Function(d) d.DisplayName = cbAudioOutputDevice.Text)
                If audioOutput IsNot Nothing Then
                    VideoCapture1.Audio_OutputDevice = New AudioRendererSettings(audioOutput)
                End If

                VideoCapture1.Audio_Play = True
                VideoCapture1.Audio_Record = rbCapture.Checked
            End If

            ' Video preview
            VideoCapture1.Video_Play = True

            ' Video effects
            VideoCapture1.Video_Effects_Clear()

            ' Output
            VideoCapture1.Outputs_Clear()
            If rbCapture.Checked Then
                VideoCapture1.Outputs_Add(New MP4Output(edOutput.Text), True)
            End If

            VideoCapture1.Snapshot_Grabber_Enabled = True

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

    Private Async Sub btPause_Click(sender As Object, e As EventArgs) Handles btPause.Click
        Await VideoCapture1.PauseAsync()
    End Sub

    Private Async Sub btResume_Click(sender As Object, e As EventArgs) Handles btResume.Click
        Await VideoCapture1.ResumeAsync()
    End Sub

    Private Async Sub btSaveScreenshot_Click(sender As Object, e As EventArgs) Handles btSaveScreenshot.Click
        Dim saveDialog As New SaveFileDialog With {
            .Filter = "JPEG|*.jpg|PNG|*.png|BMP|*.bmp",
            .FileName = "snapshot.jpg"
        }

        If saveDialog.ShowDialog() = DialogResult.OK Then
            Dim format As SKEncodedImageFormat = SKEncodedImageFormat.Jpeg
            If saveDialog.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) Then format = SKEncodedImageFormat.Png
            If saveDialog.FileName.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) Then format = SKEncodedImageFormat.Bmp

            Await VideoCapture1.Snapshot_SaveAsync(saveDialog.FileName, format)
        End If
    End Sub

    Private Sub btSelectOutputFile_Click(sender As Object, e As EventArgs) Handles btSelectOutputFile.Click
        Dim initialFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
        Dim initialFileName As String = "capture.mp4"

        Try
            If Not String.IsNullOrWhiteSpace(edOutput.Text) Then
                Dim currentPath = edOutput.Text.Trim()
                Dim folder = Path.GetDirectoryName(currentPath)
                Dim fileName = Path.GetFileName(currentPath)

                If Not String.IsNullOrWhiteSpace(folder) AndAlso Directory.Exists(folder) Then
                    initialFolder = folder
                End If

                If Not String.IsNullOrWhiteSpace(fileName) Then
                    initialFileName = fileName
                End If
            End If
        Catch
            ' ignore path parsing errors
        End Try

        Dim dlg As New SaveFileDialog With {
            .Filter = "MP4|*.mp4|All files|*.*",
            .DefaultExt = "mp4",
            .AddExtension = True,
            .InitialDirectory = initialFolder,
            .FileName = initialFileName
        }

        If dlg.ShowDialog(Me) = DialogResult.OK Then
            edOutput.Text = dlg.FileName
        End If
    End Sub

    Private Sub tbAudioVolume_ValueChanged(sender As Object, e As EventArgs) Handles tbAudioVolume.ValueChanged
        If VideoCapture1 IsNot Nothing Then
            VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0
        End If
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

    Private Sub lbViewVideoTutorials_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim startInfo = New ProcessStartInfo(HelpLinks.VideoTutorials) With {.UseShellExecute = True}
        Process.Start(startInfo)
    End Sub

    Private Async Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If VideoCapture1 IsNot Nothing Then
            Await VideoCapture1.DisposeAsync()
            VideoCapture1 = Nothing
        End If
        VisioForgeX.DestroySDK()
    End Sub
End Class
