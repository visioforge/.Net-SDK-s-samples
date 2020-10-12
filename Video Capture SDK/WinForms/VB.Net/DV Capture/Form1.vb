' ReSharper disable InconsistentNaming

Imports System.IO
Imports System.Linq
Imports System.Timers
Imports VisioForge.Controls.UI
Imports VisioForge.Controls.UI.Dialogs.OutputFormats
Imports VisioForge.Controls.UI.Dialogs.VideoEffects
Imports VisioForge.Types
Imports VisioForge.Tools
Imports VisioForge.Types.OutputFormat
Imports VisioForge.Types.VideoEffects

Public Class Form1

    Dim mp4v11SettingsDialog As MFSettingsDialog

    Dim mpegTSSettingsDialog As MFSettingsDialog

    Dim movSettingsDialog As MFSettingsDialog

    Dim mp4V10SettingsDialog As MP4v10SettingsDialog

    Dim aviSettingsDialog As AVISettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Dim dvSettingsDialog As DVSettingsDialog

    Dim gifSettingsDialog As GIFSettingsDialog

    Dim screenshotSaveDialog As SaveFileDialog

    ReadOnly tmRecording As Timer = New Timer(1000)

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

        Text += " (SDK v" + VideoCapture1.SDK_Version.ToString() + ", " + VideoCapture1.SDK_State + ")"

        cbOutputFormat.SelectedIndex = 4

        screenshotSaveDialog = New SaveFileDialog()
        screenshotSaveDialog.FileName = "image.jpg"
        screenshotSaveDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff"
        screenshotSaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\VisioForge\"

        AddHandler tmRecording.Elapsed, AddressOf UpdateRecordingTime

        For i As Int32 = 0 To VideoCapture1.Video_CaptureDevicesInfo.Count - 1
            cbVideoInputDevice.Items.Add(VideoCapture1.Video_CaptureDevicesInfo.Item(i).Name)
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

        edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\VisioForge\" + "output.mp4"

        VideoCapture1.Video_Renderer_SetAuto
    End Sub

    Private Sub cbVideoInputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbVideoInputDevice.SelectedIndexChanged
        If cbVideoInputDevice.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text

            Dim deviceItem = (From info In VideoCapture1.Video_CaptureDevicesInfo Where info.Name = cbVideoInputDevice.Text)?.First()
            If IsNothing(deviceItem) Then
                Exit Sub
            End If

            Dim formats = deviceItem.VideoFormats
            For Each item As String In formats
                cbVideoInputFormat.Items.Add(item)
            Next

            If cbVideoInputFormat.Items.Count > 0 Then
                cbVideoInputFormat.SelectedIndex = 0
                cbVideoInputFormat_SelectedIndexChanged(Nothing, Nothing)
            End If

            cbFramerate.Items.Clear()
            Dim frameRate = deviceItem.VideoFrameRates
            For Each item As String In frameRate
                cbFramerate.Items.Add(item)
            Next

            If cbFramerate.Items.Count > 0 Then
                cbFramerate.SelectedIndex = 0
            End If

            btVideoCaptureDeviceSettings.Enabled = deviceItem.DialogDefault
        End If
    End Sub

    Private Sub cbVideoInputFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbVideoInputFormat.SelectedIndexChanged
        If cbVideoInputFormat.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text
        Else
            VideoCapture1.Video_CaptureDevice_Format = ""
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
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.FastestFwd)
    End Sub

    Private Async Sub btDVPause_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVPause.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Pause)
    End Sub

    Private Async Sub btDVRewind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVRewind.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Rew)
    End Sub

    Private Async Sub btDVPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVPlay.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Play)
    End Sub

    Private Async Sub btDVStepFWD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStepFWD.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepFw)
    End Sub

    Private Async Sub btDVStepRev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStepRev.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepRev)
    End Sub

    Private Async Sub btDVStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDVStop.Click
        Await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Stop)
    End Sub

    Private Sub SetWMVOutput(ByRef wmvOutput As VFWMVOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
        End If

        wmvSettingsDialog.WMA = False
        wmvSettingsDialog.SaveSettings(wmvOutput)
    End Sub

    Private Sub SetDVOutput(ByRef dvOutput As VFDVOutput)
        If (dvSettingsDialog Is Nothing) Then
            dvSettingsDialog = New DVSettingsDialog()
        End If

        dvSettingsDialog.SaveSettings(dvOutput)
    End Sub

    Private Sub SetAVIOutput(ByRef aviOutput As VFAVIOutput)
        If (aviSettingsDialog Is Nothing) Then
            aviSettingsDialog = New AVISettingsDialog(
                VideoCapture1.Video_Codecs.ToArray(),
                VideoCapture1.Audio_Codecs.ToArray())
        End If

        aviSettingsDialog.SaveSettings(aviOutput)

        If (aviOutput.Audio_UseMP3Encoder) Then

            Dim mp3Output = New VFMP3Output()
            aviOutput.MP3 = mp3Output
        End If
    End Sub

    Private Sub SetMP4v11Output(ByRef mp4Output As VFMP4v11Output)
        If (mp4v11SettingsDialog Is Nothing) Then
            mp4v11SettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MP4v11)
        End If

        mp4v11SettingsDialog.SaveSettings(mp4Output)
    End Sub

    Private Sub SetMPEGTSOutput(ByRef mpegTSOutput As VFMPEGTSOutput)

        If (mpegTSSettingsDialog Is Nothing) Then
            mpegTSSettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MPEGTS)
        End If

        mpegTSSettingsDialog.SaveSettings(mpegTSOutput)
    End Sub

    Private Sub SetMOVOutput(ByRef mkvOutput As VFMOVOutput)

        If (movSettingsDialog Is Nothing) Then
            movSettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MOV)
        End If

        movSettingsDialog.SaveSettings(mkvOutput)
    End Sub

    Private Sub SetMP4v10Output(ByRef mp4Output As VFMP4v8v10Output)
        If (mp4V10SettingsDialog Is Nothing) Then
            mp4V10SettingsDialog = New MP4v10SettingsDialog()
        End If

        mp4V10SettingsDialog.SaveSettings(mp4Output)
    End Sub

    Private Sub SetGIFOutput(ByRef gifOutput As VFAnimatedGIFOutput)
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
        VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\VisioForge\"

        If cbRecordAudio.Checked Then
            VideoCapture1.Audio_RecordAudio = True
            VideoCapture1.Audio_PlayAudio = False
        Else
            VideoCapture1.Audio_RecordAudio = False
            VideoCapture1.Audio_PlayAudio = False
        End If

        'apply capture parameters
        VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text
        VideoCapture1.Video_CaptureDevice_IsAudioSource = True
        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text
        VideoCapture1.Audio_CaptureDevice_Format_UseBest = True
        VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text
        VideoCapture1.Video_CaptureDevice_Format_UseBest = cbUseBestVideoInputFormat.Checked

        If cbFramerate.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice_FrameRate = CSng(Convert.ToDouble(cbFramerate.Text))
        End If

        If rbPreview.Checked Then
            VideoCapture1.Mode = VFVideoCaptureMode.VideoPreview
        Else
            VideoCapture1.Mode = VFVideoCaptureMode.VideoCapture
            VideoCapture1.Output_Filename = edOutput.Text

            Select Case (cbOutputFormat.SelectedIndex)
                Case 0
                    Dim dvOutput = New VFDVOutput()
                    SetDVOutput(dvOutput)
                    VideoCapture1.Output_Format = dvOutput
                Case 1
                    VideoCapture1.Output_Format = New VFDirectCaptureDVOutput()
                Case 2
                    Dim aviOutput = New VFAVIOutput()
                    SetAVIOutput(aviOutput)
                    VideoCapture1.Output_Format = aviOutput
                Case 3
                    Dim wmvOutput = New VFWMVOutput()
                    SetWMVOutput(wmvOutput)
                    VideoCapture1.Output_Format = wmvOutput
                Case 4
                    Dim mp4Output = New VFMP4v8v10Output()
                    SetMP4v10Output(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 5
                    Dim mp4Output = New VFMP4v11Output()
                    SetMP4v11Output(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 6
                    Dim gifOutput = New VFAnimatedGIFOutput()
                    SetGIFOutput(gifOutput)
                    VideoCapture1.Output_Format = gifOutput
                Case 7
                    Dim tsOutput = New VFMPEGTSOutput()
                    SetMPEGTSOutput(tsOutput)
                    VideoCapture1.Output_Format = tsOutput
                Case 8
                    Dim movOutput = New VFMOVOutput()
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

    Private Sub VideoCapture1_OnLicenseRequired(sender As Object, e As LicenseEventArgs)  Handles VideoCapture1.OnLicenseRequired
        Log("(NOT ERROR) " + e.Message)
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
                If (mp4V10SettingsDialog Is Nothing) Then
                    mp4V10SettingsDialog = New MP4v10SettingsDialog()
                End If

                mp4V10SettingsDialog.ShowDialog(Me)
            Case 5
                If (mp4v11SettingsDialog Is Nothing) Then
                    mp4v11SettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MP4v11)
                End If

                mp4v11SettingsDialog.ShowDialog(Me)
            Case 6
                If (gifSettingsDialog Is Nothing) Then

                    gifSettingsDialog = New GIFSettingsDialog()
                End If

                gifSettingsDialog.ShowDialog(Me)
            Case 7
                If (mpegTSSettingsDialog Is Nothing) Then

                    mpegTSSettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MPEGTS)
                End If

                mpegTSSettingsDialog.ShowDialog(Me)
            Case 8
                If (movSettingsDialog Is Nothing) Then

                    movSettingsDialog = New MFSettingsDialog(MFSettingsDialogMode.MOV)
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
                    Await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.BMP, 0)
                Case ".jpg"
                    Await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.JPEG, 85)
                Case ".gif"
                    Await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.GIF, 0)
                Case ".png"
                    Await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.PNG, 0)
                Case ".tiff"
                    Await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.TIFF, 0)
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

        Dim intf As IVFVideoEffectLightness
        Dim effect = VideoCapture1.Video_Effects_Get("Lightness")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectLightness(True, tbLightness.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbLightness.Value
            End If
        End If

    End Sub

    Private Sub tbSaturation_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSaturation.Scroll

        Dim intf As IVFVideoEffectSaturation
        Dim effect = VideoCapture1.Video_Effects_Get("Saturation")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectSaturation(tbSaturation.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else

            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbSaturation.Value
            End If
        End If

    End Sub

    Private Sub tbContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbContrast.Scroll

        Dim intf As IVFVideoEffectContrast
        Dim effect = VideoCapture1.Video_Effects_Get("Contrast")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectContrast(True, tbContrast.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbContrast.Value
            End If
        End If

    End Sub

    Private Sub tbDarkness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbDarkness.Scroll

        Dim intf As IVFVideoEffectDarkness
        Dim effect = VideoCapture1.Video_Effects_Get("Darkness")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectDarkness(True, tbDarkness.Value)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbDarkness.Value
            End If
        End If

    End Sub

    Private Sub cbGreyscale_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbGreyscale.CheckedChanged

        Dim intf As IVFVideoEffectGrayscale
        Dim effect = VideoCapture1.Video_Effects_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectGrayscale(cbGreyscale.Checked)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGreyscale.Checked
            End If
        End If

    End Sub

    Private Sub cbInvert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbInvert.CheckedChanged

        Dim intf As IVFVideoEffectInvert
        Dim effect = VideoCapture1.Video_Effects_Get("Invert")
        If (IsNothing(effect)) Then
            intf = New VFVideoEffectInvert(cbInvert.Checked)
            VideoCapture1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbInvert.Checked
            End If
        End If

    End Sub

    Private Sub cbFlipX_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipX.CheckedChanged
        Dim flip As IVFVideoEffectFlipDown
        Dim effect = VideoCapture1.Video_Effects_Get("FlipDown")
        If (effect Is Nothing) Then
            flip = New VFVideoEffectFlipHorizontal(cbFlipX.Checked)
            VideoCapture1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipX.Checked
            End If
        End If
    End Sub

    Private Sub cbFlipY_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipY.CheckedChanged
        Dim flip As IVFVideoEffectFlipRight
        Dim effect = VideoCapture1.Video_Effects_Get("FlipRight")
        If (effect Is Nothing) Then
            flip = New VFVideoEffectFlipVertical(cbFlipY.Checked)
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
        Dim effect = New VFVideoEffectImageLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbLogos.Items.Add(effect.Name)

        dlg.Fill(effect)
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btTextLogoAdd_Click(sender As Object, e As EventArgs) Handles btTextLogoAdd.Click
        Dim dlg = New TextLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoCapture1)
        Dim effect = New VFVideoEffectTextLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbLogos.Items.Add(effect.Name)
        dlg.Fill(effect)

        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btLogoEdit_Click(sender As Object, e As EventArgs) Handles btLogoEdit.Click
        If (lbLogos.SelectedItem IsNot Nothing) Then
            Dim effect = VideoCapture1.Video_Effects_Get(lbLogos.SelectedItem)
            If (effect.GetEffectType() = VFVideoEffectType.TextLogo) Then
                Dim dlg = New TextLogoSettingsDialog()

                dlg.Attach(effect)

                dlg.ShowDialog(Me)
                dlg.Dispose()
            ElseIf (effect.GetEffectType() = VFVideoEffectType.ImageLogo) Then
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
        Dim cavt As IVFVideoEffectDeinterlaceCAVT
        Dim effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT")
        If (effect Is Nothing) Then
            cavt = New VFVideoEffectDeinterlaceCAVT(cbDeinterlaceCAVT.Checked, 20)
            VideoCapture1.Video_Effects_Add(cavt)
        Else
            cavt = effect

            If (cavt IsNot Nothing) Then
                cavt.Enabled = cbDeinterlaceCAVT.Checked
            End If
        End If
    End Sub
End Class

' ReSharper restore InconsistentNaming