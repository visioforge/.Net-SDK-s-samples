' ReSharper disable InconsistentNaming

Imports System.IO
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.Types
Imports VisioForge.Core
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoEffects
Imports VisioForge.Core.VideoCapture
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.VideoCapture
Imports VisioForge.Core.Types.MediaPlayer
Imports System.Drawing.Imaging
Imports VisioForge.Core.Helpers
Imports System.Linq

Public Class Form1
    Dim mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Dim mpegTSSettingsDialog As HWEncodersOutputSettingsDialog

    Dim movSettingsDialog As HWEncodersOutputSettingsDialog

    Dim _mp4SettingsDialog As MP4SettingsDialog

    Dim aviSettingsDialog As AVISettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Dim gifSettingsDialog As GIFSettingsDialog

    Dim screenshotSaveDialog As SaveFileDialog

    Dim onvifControl As ONVIFControl

    Dim onvifPtzRanges As ONVIFPTZRanges

    Dim onvifPtzX As Double

    Dim onvifPtzY As Double

    Dim onvifPtzZoom As Double

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

        cbIPCameraType.SelectedIndex = 2
        cbOutputFormat.SelectedIndex = 2

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")
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

        If (onvifControl IsNot Nothing) Then
            onvifControl.Disconnect()
            onvifControl.Dispose()
            onvifControl = Nothing

            btONVIFConnect.Text = "Connect"
        End If

        mmLog.Clear()

        VideoCapture1.Video_Sample_Grabber_Enabled = True

        VideoCapture1.Video_Renderer.Zoom_Ratio = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftX = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftY = 0

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        VideoCapture1.Audio_RecordAudio = cbIPAudioCapture.Checked
        VideoCapture1.Audio_PlayAudio = cbIPAudioCapture.Checked

        VideoCapture1.Video_Renderer_SetAuto()

        'source
        VideoCapture1.IP_Camera_Source = New IPCameraSourceSettings()

        Dim lavGPU As Boolean = False
        Select Case (cbIPCameraType.SelectedIndex)
            Case 0
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_VLC
            Case 1
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_FFMPEG
            Case 2
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV
            Case 3
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV
                lavGPU = True
            Case 4
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.MMS_WMV
            Case 5
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.HTTP_MJPEG_LowLatency
                cbIPAudioCapture.Checked = False
                VideoCapture1.Audio_RecordAudio = False
                VideoCapture1.Audio_PlayAudio = False
            Case 6
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency
                VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = False
            Case 7
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency
                VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = True
            Case 8
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.NDI
            Case 9
                VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.NDI_Legacy
        End Select

        VideoCapture1.IP_Camera_Source.URL = New Uri(cbIPURL.Text)
        VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.Checked
        VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text
        VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text
        VideoCapture1.IP_Camera_Source.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.Checked
        VideoCapture1.IP_Camera_Source.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text)
        VideoCapture1.IP_Camera_Source.ForcedFramerate = Convert.ToInt32(edIPForcedFramerate.Text)
        VideoCapture1.IP_Camera_Source.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text(0)

        If VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV Then
            VideoCapture1.IP_Camera_Source.LAV_GPU_Use = lavGPU
            VideoCapture1.IP_Camera_Source.LAV_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack
        End If

        If cbIPCameraONVIF.Checked Then
            VideoCapture1.IP_Camera_Source.ONVIF_Source = True

            If cbONVIFProfile.SelectedIndex <> -1 Then
                VideoCapture1.IP_Camera_Source.ONVIF_SourceProfile = cbONVIFProfile.Text
            End If
        End If

        If cbIPDisconnect.Checked Then
            VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.FromSeconds(10)
        End If

        If rbPreview.Checked Then
            VideoCapture1.Mode = VideoCaptureMode.IPPreview
        Else
            VideoCapture1.Mode = VideoCaptureMode.IPCapture
            VideoCapture1.Output_Filename = edOutput.Text

            Select Case cbOutputFormat.SelectedIndex
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

        VideoView1.StatusOverlay = New TextStatusOverlay()

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

    Private Async Sub btONVIFConnect_Click(sender As Object, e As EventArgs) Handles btONVIFConnect.Click

        If (btONVIFConnect.Text = "Connect") Then
            Dim connected As Boolean = False

            Try
                btONVIFConnect.Enabled = False
                btONVIFConnect.Text = "Connecting"

                If (onvifControl IsNot Nothing) Then
                    onvifControl.Disconnect()
                    onvifControl.Dispose()
                    onvifControl = Nothing
                End If

                If (String.IsNullOrEmpty(edONVIFLogin.Text) Or String.IsNullOrEmpty(edONVIFPassword.Text)) Then
                    MessageBox.Show("Please specify IP camera user name and password.")
                    Exit Sub
                End If

                onvifControl = New ONVIFControl()
                Dim result = Await onvifControl.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text)

                If (Not result) Then
                    onvifControl = Nothing
                    MessageBox.Show("Unable to connect to ONVIF camera.")
                    Exit Sub
                End If

                Dim deviceInfo = Await onvifControl.GetDeviceInformationAsync()
                lbONVIFCameraInfo.Text = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}"

                cbONVIFProfile.Items.Clear()

                Dim profiles As VisioForge.Core.ONVIF.Profile() = Await onvifControl.GetProfilesAsync()
                For Each profile As VisioForge.Core.ONVIF.Profile In profiles
                    cbONVIFProfile.Items.Add($"{profile.Name}")
                Next

                If (cbONVIFProfile.Items.Count > 0) Then
                    cbONVIFProfile.SelectedIndex = 0
                End If

                edONVIFLiveVideoURL.Text = Await onvifControl.GetVideoURLAsync()
                cbIPURL.Text = edONVIFLiveVideoURL.Text

                edIPLogin.Text = edONVIFLogin.Text
                edIPPassword.Text = edONVIFPassword.Text

                onvifPtzRanges = Await onvifControl.PTZ_GetRangesAsync()
                Await onvifControl.PTZ_SetAbsoluteAsync(0, 0, 0)

                onvifPtzX = 0
                onvifPtzY = 0
                onvifPtzZoom = 0

                btONVIFConnect.Text = "Disconnect"
            Catch ex As Exception

            Finally
                btONVIFConnect.Enabled = True

                If (Not connected) Then
                    btONVIFConnect.Text = "Connect"
                End If
            End Try
        Else
            btONVIFConnect.Text = "Connect"

            If (onvifControl IsNot Nothing) Then
                onvifControl.Disconnect()
                onvifControl.Dispose()
                onvifControl = Nothing
            End If
        End If
    End Sub

    Private Sub btONVIFRight_Click(sender As Object, e As EventArgs) Handles btONVIFRight.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30
        onvifPtzX = onvifPtzX - step_

        If (onvifPtzX < onvifPtzRanges.MinX) Then
            onvifPtzX = onvifPtzRanges.MinX
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

    End Sub

    Private Sub btONVIFPTZSetDefault_Click(sender As Object, e As EventArgs) Handles btONVIFPTZSetDefault.Click

        onvifControl?.PTZ_SetAbsolute(0, 0, 0)

    End Sub

    Private Sub btONVIFLeft_Click(sender As Object, e As EventArgs) Handles btONVIFLeft.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30
        onvifPtzX = onvifPtzX + step_

        If (onvifPtzX > onvifPtzRanges.MaxX) Then
            onvifPtzX = onvifPtzRanges.MaxX
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

    End Sub

    Private Sub btONVIFUp_Click(sender As Object, e As EventArgs) Handles btONVIFUp.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30
        onvifPtzY = onvifPtzY - step_

        If (onvifPtzY < onvifPtzRanges.MinY) Then
            onvifPtzY = onvifPtzRanges.MinY
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

    End Sub

    Private Sub btONVIFDown_Click(sender As Object, e As EventArgs) Handles btONVIFDown.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30
        onvifPtzY = onvifPtzY + step_

        If (onvifPtzY > onvifPtzRanges.MaxY) Then
            onvifPtzY = onvifPtzRanges.MaxY
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

    End Sub

    Private Sub btONVIFZoomIn_Click(sender As Object, e As EventArgs) Handles btONVIFZoomIn.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100
        onvifPtzZoom = onvifPtzZoom + step_

        If (onvifPtzZoom > onvifPtzRanges.MaxZoom) Then
            onvifPtzZoom = onvifPtzRanges.MaxZoom
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

    End Sub

    Private Sub btONVIFZoomOut_Click(sender As Object, e As EventArgs) Handles btONVIFZoomOut.Click

        If (onvifControl Is Nothing Or onvifPtzRanges Is Nothing) Then
            Exit Sub
        End If

        Dim step_ As Double = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100
        onvifPtzZoom = onvifPtzZoom - step_

        If (onvifPtzZoom < onvifPtzRanges.MinZoom) Then
            onvifPtzZoom = onvifPtzRanges.MinZoom
        End If

        onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom)

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

    Private Sub lbNDI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbNDI.LinkClicked
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor)
        Process.Start(startInfo)
    End Sub

    Private Async Sub btListNDISources_Click(sender As Object, e As EventArgs) Handles btListNDISources.Click
        cbIPURL.Items.Clear()

        Dim lst As Uri() = Await VideoCapture1.IP_Camera_NDI_ListSourcesAsync()
        For Each uri As Uri In lst
            cbIPURL.Items.Add(uri)
        Next

        If (cbIPURL.Items.Count > 0) Then
            cbIPURL.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub btListONVIFSources_Click(sender As Object, e As EventArgs) Handles btListONVIFSources.Click
        cbIPURL.Items.Clear()

        Dim lst As Uri() = Await VideoCapture1.IP_Camera_ONVIF_ListSourcesAsync(Nothing, Nothing)
        For Each uri As Uri In lst
            cbIPURL.Items.Add(uri)
        Next

        If (cbIPURL.Items.Count > 0) Then
            cbIPURL.SelectedIndex = 0
        End If
    End Sub

    Private Sub VideoCapture1_OnNetworkSourceDisconnect(sender As Object, e As EventArgs) Handles VideoCapture1.OnNetworkSourceDisconnect
        Invoke(Async Sub()
                   Await VideoCapture1.StopAsync()
                   MessageBox.Show("Network source stopped or disconnected!")
               End Sub)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyEngine()
    End Sub
End Class

' ReSharper restore InconsistentNaming