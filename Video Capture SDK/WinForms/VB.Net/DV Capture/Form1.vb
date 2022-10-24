' ReSharper disable InconsistentNaming

Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Timers
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoCapture
Imports VisioForge.Core.Types.VideoEffects
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.VideoCapture

Public Class Form1

    Dim mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Dim mpegTSSettingsDialog As HWEncodersOutputSettingsDialog

    Dim movSettingsDialog As HWEncodersOutputSettingsDialog

    Dim _mp4SettingsDialog As MP4SettingsDialog

    Dim aviSettingsDialog As AVISettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Dim dvSettingsDialog As DVSettingsDialog

    Dim gifSettingsDialog As GIFSettingsDialog

    Dim screenshotSaveDialog As SaveFileDialog

    Private tmRecording As Timer = New Timer(1000)

    Dim WithEvents VideoCapture1 As VideoCaptureCore

    Private Sub CreateEngine()
        Dim vv As IVideoView = VideoView1
        VideoCapture1 = New VideoCaptureCore(vv)
    End Sub

    Private Sub DestroyEngine()
        VideoCapture1.Dispose()
        VideoCapture1 = Nothing
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

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CreateEngine()

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        cbOutputFormat.SelectedIndex = 4

        screenshotSaveDialog = New SaveFileDialog()
        screenshotSaveDialog.FileName = "image.jpg"
        screenshotSaveDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff"
        screenshotSaveDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        AddHandler tmRecording.Elapsed, AddressOf UpdateRecordingTime

        For i As Int32 = 0 To VideoCapture1.Video_CaptureDevices.Count - 1
            cbVideoInputDevice.Items.Add(VideoCapture1.Video_CaptureDevices.Item(i).Name)
        Next

        If cbVideoInputDevice.Items.Count > 0 Then
            cbVideoInputDevice.SelectedIndex = 0
        End If

        cbVideoInputDevice_SelectedIndexChanged(Nothing, Nothing)

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
        End If

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")

        VideoCapture1.Video_Renderer_SetAuto()
    End Sub

    Private Sub cbVideoInputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbVideoInputDevice.SelectedIndexChanged
        If cbVideoInputDevice.SelectedIndex <> -1 Then
            Dim deviceItem = (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbVideoInputDevice.Text)?.FirstOrDefault()
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

    Private Sub cbUseBestVideoInputFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbUseBestVideoInputFormat.CheckedChanged
        cbVideoInputFormat.Enabled = Not cbUseBestVideoInputFormat.Checked
    End Sub

    Private Sub btVideoCaptureDeviceSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btVideoCaptureDeviceSettings.Click
        VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text)
    End Sub

    Private Sub tbAudioVolume_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioVolume.Scroll
        VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value)
    End Sub

    Private Sub tbAudioBalance_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbAudioBalance.Scroll
        VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value)
        VideoCapture1.Audio_OutputDevice_Balance_Get()
    End Sub

    Private Sub btSelectOutput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSelectOutput.Click
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = saveFileDialog1.FileName
        End If
    End Sub

    Private Async Sub btDVFF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVFF.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.FastestFwd)
    End Sub

    Private Async Sub btDVPause_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVPause.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Pause)
    End Sub

    Private Async Sub btDVRewind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVRewind.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Rew)
    End Sub

    Private Async Sub btDVPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVPlay.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Play)
    End Sub

    Private Async Sub btDVStepFWD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStepFWD.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.StepFw)
    End Sub

    Private Async Sub btDVStepRev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStepRev.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.StepRev)
    End Sub

    Private Async Sub btDVStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStop.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Stop)
    End Sub

    Private Sub SetWMVOutput(ByRef wmvOutput As WMVOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
        End If

        wmvSettingsDialog.WMA = False
        wmvSettingsDialog.SaveSettings(wmvOutput)
    End Sub

    Private Sub SetDVOutput(ByRef dvOutput As DVOutput)
        If (dvSettingsDialog Is Nothing) Then
            dvSettingsDialog = New DVSettingsDialog()
        End If

        dvSettingsDialog.SaveSettings(dvOutput)
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

    Private Async Sub btStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStart.Click
        mmLog.Clear()

        VideoCapture1.Video_Sample_Grabber_Enabled = True

        VideoCapture1.Video_Renderer.Zoom_Ratio = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftX = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftY = 0

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        If cbRecordAudio.Checked Then
            VideoCapture1.Audio_RecordAudio = True
            VideoCapture1.Audio_PlayAudio = False
        Else
            VideoCapture1.Audio_RecordAudio = False
            VideoCapture1.Audio_PlayAudio = False
        End If

        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text

        'apply capture parameters
        VideoCapture1.Video_CaptureDevice = New VideoCaptureSource(cbVideoInputDevice.Text)
        VideoCapture1.Video_CaptureDevice.IsAudioSource = True
        VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text
        VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked

        If cbVideoInputFrameRate.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice.FrameRate = New VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text))
        End If

        If rbPreview.Checked Then
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview
        Else
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture
            VideoCapture1.Output_Filename = edOutput.Text

            Select Case (cbOutputFormat.SelectedIndex)
                Case 0
                    Dim dvOutput = New DVOutput()
                    SetDVOutput(dvOutput)
                    VideoCapture1.Output_Format = dvOutput
                Case 1
                    VideoCapture1.Output_Format = New DirectCaptureDVOutput()
                Case 2
                    Dim aviOutput = New AVIOutput()
                    SetAVIOutput(aviOutput)
                    VideoCapture1.Output_Format = aviOutput
                Case 3
                    Dim wmvOutput = New WMVOutput()
                    SetWMVOutput(wmvOutput)
                    VideoCapture1.Output_Format = wmvOutput
                Case 4
                    Dim mp4Output = New MP4Output()
                    SetMP4Output(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 5
                    Dim mp4Output = New MP4HWOutput()
                    SetMP4HWOutput(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 6
                    Dim gifOutput = New AnimatedGIFOutput()
                    SetGIFOutput(gifOutput)
                    VideoCapture1.Output_Format = gifOutput
                Case 7
                    Dim tsOutput = New MPEGTSOutput()
                    SetMPEGTSOutput(tsOutput)
                    VideoCapture1.Output_Format = tsOutput
                Case 8
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

    Private Sub llVideoTutorials_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles llVideoTutorials.LinkClicked
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

    Private Sub btOutputConfigure_Click(sender As Object, e As EventArgs) Handles btOutputConfigure.Click
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                If (dvSettingsDialog Is Nothing) Then
                    dvSettingsDialog = New DVSettingsDialog()
                End If

                dvSettingsDialog.ShowDialog(Me)
            Case 1
                MessageBox.Show("No settings available for selected output format.")
            Case 2
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 3
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
                End If

                wmvSettingsDialog.WMA = False
                wmvSettingsDialog.ShowDialog(Me)
            Case 4
                If (_mp4SettingsDialog Is Nothing) Then
                    _mp4SettingsDialog = New MP4SettingsDialog()
                End If

                _mp4SettingsDialog.ShowDialog(Me)
            Case 5
                If (mp4HWSettingsDialog Is Nothing) Then
                    mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
                End If

                mp4HWSettingsDialog.ShowDialog(Me)
            Case 6
                If (gifSettingsDialog Is Nothing) Then

                    gifSettingsDialog = New GIFSettingsDialog()
                End If

                gifSettingsDialog.ShowDialog(Me)
            Case 7
                If (mpegTSSettingsDialog Is Nothing) Then

                    mpegTSSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS)
                End If

                mpegTSSettingsDialog.ShowDialog(Me)
            Case 8
                If (movSettingsDialog Is Nothing) Then

                    movSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV)
                End If

                movSettingsDialog.ShowDialog(Me)
        End Select
    End Sub

    Private Sub cbOutputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputFormat.SelectedIndexChanged
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
            Case 1
            Case 2
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 3
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv")
            Case 4
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 5
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 6
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif")
            Case 7
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts")
            Case 8
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov")
        End Select
    End Sub

    Private Async Sub btPause_Click(sender As Object, e As EventArgs) Handles btPause.Click
        Await VideoCapture1.PauseAsync()
    End Sub

    Private Async Sub btResume_Click(sender As Object, e As EventArgs) Handles btResume.Click
        Await VideoCapture1.ResumeAsync()
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

        If cbDeinterlaceCAVT.Checked Then
            cbDeinterlaceCAVT_CheckedChanged(Nothing, Nothing)
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

    Private Sub cbDeinterlaceCAVT_CheckedChanged(sender As Object, e As EventArgs) Handles cbDeinterlaceCAVT.CheckedChanged
        If VideoCapture1 Is Nothing Then
            Return
        End If

        Dim cavt As IVideoEffectDeinterlaceCAVT
        Dim effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT")
        If (effect Is Nothing) Then
            cavt = New VideoEffectDeinterlaceCAVT(cbDeinterlaceCAVT.Checked, 20)
            VideoCapture1.Video_Effects_Add(cavt)
        Else
            cavt = effect

            If (cavt IsNot Nothing) Then
                cavt.Enabled = cbDeinterlaceCAVT.Checked
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyEngine()
    End Sub
End Class

' ReSharper restore InconsistentNaming