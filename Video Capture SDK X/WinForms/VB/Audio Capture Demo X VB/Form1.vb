Imports System.IO
Imports System.Timers
Imports VisioForge.Core
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.AudioRenderers
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.Types.X.Sources
Imports VisioForge.Core.Types.X.VideoCapture
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.VideoCaptureX

Public Class Form1
    Private ReadOnly saveFileDialog1 As New SaveFileDialog()

    Private WithEvents tmRecording As New Timer(1000)

    Private VideoCapture1 As VideoCaptureCoreX

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' We have to initialize the engine on start
        Me.Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]"
        Me.Enabled = False
        Await VisioForgeX.InitSDKAsync()
        Me.Enabled = True
        Me.Text = Me.Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "")

        VideoCapture1 = New VideoCaptureCoreX()
        AddHandler VideoCapture1.OnError, AddressOf VideoCapture1_OnError
        AddHandler VideoCapture1.OnStop, AddressOf VideoCapture1_OnStop

        Me.Text += $" (SDK v{VideoCaptureCoreX.SDK_Version})"
        cbMode.SelectedIndex = 0

        ' enumerate audio sources
        Dim audioSources = Await DeviceEnumerator.Shared.AudioSourcesAsync()

        For Each source In audioSources
            cbAudioInputDevice.Items.Add(source.DisplayName)

            If cbAudioInputDevice.Items.Count = 1 Then
                cbAudioInputDevice.SelectedIndex = 0
            End If
        Next

        ' enumerate audio sinks
        Dim audioSinks = Await DeviceEnumerator.Shared.AudioOutputsAsync()
        For Each sink In audioSinks
            cbAudioOutputDevice.Items.Add(sink.DisplayName)

            If cbAudioOutputDevice.Items.Count = 1 Then
                cbAudioOutputDevice.SelectedIndex = 0
            End If

            If sink.API = AudioOutputDeviceAPI.WASAPI2 Then
                cbAudioLoopbackDevice.Items.Add(sink.Name)

                If cbAudioLoopbackDevice.Items.Count = 1 Then
                    cbAudioLoopbackDevice.SelectedIndex = 0
                End If
            End If
        Next

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp3")
    End Sub

    Private Async Sub cbAudioInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAudioInputDevice.SelectedIndexChanged
        If cbAudioInputDevice.SelectedIndex <> -1 Then
            cbAudioInputFormat.Items.Clear()

            Dim deviceItem = (Await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(Function(device) device.DisplayName = cbAudioInputDevice.Text)
            If deviceItem Is Nothing Then
                Return
            End If

            For Each audioFormat In deviceItem.Formats
                cbAudioInputFormat.Items.Add(audioFormat.Name)
            Next

            If cbAudioInputFormat.Items.Count > 0 Then
                cbAudioInputFormat.SelectedIndex = 0
            End If
        End If
    End Sub

        ''' <summary>
        ''' Tb audio volume scroll.
        ''' </summary>
    Private Sub tbAudioVolume_Scroll(sender As Object, e As EventArgs) Handles tbAudioVolume.Scroll
        If VideoCapture1 Is Nothing Then
            Return
        End If

        VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0
    End Sub

        ''' <summary>
        ''' Bt select output click.
        ''' </summary>
    Private Sub btSelectOutput_Click(sender As Object, e As EventArgs) Handles btSelectOutput.Click
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = saveFileDialog1.FileName
        End If
    End Sub

    Private Async Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Try
            mmLog.Clear()

            VideoCapture1.Debug_Mode = cbDebugMode.Checked
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

            ' audio output
            Dim audioOutputDevice = (Await DeviceEnumerator.Shared.AudioOutputsAsync()).FirstOrDefault(Function(device) device.DisplayName = cbAudioOutputDevice.Text)
            If audioOutputDevice Is Nothing Then
                MessageBox.Show(Me, "Selected audio output device not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            VideoCapture1.Audio_OutputDevice = New AudioRendererSettings(audioOutputDevice)

            ' audio input
            Dim audioSource As IVideoCaptureBaseAudioSourceSettings = Nothing
            If rbSystemAudio.Checked Then
                Dim deviceItem = (Await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(Function(device) device.DisplayName = cbAudioInputDevice.Text)
                If deviceItem Is Nothing Then
                    Return
                End If

                Dim format As AudioCaptureDeviceFormat = Nothing
                Dim formats = deviceItem.Formats.Where(Function(fmt) fmt.Name = cbAudioInputFormat.Text).ToList()
                If formats.Count > 0 Then
                    format = formats(0).ToFormat()
                End If

                audioSource = deviceItem.CreateSourceSettingsVC(format)
            Else
                Dim deviceItem = (Await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(Function(device) device.Name = cbAudioLoopbackDevice.Text)
                If deviceItem Is Nothing Then
                    Return
                End If

                audioSource = New LoopbackAudioCaptureDeviceSourceSettings(deviceItem)
            End If

            VideoCapture1.Audio_Source = audioSource

            VideoCapture1.Audio_Play = cbPlayAudio.Checked
            VideoCapture1.Audio_Record = False

            VideoCapture1.Outputs_Clear()

            If cbMode.SelectedIndex = 0 Then
                ' Preview mode
            Else
                ' Capture mode
                VideoCapture1.Audio_Record = True

                Select Case cbOutputFormat.SelectedIndex
                    Case 0
                        VideoCapture1.Outputs_Add(New WAVOutput(edOutput.Text), True)

                    Case 1
                        VideoCapture1.Outputs_Add(New MP3Output(edOutput.Text), True)

                    Case 2
                        VideoCapture1.Outputs_Add(New WMAOutput(edOutput.Text), True)

                    Case 3
                        VideoCapture1.Outputs_Add(New OGGVorbisOutput(edOutput.Text), True)

                    Case 4
                        VideoCapture1.Outputs_Add(New FLACOutput(edOutput.Text), True)

                    Case 5
                        VideoCapture1.Outputs_Add(New SpeexOutput(edOutput.Text), True)

                    Case 6
                        VideoCapture1.Outputs_Add(New M4AOutput(edOutput.Text), True)
                End Select
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

        ''' <summary>
        ''' Tm recording elapsed.
        ''' </summary>
    Private Sub tmRecording_Elapsed(sender As Object, e As ElapsedEventArgs) Handles tmRecording.Elapsed
        UpdateRecordingTime()
    End Sub

        ''' <summary>
        ''' Update recording time.
        ''' </summary>
    Private Sub UpdateRecordingTime()
        Dim ts = VideoCapture1.Duration()

        If Math.Abs(ts.TotalMilliseconds) < 0.01 Then
            Return
        End If

        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          lbTimestamp.Text = "Recording time: " & ts.ToString("hh\:mm\:ss")
                      End Sub)
        Else
            lbTimestamp.Text = "Recording time: " & ts.ToString("hh\:mm\:ss")
        End If
    End Sub

        ''' <summary>
        ''' Ll video tutorials link clicked.
        ''' </summary>
    Private Sub llVideoTutorials_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llVideoTutorials.LinkClicked
        Dim startInfo = New ProcessStartInfo(HelpLinks.VideoTutorials) With {
            .UseShellExecute = True
        }
        Process.Start(startInfo)
    End Sub

        ''' <summary>
        ''' Log.
        ''' </summary>
    Private Sub Log(txt As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() mmLog.Text = mmLog.Text & txt & Environment.NewLine)
        Else
            mmLog.Text = mmLog.Text & txt & Environment.NewLine
        End If
    End Sub

        ''' <summary>
        ''' Video capture 1 on error.
        ''' </summary>
    Private Sub VideoCapture1_OnError(sender As Object, e As ErrorsEventArgs)
        Log(e.Message)
    End Sub

        ''' <summary>
        ''' Cb output format selected index changed.
        ''' </summary>
    Private Sub cbOutputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputFormat.SelectedIndexChanged
        If edOutput Is Nothing Then
            Return
        End If

        Select Case cbOutputFormat.SelectedIndex
            Case 0
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav")
            Case 1
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3")
            Case 2
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma")
            Case 3
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 4
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac")
            Case 5
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 6
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a")
        End Select
    End Sub

        ''' <summary>
        ''' Video capture 1 on stop.
        ''' </summary>
    Private Sub VideoCapture1_OnStop(sender As Object, e As EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() lbTimestamp.Text = "Recording time: 00:00:00")
        Else
            lbTimestamp.Text = "Recording time: 00:00:00"
        End If
    End Sub

    Private Async Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If VideoCapture1 IsNot Nothing Then
            Await VideoCapture1.DisposeAsync()
            VideoCapture1 = Nothing
        End If

        VisioForgeX.DestroySDK()
    End Sub
End Class
