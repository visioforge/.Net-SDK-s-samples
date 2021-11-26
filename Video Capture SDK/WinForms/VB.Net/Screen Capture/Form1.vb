' ReSharper disable InconsistentNaming

Imports System.IO
Imports System.Linq
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Types
Imports VisioForge.Types.Output
Imports VisioForge.Types.VideoEffects
Imports VisioForge.Core.VideoCapture
Imports VisioForge.Types.Events
Imports System.Drawing.Imaging
Imports VisioForge.Types.VideoCapture
Imports VisioForge.Core

Public Class Form1
    Dim mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Dim mpegTSSettingsDialog As HWEncodersOutputSettingsDialog

    Dim movSettingsDialog As HWEncodersOutputSettingsDialog

    Dim _mp4SettingsDialog As MP4SettingsDialog

    Dim aviSettingsDialog As AVISettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Dim gifSettingsDialog As GIFSettingsDialog

    Dim screenshotSaveDialog As SaveFileDialog

    Private WithEvents windowCaptureForm As WindowCaptureForm

    Private tmRecording As Timers.Timer = New Timers.Timer(1000)

    Dim WithEvents VideoCapture1 As VideoCaptureCore

    Private Sub CreateEngine()
        Dim vv As IVideoView = VideoView1
        VideoCapture1 = New VideoCaptureCore(vv)
    End Sub

    Private Sub DestroyEngine()
        VideoCapture1.Dispose()
        VideoCapture1 = Nothing
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        AddHandler tmRecording.Elapsed, AddressOf UpdateRecordingTime

        screenshotSaveDialog = New SaveFileDialog()
        screenshotSaveDialog.FileName = "image.jpg"
        screenshotSaveDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff"
        screenshotSaveDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        cbOutputFormat.SelectedIndex = 2

        For i As Int32 = 0 To VideoCapture1.Audio_CaptureDevices.Count - 1
            cbAudioInputDevice.Items.Add(VideoCapture1.Audio_CaptureDevices.Item(i).Name)
        Next

        If (cbAudioInputDevice.Items.Count > 0) Then
            cbAudioInputDevice.SelectedIndex = 0
            cbAudioInputDevice_SelectedIndexChanged(Nothing, Nothing)
        End If

        For Each screen As Screen In Screen.AllScreens
            cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace("\\.\DISPLAY", String.Empty))
        Next

        cbScreenCaptureDisplayIndex.Items.Add("All (fullscreen)")

        cbScreenCaptureDisplayIndex.SelectedIndex = 0
        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")

    End Sub

    Private Async Sub btScreenCaptureUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btScreenCaptureUpdate.Click
        Await VideoCapture1.Screen_Capture_UpdateParametersAsync(Convert.ToInt32(edScreenLeft.Text), Convert.ToInt32(edScreenTop.Text), cbScreenCapture_GrabMouseCursor.Checked)
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

    Private Function CreateScreenCaptureSource(screenID As Integer, forcedFullScreen As Boolean) As ScreenCaptureSourceSettings
        Dim source = New ScreenCaptureSourceSettings()

        If (rbScreenCaptureWindow.Checked) Then
            source.Mode = ScreenCaptureMode.Window
            source.WindowHandle = IntPtr.Zero

            Try
                If (windowCaptureForm Is Nothing) Then
                    MessageBox.Show("Window for screen capture is not specified.")
                    Return Nothing
                End If

                source.WindowHandle = windowCaptureForm.CapturedWindowHandle
            Catch
            End Try

            If (source.WindowHandle = IntPtr.Zero) Then
                MessageBox.Show("Incorrect window title for screen capture.")
                Return Nothing
            End If
        Else
            source.Mode = ScreenCaptureMode.Screen
        End If

        source.FrameRate = Convert.ToDouble(edScreenFrameRate.Text)
        source.FullScreen = rbScreenFullScreen.Checked Or forcedFullScreen
        source.Top = Convert.ToInt32(edScreenTop.Text)
        source.Bottom = Convert.ToInt32(edScreenBottom.Text)
        source.Left = Convert.ToInt32(edScreenLeft.Text)
        source.Right = Convert.ToInt32(edScreenRight.Text)
        source.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked
        source.DisplayIndex = screenID
        source.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked

        Return source
    End Function


    Private Async Sub btStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStart.Click

        VideoCapture1.Video_Sample_Grabber_Enabled = True

        mmLog.Clear()

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        'from screen
        Dim allScreens = cbScreenCaptureDisplayIndex.SelectedIndex = cbScreenCaptureDisplayIndex.Items.Count - 1

        If (allScreens) Then

            Dim n = cbScreenCaptureDisplayIndex.Items.Count - 1
            VideoCapture1.Screen_Capture_Source = CreateScreenCaptureSource(
                Convert.ToInt32(cbScreenCaptureDisplayIndex.Items(0)),
                True)

            If (n > 1) Then
                For i As Integer = 1 To n - 1
                    Dim source = CreateScreenCaptureSource(
                        Convert.ToInt32(cbScreenCaptureDisplayIndex.Items(i)),
                        True)
                    VideoCapture1.PIP_Mode = PIPMode.Horizontal
                    VideoCapture1.PIP_Sources_Add_ScreenSource(source, 0, 0, 0, 0)
                Next
            End If
        Else
            VideoCapture1.Screen_Capture_Source = CreateScreenCaptureSource(
                Convert.ToInt32(cbScreenCaptureDisplayIndex.Text),
                False)
        End If

        ' audio source
        If cbRecordAudio.Checked Then
            VideoCapture1.Audio_RecordAudio = True
            VideoCapture1.Audio_PlayAudio = False

            VideoCapture1.Audio_CaptureDevice = New AudioCaptureSource(cbAudioInputDevice.Text)
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text
            VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text
        Else
            VideoCapture1.Audio_RecordAudio = False
            VideoCapture1.Audio_PlayAudio = False
        End If

        'apply capture parameters
        VideoCapture1.Video_Renderer_SetAuto()

        VideoCapture1.Video_Effects_Enabled = True
        VideoCapture1.Video_Effects_Clear()

        If (rbPreview.Checked) Then
            VideoCapture1.Mode = VideoCaptureMode.ScreenPreview
        Else
            VideoCapture1.Mode = VideoCaptureMode.ScreenCapture
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

        VideoCapture1.Video_Effects_Enabled = True
        VideoCapture1.Video_Effects_Clear()
        lbLogos.Items.Clear()
        ConfigureVideoEffects()

        Await VideoCapture1.StartAsync()

        tcMain.SelectedIndex = 3
        tmRecording.Start()
    End Sub

    Private Async Sub btStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStop.Click

        tmRecording.Stop()
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

    Private Sub btScreenSourceWindowSelect_Click(sender As Object, e As EventArgs) Handles btScreenSourceWindowSelect.Click
        If (windowCaptureForm Is Nothing) Then
            windowCaptureForm = New WindowCaptureForm()
        End If

        windowCaptureForm.StartCapture()
    End Sub

    Private Sub WindowCaptureForm_OnCaptureHotkey(sender As Object, e As WindowCaptureEventArgs) Handles windowCaptureForm.OnCaptureHotkey
        windowCaptureForm.StopCapture()
        windowCaptureForm.Hide()

        lbScreenSourceWindowText.Text = e.Caption
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyEngine()
    End Sub
End Class

' ReSharper restore InconsistentNaming