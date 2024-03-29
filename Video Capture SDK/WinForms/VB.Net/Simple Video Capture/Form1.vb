' ReSharper disable InconsistentNaming

Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.AudioEffects
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoCapture
Imports VisioForge.Core.Types.VideoEffects
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.VideoCapture

Public Class Form1
    Private Const AUDIO_EFFECT_ID_AMPLIFY As String = "amplify"

    Private Const AUDIO_EFFECT_ID_EQ As String = "eq"

    Private Const AUDIO_EFFECT_ID_DYN_AMPLIFY As String = "dyn_amplify"

    Private Const AUDIO_EFFECT_ID_SOUND_3D As String = "sound3d"

    Private Const AUDIO_EFFECT_ID_TRUE_BASS As String = "true_bass"

    Private Const AUDIO_EFFECT_ID_PITCH_SHIFT As String = "pitch_shift"

    Private mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Private mpegTSSettingsDialog As HWEncodersOutputSettingsDialog

    Private movSettingsDialog As HWEncodersOutputSettingsDialog

    Private _mp4SettingsDialog As MP4SettingsDialog

    Private aviSettingsDialog As AVISettingsDialog

    Private wmvSettingsDialog As WMVSettingsDialog

    Private gifSettingsDialog As GIFSettingsDialog

    Private screenshotSaveDialog As SaveFileDialog

    Private tmRecording As Timers.Timer = New Timers.Timer(1000)

    Private WithEvents VideoCapture1 As VideoCaptureCore

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Async Function CreateEngineAsync() As Task(Of VideoCaptureCore)
        VideoCapture1 = Await VideoCaptureCore.CreateAsync(VideoView1)
        Return VideoCapture1
    End Function

    Private Sub DestroyEngine()
        VideoCapture1.Dispose()
        VideoCapture1 = Nothing
    End Sub

    Private Sub cbAudioInputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudioInputDevice.SelectedIndexChanged
        If cbAudioInputDevice.SelectedIndex <> -1 Then
            cbAudioInputFormat.Items.Clear()

            Dim deviceItem =
                    (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text)?.FirstOrDefault()
            If IsNothing(deviceItem) Then
                Exit Sub
            End If

            Dim defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels"
            Dim defaultValueExists = False

            For Each s As String In deviceItem.Formats
                cbAudioInputFormat.Items.Add(s)

                If (defaultValue = s) Then
                    defaultValueExists = True
                End If

            Next

            If (cbAudioInputFormat.Items.Count > 0) Then
                cbAudioInputFormat.SelectedIndex = 0

                If (defaultValueExists) Then
                    cbAudioInputFormat.Text = defaultValue
                End If
            End If

            cbAudioInputLine.Items.Clear()
            Dim lines = deviceItem.Lines
            For Each item As String In lines
                cbAudioInputLine.Items.Add(item)
            Next

            If cbAudioInputLine.Items.Count > 0 Then
                cbAudioInputLine.SelectedIndex = 0
            End If

            btAudioInputDeviceSettings.Enabled = deviceItem.DialogDefault
        End If
    End Sub

    Private Sub btAudioInputDeviceSettings_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btAudioInputDeviceSettings.Click
        VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text)
    End Sub

    Private Sub cbAudioOutputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudioOutputDevice.SelectedIndexChanged
        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text
    End Sub

    Private Sub cbUseBestAudioInputFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbUseBestAudioInputFormat.CheckedChanged
        cbAudioInputFormat.Enabled = Not cbUseBestAudioInputFormat.Checked
    End Sub

    Private Sub cbVideoInputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbVideoInputDevice.SelectedIndexChanged
        If cbVideoInputDevice.SelectedIndex <> -1 Then
            cbVideoInputFormat.Items.Clear()

            Dim deviceItem =
                    (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbVideoInputDevice.Text)?.
                    FirstOrDefault()
            If IsNothing(deviceItem) Then
                Exit Sub
            End If

            Dim formats = deviceItem.VideoFormats
            For Each item As VideoCaptureDeviceFormat In formats
                cbVideoInputFormat.Items.Add(item)
            Next

            If cbVideoInputFormat.Items.Count > 0 Then
                cbVideoInputFormat.SelectedIndex = 0
                cbVideoInputFormat_SelectedIndexChanged(Nothing, Nothing)
            End If

            btVideoCaptureDeviceSettings.Enabled = deviceItem.DialogDefault
        End If
    End Sub

    Private Sub cbVideoInputFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbVideoInputFormat.SelectedIndexChanged
        If (String.IsNullOrEmpty(cbVideoInputFormat.Text)) Then
            Return
        End If

        If (cbVideoInputDevice.SelectedIndex <> -1) Then

            Dim deviceItem As VideoCaptureDeviceInfo = (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbVideoInputDevice.Text)?.FirstOrDefault()
            If (deviceItem Is Nothing) Then
                Return
            End If

            Dim videoFormat As VideoCaptureDeviceFormat = (From Format In deviceItem.VideoFormats Where Format.Name = cbVideoInputFormat.Text)?.FirstOrDefault()
            If (videoFormat Is Nothing) Then
                Return
            End If

            cbVideoInputFrameRate.Items.Clear()
            For Each frameRate As VideoFrameRate In videoFormat.FrameRates
                cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture))
            Next

            If (cbVideoInputFrameRate.Items.Count > 0) Then
                cbVideoInputFrameRate.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cbUseBestVideoInputFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbUseBestVideoInputFormat.CheckedChanged
        cbVideoInputFormat.Enabled = Not cbUseBestVideoInputFormat.Checked
    End Sub

    Private Sub btVideoCaptureDeviceSettings_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btVideoCaptureDeviceSettings.Click
        VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text)
    End Sub

    Private Sub tbAudioVolume_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioVolume.Scroll
        VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value)
    End Sub

    Private Sub tbAudioBalance_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioBalance.Scroll
        VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value)
        VideoCapture1.Audio_OutputDevice_Balance_Get()
    End Sub

    Private Sub cbAudAmplifyEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudAmplifyEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked)
    End Sub

    Private Sub tbAudAmplifyAmp_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudAmplifyAmp.Scroll
        VideoCapture1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, False)
    End Sub

    Private Sub cbAudEqualizerEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudEqualizerEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked)
    End Sub

    Private Sub tbAudEq0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq0.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, tbAudEq0.Value)
    End Sub

    Private Sub tbAudEq1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq1.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, tbAudEq1.Value)
    End Sub

    Private Sub tbAudEq2_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq2.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, tbAudEq2.Value)
    End Sub

    Private Sub tbAudEq3_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq3.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, tbAudEq3.Value)
    End Sub

    Private Sub tbAudEq4_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq4.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, tbAudEq4.Value)
    End Sub

    Private Sub tbAudEq5_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq5.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, tbAudEq5.Value)
    End Sub

    Private Sub tbAudEq6_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq6.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, tbAudEq6.Value)
    End Sub

    Private Sub tbAudEq7_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq7.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, tbAudEq7.Value)
    End Sub

    Private Sub tbAudEq8_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq8.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, tbAudEq8.Value)
    End Sub

    Private Sub tbAudEq9_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq9.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, tbAudEq9.Value)
    End Sub

    Private Sub cbAudEqualizerPreset_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudEqualizerPreset.SelectedIndexChanged
        VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerPreset.SelectedIndex)
        btAudEqRefresh_Click(sender, e)
    End Sub

    Private Sub btAudEqRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAudEqRefresh.Click
        tbAudEq0.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0)
        tbAudEq1.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1)
        tbAudEq2.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2)
        tbAudEq3.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3)
        tbAudEq4.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4)
        tbAudEq5.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5)
        tbAudEq6.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6)
        tbAudEq7.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7)
        tbAudEq8.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8)
        tbAudEq9.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9)
    End Sub

    Private Sub cbAudTrueBassEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles cbAudTrueBassEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked)
    End Sub

    Private Sub tbAudTrueBass_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudTrueBass.Scroll
        VideoCapture1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, False, tbAudTrueBass.Value)
    End Sub

    Private Sub btSelectOutput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSelectOutput.Click
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = saveFileDialog1.FileName
        End If
    End Sub

    Private Sub SetMP4HWOutput(ByRef mp4Output As MP4HWOutput)
        If (mp4HWSettingsDialog Is Nothing) Then
            mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
        End If

        mp4HWSettingsDialog.SaveSettings(mp4Output)
    End Sub

    Private Sub SetMPEGTSOutput(ByRef mpegTSOutput As MPEGTSOutput)

        If (mpegTSSettingsDialog Is Nothing) Then
            mpegTSSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS)
        End If

        mpegTSSettingsDialog.SaveSettings(mpegTSOutput)
    End Sub

    Private Sub SetMOVOutput(ByRef mkvOutput As MOVOutput)

        If (movSettingsDialog Is Nothing) Then
            movSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV)
        End If

        movSettingsDialog.SaveSettings(mkvOutput)
    End Sub

    Private Sub SetMP4Output(ByRef mp4Output As MP4Output)
        If (_mp4SettingsDialog Is Nothing) Then
            _mp4SettingsDialog = New MP4SettingsDialog()
        End If

        _mp4SettingsDialog.SaveSettings(mp4Output)
    End Sub

    Private Sub SetGIFOutput(ByRef gifOutput As AnimatedGIFOutput)
        If (gifSettingsDialog Is Nothing) Then
            gifSettingsDialog = New GIFSettingsDialog()
        End If

        gifSettingsDialog.SaveSettings(gifOutput)
    End Sub

    Private Sub SetWMVOutput(ByRef wmvOutput As WMVOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
        End If

        wmvSettingsDialog.WMA = False
        wmvSettingsDialog.SaveSettings(wmvOutput)
    End Sub

    Private Sub SetAVIOutput(ByRef aviOutput As AVIOutput)
        If (aviSettingsDialog Is Nothing) Then
            aviSettingsDialog = New AVISettingsDialog(
                VideoCapture1.Video_Codecs.ToArray(),
                VideoCapture1.Audio_Codecs.ToArray())
        End If

        aviSettingsDialog.SaveSettings(aviOutput)

        If (aviOutput.Audio_UseMP3Encoder) Then

            Dim mp3Output = New MP3Output()
            aviOutput.MP3 = mp3Output
        End If
    End Sub

    Private Async Sub btStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStart.Click
        mmLog.Clear()

        VideoCapture1.Video_Sample_Grabber_Enabled = True

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")


        If cbRecordAudio.Checked Then
            VideoCapture1.Audio_RecordAudio = True
            VideoCapture1.Audio_PlayAudio = True
        Else
            VideoCapture1.Audio_RecordAudio = False
            VideoCapture1.Audio_PlayAudio = False
        End If

        'apply capture parameters
        VideoCapture1.Video_Renderer_SetAuto()

        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text

        VideoCapture1.Video_CaptureDevice = New VideoCaptureSource(cbVideoInputDevice.Text)
        VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text
        VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked

        VideoCapture1.Audio_CaptureDevice = New AudioCaptureSource(cbAudioInputDevice.Text)
        VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text
        VideoCapture1.Audio_CaptureDevice.Format_UseBest = cbUseBestAudioInputFormat.Checked

        If cbVideoInputFrameRate.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice.FrameRate = New VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text))
        End If

        If (rbPreview.Checked) Then
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview
        Else
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture
            VideoCapture1.Output_Filename = edOutput.Text

            Select Case (cbOutputFormat.SelectedIndex)
                Case 0
                    Dim aviOutput = New AVIOutput()
                    SetAVIOutput(aviOutput)
                    VideoCapture1.Output_Format = aviOutput
                Case 1
                    Dim wmvOutput = New WMVOutput()
                    SetWMVOutput(wmvOutput)
                    VideoCapture1.Output_Format = wmvOutput
                Case 2
                    Dim mp4Output = New MP4Output()
                    SetMP4Output(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 3
                    Dim mp4Output = New MP4HWOutput()
                    SetMP4HWOutput(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 4
                    Dim gifOutput = New AnimatedGIFOutput()
                    SetGIFOutput(gifOutput)

                    VideoCapture1.Output_Format = gifOutput
                Case 5
                    Dim tsOutput = New MPEGTSOutput()
                    SetMPEGTSOutput(tsOutput)
                    VideoCapture1.Output_Format = tsOutput
                Case 6
                    Dim movOutput = New MOVOutput()
                    SetMOVOutput(movOutput)
                    VideoCapture1.Output_Format = movOutput
            End Select
        End If

        'Audio processing
        VideoCapture1.Audio_Effects_Clear(-1)
        VideoCapture1.Audio_Effects_Enabled = True

        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)

        VideoCapture1.Video_Effects_Enabled = True
        VideoCapture1.Video_Effects_MergeImageLogos = cbMergeImageLogos.Checked
        VideoCapture1.Video_Effects_MergeTextLogos = cbMergeTextLogos.Checked
        VideoCapture1.Video_Effects_Clear()
        lbLogos.Items.Clear()
        ' ConfigureVideoEffects()

        ' Separate capture
        If cbSeparateCapture.Checked Then
            VideoCapture1.SeparateCapture_Enabled = True
            If (rbSeparateCaptureStartManually.Checked) Then
                VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.Normal
                VideoCapture1.SeparateCapture_AutostartCapture = False
            ElseIf (rbSeparateCaptureSplitByDuration.Checked) Then
                VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.SplitByDuration
                VideoCapture1.SeparateCapture_AutostartCapture = True
                VideoCapture1.SeparateCapture_TimeThreshold = TimeSpan.FromMilliseconds(Convert.ToInt32(edSeparateCaptureDuration.Text))
            ElseIf (rbSeparateCaptureSplitBySize.Checked) Then
                VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.SplitByFileSize
                VideoCapture1.SeparateCapture_AutostartCapture = True
                VideoCapture1.SeparateCapture_FileSizeThreshold = Convert.ToInt32(edSeparateCaptureFileSize.Text) * 1024 * 1024
            End If
        Else
            VideoCapture1.SeparateCapture_Enabled = False
        End If

        Await VideoCapture1.StartAsync()

        tcMain.SelectedIndex = 5
        tmRecording.Start()
    End Sub

    Private Async Sub btStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStop.Click
        tmRecording.Stop()
        Await VideoCapture1.StopAsync()
    End Sub

    Private Async Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Await CreateEngineAsync()

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        AddHandler tmRecording.Elapsed, AddressOf UpdateRecordingTime

        screenshotSaveDialog = New SaveFileDialog()
        screenshotSaveDialog.FileName = "image.jpg"
        screenshotSaveDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff"
        screenshotSaveDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        cbOutputFormat.SelectedIndex = 2

        For i As Int32 = 0 To VideoCapture1.Video_CaptureDevices.Count - 1
            cbVideoInputDevice.Items.Add(VideoCapture1.Video_CaptureDevices.Item(i).Name)
        Next

        If cbVideoInputDevice.Items.Count > 0 Then
            cbVideoInputDevice.SelectedIndex = 0
        End If

        cbVideoInputDevice_SelectedIndexChanged(Nothing, Nothing)

        For i As Int32 = 0 To VideoCapture1.Audio_CaptureDevices.Count - 1
            cbAudioInputDevice.Items.Add(VideoCapture1.Audio_CaptureDevices.Item(i).Name)
        Next

        If (cbAudioInputDevice.Items.Count > 0) Then
            cbAudioInputDevice.SelectedIndex = 0
            cbAudioInputDevice_SelectedIndexChanged(Nothing, Nothing)
        End If

        cbAudioInputLine.Items.Clear()

        Dim deviceItem As List(Of AudioCaptureDeviceInfo) =
                (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text).ToList()
        If Not IsNothing(deviceItem) And deviceItem.Any() Then
            Dim lines = deviceItem.FirstOrDefault.Lines
            For Each item As String In lines
                cbAudioInputLine.Items.Add(item)
            Next

            If cbAudioInputLine.Items.Count > 0 Then
                cbAudioInputLine.SelectedIndex = 0
            End If
        End If

        Dim defaultAudioRenderer = String.Empty
        For i As Integer = 0 To VideoCapture1.Audio_OutputDevices.Count - 1
            cbAudioOutputDevice.Items.Add(VideoCapture1.Audio_OutputDevices.Item(i))

            If (VideoCapture1.Audio_OutputDevices.Item(i).Contains("Default DirectSound Device")) Then
                defaultAudioRenderer = VideoCapture1.Audio_OutputDevices.Item(i)
            End If
        Next i

        If cbAudioOutputDevice.Items.Count > 0 Then
            If (String.IsNullOrEmpty(defaultAudioRenderer)) Then
                cbAudioOutputDevice.SelectedIndex = 0
            Else
                cbAudioOutputDevice.Text = defaultAudioRenderer
            End If

            cbAudioOutputDevice_SelectedIndexChanged(Nothing, Nothing)
        End If

        For i As Int32 = 0 To VideoCapture1.Audio_Effects_Equalizer_Presets.Count - 1
            cbAudEqualizerPreset.Items.Add(VideoCapture1.Audio_Effects_Equalizer_Presets.Item(i))
        Next

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")
    End Sub

    Private Sub llVideoTutorials_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles llVideoTutorials.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub Log(msg As String)
        If (IsHandleCreated) Then
            Invoke(Sub()
                       mmLog.Text = mmLog.Text + msg + Environment.NewLine
                   End Sub)
        End If
    End Sub

    Private Sub VideoCapture1_OnError(ByVal sender As System.Object, ByVal e As ErrorsEventArgs) Handles VideoCapture1.OnError
        Log(e.Message)
    End Sub

    Private Sub cbOutputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputFormat.SelectedIndexChanged
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 1
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv")
            Case 2
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 3
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 4
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif")
            Case 5
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts")
            Case 6
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov")
        End Select
    End Sub

    Private Async Sub btResume_Click(sender As Object, e As EventArgs) Handles btResume.Click
        Await VideoCapture1.ResumeAsync()
    End Sub

    Private Async Sub btPause_Click(sender As Object, e As EventArgs) Handles btPause.Click
        Await VideoCapture1.PauseAsync()
    End Sub

    Private Sub UpdateRecordingTime()
        If Me.IsHandleCreated Then
            Dim ts = VideoCapture1.Duration_Time()

            If (Math.Abs(ts.TotalMilliseconds) < 0.01) Then
                Return
            End If

            BeginInvoke(Sub()
                            lbTimestamp.Text = $"Recording time: " + String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
                        End Sub)
        End If
    End Sub

    Private Sub btOutputConfigure_Click(sender As Object, e As EventArgs) Handles btOutputConfigure.Click
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 1
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
                End If

                wmvSettingsDialog.WMA = False
                wmvSettingsDialog.ShowDialog(Me)
            Case 2
                If (_mp4SettingsDialog Is Nothing) Then
                    _mp4SettingsDialog = New MP4SettingsDialog()
                End If

                _mp4SettingsDialog.ShowDialog(Me)
            Case 3
                If (mp4HWSettingsDialog Is Nothing) Then
                    mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
                End If

                mp4HWSettingsDialog.ShowDialog(Me)
            Case 4
                If (gifSettingsDialog Is Nothing) Then
                    gifSettingsDialog = New GIFSettingsDialog()
                End If

                gifSettingsDialog.ShowDialog(Me)
            Case 5
                If (mpegTSSettingsDialog Is Nothing) Then
                    mpegTSSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS)
                End If

                mpegTSSettingsDialog.ShowDialog(Me)
            Case 6
                If (movSettingsDialog Is Nothing) Then
                    movSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV)
                End If

                movSettingsDialog.ShowDialog(Me)
        End Select
    End Sub

    Private Async Sub btSaveScreenshot_Click(sender As Object, e As EventArgs) Handles btSaveScreenshot.Click
        If (screenshotSaveDialog.ShowDialog(Me) = DialogResult.OK) Then
            Dim filename = screenshotSaveDialog.FileName
            Dim ext = Path.GetExtension(filename)?.ToLowerInvariant()
            Select Case (ext)
                Case ".bmp"
                    Await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Bmp, 0)
                Case ".jpg"
                    Await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Jpeg, 85)
                Case ".gif"
                    Await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Gif, 0)
                Case ".png"
                    Await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Png, 0)
                Case ".tiff"
                    Await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Tiff, 0)
            End Select
        End If
    End Sub

    Private Sub ConfigureVideoEffects()

        'Other effects
        If tbLightness.Value > 0 Then
            tbLightness_Scroll(Nothing, Nothing)
        End If

        If tbSaturation.Value < 255 Then
            tbSaturation_Scroll(Nothing, Nothing)
        End If

        If tbContrast.Value > 0 Then
            tbContrast_Scroll(Nothing, Nothing)
        End If

        If tbDarkness.Value > 0 Then
            tbDarkness_Scroll(Nothing, Nothing)
        End If

        If cbGreyscale.Checked Then
            cbGreyscale_CheckedChanged(Nothing, Nothing)
        End If

        If cbInvert.Checked Then
            cbInvert_CheckedChanged(Nothing, Nothing)
        End If

        If cbFlipX.Checked Then
            cbFlipX_CheckedChanged(Nothing, Nothing)
        End If

        If cbFlipY.Checked Then
            cbFlipY_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub tbLightness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbLightness.Scroll

        Dim intf As IVideoEffectLightness
        Dim effect = VideoCapture1.Video_Effects_Get("Lightness")
        If (IsNothing(effect)) Then
            intf = New VideoEffectLightness(True, tbLightness.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbLightness.Value
            End If
        End If

    End Sub

    Private Sub tbSaturation_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSaturation.Scroll

        Dim intf As IVideoEffectSaturation
        Dim effect = VideoCapture1.Video_Effects_Get("Saturation")
        If (IsNothing(effect)) Then
            intf = New VideoEffectSaturation(tbSaturation.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else

            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbSaturation.Value
            End If
        End If

    End Sub

    Private Sub tbContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbContrast.Scroll

        Dim intf As IVideoEffectContrast
        Dim effect = VideoCapture1.Video_Effects_Get("Contrast")
        If (IsNothing(effect)) Then
            intf = New VideoEffectContrast(True, tbContrast.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbContrast.Value
            End If
        End If

    End Sub

    Private Sub tbDarkness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbDarkness.Scroll

        Dim intf As IVideoEffectDarkness
        Dim effect = VideoCapture1.Video_Effects_Get("Darkness")
        If (IsNothing(effect)) Then
            intf = New VideoEffectDarkness(True, tbDarkness.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbDarkness.Value
            End If
        End If

    End Sub

    Private Sub cbGreyscale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbGreyscale.CheckedChanged

        Dim intf As IVideoEffectGrayscale
        Dim effect = VideoCapture1.Video_Effects_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New VideoEffectGrayscale(cbGreyscale.Checked)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGreyscale.Checked
            End If
        End If

    End Sub

    Private Sub cbInvert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbInvert.CheckedChanged

        Dim intf As IVideoEffectInvert
        Dim effect = VideoCapture1.Video_Effects_Get("Invert")
        If (IsNothing(effect)) Then
            intf = New VideoEffectInvert(cbInvert.Checked)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbInvert.Checked
            End If
        End If

    End Sub

    Private Sub cbFlipX_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipX.CheckedChanged
        Dim flip As IVideoEffectFlipDown
        Dim effect = VideoCapture1.Video_Effects_Get("FlipDown")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipHorizontal(cbFlipX.Checked)
            VideoCapture1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipX.Checked
            End If
        End If
    End Sub

    Private Sub cbFlipY_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipY.CheckedChanged
        Dim flip As IVideoEffectFlipRight
        Dim effect = VideoCapture1.Video_Effects_Get("FlipRight")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipVertical(cbFlipY.Checked)
            VideoCapture1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipY.Checked
            End If
        End If
    End Sub

    Private Sub btImageLogoAdd_Click(sender As Object, e As EventArgs) Handles btImageLogoAdd.Click
        Dim dlg = New ImageLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoCapture1)
        Dim effect = New VideoEffectImageLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbLogos.Items.Add(effect.Name)

        dlg.Fill(effect)
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btTextLogoAdd_Click(sender As Object, e As EventArgs) Handles btTextLogoAdd.Click
        Dim dlg = New TextLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoCapture1)
        Dim effect = New VideoEffectTextLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbLogos.Items.Add(effect.Name)
        dlg.Fill(effect)

        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btLogoEdit_Click(sender As Object, e As EventArgs) Handles btLogoEdit.Click
        If (lbLogos.SelectedItem IsNot Nothing) Then
            Dim effect = VideoCapture1.Video_Effects_Get(lbLogos.SelectedItem)
            If (effect.GetEffectType() = VideoEffectType.TextLogo) Then
                Dim dlg = New TextLogoSettingsDialog()

                dlg.Attach(effect)

                dlg.ShowDialog(Me)
                dlg.Dispose()
            ElseIf (effect.GetEffectType() = VideoEffectType.ImageLogo) Then
                Dim dlg = New ImageLogoSettingsDialog()

                dlg.Attach(effect)

                dlg.ShowDialog(Me)
                dlg.Dispose()
            End If
        End If
    End Sub

    Private Sub btLogoRemove_Click(sender As Object, e As EventArgs) Handles btLogoRemove.Click
        If (lbLogos.SelectedItem IsNot Nothing) Then
            VideoCapture1.Video_Effects_Remove(lbLogos.SelectedItem)
            lbLogos.Items.Remove(lbLogos.SelectedItem)
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyEngine()
    End Sub

    Private Async Sub btSeparateCaptureStart_Click(sender As Object, e As EventArgs) Handles btSeparateCaptureStart.Click
        Await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text)
    End Sub

    Private Async Sub btSeparateCapturePause_Click(sender As Object, e As EventArgs) Handles btSeparateCapturePause.Click
        Await VideoCapture1.SeparateCapture_PauseAsync()
    End Sub

    Private Async Sub btSeparateCaptureResume_Click(sender As Object, e As EventArgs) Handles btSeparateCaptureResume.Click
        Await VideoCapture1.SeparateCapture_ResumeAsync()
    End Sub

    Private Async Sub btSeparateCaptureStop_Click(sender As Object, e As EventArgs) Handles btSeparateCaptureStop.Click
        Await VideoCapture1.SeparateCapture_StopAsync()
    End Sub

    Private Async Sub btSeparateCaptureChangeFilename_Click(sender As Object, e As EventArgs) Handles btSeparateCaptureChangeFilename.Click
        Await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text)
    End Sub
End Class

' ReSharper restore InconsistentNaming