' ReSharper disable InconsistentNaming

Imports System.Linq
Imports VisioForge.Controls.UI
Imports VisioForge.Controls.UI.Dialogs.OutputFormats
Imports VisioForge.Types
Imports VisioForge.Controls.VideoCapture
Imports VisioForge.Tools
Imports VisioForge.Types.Output
Imports System.IO
Imports VisioForge.Types.Events
Imports VisioForge.Types.VideoCapture
Imports VisioForge.Types.AudioEffects

Public Class Form1

    Dim WithEvents VideoCapture1 As VideoCaptureCore

    Dim pcmSettingsDialog As PCMSettingsDialog

    Dim mp3SettingsDialog As MP3SettingsDialog

    Dim flacSettingsDialog As FLACSettingsDialog

    Dim oggVorbisSettingsDialog As OggVorbisSettingsDialog

    Dim speexSettingsDialog As SpeexSettingsDialog

    Dim m4aSettingsDialog As M4ASettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        VideoCapture1 = New VideoCaptureCore()

        AddHandler VideoCapture1.OnError, AddressOf VideoCapture1_OnError
        AddHandler VideoCapture1.OnAudioFrameBuffer, AddressOf VideoCapture1_OnAudioFrameBuffer
        AddHandler VideoCapture1.OnLicenseRequired, AddressOf VideoCapture1_OnLicenseRequired
        AddHandler VideoCapture1.OnStop, AddressOf VideoCapture1_OnStop

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        Dim i As Integer
        For i = 0 To VideoCapture1.Audio_CaptureDevices.Count - 1
            cbAudioInputDevice.Items.Add(VideoCapture1.Audio_CaptureDevices.Item(i).Name)
        Next

        If cbAudioInputDevice.Items.Count > 0 Then
            cbAudioInputDevice.SelectedIndex = 0
            cbAudioInputDevice_SelectedIndexChanged(Nothing, Nothing)
        End If

        cbAudioInputLine.Items.Clear()

        Dim deviceItem As List(Of AudioCaptureDeviceInfo) = (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text).ToList()
        If Not IsNothing(deviceItem) And deviceItem.Any() Then
            Dim lines = deviceItem.First.Lines
            For Each item As String In lines
                cbAudioInputLine.Items.Add(item)
            Next

            If cbAudioInputLine.Items.Count > 0 Then
                cbAudioInputLine.SelectedIndex = 0
            End If
        End If

        Dim defaultAudioRenderer = String.Empty
        For i = 0 To VideoCapture1.Audio_OutputDevices.Count - 1
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

        For i = 0 To VideoCapture1.Audio_Effects_Equalizer_Presets.Count - 1
            cbAudEqualizerPreset.Items.Add(VideoCapture1.Audio_Effects_Equalizer_Presets.Item(i))
        Next

        cbOutputFormat.SelectedIndex = 1
        cbAudEqualizerPreset.SelectedIndex = 0
        cbAudEqualizerPreset_SelectedIndexChanged(Nothing, Nothing)
        cbMode.SelectedIndex = 0

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp3")
    End Sub

    Private Sub cbAudioInputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudioInputDevice.SelectedIndexChanged
        If cbAudioInputDevice.SelectedIndex <> -1 Then
            cbAudioInputFormat.Items.Clear()

            Dim deviceItem = (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text)?.FirstOrDefault()
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
    Private Sub btAudioInputDeviceSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAudioInputDeviceSettings.Click
        VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text)
    End Sub

    Private Sub cbUseBestAudioInputFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbUseBestAudioInputFormat.CheckedChanged
        cbAudioInputFormat.Enabled = Not cbUseBestAudioInputFormat.Checked
    End Sub

    Private Sub cbAudioOutputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudioOutputDevice.SelectedIndexChanged
        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text
    End Sub

    Private Sub tbAudioVolume_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioVolume.Scroll
        VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value)
    End Sub

    Private Sub tbAudioBalance_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioBalance.Scroll
        VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value)
        VideoCapture1.Audio_OutputDevice_Balance_Get()
    End Sub

    Private Sub cbAudAmplifyEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudAmplifyEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, 0, cbAudAmplifyEnabled.Checked)
    End Sub

    Private Sub tbAudAmplifyAmp_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudAmplifyAmp.Scroll
        VideoCapture1.Audio_Effects_Amplify(-1, 0, tbAudAmplifyAmp.Value * 10, False)
    End Sub

    Private Sub cbAudEqualizerEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudEqualizerEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, 1, cbAudEqualizerEnabled.Checked)
    End Sub

    Private Sub tbAudEq0_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq0.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 0, tbAudEq0.Value)
    End Sub

    Private Sub tbAudEq1_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq1.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 1, tbAudEq1.Value)
    End Sub

    Private Sub tbAudEq2_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq2.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 2, tbAudEq2.Value)
    End Sub

    Private Sub tbAudEq3_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq3.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 3, tbAudEq3.Value)
    End Sub

    Private Sub tbAudEq4_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq4.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 4, tbAudEq4.Value)
    End Sub

    Private Sub tbAudEq5_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq5.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 5, tbAudEq5.Value)
    End Sub

    Private Sub tbAudEq6_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq6.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 6, tbAudEq6.Value)
    End Sub

    Private Sub tbAudEq7_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq7.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 7, tbAudEq7.Value)
    End Sub

    Private Sub tbAudEq8_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq8.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 8, tbAudEq8.Value)
    End Sub

    Private Sub tbAudEq9_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudEq9.Scroll
        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 9, tbAudEq9.Value)
    End Sub

    Private Sub cbAudEqualizerPreset_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudEqualizerPreset.SelectedIndexChanged
        VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, 1, cbAudEqualizerPreset.SelectedIndex)
        btAudEqRefresh_Click(sender, e)
    End Sub

    Private Sub btAudEqRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAudEqRefresh.Click
        tbAudEq0.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 0)
        tbAudEq1.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 1)
        tbAudEq2.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 2)
        tbAudEq3.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 3)
        tbAudEq4.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 4)
        tbAudEq5.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 5)
        tbAudEq6.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 6)
        tbAudEq7.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 7)
        tbAudEq8.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 8)
        tbAudEq9.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 9)
    End Sub

    Private Sub cbAudTrueBassEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudTrueBassEnabled.CheckedChanged
        VideoCapture1.Audio_Effects_Enable(-1, 5, cbAudTrueBassEnabled.Checked)
    End Sub

    Private Sub tbAudTrueBass_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudTrueBass.Scroll
        VideoCapture1.Audio_Effects_TrueBass(-1, 5, 200, False, tbAudTrueBass.Value)
    End Sub
    Private Sub cbAudSound3DEnabled_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudSound3DEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, 3, cbAudSound3DEnabled.Checked)

    End Sub
    Private Sub tbAud3DSound_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAud3DSound.Scroll

        VideoCapture1.Audio_Effects_Sound3D(-1, 3, tbAud3DSound.Value)

    End Sub
    Private Sub btSelectOutput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSelectOutput.Click

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = saveFileDialog1.FileName
        End If

    End Sub

    Private Sub SetM4AOutput(ByRef m4aOutput As M4AOutput)
        If (m4aSettingsDialog Is Nothing) Then
            m4aSettingsDialog = New M4ASettingsDialog()
        End If

        m4aSettingsDialog.SaveSettings(m4aOutput)
    End Sub

    Private Sub SetWMAOutput(ByRef wmaOutput As WMAOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
        End If

        wmvSettingsDialog.WMA = True
        wmvSettingsDialog.SaveSettings(wmaOutput)
    End Sub

    Private Sub SetOGGOutput(ByRef oggVorbisOutput As OGGVorbisOutput)
        If (oggVorbisSettingsDialog Is Nothing) Then
            oggVorbisSettingsDialog = New OggVorbisSettingsDialog()
        End If

        oggVorbisSettingsDialog.SaveSettings(oggVorbisOutput)
    End Sub

    Private Sub SetSpeexOutput(ByRef speexOutput As SpeexOutput)
        If (speexSettingsDialog Is Nothing) Then
            speexSettingsDialog = New SpeexSettingsDialog()
        End If

        speexSettingsDialog.SaveSettings(speexOutput)
    End Sub

    Private Sub SetFLACOutput(ByRef flacOutput As FLACOutput)
        If (flacSettingsDialog Is Nothing) Then
            flacSettingsDialog = New FLACSettingsDialog()
        End If

        flacSettingsDialog.SaveSettings(flacOutput)
    End Sub

    Private Sub SetMP3Output(ByRef mp3Output As MP3Output)
        If (mp3SettingsDialog Is Nothing) Then
            mp3SettingsDialog = New MP3SettingsDialog()
        End If

        mp3SettingsDialog.SaveSettings(mp3Output)
    End Sub

    Private Sub SetACMOutput(ByRef acmOutput As ACMOutput)
        If (pcmSettingsDialog Is Nothing) Then
            pcmSettingsDialog = New PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray())
        End If

        pcmSettingsDialog.SaveSettings(acmOutput)
    End Sub


    Private Async Sub btStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStart.Click
        mmLog.Clear()

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text

        VideoCapture1.Audio_CaptureDevice = New AudioCaptureSource(cbAudioInputDevice.Text)
        VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text
        VideoCapture1.Audio_CaptureDevice.Format_UseBest = False
        VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text
        VideoCapture1.Audio_PlayAudio = cbPlayAudio.Checked

        VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None

        If cbMode.SelectedIndex = 0 Then
            VideoCapture1.Mode = VideoCaptureMode.AudioPreview
            VideoCapture1.Audio_RecordAudio = True
        Else
            VideoCapture1.Mode = VideoCaptureMode.AudioCapture
            VideoCapture1.Audio_RecordAudio = True
            VideoCapture1.Output_Filename = edOutput.Text

            Select Case (cbOutputFormat.SelectedIndex)
                Case 0
                    Dim acmOutput = New ACMOutput()
                    SetACMOutput(acmOutput)
                    VideoCapture1.Output_Format = acmOutput
                Case 1
                    Dim mp3Output = New MP3Output()
                    SetMP3Output(mp3Output)
                    VideoCapture1.Output_Format = mp3Output
                Case 2
                    Dim wmaOutput = New WMAOutput()
                    SetWMAOutput(wmaOutput)
                    VideoCapture1.Output_Format = wmaOutput
                Case 3
                    Dim oggVorbisOutput = New OGGVorbisOutput()
                    SetOGGOutput(oggVorbisOutput)
                    VideoCapture1.Output_Format = oggVorbisOutput
                Case 4
                    Dim flacOutput = New FLACOutput()
                    SetFLACOutput(flacOutput)
                    VideoCapture1.Output_Format = flacOutput
                Case 5
                    Dim speexOutput = New SpeexOutput()
                    SetSpeexOutput(speexOutput)
                    VideoCapture1.Output_Format = speexOutput
                Case 6
                    Dim m4aOutput = New M4AOutput()
                    SetM4AOutput(m4aOutput)
                    VideoCapture1.Output_Format = m4aOutput
            End Select
        End If

        'Audio processing
        VideoCapture1.Audio_Effects_Clear(-1)
        VideoCapture1.Audio_Effects_Enabled = True

        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Amplify, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)

        Await VideoCapture1.StartAsync()

    End Sub
    Private Async Sub btStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStop.Click

        Await VideoCapture1.StopAsync()

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

    Private Sub VideoCapture1_OnLicenseRequired(sender As Object, e As LicenseEventArgs) Handles VideoCapture1.OnLicenseRequired
        Log("(NOT ERROR) " + e.Message)
    End Sub

    Private Sub VideoCapture1_OnAudioFrameBuffer(sender As Object, e As AudioFrameBufferEventArgs)

        If (e.Frame.Timestamp.TotalMilliseconds < 0) Then
            Return
        End If

        BeginInvoke(Sub()
                        lbTimestamp.Text = $"Recording time: " + String.Format("{0:00}:{1:00}:{2:00}", e.Frame.Timestamp.Hours, e.Frame.Timestamp.Minutes, e.Frame.Timestamp.Seconds)
                    End Sub)
    End Sub

    Private Sub VideoCapture1_OnStop(sender As Object, e As EventArgs)

        If Me.IsHandleCreated Then
            BeginInvoke(Sub()
                            lbTimestamp.Text = $"Recording time: 00:00:00"
                        End Sub)
        End If
    End Sub

    Private Sub btOutputConfigure_Click(sender As Object, e As EventArgs) Handles btOutputConfigure.Click
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                If (pcmSettingsDialog Is Nothing) Then
                    pcmSettingsDialog = New PCMSettingsDialog(VideoCapture1.Audio_Codecs().ToArray())
                End If

                pcmSettingsDialog.ShowDialog(Me)
            Case 1
                If (mp3SettingsDialog Is Nothing) Then
                    mp3SettingsDialog = New MP3SettingsDialog()
                End If

                mp3SettingsDialog.ShowDialog(Me)
            Case 2
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
                End If

                wmvSettingsDialog.WMA = True
                wmvSettingsDialog.ShowDialog(Me)
            Case 3
                If (oggVorbisSettingsDialog Is Nothing) Then
                    oggVorbisSettingsDialog = New OggVorbisSettingsDialog()
                End If

                oggVorbisSettingsDialog.ShowDialog(Me)
            Case 4
                If (flacSettingsDialog Is Nothing) Then
                    flacSettingsDialog = New FLACSettingsDialog()
                End If

                flacSettingsDialog.ShowDialog(Me)
            Case 5
                If (speexSettingsDialog Is Nothing) Then
                    speexSettingsDialog = New SpeexSettingsDialog()
                End If

                speexSettingsDialog.ShowDialog(Me)
            Case 6
                If (m4aSettingsDialog Is Nothing) Then
                    m4aSettingsDialog = New M4ASettingsDialog()
                End If

                m4aSettingsDialog.ShowDialog(Me)
        End Select
    End Sub

    Private Sub cbOutputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputFormat.SelectedIndexChanged
        Select Case (cbOutputFormat.SelectedIndex)
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
End Class

' ReSharper restore InconsistentNaming