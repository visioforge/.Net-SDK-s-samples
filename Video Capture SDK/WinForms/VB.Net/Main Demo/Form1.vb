' ReSharper disable InconsistentNaming

Imports System.Collections.ObjectModel
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.AudioEffects
Imports VisioForge.Core.Types.Decklink
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.FFMPEGEXE
Imports VisioForge.Core.Types.MediaPlayer
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoCapture
Imports VisioForge.Core.Types.VideoEffects
Imports VisioForge.Core.Types.VideoProcessing
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.VideoCapture
Imports VisioForge.Libs.Types

Public Class Form1

    Private Const AUDIO_EFFECT_ID_AMPLIFY As String = "amplify"

    Private Const AUDIO_EFFECT_ID_EQ As String = "eq"

    Private Const AUDIO_EFFECT_ID_DYN_AMPLIFY As String = "dyn_amplify"

    Private Const AUDIO_EFFECT_ID_SOUND_3D As String = "sound3d"

    Private Const AUDIO_EFFECT_ID_TRUE_BASS As String = "true_bass"

    Private Const AUDIO_EFFECT_ID_PITCH_SHIFT As String = "pitch_shift"

    Dim mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Dim mpegTSSettingsDialog As HWEncodersOutputSettingsDialog

    Dim movSettingsDialog As HWEncodersOutputSettingsDialog

    Dim mp4SettingsDialog As MP4SettingsDialog

    Dim aviSettingsDialog As AVISettingsDialog

    Dim wmvSettingsDialog As WMVSettingsDialog

    Dim dvSettingsDialog As DVSettingsDialog

    Dim pcmSettingsDialog As PCMSettingsDialog

    Dim mp3SettingsDialog As MP3SettingsDialog

    Dim webmSettingsDialog As WebMSettingsDialog

    Dim ffmpegSettingsDialog As FFMPEGSettingsDialog

    Dim ffmpegEXESettingsDialog As FFMPEGEXESettingsDialog

    Dim flacSettingsDialog As FLACSettingsDialog

    Dim customFormatSettingsDialog As CustomFormatSettingsDialog

    Dim oggVorbisSettingsDialog As OggVorbisSettingsDialog

    Dim speexSettingsDialog As SpeexSettingsDialog

    Dim m4aSettingsDialog As M4ASettingsDialog

    Dim gifSettingsDialog As GIFSettingsDialog

    Dim screenshotSaveDialog As SaveFileDialog

    Dim onvifControl As ONVIFControl

    Dim onvifPtzRanges As ONVIFPTZRanges

    Dim onvifPtzX As Double

    Dim onvifPtzY As Double

    Dim onvifPtzZoom As Double

    ' Zoom
    Dim zoom As Double = 1.0

    Dim zoomShiftX As Integer = 0

    Dim zoomShiftY As Integer = 0

    ReadOnly multiscreenWindows As List(Of Form) = New List(Of Form)

    ReadOnly audioChannelMapperItems As List(Of AudioChannelMapperItem) = New List(Of AudioChannelMapperItem)

    Private tmRecording As Timers.Timer = New Timers.Timer(1000)

    Private WithEvents windowCaptureForm As WindowCaptureForm

    Dim WithEvents VideoCapture1 As VideoCaptureCore

    Private Sub CreateEngine()
        Dim vv As IVideoView = VideoView1
        VideoCapture1 = New VideoCaptureCore(vv)
    End Sub

    Private Sub DestroyEngine()
        VideoCapture1.Dispose()
        VideoCapture1 = Nothing
    End Sub

    Private Sub AddAudioEffects()

        VideoCapture1.Audio_Effects_Clear(-1)

        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
        VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
    End Sub

    Private Async Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        Tag = 1

        AddHandler tmRecording.Elapsed, AddressOf UpdateRecordingTime

        screenshotSaveDialog = New SaveFileDialog()
        screenshotSaveDialog.FileName = "image.jpg"
        screenshotSaveDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff"
        screenshotSaveDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        ' set combobox indexes
        cbMode.SelectedIndex = 0
        cbOutputFormat.SelectedIndex = 22

        cbResizeMode.SelectedIndex = 0
        cbMotDetHLColor.SelectedIndex = 1
        cbIPCameraType.SelectedIndex = 2
        cbRotate.SelectedIndex = 0
        cbBarcodeType.SelectedIndex = 0
        cbNetworkStreamingMode.SelectedIndex = 0

        cbCustomAudioSourceCategory.SelectedIndex = 0
        cbCustomVideoSourceCategory.SelectedIndex = 0

        For Each screen As Screen In Screen.AllScreens
            cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace("\\.\DISPLAY", String.Empty))
        Next

        cbScreenCaptureDisplayIndex.SelectedIndex = 0

        cbDecklinkOutputAnalog.SelectedIndex = 0
        cbDecklinkOutputBlackToDeck.SelectedIndex = 0
        cbDecklinkOutputComponentLevels.SelectedIndex = 0
        cbDecklinkOutputDownConversion.SelectedIndex = 0
        cbDecklinkOutputDualLink.SelectedIndex = 0
        cbDecklinkOutputHDTVPulldown.SelectedIndex = 0
        cbDecklinkOutputNTSC.SelectedIndex = 0
        cbDecklinkOutputSingleField.SelectedIndex = 0

        cbDecklinkSourceInput.SelectedIndex = 0
        cbDecklinkSourceNTSC.SelectedIndex = 0
        cbDecklinkSourceComponentLevels.SelectedIndex = 0
        cbDecklinkSourceTimecode.SelectedIndex = 0

        For Each item As String In VideoCapture1.Decklink_Output_VideoRenderers()
            cbDecklinkOutputVideoRenderer.Items.Add(item)
        Next

        If (cbDecklinkOutputVideoRenderer.Items.Count > 0) Then
            cbDecklinkOutputVideoRenderer.SelectedIndex = 0
        End If

        For Each item As String In VideoCapture1.Decklink_Output_AudioRenderers()
            cbDecklinkOutputAudioRenderer.Items.Add(item)
        Next

        If (cbDecklinkOutputAudioRenderer.Items.Count > 0) Then
            cbDecklinkOutputAudioRenderer.SelectedIndex = 0
        End If

        cbFaceTrackingColorMode.SelectedIndex = 0
        cbFaceTrackingScalingMode.SelectedIndex = 0
        cbFaceTrackingSearchMode.SelectedIndex = 1

        cbHLSMode.SelectedIndex = 0

        rbMotionDetectionExProcessor.SelectedIndex = 1
        rbMotionDetectionExDetector.SelectedIndex = 1

        pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128)

        Dim genres As List(Of String) = New List(Of String)
        For Each s As String In VideoCapture1.Tags_GetDefaultAudioGenres
            genres.Add(s)
        Next

        For Each s As String In VideoCapture1.Tags_GetDefaultVideoGenres
            genres.Add(s)
        Next

        genres.Sort()

        For Each genre As String In genres
            cbTagGenre.Items.Add(genre)
        Next

        cbTagGenre.Text = "Rock"

        cbDirect2DRotate.SelectedIndex = 0

        Await VideoCapture1.TVTuner_ReadAsync()

        For i As Integer = 0 To VideoCapture1.TVTuner_Devices.Count - 1
            cbTVTuner.Items.Add(VideoCapture1.TVTuner_Devices.Item(i))
        Next i

        If cbTVTuner.Items.Count > 0 Then
            cbTVTuner.SelectedIndex = 0
        End If

        For i As Integer = 0 To VideoCapture1.TVTuner_TVFormats.Count - 1
            cbTVSystem.Items.Add(VideoCapture1.TVTuner_TVFormats.Item(i))
        Next i

        cbTVSystem.SelectedIndex = 0

        For i As Integer = 0 To VideoCapture1.TVTuner_Countries.Count - 1
            cbTVCountry.Items.Add(VideoCapture1.TVTuner_Countries.Item(i))
        Next i

        cbTVCountry.SelectedIndex = 0

        cbTVTuner_SelectedIndexChanged(sender, e)

        For Each info As VideoCaptureDeviceInfo In VideoCapture1.Video_CaptureDevices
            cbVideoInputDevice.Items.Add(info.Name)
            cbPIPDevice.Items.Add(info.Name)
        Next

        If cbVideoInputDevice.Items.Count > 0 Then
            cbVideoInputDevice.SelectedIndex = 0
            'cbVideoInputDevice_SelectedIndexChanged(sender, e)
            cbPIPDevice.SelectedIndex = 0
            'cbPIPDevice_SelectedIndexChanged(sender, e)
        End If

        For Each info As AudioCaptureDeviceInfo In VideoCapture1.Audio_CaptureDevices
            cbAudioInputDevice.Items.Add(info.Name)
            cbAdditionalAudioSource.Items.Add(info.Name)
        Next

        If cbAudioInputDevice.Items.Count > 0 Then
            cbAudioInputDevice.SelectedIndex = 0
            'cbAudioInputDevice_SelectedIndexChanged(sender, e)
            cbAdditionalAudioSource.SelectedIndex = 0
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

        Dim devices As List(Of AudioCaptureDeviceInfo) = (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text).ToList()
        If devices.Any() Then
            Dim deviceItem = devices.FirstOrDefault()
            If Not IsNothing(deviceItem) Then
                Dim lines = deviceItem.Lines
                For Each item As String In lines
                    cbAudioInputLine.Items.Add(item)
                Next
            End If
        End If

        If cbAudioInputLine.Items.Count > 0 Then
            cbAudioInputLine.SelectedIndex = 0
            'cbAudioInputLine_SelectedIndexChanged(sender, e)
        End If

        cbVideoInputSelectedIndexChanged(sender, e)

        rbEVR.Enabled = FilterDialogHelper.Filter_Supported_EVR()
        rbVMR9.Enabled = FilterDialogHelper.Filter_Supported_VMR9()

        rbVR_CheckedChanged(sender, e)

        Dim filters As List(Of String)
        filters = VideoCapture1.Special_Filters(SpecialFilterType.HardwareVideoEncoder).ToList()
        For i As Integer = 0 To filters.Count - 1
            cbMPEGEncoder.Items.Add(filters.Item(i))
        Next i

        If cbMPEGEncoder.Items.Count > 0 Then
            cbMPEGEncoder.SelectedIndex = 0
        End If

        For i As Integer = 0 To VideoCapture1.DirectShow_Filters.Count - 1
            cbFilters.Items.Add(VideoCapture1.DirectShow_Filters.Item(i))
        Next i

        cbMPEGVideoDecoder.Items.Add("(default)")
        cbMPEGAudioDecoder.Items.Add("(default)")

        filters = VideoCapture1.Special_Filters(SpecialFilterType.MPEG12VideoDecoder).ToList()
        For i As Integer = 0 To filters.Count - 1
            cbMPEGVideoDecoder.Items.Add(filters.Item(i))
        Next i

        filters = VideoCapture1.Special_Filters(SpecialFilterType.MPEG1AudioDecoder).ToList()
        For i As Integer = 0 To filters.Count - 1
            cbMPEGAudioDecoder.Items.Add(filters.Item(i))
        Next i

        cbMPEGVideoDecoder.SelectedIndex = 0
        cbMPEGAudioDecoder.SelectedIndex = 0

        Dim names As List(Of String) = New List(Of String)

        Dim descs As List(Of String) = New List(Of String)

        VideoCapture1.WMV_V8_Profiles(names, descs)

        'audio effects
        For i As Integer = 0 To VideoCapture1.Audio_Effects_Equalizer_Presets.Count - 1
            cbAudEqualizerPreset.Items.Add(VideoCapture1.Audio_Effects_Equalizer_Presets.Item(i))
        Next i

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")

        cbPIPMode.SelectedIndex = 0

        ' BDA
        For Each source As String In VideoCapture1.BDA_Sources()

            cbBDASourceDevice.Items.Add(source)

        Next

        For Each receiver As String In VideoCapture1.BDA_Receivers()

            cbBDAReceiver.Items.Add(receiver)

        Next

        If (cbBDASourceDevice.Items.Count > 0) Then

            cbBDASourceDevice.SelectedIndex = 0

        End If

        If (cbBDAReceiver.Items.Count > 1) Then

            cbBDAReceiver.SelectedIndex = 1

        End If

        cbBDADeviceStandard.SelectedIndex = 0
        cbDVBSPolarisation.SelectedIndex = 0
        cbDVBCModulation.SelectedIndex = 4

        ' Decklink
        For Each device As DecklinkDeviceInfo In VideoCapture1.Decklink_CaptureDevices
            cbDecklinkCaptureDevice.Items.Add(device.Name)
        Next

        If (cbDecklinkCaptureDevice.Items.Count > 0) Then
            cbDecklinkCaptureDevice.SelectedIndex = 0
            cbDecklinkCaptureDevice_SelectedIndexChanged(Nothing, Nothing)
        End If

        btVirtualCameraRegister.Enabled = Not VideoCapture1.DirectShow_Filters.Contains("VisioForge Virtual Camera")
    End Sub


    Private Async Sub cbVideoInputDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbVideoInputDevice.SelectedIndexChanged

        If cbVideoInputDevice.SelectedIndex <> -1 Then
            cbVideoInputFormat.Items.Clear()

            Dim deviceItem = (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbVideoInputDevice.Text)?.FirstOrDefault()
            If Not IsNothing(deviceItem) Then
                Dim formats = deviceItem.VideoFormats
                For Each item As VideoCaptureDeviceFormat In formats
                    cbVideoInputFormat.Items.Add(item)
                Next

                If cbVideoInputFormat.Items.Count > 0 Then
                    cbVideoInputFormat.SelectedIndex = 0
                End If

                cbVideoInputSelectedIndexChanged(sender, e)

                'currently device active, we can read TV Tuner name
                Dim tvTuner = deviceItem.TVTuner
                If tvTuner <> "" Then

                    Dim k As Integer = cbTVTuner.Items.IndexOf(tvTuner)
                    If k >= 0 Then
                        cbTVTuner.SelectedIndex = k
                    End If

                End If

                cbCrossBarAvailable.Enabled = VideoCapture1.Video_CaptureDevice_CrossBar_Init(cbVideoInputDevice.Text)
                cbCrossBarAvailable.Checked = cbCrossBarAvailable.Enabled

                If cbCrossBarAvailable.Enabled Then

                    cbCrossbarInput.Enabled = True
                    cbCrossbarOutput.Enabled = True
                    rbCrossbarSimple.Enabled = True
                    rbCrossbarAdvanced.Enabled = True
                    cbCrossbarVideoInput.Enabled = True
                    btConnect.Enabled = True
                    cbConnectRelated.Enabled = True
                    lbRotes.Enabled = True

                    VideoCapture1.Video_CaptureDevice_CrossBar_ClearConnections()

                    cbCrossbarVideoInput.Items.Clear()

                    Dim inputs As List(Of String)

                    inputs = VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput("Video Decoder").ToList()
                    For i As Integer = 0 To inputs.Count - 1
                        cbCrossbarVideoInput.Items.Add(inputs.Item(i))
                    Next i

                    If cbCrossbarVideoInput.Items.Count > 0 Then
                        cbCrossbarVideoInput.SelectedIndex = 0
                    End If

                    cbCrossbarOutput.Items.Clear()

                    For i As Integer = 0 To VideoCapture1.Video_CaptureDevice_CrossBar_Outputs.Count - 1
                        cbCrossbarOutput.Items.Add(VideoCapture1.Video_CaptureDevice_CrossBar_Outputs.Item(i))
                    Next i

                    If cbCrossbarOutput.Items.Count > 0 Then
                        cbCrossbarOutput.SelectedIndex = 0
                        cbCrossbarOutput_SelectedIndexChanged(sender, e)
                    End If

                    lbRotes.Items.Clear()
                    For i As Integer = 0 To cbCrossbarOutput.Items.Count - 1

                        Dim input1 As String
                        input1 = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Text)

                        If input1 <> "" Then
                            lbRotes.Items.Add("Input: " + input1 + ", Output: " + cbCrossbarOutput.Items.Item(i))
                        End If

                    Next i

                Else
                    cbCrossbarInput.Enabled = False
                    cbCrossbarOutput.Enabled = False
                    rbCrossbarSimple.Enabled = False
                    rbCrossbarAdvanced.Enabled = False
                    cbCrossbarVideoInput.Enabled = False
                    btConnect.Enabled = False
                    cbConnectRelated.Enabled = False
                    lbRotes.Enabled = False
                End If

                'updating adjust settings
                Dim brightnessRanges As VideoCaptureDeviceAdjustRanges = Await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Brightness)
                If brightnessRanges IsNot Nothing Then
                    tbAdjBrightness.Minimum = brightnessRanges.Min
                    tbAdjBrightness.Maximum = brightnessRanges.Max
                    tbAdjBrightness.SmallChange = brightnessRanges.Step
                    tbAdjBrightness.Value = brightnessRanges.Default
                    cbAdjBrightnessAuto.Checked = brightnessRanges.Auto
                    lbAdjBrightnessMin.Text = "Min: " + Convert.ToString(brightnessRanges.Min)
                    lbAdjBrightnessMax.Text = "Max: " + Convert.ToString(brightnessRanges.Max)
                    lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(brightnessRanges.Default)
                End If

                Dim hueRanges As VideoCaptureDeviceAdjustRanges = Await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Hue)
                If hueRanges IsNot Nothing Then
                    tbAdjHue.Minimum = hueRanges.Min
                    tbAdjHue.Maximum = hueRanges.Max
                    tbAdjHue.SmallChange = hueRanges.Step
                    tbAdjHue.Value = hueRanges.Default
                    cbAdjHueAuto.Checked = hueRanges.Auto
                    lbAdjHueMin.Text = "Min: " + Convert.ToString(hueRanges.Min)
                    lbAdjHueMax.Text = "Max: " + Convert.ToString(hueRanges.Max)
                    lbAdjHueCurrent.Text = "Current: " + Convert.ToString(hueRanges.Default)
                End If

                Dim saturationRanges As VideoCaptureDeviceAdjustRanges = Await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Saturation)
                If saturationRanges IsNot Nothing Then
                    tbAdjSaturation.Minimum = saturationRanges.Min
                    tbAdjSaturation.Maximum = saturationRanges.Max
                    tbAdjSaturation.SmallChange = saturationRanges.Step
                    tbAdjSaturation.Value = saturationRanges.Default
                    cbAdjSaturationAuto.Checked = saturationRanges.Auto
                    lbAdjSaturationMin.Text = "Min: " + Convert.ToString(saturationRanges.Min)
                    lbAdjSaturationMax.Text = "Max: " + Convert.ToString(saturationRanges.Max)
                    lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(saturationRanges.Default)
                End If

                Dim contrastRanges As VideoCaptureDeviceAdjustRanges = Await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Contrast)
                If contrastRanges IsNot Nothing Then
                    tbAdjContrast.Minimum = contrastRanges.Min
                    tbAdjContrast.Maximum = contrastRanges.Max
                    tbAdjContrast.SmallChange = contrastRanges.Step
                    tbAdjContrast.Value = contrastRanges.Default
                    cbAdjContrastAuto.Checked = contrastRanges.Auto
                    lbAdjContrastMin.Text = "Min: " + Convert.ToString(contrastRanges.Min)
                    lbAdjContrastMax.Text = "Max: " + Convert.ToString(contrastRanges.Max)
                    lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(contrastRanges.Default)
                End If

                btVideoCaptureDeviceSettings.Enabled = deviceItem.DialogDefault
            End If
        End If

    End Sub

    Private Sub cbVideoInputSelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbVideoInputFormat.SelectedIndexChanged

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

    Private Sub cbAudioInputDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioInputDevice.SelectedIndexChanged

        cbAudioInputFormat.Items.Clear()
        cbAudioInputLine.Items.Clear()

        If (cbAudioInputDevice.SelectedIndex <> -1) Then
            Dim deviceItem = (From info In VideoCapture1.Audio_CaptureDevices Where info.Name = cbAudioInputDevice.Text)?.FirstOrDefault()
            If (Not IsNothing(deviceItem)) Then

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

                cbAudioInputFormat_SelectedIndexChanged(Nothing, Nothing)

                For Each s As String In deviceItem.Lines
                    cbAudioInputLine.Items.Add(s)
                Next

                If (cbAudioInputLine.Items.Count > 0) Then
                    cbAudioInputLine.SelectedIndex = 0
                End If

                btAudioInputDeviceSettings.Enabled = deviceItem.DialogDefault

            End If
        End If

    End Sub

    Private Sub btSelectOutput_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectOutput.Click

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = saveFileDialog1.FileName
        End If

    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        VideoCapture1.Debug_Mode = cbDebugMode.Checked
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        VideoCapture1.Debug_Telemetry = cbTelemetry.Checked

        VideoView1.StatusOverlay = Nothing

        If (onvifControl IsNot Nothing) Then
            onvifControl.Disconnect()
            onvifControl.Dispose()
            onvifControl = Nothing

            btONVIFConnect.Text = "Connect"
        End If

        zoom = 1.0
        zoomShiftX = 0
        zoomShiftY = 0

        mmLog.Clear()

        If (cbPIPDevices.Items.Count > 0) Then
            If (cbPIPDevices.Items.IndexOf("Main source") = -1) Then
                cbPIPDevices.Items.Insert(0, "Main source")
            End If
        End If

        VideoCapture1.Video_Renderer.Zoom_Ratio = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftX = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftY = 0

        'VideoCapture1.VLC_Path = Environment.GetEnvironmentVariable("VFVLCPATH")

        VideoCapture1.Video_Effects_Clear()
        lbTextLogos.Items.Clear()
        lbImageLogos.Items.Clear()

        Select Case cbMode.SelectedIndex
            Case 0 : VideoCapture1.Mode = VideoCaptureMode.VideoPreview
            Case 1 : VideoCapture1.Mode = VideoCaptureMode.VideoCapture
            Case 2 : VideoCapture1.Mode = VideoCaptureMode.AudioPreview
            Case 3 : VideoCapture1.Mode = VideoCaptureMode.AudioCapture
            Case 4 : VideoCapture1.Mode = VideoCaptureMode.ScreenPreview
            Case 5 : VideoCapture1.Mode = VideoCaptureMode.ScreenCapture
            Case 6 : VideoCapture1.Mode = VideoCaptureMode.IPPreview
            Case 7 : VideoCapture1.Mode = VideoCaptureMode.IPCapture
            Case 8 : VideoCapture1.Mode = VideoCaptureMode.BDAPreview
            Case 9 : VideoCapture1.Mode = VideoCaptureMode.BDACapture
            Case 10 : VideoCapture1.Mode = VideoCaptureMode.CustomPreview
            Case 11 : VideoCapture1.Mode = VideoCaptureMode.CustomCapture
            Case 12 : VideoCapture1.Mode = VideoCaptureMode.DecklinkSourcePreview
            Case 13 : VideoCapture1.Mode = VideoCaptureMode.DecklinkSourceCapture
        End Select

        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text

        VideoCapture1.Audio_CaptureDevice = New AudioCaptureSource(cbAudioInputDevice.Text)
        VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text
        VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text
        VideoCapture1.Audio_CaptureDevice.Format_UseBest = cbUseBestAudioInputFormat.Checked

        VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = rbAddAudioStreamsMix.Checked

        If (VideoCapture1.Mode = VideoCaptureMode.ScreenCapture) Or (VideoCapture1.Mode = VideoCaptureMode.ScreenPreview) Then

            Dim settings As ScreenCaptureSourceSettings = SelectScreenSource()
            VideoCapture1.Screen_Capture_Source = settings

            'from screen

        ElseIf VideoCapture1.Mode = VideoCaptureMode.IPCapture Or VideoCapture1.Mode = VideoCaptureMode.IPPreview Then

            Dim settings As IPCameraSourceSettings = SelectIPCameraSource()
            VideoCapture1.IP_Camera_Source = settings

            VideoView1.StatusOverlay = New TextStatusOverlay()

        ElseIf ((VideoCapture1.Mode = VideoCaptureMode.BDACapture) Or (VideoCapture1.Mode = VideoCaptureMode.BDAPreview)) Then

            SelectBDASource()

        ElseIf ((VideoCapture1.Mode = VideoCaptureMode.CustomCapture) Or (VideoCapture1.Mode = VideoCaptureMode.CustomPreview)) Then

            SelectCustomSource()

        ElseIf ((VideoCapture1.Mode = VideoCaptureMode.DecklinkSourceCapture) Or (VideoCapture1.Mode = VideoCaptureMode.DecklinkSourcePreview)) Then

            VideoCapture1.Decklink_Source = New DecklinkSourceSettings()
            VideoCapture1.Decklink_Source.Name = cbDecklinkCaptureDevice.Text
            VideoCapture1.Decklink_Source.VideoFormat = cbDecklinkCaptureVideoFormat.Text

        Else

            SelectVideoCaptureSource()

        End If


        Dim captureMode = (VideoCapture1.Mode = VideoCaptureMode.AudioCapture Or VideoCapture1.Mode = VideoCaptureMode.BDACapture Or
                           VideoCapture1.Mode = VideoCaptureMode.CustomCapture Or VideoCapture1.Mode = VideoCaptureMode.IPCapture Or
                           VideoCapture1.Mode = VideoCaptureMode.ScreenCapture Or VideoCapture1.Mode = VideoCaptureMode.DecklinkSourceCapture Or
                           VideoCapture1.Mode = VideoCaptureMode.VideoCapture)

        If (captureMode) Then
            VideoCapture1.Output_Filename = edOutput.Text
        End If

        ' Network streaming
        VideoCapture1.Network_Streaming_Enabled = False

        If cbNetworkStreaming.Checked Then
            ConfigureNetworkStreaming()
        End If

        VideoCapture1.Audio_RecordAudio = cbRecordAudio.Checked
        VideoCapture1.Audio_PlayAudio = cbPlayAudio.Checked

        ' multiscreen
        ConfigureMultiscreen()

        ' OSD
        VideoCapture1.OSD_Enabled = cbOSDEnabled.Checked

        If captureMode Then
            Dim outputFormat = VideoCaptureOutputFormat.AVI
            Select Case cbOutputFormat.SelectedIndex
                Case 0
                    outputFormat = VideoCaptureOutputFormat.AVI

                    Dim aviOutput = New AVIOutput()
                    SetAVIOutput(aviOutput)
                    VideoCapture1.Output_Format = aviOutput
                Case 1
                    outputFormat = VideoCaptureOutputFormat.MKVv1

                    Dim mkvOutput = New MKVv1Output()
                    SetMKVOutput(mkvOutput)
                    VideoCapture1.Output_Format = mkvOutput
                Case 2
                    outputFormat = VideoCaptureOutputFormat.WMV

                    Dim wmvOutput As WMVOutput = New WMVOutput
                    SetWMVOutput(wmvOutput)
                    VideoCapture1.Output_Format = wmvOutput
                Case 3
                    outputFormat = VideoCaptureOutputFormat.DV

                    Dim dvOutput = New DVOutput()
                    SetDVOutput(dvOutput)
                    VideoCapture1.Output_Format = dvOutput
                Case 4
                    outputFormat = VideoCaptureOutputFormat.PCM_ACM

                    Dim acmOutput = New ACMOutput()
                    SetACMOutput(acmOutput)
                    VideoCapture1.Output_Format = acmOutput
                Case 5
                    outputFormat = VideoCaptureOutputFormat.MP3

                    Dim mp3Output = New MP3Output()
                    SetMP3Output(mp3Output)
                    VideoCapture1.Output_Format = mp3Output
                Case 6
                    outputFormat = VideoCaptureOutputFormat.M4A

                    Dim m4aOutput = New M4AOutput()
                    SetM4AOutput(m4aOutput)
                    VideoCapture1.Output_Format = m4aOutput
                Case 7
                    outputFormat = VideoCaptureOutputFormat.WMA

                    Dim wmaOutput As WMAOutput = New WMAOutput()
                    SetWMAOutput(wmaOutput)
                    VideoCapture1.Output_Format = wmaOutput
                Case 8
                    outputFormat = VideoCaptureOutputFormat.FLAC

                    Dim flacOutput = New FLACOutput()
                    SetFLACOutput(flacOutput)
                    VideoCapture1.Output_Format = flacOutput
                Case 9
                    outputFormat = VideoCaptureOutputFormat.OggVorbis

                    Dim oggVorbisOutput = New OGGVorbisOutput()
                    SetOGGOutput(oggVorbisOutput)
                    VideoCapture1.Output_Format = oggVorbisOutput
                Case 10
                    outputFormat = VideoCaptureOutputFormat.Speex

                    Dim speexOutput = New SpeexOutput()
                    SetSpeexOutput(speexOutput)
                    VideoCapture1.Output_Format = speexOutput
                Case 11
                    outputFormat = VideoCaptureOutputFormat.Custom

                    Dim customOutput = New CustomOutput()
                    SetCustomOutput(customOutput)
                    VideoCapture1.Output_Format = customOutput
                Case 12
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureDV
                    VideoCapture1.Output_Format = New DirectCaptureDVOutput()
                Case 13
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureAVI
                    VideoCapture1.Output_Format = New DirectCaptureAVIOutput()
                Case 14
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureMPEG
                    VideoCapture1.Output_Format = New DirectCaptureMPEGOutput()
                Case 15
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureMKV
                    VideoCapture1.Output_Format = New DirectCaptureMKVOutput()
                Case 16
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureMP4_GDCL

                    Dim directCaptureOutputGDCL = New DirectCaptureMP4Output()
                    SetDirectCaptureCustomOutput(directCaptureOutputGDCL)
                    directCaptureOutputGDCL.Muxer = DirectCaptureMP4Muxer.GDCL
                    VideoCapture1.Output_Format = directCaptureOutputGDCL
                Case 17
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureMP4_Monogram

                    Dim directCaptureOutputMG = New DirectCaptureMP4Output()
                    SetDirectCaptureCustomOutput(directCaptureOutputMG)
                    directCaptureOutputMG.Muxer = DirectCaptureMP4Muxer.Monogram
                    VideoCapture1.Output_Format = directCaptureOutputMG
                Case 18
                    outputFormat = VideoCaptureOutputFormat.DirectCaptureCustom

                    Dim directCaptureOutput = New DirectCaptureCustomOutput()
                    SetDirectCaptureCustomOutput(directCaptureOutput)
                    VideoCapture1.Output_Format = directCaptureOutput
                Case 19
                    outputFormat = VideoCaptureOutputFormat.WebM

                    Dim webmOutput = New WebMOutput()
                    SetWebMOutput(webmOutput)
                    VideoCapture1.Output_Format = webmOutput
                Case 20
                    outputFormat = VideoCaptureOutputFormat.FFMPEG

                    Dim ffmpegOutput = New FFMPEGOutput()
                    SetFFMPEGOutput(ffmpegOutput)
                    VideoCapture1.Output_Format = ffmpegOutput
                Case 21
                    outputFormat = VideoCaptureOutputFormat.FFMPEG_EXE

                    Dim ffmpegOutput = New FFMPEGEXEOutput()
                    SetFFMPEGEXEOutput(ffmpegOutput)
                    VideoCapture1.Output_Format = ffmpegOutput
                Case 22
                    outputFormat = VideoCaptureOutputFormat.MP4
                Case 23
                    outputFormat = VideoCaptureOutputFormat.MP4_HW

                    Dim mp4Output = New MP4HWOutput()
                    SetMP4HWOutput(mp4Output)
                    VideoCapture1.Output_Format = mp4Output
                Case 24
                    outputFormat = VideoCaptureOutputFormat.AnimatedGIF

                    Dim gifOutput = New AnimatedGIFOutput()
                    SetGIFOutput(gifOutput)
                    VideoCapture1.Output_Format = gifOutput
                Case 25
                    outputFormat = VideoCaptureOutputFormat.Encrypted
                Case 26
                    Dim tsOutput = New MPEGTSOutput()
                    SetMPEGTSOutput(tsOutput)
                    VideoCapture1.Output_Format = tsOutput
                Case 27
                    Dim movOutput = New MOVOutput()
                    SetMOVOutput(movOutput)
                    VideoCapture1.Output_Format = movOutput
            End Select

            If outputFormat = VideoCaptureOutputFormat.DirectCaptureMPEG Then

                If cbMPEGEncoder.SelectedIndex <> -1 Then
                    VideoCapture1.Video_CaptureDevice.InternalMPEGEncoder_Name = cbMPEGEncoder.Text
                End If

            ElseIf ((outputFormat = VideoCaptureOutputFormat.MP4) Or
                ((outputFormat = VideoCaptureOutputFormat.Encrypted) And (rbEncryptedH264SW.Checked)) Or
                        (VideoCapture1.Network_Streaming_Enabled And (VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW))) Then

                Dim mp4Output As MP4Output = New MP4Output()
                SetMP4Output(mp4Output)

                If (outputFormat = VideoCaptureOutputFormat.Encrypted) Then
                    mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC

                    If (rbEncryptionKeyString.Checked) Then

                        mp4Output.Encryption_KeyType = EncryptionKeyType.String
                        mp4Output.Encryption_Key = edEncryptionKeyString.Text


                        mp4Output.Encryption = True

                    ElseIf (rbEncryptionKeyFile.Checked) Then
                        mp4Output.Encryption_KeyType = EncryptionKeyType.File
                        mp4Output.Encryption_Key = edEncryptionKeyFile.Text

                    Else

                        mp4Output.Encryption_KeyType = EncryptionKeyType.Binary
                        mp4Output.Encryption_Key = VideoCapture1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text)

                    End If

                    If (rbEncryptionModeAES128.Checked) Then
                        mp4Output.Encryption_Mode = EncryptionMode.V8_AES128
                    Else
                        mp4Output.Encryption_Mode = EncryptionMode.V9_AES256
                    End If
                End If

                VideoCapture1.Output_Format = mp4Output
            End If
        End If


        'crossbar
        SelectCrossbar()

        ' Video effects CPU
        ConfigureVideoEffects()

        ' Videoeffects GPU
        VideoCapture1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.Checked

        ' Barcode detection
        VideoCapture1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked
        VideoCapture1.Barcode_Reader_Type = cbBarcodeType.SelectedIndex

        ' Face tracking
        ConfigureFaceTracking()

        ' Chromakey
        ConfigureChromaKey()

        'Object tracking 
        ConfigureMotionDetectionEx()

        ' Virtual camera output
        VideoCapture1.Virtual_Camera_Output_Enabled = cbVirtualCamera.Checked

        ' Decklink output
        ConfigureDecklink()

        ' Video renderer
        ConfigureVideoRenderer()

        ' resize crop rotate
        ConfigureResizeCropRotate()

        ' MPEG / DV decoding
        ConfigureMPEGDVDecoding()

        'motion detection
        ConfigureMotionDetection()

        'VU Meters
        ConfigureVUMeter()

        ' Audio enhancement
        VideoCapture1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.Checked
        If (VideoCapture1.Audio_Enhancer_Enabled) Then
            Await VideoCapture1.Audio_Enhancer_NormalizeAsync(cbAudioNormalize.Checked)
            Await VideoCapture1.Audio_Enhancer_AutoGainAsync(cbAudioAutoGain.Checked)

            Await ApplyAudioInputGainsAsync()
            Await ApplyAudioOutputGainsAsync()

            Await VideoCapture1.Audio_Enhancer_TimeshiftAsync(tbAudioTimeshift.Value)
        End If

        ' Audio channels mapping
        If (cbAudioChannelMapperEnabled.Checked) Then
            VideoCapture1.Audio_Channel_Mapper = New AudioChannelMapperSettings()
            VideoCapture1.Audio_Channel_Mapper.Routes = audioChannelMapperItems.ToArray()
            VideoCapture1.Audio_Channel_Mapper.OutputChannelsCount = Convert.ToInt32(edAudioChannelMapperOutputChannels.Text)
        Else
            VideoCapture1.Audio_Channel_Mapper = Nothing
        End If

        'Audio processing
        VideoCapture1.Audio_Effects_Enabled = cbAudioEffectsEnabled.Checked
        If VideoCapture1.Audio_Effects_Enabled Then
            AddAudioEffects()
        End If

        ' separate capture
        ConfigureSeparateCapture()

        ' tags
        ConfigureOutputTags()

        ' PIP
        VideoCapture1.PIP_Mode = cbPIPMode.SelectedIndex
        VideoCapture1.PIP_ResizeQuality = cbPIPResizeMode.SelectedIndex

        If (VideoCapture1.PIP_Mode = PIPMode.ChromaKey) Then
            Dim chromaKey = New PIPChromaKeySettings()
            chromaKey.Color = pnPIPChromaKeyColor.BackColor
            chromaKey.Tolerance1 = tbPIPChromaKeyTolerance1.Value
            chromaKey.Tolerance2 = tbPIPChromaKeyTolerance2.Value

            VideoCapture1.PIP_ChromaKeySettings = chromaKey
        End If

        ' start
        Await VideoCapture1.StartAsync()

        edNetworkURL.Text = VideoCapture1.Network_Streaming_URL

        tmRecording.Start()
    End Sub

    Private Sub ConfigureMotionDetectionEx()
        If (cbMotionDetectionEx.Checked) Then
            VideoCapture1.Motion_DetectionEx = New MotionDetectionExSettings()
            VideoCapture1.Motion_DetectionEx.ProcessorType = rbMotionDetectionExProcessor.SelectedIndex
            VideoCapture1.Motion_DetectionEx.DetectorType = rbMotionDetectionExDetector.SelectedIndex
        Else
            VideoCapture1.Motion_DetectionEx = Nothing
        End If
    End Sub

    Private Sub ConfigureOutputTags()

        If cbTagEnabled.Checked Then

            Dim tags As MediaFileTags = New MediaFileTags
            tags.Title = edTagTitle.Text
            tags.Performers = New String() {edTagArtists.Text}
            tags.Album = edTagAlbum.Text
            tags.Comment = edTagComment.Text
            tags.Track = Convert.ToUInt32(edTagTrackID.Text)
            tags.Copyright = edTagCopyright.Text
            tags.Year = Convert.ToUInt32(edTagYear.Text)
            tags.Composers = New String() {edTagComposers.Text}
            tags.Genres = New String() {cbTagGenre.Text}
            tags.Lyrics = edTagLyrics.Text

            If Not IsNothing(imgTagCover.Image) Then
                tags.Pictures = New Bitmap() {imgTagCover.Image}
            End If

            VideoCapture1.Tags = tags

        End If
    End Sub

    Private Sub ConfigureSeparateCapture()

        VideoCapture1.SeparateCapture_Enabled = cbSeparateCaptureEnabled.Checked
        If (VideoCapture1.SeparateCapture_Enabled) Then
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
        End If
    End Sub

    Private Sub ConfigureVUMeter()

        VideoCapture1.Audio_VUMeter_Enabled = cbVUMeter.Checked
        VideoCapture1.Audio_VUMeter_Pro_Enabled = cbVUMeterPro.Checked

        If (VideoCapture1.Audio_VUMeter_Pro_Enabled) Then

            VideoCapture1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value

            volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F
            volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F

            waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F
            waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F

        End If
    End Sub

    Private Sub ConfigureMPEGDVDecoding()

        'MPEG decoding (only for tuners with internal HW encoder)
        If cbMPEGVideoDecoder.SelectedIndex < 1 Then
            VideoCapture1.MPEG_Video_Decoder = "" 'default
        Else
            VideoCapture1.MPEG_Video_Decoder = cbMPEGVideoDecoder.Text
        End If

        If cbMPEGAudioDecoder.SelectedIndex < 1 Then
            VideoCapture1.MPEG_Audio_Decoder = "" 'default
        Else
            VideoCapture1.MPEG_Audio_Decoder = cbMPEGAudioDecoder.Text
        End If

        'DV resolution
        If rbDVResFull.Checked Then
            VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Full
        ElseIf rbDVResHalf.Checked Then
            VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Half
        ElseIf rbDVResQuarter.Checked Then
            VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Quarter
        Else
            VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.DC
        End If
    End Sub

    Private Sub ConfigureResizeCropRotate()

        VideoCapture1.Video_ResizeOrCrop_Enabled = False

        If cbResize.Checked Then
            VideoCapture1.Video_ResizeOrCrop_Enabled = True

            VideoCapture1.Video_Resize = New VideoResizeSettings()

            VideoCapture1.Video_Resize.Width = Convert.ToInt32(edResizeWidth.Text)
            VideoCapture1.Video_Resize.Height = Convert.ToInt32(edResizeHeight.Text)
            VideoCapture1.Video_Resize.LetterBox = cbResizeLetterbox.Checked

            Select Case cbResizeMode.SelectedIndex
                Case 0 : VideoCapture1.Video_Resize.Mode = VideoResizeMode.NearestNeighbor
                Case 1 : VideoCapture1.Video_Resize.Mode = VideoResizeMode.Bilinear
                Case 2 : VideoCapture1.Video_Resize.Mode = VideoResizeMode.Bicubic
                Case 3 : VideoCapture1.Video_Resize.Mode = VideoResizeMode.Lancroz
            End Select
        Else
            VideoCapture1.Video_Resize = Nothing
        End If

        If (cbCrop.Checked) Then

            VideoCapture1.Video_ResizeOrCrop_Enabled = True

            VideoCapture1.Video_Crop = New VideoCropSettings(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text))

        Else

            VideoCapture1.Video_Crop = Nothing

        End If

        Select Case cbRotate.SelectedIndex
            Case 0 : VideoCapture1.Video_Rotation = RotateMode.RotateNone
            Case 1 : VideoCapture1.Video_Rotation = RotateMode.Rotate90
            Case 2 : VideoCapture1.Video_Rotation = RotateMode.Rotate180
            Case 3 : VideoCapture1.Video_Rotation = RotateMode.Rotate270
        End Select
    End Sub

    Private Sub ConfigureVideoRenderer()

        If rbVMR9.Checked Then
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
        ElseIf rbEVR.Checked Then
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
        ElseIf (rbDirect2D.Checked) Then
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
        Else
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None
        End If

        If (cbStretch.Checked) Then
            VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch
        Else
            VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox
        End If

        VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)

        VideoCapture1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor
        VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked
    End Sub

    Private Sub ConfigureDecklink()

        If cbDecklinkOutput.Checked Then
            VideoCapture1.Decklink_Output = New DecklinkOutputSettings()
            VideoCapture1.Decklink_Output.VideoRendererName = cbDecklinkOutputVideoRenderer.Text
            VideoCapture1.Decklink_Output.AudioRendererName = cbDecklinkOutputAudioRenderer.Text
            VideoCapture1.Decklink_Output.DVEncoding = cbDecklinkDV.Checked
            VideoCapture1.Decklink_Output.AnalogOutputIREUSA = cbDecklinkOutputNTSC.SelectedIndex = 0
            VideoCapture1.Decklink_Output.AnalogOutputSMPTE = cbDecklinkOutputComponentLevels.SelectedIndex = 0
            VideoCapture1.Decklink_Output.BlackToDeckInCapture = cbDecklinkOutputBlackToDeck.SelectedIndex
            VideoCapture1.Decklink_Output.DualLinkOutputMode = cbDecklinkOutputDualLink.SelectedIndex
            VideoCapture1.Decklink_Output.HDTVPulldownOnOutput = cbDecklinkOutputHDTVPulldown.SelectedIndex
            VideoCapture1.Decklink_Output.SingleFieldOutputForSynchronousFrames = cbDecklinkOutputSingleField.SelectedIndex
            VideoCapture1.Decklink_Output.VideoOutputDownConversionMode = cbDecklinkOutputDownConversion.SelectedIndex
            VideoCapture1.Decklink_Output.VideoOutputDownConversionModeAnalogUsed = cbDecklinkOutputDownConversionAnalogOutput.Checked
            VideoCapture1.Decklink_Output.AnalogOutput = cbDecklinkOutputAnalog.SelectedIndex

            VideoCapture1.Decklink_Input = cbDecklinkSourceInput.SelectedIndex
            VideoCapture1.Decklink_Input_SMPTE = cbDecklinkSourceComponentLevels.SelectedIndex = 0
            VideoCapture1.Decklink_Input_IREUSA = cbDecklinkSourceNTSC.SelectedIndex = 0
            VideoCapture1.Decklink_Input_Capture_Timecode_Source = cbDecklinkSourceTimecode.SelectedIndex
        Else
            VideoCapture1.Decklink_Output = Nothing
        End If

    End Sub

    Private Sub ConfigureChromaKey()
        If (Not IsNothing(VideoCapture1.ChromaKey)) Then
            VideoCapture1.ChromaKey.Dispose()
            VideoCapture1.ChromaKey = Nothing
        End If

        If (cbChromaKeyEnabled.Checked) Then
            If (Not File.Exists(edChromaKeyImage.Text)) Then
                MessageBox.Show("Chroma-key background file doesn't exists.")
                Return
            End If

            VideoCapture1.ChromaKey = New ChromaKeySettings(New Bitmap(edChromaKeyImage.Text))
            VideoCapture1.ChromaKey.Smoothing = tbChromaKeySmoothing.Value / 1000.0F
            VideoCapture1.ChromaKey.ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000.0F
            VideoCapture1.ChromaKey.Color = pnChromaKeyColor.BackColor
        Else

            VideoCapture1.ChromaKey = Nothing
        End If
    End Sub

    Private Sub ConfigureFaceTracking()

        If (cbFaceTrackingEnabled.Checked) Then

            VideoCapture1.Face_Tracking = New FaceTrackingSettings()
            VideoCapture1.Face_Tracking.ColorMode = cbFaceTrackingColorMode.SelectedIndex
            VideoCapture1.Face_Tracking.Highlight = cbFaceTrackingCHL.Checked
            VideoCapture1.Face_Tracking.MinimumWindowSize = Int32.Parse(edFaceTrackingMinimumWindowSize.Text)

            ' VideoCapture1.FaceTracking_ScaleFactor = Int32.Parse(edFaceTrackingScaleFactor.Text)
            VideoCapture1.Face_Tracking.ScalingMode = cbFaceTrackingScalingMode.SelectedIndex
            VideoCapture1.Face_Tracking.SearchMode = cbFaceTrackingSearchMode.SelectedIndex

        Else

            VideoCapture1.Face_Tracking = Nothing

        End If

    End Sub

    Private Sub ConfigureVideoEffects()

        VideoCapture1.Video_Effects_Enabled = cbEffects.Checked
        VideoCapture1.Video_Effects_MergeImageLogos = cbMergeImageLogos.Checked
        VideoCapture1.Video_Effects_MergeTextLogos = cbMergeTextLogos.Checked
        VideoCapture1.Video_Effects_Clear()

        'Deinterlace
        If cbDeinterlace.Checked And VideoCapture1.Mode <> VideoCaptureMode.ScreenCapture And VideoCapture1.Mode <> VideoCaptureMode.ScreenPreview Then

            If rbDeintBlendEnabled.Checked Then
                Dim blend As IVideoEffectDeinterlaceBlend
                Dim effect = VideoCapture1.Video_Effects_Get("DeinterlaceBlend")
                If IsNothing(effect) Then
                    blend = New VideoEffectDeinterlaceBlend(True)
                    VideoCapture1.Video_Effects_Add(blend)
                Else
                    blend = effect
                End If

                If (IsNothing(blend)) Then

                    MessageBox.Show("Unable to configure deinterlace blend effect.")
                    Return
                End If

                blend.Threshold1 = Convert.ToInt32(edDeintBlendThreshold1.Text)
                blend.Threshold2 = Convert.ToInt32(edDeintBlendThreshold2.Text)
                blend.Constants1 = Convert.ToInt32(edDeintBlendConstants1.Text) / 10.0
                blend.Constants2 = Convert.ToInt32(edDeintBlendConstants2.Text) / 10.0
            ElseIf (rbDeintCAVTEnabled.Checked) Then
                Dim cavt As IVideoEffectDeinterlaceCAVT
                Dim effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT")
                If (IsNothing(effect)) Then
                    cavt = New VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.Checked, Convert.ToInt32(edDeintCAVTThreshold.Text))
                    VideoCapture1.Video_Effects_Add(cavt)
                Else
                    cavt = effect
                End If

                If (IsNothing(cavt)) Then
                    MessageBox.Show("Unable to configure deinterlace CAVT effect.")
                    Return
                End If

                cavt.Threshold = Convert.ToInt32(edDeintCAVTThreshold.Text)
            Else
                Dim triangle As IVideoEffectDeinterlaceTriangle
                Dim effect = VideoCapture1.Video_Effects_Get("DeinterlaceTriangle")
                If (IsNothing(effect)) Then
                    triangle = New VideoEffectDeinterlaceTriangle(True, Convert.ToByte(edDeintTriangleWeight.Text))
                    VideoCapture1.Video_Effects_Add(triangle)
                Else
                    triangle = effect
                End If

                If (IsNothing(triangle)) Then
                    MessageBox.Show("Unable to configure deinterlace triangle effect.")
                    Return
                End If

                triangle.Weight = Convert.ToByte(edDeintTriangleWeight.Text)
            End If

        End If

        'Denoise
        If cbDenoise.Checked And VideoCapture1.Mode <> VideoCaptureMode.ScreenCapture And VideoCapture1.Mode <> VideoCaptureMode.ScreenPreview Then

            If (rbDenoiseCAST.Checked) Then
                Dim cast As IVideoEffectDenoiseCAST
                Dim effect = VideoCapture1.Video_Effects_Get("DenoiseCAST")
                If (IsNothing(effect)) Then
                    cast = New VideoEffectDenoiseCAST(True)
                    VideoCapture1.Video_Effects_Add(cast)
                Else
                    cast = effect
                End If

                If (IsNothing(cast)) Then
                    MessageBox.Show("Unable to configure denoise CAST effect.")
                    Return
                End If
            Else
                Dim mosquito As IVideoEffectDenoiseMosquito
                Dim effect = VideoCapture1.Video_Effects_Get("DenoiseMosquito")
                If (IsNothing(effect)) Then
                    mosquito = New VideoEffectDenoiseMosquito(True)
                    VideoCapture1.Video_Effects_Add(mosquito)
                Else
                    mosquito = effect
                End If

                If (IsNothing(mosquito)) Then
                    MessageBox.Show("Unable to configure denoise mosquito effect.")
                    Return
                End If
            End If

        End If

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

        If (cbZoom.Checked) Then
            cbZoom_CheckedChanged(Nothing, Nothing)
        End If

        If (cbPan.Checked) Then
            cbPan_CheckedChanged(Nothing, Nothing)
        End If

        If cbLiveRotation.Checked Then
            cbLiveRotation_CheckedChanged(Nothing, Nothing)
        End If

        If cbFadeInOut.Checked Then
            cbFadeInOut_CheckedChanged(Nothing, Nothing)
        End If

        If cbFlipX.Checked Then
            cbFlipX_CheckedChanged(Nothing, Nothing)
        End If

        If cbFlipY.Checked Then
            cbFlipY_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub SelectCrossbar()

        If cbCrossBarAvailable.Enabled Then
            If rbCrossbarSimple.Checked Then
                If cbCrossbarVideoInput.SelectedIndex <> -1 Then
                    VideoCapture1.Video_CaptureDevice_CrossBar_ClearConnections()
                    VideoCapture1.Video_CaptureDevice_CrossBar_Connect(cbCrossbarVideoInput.Text, "Video Decoder", True)
                End If
            Else

                'all routes must be already applied
                'you don't need to do anything
            End If
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
        If (mp4SettingsDialog Is Nothing) Then
            mp4SettingsDialog = New MP4SettingsDialog()
        End If

        mp4SettingsDialog.SaveSettings(mp4Output)
    End Sub

    Private Sub SetFFMPEGOutput(ByRef ffmpegOutput As FFMPEGOutput)
        If (ffmpegSettingsDialog Is Nothing) Then
            ffmpegSettingsDialog = New FFMPEGSettingsDialog()
        End If

        ffmpegSettingsDialog.SaveSettings(ffmpegOutput)
    End Sub

    Private Sub SetFFMPEGEXEOutput(ByRef ffmpegOutput As FFMPEGEXEOutput)
        If (ffmpegEXESettingsDialog Is Nothing) Then
            ffmpegEXESettingsDialog = New FFMPEGEXESettingsDialog()
        End If

        ffmpegEXESettingsDialog.SaveSettings(ffmpegOutput)
    End Sub

    Private Sub SetGIFOutput(ByRef gifOutput As AnimatedGIFOutput)
        If (gifSettingsDialog Is Nothing) Then
            gifSettingsDialog = New GIFSettingsDialog()
        End If

        gifSettingsDialog.SaveSettings(gifOutput)
    End Sub

    Private Sub SetDirectCaptureCustomOutput(ByRef directCaptureOutput As DirectCaptureCustomOutput)
        If (customFormatSettingsDialog Is Nothing) Then
            customFormatSettingsDialog = New CustomFormatSettingsDialog(
                VideoCapture1.Video_Codecs.ToArray(),
                VideoCapture1.Audio_Codecs.ToArray(),
                VideoCapture1.DirectShow_Filters.ToArray())
        End If

        customFormatSettingsDialog.SaveSettings(directCaptureOutput)
    End Sub

    Private Sub SetDirectCaptureCustomOutput(ByRef directCaptureOutput As DirectCaptureMP4Output)
        If (customFormatSettingsDialog Is Nothing) Then

            customFormatSettingsDialog = New CustomFormatSettingsDialog(
                VideoCapture1.Video_Codecs.ToArray(),
                VideoCapture1.Audio_Codecs.ToArray(),
                VideoCapture1.DirectShow_Filters.ToArray())
        End If

        customFormatSettingsDialog.SaveSettings(directCaptureOutput)
    End Sub

    Private Sub SetWebMOutput(ByRef webmOutput As WebMOutput)
        If (webmSettingsDialog Is Nothing) Then
            webmSettingsDialog = New WebMSettingsDialog()
        End If

        webmSettingsDialog.SaveSettings(webmOutput)
    End Sub

    Private Sub SetM4AOutput(ByRef m4aOutput As M4AOutput)
        If (m4aSettingsDialog Is Nothing) Then
            m4aSettingsDialog = New M4ASettingsDialog()
        End If

        m4aSettingsDialog.SaveSettings(m4aOutput)
    End Sub

    Private Sub SetWMVOutput(ByRef wmvOutput As WMVOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
        End If

        wmvSettingsDialog.WMA = False
        wmvSettingsDialog.SaveSettings(wmvOutput)
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

    Private Sub SetCustomOutput(ByRef customOutput As CustomOutput)
        If (customFormatSettingsDialog Is Nothing) Then
            customFormatSettingsDialog = New CustomFormatSettingsDialog(
                        VideoCapture1.Video_Codecs.ToArray(),
                        VideoCapture1.Audio_Codecs.ToArray(),
                        VideoCapture1.DirectShow_Filters.ToArray())
        End If

        customFormatSettingsDialog.SaveSettings(customOutput)
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
            SetMP3Output(mp3Output)
            aviOutput.MP3 = mp3Output
        End If
    End Sub

    Private Sub SetMKVOutput(ByRef mkvOutput As MKVv1Output)
        If (aviSettingsDialog Is Nothing) Then
            aviSettingsDialog = New AVISettingsDialog(
                    VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray())
        End If

        aviSettingsDialog.SaveSettings(mkvOutput)

        If (mkvOutput.Audio_UseMP3Encoder) Then
            Dim mp3Output = New MP3Output()
            SetMP3Output(mp3Output)
            mkvOutput.MP3 = mp3Output
        End If
    End Sub

    Private Sub ShowOnScreen(window As Form, screenNumber As Int32)
        If (screenNumber >= 0 And screenNumber < Screen.AllScreens.Length) Then
            window.Location = Screen.AllScreens(screenNumber).WorkingArea.Location

            window.Show()

            window.Width = Screen.AllScreens(screenNumber).Bounds.Width
            window.Height = Screen.AllScreens(screenNumber).Bounds.Height
            window.Left = Screen.AllScreens(screenNumber).Bounds.Left
            window.Top = Screen.AllScreens(screenNumber).Bounds.Top
            window.TopMost = True
            window.FormBorderStyle = FormBorderStyle.None
            window.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub ConfigureMultiscreen()
        VideoCapture1.MultiScreen_Clear()
        VideoCapture1.MultiScreen_Enabled = cbMultiscreenDrawOnPanels.Checked Or cbMultiscreenDrawOnExternalDisplays.Checked

        If (Not VideoCapture1.MultiScreen_Enabled) Then
            Return
        End If

        If (cbMultiscreenDrawOnPanels.Checked) Then
            VideoCapture1.MultiScreen_AddScreen(pnScreen1.Handle, pnScreen1.Width, pnScreen1.Height)
            VideoCapture1.MultiScreen_AddScreen(pnScreen2.Handle, pnScreen2.Width, pnScreen2.Height)
            VideoCapture1.MultiScreen_AddScreen(pnScreen3.Handle, pnScreen3.Width, pnScreen3.Height)
        End If

        If (cbMultiscreenDrawOnExternalDisplays.Checked) Then

            If (Screen.AllScreens.Length > 1) Then

                For i As Integer = 1 To Screen.AllScreens.Length
                    Dim additinalWindow1 As Form = New Form()
                    ShowOnScreen(additinalWindow1, i)
                    VideoCapture1.MultiScreen_AddScreen(additinalWindow1.Handle, additinalWindow1.Width, additinalWindow1.Height)
                    multiscreenWindows.Add(additinalWindow1)
                Next
            End If
        End If
    End Sub

    Private Sub ConfigureNetworkStreaming()

        VideoCapture1.Network_Streaming_Enabled = True

        Select Case (cbNetworkStreamingMode.SelectedIndex)
            Case 0
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.WMV

                If (rbNetworkStreamingUseMainWMVSettings.Checked) Then
                    Dim wmvOutput As WMVOutput = New WMVOutput()
                    SetWMVOutput(wmvOutput)
                    VideoCapture1.Network_Streaming_Output = wmvOutput
                Else
                    Dim wmvOutput As WMVOutput = New WMVOutput()
                    wmvOutput.Mode = WMVMode.ExternalProfile
                    wmvOutput.External_Profile_FileName = edNetworkStreamingWMVProfile.Text
                    VideoCapture1.Network_Streaming_Output = wmvOutput
                End If

                VideoCapture1.Network_Streaming_WMV_Maximum_Clients = Convert.ToInt32(edMaximumClients.Text)
                VideoCapture1.Network_Streaming_Network_Port = Convert.ToInt32(edWMVNetworkPort.Text)
            Case 1
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW

                Dim mp4Output As MP4Output = New MP4Output()
                SetMP4Output(mp4Output)
                VideoCapture1.Network_Streaming_Output = mp4Output

                VideoCapture1.Network_Streaming_URL = edNetworkRTSPURL.Text
            Case 2
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.RTMP_FFMPEG_EXE

                Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                If (rbNetworkUDPFFMPEG.Checked) Then
                    ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)
                Else
                    SetFFMPEGEXEOutput(ffmpegOutput)
                End If

                ffmpegOutput.OutputMuxer = OutputMuxer.FLV
                ffmpegOutput.UsePipe = cbNetworkRTMPFFMPEGUsePipes.Checked

                VideoCapture1.Network_Streaming_Output = ffmpegOutput
                VideoCapture1.Network_Streaming_URL = edNetworkRTMPURL.Text
            Case 3
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.NDI

                Dim ndiOutput As NDIOutput = New NDIOutput(edNDIName.Text)
                VideoCapture1.Network_Streaming_Output = ndiOutput
                edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}"
            Case 4
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.UDP_FFMPEG_EXE

                Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                If (rbNetworkUDPFFMPEG.Checked) Then
                    ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)
                Else
                    SetFFMPEGEXEOutput(ffmpegOutput)
                End If

                ffmpegOutput.OutputMuxer = OutputMuxer.MPEGTS
                ffmpegOutput.UsePipe = cbNetworkUDPFFMPEGUsePipes.Checked
                VideoCapture1.Network_Streaming_Output = ffmpegOutput

                VideoCapture1.Network_Streaming_URL = edNetworkUDPURL.Text
            Case 5
                If (rbNetworkSSSoftware.Checked) Then
                    VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.SSF_H264_AAC_SW

                    Dim mp4Output As MP4Output = New MP4Output()
                    SetMP4Output(mp4Output)
                    VideoCapture1.Network_Streaming_Output = mp4Output
                Else
                    VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.SSF_FFMPEG_EXE

                    Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                    If (rbNetworkSSFFMPEGDefault.Checked) Then
                        ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)
                    Else
                        SetFFMPEGEXEOutput(ffmpegOutput)
                    End If

                    ffmpegOutput.OutputMuxer = OutputMuxer.ISMV
                    ffmpegOutput.UsePipe = cbNetworkSSUsePipes.Checked
                    VideoCapture1.Network_Streaming_Output = ffmpegOutput
                End If

                VideoCapture1.Network_Streaming_URL = edNetworkSSURL.Text
            Case 6
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.HLS

                Dim hls As HLSOutput = New HLSOutput()
                hls.HLS.SegmentDuration = Convert.ToInt32(edHLSSegmentDuration.Text)
                hls.HLS.NumSegments = Convert.ToInt32(edHLSSegmentCount.Text)
                hls.HLS.OutputFolder = edHLSOutputFolder.Text
                hls.HLS.PlaylistType = cbHLSMode.SelectedIndex
                hls.HLS.Custom_HTTP_Server_Enabled = cbHLSEmbeddedHTTPServerEnabled.Checked
                hls.HLS.Custom_HTTP_Server_Port = Convert.ToInt32(edHLSEmbeddedHTTPServerPort.Text)
                VideoCapture1.Network_Streaming_Output = hls

                If (cbHLSEmbeddedHTTPServerEnabled.Checked) Then
                    edHLSURL.Text = $"http://localhost:{edHLSEmbeddedHTTPServerPort.Text}/playlist.m3u8"
                Else
                    edHLSURL.Text = String.Empty
                End If
            Case 7
                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.External
        End Select

        VideoCapture1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.Checked
    End Sub

    Private Sub SelectVideoCaptureSource()

        'from video capture device
        VideoCapture1.Video_CaptureDevice = New VideoCaptureSource(cbVideoInputDevice.Text)
        VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text
        VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked

        VideoCapture1.Video_CaptureDevice.UseClosedCaptions = cbUseClosedCaptions.Checked

        If cbVideoInputFrameRate.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice.FrameRate = New VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text))
        End If

        VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked

    End Sub

    Private Sub SelectCustomSource()

        VideoCapture1.Custom_Source = New CustomSourceSettings()

        If (cbCustomVideoSourceCategory.SelectedIndex = 0) Then
            VideoCapture1.Custom_Source.VideoFilterCategory = FilterCategoryX.VideoCaptureSource
        Else
            VideoCapture1.Custom_Source.VideoFilterCategory = FilterCategoryX.DirectShowFilters
        End If

        VideoCapture1.Custom_Source.VideoFilterName = cbCustomVideoSourceFilter.Text
        VideoCapture1.Custom_Source.VideoFilterFormat = cbCustomVideoSourceFormat.Text
        VideoCapture1.Custom_Source.VideoFilenameOrURL = edCustomVideoSourceURL.Text

        If (String.IsNullOrEmpty(cbCustomVideoSourceFrameRate.Text)) Then
            VideoCapture1.Custom_Source.VideoFilterFrameRate = VideoFrameRate.Empty
        Else
            VideoCapture1.Custom_Source.VideoFilterFrameRate = New VideoFrameRate(Convert.ToDouble(cbCustomVideoSourceFrameRate.Text))
        End If

        If (cbCustomAudioSourceCategory.SelectedIndex = 0) Then
            VideoCapture1.Custom_Source.AudioFilterCategory = FilterCategoryX.AudioCaptureSource
        Else
            VideoCapture1.Custom_Source.AudioFilterCategory = FilterCategoryX.DirectShowFilters
        End If

        VideoCapture1.Custom_Source.AudioFilterName = cbCustomAudioSourceFilter.Text
        VideoCapture1.Custom_Source.AudioFilterFormat = cbCustomAudioSourceFormat.Text
        VideoCapture1.Custom_Source.AudioFilenameOrURL = edCustomAudioSourceURL.Text

    End Sub

    Private Sub SelectBDASource()

        VideoCapture1.BDA_Source = New BDASourceSettings()
        VideoCapture1.BDA_Source.ReceiverName = cbBDAReceiver.Text
        VideoCapture1.BDA_Source.SourceType = cbBDADeviceStandard.SelectedIndex
        VideoCapture1.BDA_Source.SourceName = cbBDASourceDevice.Text

        If (VideoCapture1.BDA_Source.SourceType = BDAType.DVBT) Then

            Dim bdaTuningParameters As BDATuningParameters = New BDATuningParameters

            bdaTuningParameters.Frequency = Convert.ToInt32(edDVBTFrequency.Text)
            bdaTuningParameters.ONID = Convert.ToInt32(edDVBTONID.Text)
            bdaTuningParameters.SID = Convert.ToInt32(edDVBTSID.Text)
            bdaTuningParameters.TSID = Convert.ToInt32(edDVBTTSID.Text)

            VideoCapture1.BDA_SetParameters(bdaTuningParameters)

        End If
    End Sub

    Private Function SelectIPCameraSource() As IPCameraSourceSettings

        Dim settings As IPCameraSourceSettings = New IPCameraSourceSettings()
        settings.URL = New Uri(cbIPURL.Text)

        Dim lavGPU As Boolean = False
        Select Case (cbIPCameraType.SelectedIndex)
            Case 0
                settings.Type = IPSourceEngine.Auto_VLC
            Case 1
                settings.Type = IPSourceEngine.Auto_FFMPEG
            Case 2
                settings.Type = IPSourceEngine.Auto_LAV
            Case 3
                settings.Type = IPSourceEngine.Auto_LAV
            Case 4
                settings.Type = IPSourceEngine.MMS_WMV
            Case 5
                settings.Type = IPSourceEngine.HTTP_MJPEG_LowLatency
                cbIPAudioCapture.Checked = False
            Case 6
                settings.Type = IPSourceEngine.RTSP_LowLatency
                settings.RTSP_LowLatency_UseUDP = False
            Case 7
                settings.Type = IPSourceEngine.RTSP_LowLatency
                settings.RTSP_LowLatency_UseUDP = True
            Case 8
                settings.Type = IPSourceEngine.NDI
            Case 9
                settings.Type = IPSourceEngine.NDI_Legacy
        End Select

        settings.AudioCapture = cbIPAudioCapture.Checked
        settings.Login = edIPLogin.Text
        settings.Password = edIPPassword.Text
        settings.ForcedFramerate = Convert.ToDouble(edIPForcedFramerate.Text)
        settings.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text(0)
        settings.Debug_Enabled = cbDebugMode.Checked
        settings.Debug_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "ip_cam_log.txt")
        settings.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.Checked
        settings.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text)

        If (settings.Type = IPSourceEngine.Auto_LAV) Then
            settings.LAV_GPU_Use = lavGPU
            settings.LAV_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack
        End If

        If (cbIPCameraONVIF.Checked) Then
            settings.ONVIF_Source = True

            If (cbONVIFProfile.SelectedIndex <> -1) Then
                settings.ONVIF_SourceProfile = cbONVIFProfile.Text
            End If
        End If

        If (cbIPDisconnect.Checked) Then
            settings.DisconnectEventInterval = TimeSpan.FromSeconds(10)
        End If

        Return settings

    End Function

    Private Function SelectScreenSource() As ScreenCaptureSourceSettings
        Dim settings As ScreenCaptureSourceSettings = New ScreenCaptureSourceSettings()

        If (rbScreenCaptureWindow.Checked) Then
            settings.Mode = ScreenCaptureMode.Window

            settings.WindowHandle = IntPtr.Zero

            Try
                If (windowCaptureForm Is Nothing) Then
                    MessageBox.Show("Window for screen capture is not specified.")
                    Return Nothing
                End If

                settings.WindowHandle = windowCaptureForm.CapturedWindowHandle
            Catch

            End Try

            If (settings.WindowHandle = IntPtr.Zero) Then
                MessageBox.Show("Incorrect window title for screen capture.")
                Return Nothing
            End If
        Else
            settings.Mode = ScreenCaptureMode.Screen
        End If

        settings.FrameRate = New VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text))
        settings.FullScreen = rbScreenFullScreen.Checked
        settings.Top = Convert.ToInt32(edScreenTop.Text)
        settings.Bottom = Convert.ToInt32(edScreenBottom.Text)
        settings.Left = Convert.ToInt32(edScreenLeft.Text)
        settings.Right = Convert.ToInt32(edScreenRight.Text)
        settings.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked
        settings.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text)
        settings.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked

        Return settings
    End Function

    Private Async Sub btStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStop.Click

        tmRecording.Stop()

        VideoCapture1.Video_Filters_Clear()
        Await VideoCapture1.StopAsync()

        If cbMultiscreenDrawOnPanels.Checked Then
            pnScreen1.Refresh()
            pnScreen2.Refresh()
            pnScreen3.Refresh()
        End If

        For Each form As Form In multiscreenWindows
            form.Close()
            'form.Dispose()
        Next

        multiscreenWindows.Clear()

        'clear VU Meters
        Dim data(19) As Int32

        peakMeterCtrl1.SetData(data, 0, 19)
        peakMeterCtrl1.Stop()
        waveformPainter1.Clear()
        waveformPainter2.Clear()

        volumeMeter1.Clear()
        volumeMeter2.Clear()

        cbPIPDevices.Items.Clear()

        lbFilters.Items.Clear()
    End Sub

    ' ReSharper disable once UnusedParameter.Local
    Private Sub cbAudioOutputDevice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAudioOutputDevice.SelectedIndexChanged
        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text
    End Sub

    Private Sub cbCrossbarInput_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCrossbarInput.SelectedIndexChanged
        Dim RelatedInput As String = "", RelatedOutput As String = ""

        If cbCrossbarInput.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice_CrossBar_GetRelated(cbCrossbarInput.Text, cbCrossbarOutput.Text, RelatedInput, RelatedOutput)
        End If
    End Sub

    Private Sub cbCrossbarOutput_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbCrossbarOutput.SelectedIndexChanged
        cbCrossbarInput.Items.Clear()

        If cbCrossbarOutput.SelectedIndex <> -1 Then

            Dim inputs As List(Of String)

            inputs = VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput(cbCrossbarOutput.Text).ToList()
            For i As Integer = 0 To inputs.Count - 1
                cbCrossbarInput.Items.Add(inputs.Item(i))
            Next i
        End If

        Dim input1 As String
        input1 = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Text)

        If input1 <> "" Then
            cbCrossbarInput.SelectedIndex = cbCrossbarInput.Items.IndexOf(input1)
        Else
            cbCrossbarInput.SelectedIndex = -1
        End If

        cbCrossbarInput_SelectedIndexChanged(sender, e)
    End Sub

    Private Async Sub cbTVChannel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbTVChannel.SelectedIndexChanged
        If cbTVChannel.SelectedIndex <> -1 Then

            Dim k As Integer = Convert.ToInt32(cbTVChannel.Text)

            If k <= 10000 Then
                'channel
                VideoCapture1.TVTuner_Channel = k
            Else

                VideoCapture1.TVTuner_Channel = -1
                'must be -1 to use frequency

                VideoCapture1.TVTuner_Frequency = k
            End If

            If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
                Return
            End If

            Await VideoCapture1.TVTuner_ApplyAsync()
            Await VideoCapture1.TVTuner_ReadAsync()
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString()
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString()
        End If
    End Sub

    Private Async Sub cbTVTuner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbTVTuner.SelectedIndexChanged

        If cbTVTuner.Items.Count > 0 And cbTVTuner.SelectedIndex <> -1 Then
            VideoCapture1.TVTuner_Name = cbTVTuner.Text
            Await VideoCapture1.TVTuner_ReadAsync()

            cbTVMode.Items.Clear()
            For i As Integer = 0 To VideoCapture1.TVTuner_Modes.Count - 1
                cbTVMode.Items.Add(VideoCapture1.TVTuner_Modes.Item(i))
            Next i

            edVideoFreq.Text = Convert.ToString(VideoCapture1.TVTuner_VideoFrequency)
            edAudioFreq.Text = Convert.ToString(VideoCapture1.TVTuner_AudioFrequency)
            cbTVInput.SelectedIndex = cbTVInput.Items.IndexOf(VideoCapture1.TVTuner_InputType)
            cbTVMode.SelectedIndex = cbTVMode.Items.IndexOf(VideoCapture1.TVTuner_Mode)
            cbTVSystem.SelectedIndex = cbTVSystem.Items.IndexOf(VideoCapture1.TVTuner_TVFormat)
            cbTVCountry.SelectedIndex = cbTVCountry.Items.IndexOf(VideoCapture1.TVTuner_Country)
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

    Private Async Sub btSaveScreenshot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSaveScreenshot.Click
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

    Private Async Sub tbAdjBrightness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjBrightness.Scroll, cbAdjBrightnessAuto.CheckedChanged
        Await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Brightness, New VideoCaptureDeviceAdjustValue(tbAdjBrightness.Value, cbAdjBrightnessAuto.Checked))
        lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(tbAdjBrightness.Value)
    End Sub

    Private Async Sub tbAdjContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjContrast.Scroll, cbAdjContrastAuto.CheckedChanged
        Await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Contrast, New VideoCaptureDeviceAdjustValue(tbAdjContrast.Value, cbAdjContrastAuto.Checked))
        lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(tbAdjContrast.Value)
    End Sub

    Private Async Sub tbAdjHue_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjHue.Scroll, cbAdjHueAuto.CheckedChanged
        Await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Hue, New VideoCaptureDeviceAdjustValue(tbAdjHue.Value, cbAdjHueAuto.Checked))
        lbAdjHueCurrent.Text = "Current: " + Convert.ToString(tbAdjHue.Value)
    End Sub

    Private Async Sub tbAdjSaturation_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjSaturation.Scroll, cbAdjSaturationAuto.CheckedChanged
        Await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Saturation, New VideoCaptureDeviceAdjustValue(tbAdjSaturation.Value, cbAdjSaturationAuto.Checked))
        lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(tbAdjSaturation.Value)
    End Sub

    Private Sub rbVR_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbVMR9.CheckedChanged, rbNone.CheckedChanged, rbEVR.CheckedChanged, rbDirect2D.CheckedChanged

        cbScreenFlipVertical.Enabled = rbVMR9.Checked Or rbDirect2D.Checked
        cbScreenFlipHorizontal.Enabled = rbVMR9.Checked Or rbDirect2D.Checked

        If Tag = 1 Then
            If rbVMR9.Checked Then
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
            ElseIf rbEVR.Checked Then
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
            ElseIf (rbDirect2D.Checked) Then
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
            Else
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None
            End If

        End If

    End Sub

    Private Sub btVideoCaptureDeviceSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btVideoCaptureDeviceSettings.Click

        VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text)

    End Sub

    Private Sub btAudioInputDeviceSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAudioInputDeviceSettings.Click

        VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text)

    End Sub

    Private Sub btConnect_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btConnect.Click
        Dim input1 As String

        If (cbCrossbarInput.SelectedIndex <> -1) And (cbCrossbarOutput.SelectedIndex <> -1) Then
            VideoCapture1.Video_CaptureDevice_CrossBar_Connect(cbCrossbarInput.Text, cbCrossbarOutput.Text, cbConnectRelated.Checked)

            lbRotes.Items.Clear()
            For i As Integer = 0 To cbCrossbarOutput.Items.Count - 1
                input1 = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Items.Item(i).ToString())
                lbRotes.Items.Add("Input: " + input1 + ", Output: " + cbCrossbarOutput.Items.Item(i))
            Next i
        End If
    End Sub

    Private Async Sub btDVFF_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVFF.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.FastestFwd)
    End Sub

    Private Async Sub btDVPause_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVPause.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Pause)
    End Sub

    Private Async Sub btDVRewind_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVRewind.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Rew)
    End Sub

    Private Async Sub btDVPlay_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVPlay.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Play)
    End Sub

    Private Async Sub btDVStepFWD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVStepFWD.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.StepFw)
    End Sub

    Private Async Sub btDVStepRev_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVStepRev.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.StepRev)
    End Sub

    Private Async Sub btDVStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVStop.Click
        Await VideoCapture1.DV_SendCommandAsync(DVCommand.Stop)
    End Sub

    Private Sub btRefreshClients_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btRefreshClients.Click

        Dim dns1 As String = "", address As String = ""

        Dim port As Integer = 0

        lbNetworkClients.Items.Clear()

        For i As Integer = 0 To VideoCapture1.Network_Streaming_WMV_Clients_GetCount - 1

            VideoCapture1.Network_Streaming_WMV_Clients_GetInfo(i, port, address, dns1)

            Dim client As String = "ID: " + i + ", Port: " + port + ", Address: " + address + ", DNS: " + dns1
            lbNetworkClients.Items.Add(client)

        Next i

    End Sub

    Private Async Sub btStartTune_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStartTune.Click

        Const KHz As Integer = 1000
        Const MHz As Integer = 1000000

        Await VideoCapture1.TVTuner_ReadAsync()
        cbTVChannel.Items.Clear()

        If (cbTVMode.SelectedIndex <> -1) And (cbTVMode.Text = "FM Radio") Then
            VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 100 * MHz
            VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 110 * MHz
            VideoCapture1.TVTuner_FM_Tuning_Step = 100 * KHz
        End If

        VideoCapture1.TVTuner_TuneChannels_Start()

    End Sub

    Private Sub btStopTune_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStopTune.Click

        VideoCapture1.TVTuner_TuneChannels_Stop()

    End Sub

    Private Async Sub btUseThisChannel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btUseThisChannel.Click
        If Convert.ToInt32(edChannel.Text) <= 10000 Then
            'channel
            VideoCapture1.TVTuner_Channel = Convert.ToInt32(edChannel.Text)
        Else

            VideoCapture1.TVTuner_Channel = -1
            'must be -1 to use frequency

            VideoCapture1.TVTuner_Frequency = Convert.ToInt32(edChannel.Text)

        End If

        If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
            Return
        End If

        Await VideoCapture1.TVTuner_ApplyAsync()
        Await VideoCapture1.TVTuner_ReadAsync()
        edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString()
        edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString()

    End Sub

    Private Async Sub cbTVCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbTVCountry.SelectedIndexChanged
        If cbTVCountry.SelectedIndex <> -1 Then

            VideoCapture1.TVTuner_Country = cbTVCountry.Text
            edTVDefaultFormat.Text = VideoCapture1.TVTuner_Countries_GetPreferredFormatForCountry(VideoCapture1.TVTuner_Country)

            If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
                Return
            End If

            If VideoCapture1.State = PlaybackState.Play Then
                Await VideoCapture1.TVTuner_ApplyAsync()
                Await VideoCapture1.TVTuner_ReadAsync()
            End If

        End If
    End Sub

    Private Async Sub cbStretch_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch.CheckedChanged

        VideoCapture1.Video_Renderer.StretchMode = cbStretch.Checked
        Await VideoCapture1.Video_Renderer_UpdateAsync()

    End Sub

    Private Async Sub cbTVSelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbTVMode.SelectedIndexChanged

        If cbTVMode.SelectedIndex <> -1 Then
            VideoCapture1.TVTuner_Mode = cbTVMode.Text

            If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
                Return
            End If

            Await VideoCapture1.TVTuner_ApplyAsync()
            Await VideoCapture1.TVTuner_ReadAsync()
            cbTVChannel.Items.Clear()
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString()
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString()
        End If

    End Sub

    Private Async Sub cbTVInput_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbTVInput.SelectedIndexChanged
        If cbTVInput.SelectedIndex <> -1 Then
            VideoCapture1.TVTuner_InputType = cbTVInput.Text

            If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
                Return
            End If

            Await VideoCapture1.TVTuner_ApplyAsync()
            Await VideoCapture1.TVTuner_ReadAsync()
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString()
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString()
        End If

    End Sub

    Private Async Sub cbTVSystem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbTVSystem.SelectedIndexChanged

        If cbTVSystem.SelectedIndex <> -1 Then
            VideoCapture1.TVTuner_TVFormat = VideoCapture1.TVTuner_TVFormat_FromString(cbTVSystem.Text)

            If String.IsNullOrEmpty(VideoCapture1.TVTuner_Name) Then
                Return
            End If

            Await VideoCapture1.TVTuner_ApplyAsync()
            Await VideoCapture1.TVTuner_ReadAsync()
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString()
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString()
        End If

    End Sub

    Private Sub cbUseBestAudioInputCheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbUseBestAudioInputFormat.CheckedChanged

        cbAudioInputFormat.Enabled = Not cbUseBestAudioInputFormat.Checked

    End Sub

    Private Sub cbUseBestVideoInputCheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbUseBestVideoInputFormat.CheckedChanged

        cbVideoInputFormat.Enabled = Not cbUseBestVideoInputFormat.Checked

    End Sub

    Private Sub tbAudioVolume_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudioVolume.Scroll

        VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value)

    End Sub

    Private Sub tbAudioBalance_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudioBalance.Scroll

        VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value)
        VideoCapture1.Audio_OutputDevice_Balance_Get()

    End Sub

    Private Sub btSelectWMVProfileNetwork_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectWMVProfileNetwork.Click

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Async Sub btPause_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btPause.Click

        Await VideoCapture1.PauseAsync()

    End Sub

    Private Async Sub btResume_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btResume.Click

        Await VideoCapture1.ResumeAsync()

    End Sub

    Private Sub btMPEGEncoderShowDialog_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMPEGEncoderShowDialog.Click

        If cbMPEGEncoder.SelectedIndex <> -1 Then
            VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_ShowDialog(IntPtr.Zero, cbMPEGEncoder.Text)
        End If

    End Sub

    Private Sub cbFilters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFilters.SelectedIndexChanged

        If cbFilters.SelectedIndex <> -1 Then

            Dim sName As String = cbFilters.Text
            btFilterSettings.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))

        End If

    End Sub

    Private Sub btFilterSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btFilterSettings.Click

        Dim sName As String = cbFilters.Text

        If (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Then
            FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
        ElseIf (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)) Then
            FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)

        End If

    End Sub

    Private Sub lbFilters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lbFilters.SelectedIndexChanged

        If lbFilters.SelectedIndex <> -1 Then

            Dim sName As String = lbFilters.Text
            btFilterSettings2.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))

        End If

    End Sub

    Private Sub btFilterSettings2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btFilterSettings2.Click

        If lbFilters.SelectedIndex <> -1 Then

            Dim sName As String = lbFilters.Text

            If (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
            ElseIf (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)

            End If

        End If

    End Sub

    Private Sub btFilterDeleteAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btFilterDeleteAll.Click

        lbFilters.Items.Clear()
        VideoCapture1.Video_Filters_Clear()

    End Sub

    Private Sub btOSDClearLayers_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDClearLayers.Click

        VideoCapture1.OSD_Layers_Clear()
        lbOSDLayers.Items.Clear()

    End Sub

    Private Sub btOSDLayerAdd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDLayerAdd.Click

        VideoCapture1.OSD_Layers_Create(
            Convert.ToInt32(edOSDLayerLeft.Text),
            Convert.ToInt32(edOSDLayerTop.Text),
            Convert.ToInt32(edOSDLayerWidth.Text),
            Convert.ToInt32(edOSDLayerHeight.Text),
            True)
        lbOSDLayers.Items.Add("layer " + Convert.ToString(lbOSDLayers.Items.Count + 1), CheckState.Checked)

    End Sub

    Private Sub btOSDSelectImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSelectImage.Click

        If openFileDialog2.ShowDialog() = DialogResult.OK Then
            edOSDImageFilename.Text = openFileDialog2.FileName
        End If

    End Sub

    Private Sub btOSDImageDraw_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDImageDraw.Click

        If (Not System.IO.File.Exists(edOSDImageFilename.Text)) Then
            MessageBox.Show("OSD image file does not exist.")
            Return
        End If

        If (lbOSDLayers.SelectedIndex <> -1) Then
            If (cbOSDImageTranspColor.Checked) Then
                VideoCapture1.OSD_Layers_Draw_Image(lbOSDLayers.SelectedIndex, edOSDImageFilename.Text, Convert.ToInt32(edOSDImageLeft.Text), Convert.ToInt32(edOSDImageTop.Text), True, pnOSDColorKey.BackColor)
            Else
                VideoCapture1.OSD_Layers_Draw_Image(lbOSDLayers.SelectedIndex, edOSDImageFilename.Text, Convert.ToInt32(edOSDImageLeft.Text), Convert.ToInt32(edOSDImageTop.Text), False, Color.Black)
            End If
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub btOSDSelectFont_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSelectFont.Click

        If fontDialog1.ShowDialog() = DialogResult.OK Then
            edOSDText.Font = fontDialog1.Font
            edOSDText.ForeColor = fontDialog1.Color
        End If

    End Sub

    Private Sub btOSDTextDraw_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDTextDraw.Click

        If lbOSDLayers.SelectedIndex <> -1 Then
            Dim fnt As Font
            Dim color1 As Color

            fnt = edOSDText.Font
            color1 = edOSDText.ForeColor

            VideoCapture1.OSD_Layers_Draw_Text(lbOSDLayers.SelectedIndex, Convert.ToInt32(edOSDTextLeft.Text), Convert.ToInt32(edOSDTextTop.Text), edOSDText.Text, fnt, color1)
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub btOSDSetTransp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSetTransp.Click

        If lbOSDLayers.SelectedIndex <> -1 Then
            VideoCapture1.OSD_Layers_SetTransparency(lbOSDLayers.SelectedIndex, tbOSDTranspLevel.Value)
            VideoCapture1.OSD_Layers_Render()
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub cbMPEGVideoDecoder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbMPEGVideoDecoder.SelectedIndexChanged

        Dim sName As String

        If cbMPEGVideoDecoder.SelectedIndex < 1 Then
            btMPEGVidDecSetting.Enabled = False
        Else
            sName = cbMPEGVideoDecoder.Text
            btMPEGVidDecSetting.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)))
        End If

    End Sub

    Private Sub cbMPEGAudioDecoder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbMPEGAudioDecoder.SelectedIndexChanged

        Dim sName As String

        If cbMPEGAudioDecoder.SelectedIndex < 1 Then
            btMPEGAudDecSettings.Enabled = False
        Else
            sName = cbMPEGVideoDecoder.Text
            btMPEGAudDecSettings.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)))
        End If

    End Sub

    Private Sub btMPEGVidDecSetting_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMPEGVidDecSetting.Click

        Dim sName As String

        If cbMPEGVideoDecoder.SelectedIndex > 0 Then
            sName = cbMPEGVideoDecoder.Text

            If FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
            ElseIf FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)
            End If
        End If

    End Sub

    Private Sub btMPEGAudDecSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMPEGAudDecSettings.Click

        Dim sName As String

        If cbMPEGAudioDecoder.SelectedIndex > 0 Then
            sName = cbMPEGAudioDecoder.Text

            If FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
            ElseIf FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)
            End If
        End If

    End Sub

    Private Async Sub btScreenCaptureUpdate_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btScreenCaptureUpdate.Click
        Await VideoCapture1.Screen_Capture_UpdateParametersAsync(Convert.ToInt32(edScreenLeft.Text), Convert.ToInt32(edScreenTop.Text), cbScreenCapture_GrabMouseCursor.Checked)
    End Sub

    Private Sub cbPIPDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbPIPDevice.SelectedIndexChanged

        If cbPIPDevice.SelectedIndex <> -1 Then
            cbPIPFormat.Items.Clear()

            Dim deviceItem = (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbPIPDevice.Text)?.FirstOrDefault()
            If Not IsNothing(deviceItem) Then
                Dim formats = deviceItem.VideoFormats
                For Each item As VideoCaptureDeviceFormat In formats
                    cbPIPFormat.Items.Add(item)
                Next

                If cbPIPFormat.Items.Count > 0 Then
                    cbPIPFormat.SelectedIndex = 0
                End If

                cbPIPInput.Items.Clear()

                VideoCapture1.PIP_Sources_Device_GetCrossbar(cbPIPDevice.Text)
                For i As Integer = 0 To VideoCapture1.PIP_Sources_Device_GetCrossbarInputs().Count - 1
                    cbPIPInput.Items.Add(VideoCapture1.PIP_Sources_Device_GetCrossbarInputs().Item(i))
                Next i

                If (cbPIPInput.Items.Count > 0) Then
                    cbPIPInput.SelectedIndex = 0
                End If
            End If
        End If

    End Sub

    Private Sub cbPIPFormatUseBest_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbPIPFormatUseBest.CheckedChanged

        cbPIPFormat.Enabled = Not cbPIPFormatUseBest.Checked

    End Sub

    Private Sub btPIPAddDevice_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btPIPAddDevice.Click

        Dim format As String
        Dim frame_rate As String
        Dim input As String

        If cbPIPDevice.SelectedIndex <> -1 Then
            If cbPIPFrameRate.SelectedIndex <> -1 Then
                frame_rate = cbPIPFrameRate.Text
            Else
                frame_rate = "0"
            End If

            If cbPIPFormat.SelectedIndex <> -1 Then
                format = cbPIPFormat.Text
            Else
                format = ""
            End If

            If (cbPIPInput.SelectedIndex <> -1) Then
                input = cbPIPInput.Text
            Else
                input = ""
            End If

            VideoCapture1.PIP_Sources_Add_VideoCaptureDevice(
                cbPIPDevice.Text,
                format,
                cbPIPFormatUseBest.Checked,
                New VideoFrameRate(Convert.ToDouble(frame_rate)),
                input,
                Convert.ToInt32(edPIPVidCapLeft.Text),
                Convert.ToInt32(edPIPVidCapTop.Text),
                Convert.ToInt32(edPIPVidCapWidth.Text),
                Convert.ToInt32(edPIPVidCapHeight.Text))

            cbPIPDevices.Items.Add(cbPIPDevice.Text)
        End If

    End Sub


    Private Async Sub cbScreenFlipVertical_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbScreenFlipVertical.CheckedChanged

        VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked
        Await VideoCapture1.Video_Renderer_UpdateAsync()

    End Sub

    Private Async Sub cbScreenFlipHorizontal_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbScreenFlipHorizontal.CheckedChanged

        VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        Await VideoCapture1.Video_Renderer_UpdateAsync()

    End Sub

    Private Sub ConfigureMotionDetection()
        If (cbMotDetEnabled.Checked) Then
            VideoCapture1.Motion_Detection = New MotionDetectionSettings()
            VideoCapture1.Motion_Detection.Enabled = cbMotDetEnabled.Checked
            VideoCapture1.Motion_Detection.Compare_Red = cbCompareRed.Checked
            VideoCapture1.Motion_Detection.Compare_Green = cbCompareGreen.Checked
            VideoCapture1.Motion_Detection.Compare_Blue = cbCompareBlue.Checked
            VideoCapture1.Motion_Detection.Compare_Greyscale = cbCompareGreyscale.Checked
            VideoCapture1.Motion_Detection.Highlight_Color = cbMotDetHLColor.SelectedIndex
            VideoCapture1.Motion_Detection.Highlight_Enabled = cbMotDetHLEnabled.Checked
            VideoCapture1.Motion_Detection.Highlight_Threshold = tbMotDetHLThreshold.Value
            VideoCapture1.Motion_Detection.FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text)
            VideoCapture1.Motion_Detection.Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text)
            VideoCapture1.Motion_Detection.Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text)
            VideoCapture1.Motion_Detection.DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked
            VideoCapture1.Motion_Detection.DropFrames_Threshold = tbMotDetDropFramesThreshold.Value
            VideoCapture1.MotionDetection_Update()
        Else
            VideoCapture1.Motion_Detection = Nothing
        End If
    End Sub

    Private Sub btMotDetUpdateSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMotDetUpdateSettings.Click
        ConfigureMotionDetection()
    End Sub

    Private Async Sub btSignal_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSignal.Click

        If Await VideoCapture1.Video_CaptureDevice_SignalPresentAsync() Then
            MessageBox.Show("Signal present")
        Else
            MessageBox.Show("Signal not present")
        End If

    End Sub

    Private Async Sub cbStretch1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch1.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Async Sub cbFlipVertical1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipVertical1.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Async Sub cbFlipHorizontal1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipHorizontal1.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Async Sub cbStretch2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch2.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Async Sub cbFlipVertical2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipVertical2.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Async Sub cbFlipHorizontal2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipHorizontal2.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Async Sub cbStretch3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch3.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(2, cbStretch3.Checked, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked)

    End Sub

    Private Async Sub cbFlipVertical3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipVertical3.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(2, cbStretch3.Checked, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked)

    End Sub

    Private Async Sub cbFlipHorizontal3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFlipHorizontal3.CheckedChanged

        Await VideoCapture1.MultiScreen_SetParametersAsync(2, cbStretch3.Checked, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked)

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

    Private Sub cbAudioEffectsEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioEffectsEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked)

    End Sub

    Private Sub pnOSDColorKey_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles pnOSDColorKey.Click

        If colorDialog1.ShowDialog() = DialogResult.OK Then
            pnOSDColorKey.BackColor = colorDialog1.Color
        End If

    End Sub

    Private Sub btAudEqRefresh_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAudEqRefresh.Click

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

    Private Async Sub btZoomIn_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomIn.Click
        VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio + 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomOut_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomOut.Click
        VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio - 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftDown.Click
        VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY - 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftLeft_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftLeft.Click
        VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX - 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftRight_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftRight.Click
        VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX + 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftUp.Click
        VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY + 10
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomReset_Click(sender As Object, e As EventArgs) Handles btZoomReset.Click
        VideoCapture1.Video_Renderer.Zoom_Ratio = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftX = 0
        VideoCapture1.Video_Renderer.Zoom_ShiftY = 0

        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Sub cbAudAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudAmplifyEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked)

    End Sub

    Private Sub cbAudDynamicAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudDynamicAmplifyEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked)

    End Sub

    Private Sub tbAud3DSound_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAud3DSound.Scroll

        VideoCapture1.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, tbAud3DSound.Value)

    End Sub

    Private Sub tbAudAmplifyAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAmplifyAmp.Scroll

        VideoCapture1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, False)

    End Sub

    Private Sub tbAudAttack_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAttack.Scroll

        VideoCapture1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudEq0_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq0.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, tbAudEq0.Value)

    End Sub

    Private Sub tbAudEq1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq1.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, tbAudEq1.Value)

    End Sub

    Private Sub tbAudEq2_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq2.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, tbAudEq2.Value)

    End Sub

    Private Sub tbAudEq3_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq3.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, tbAudEq3.Value)

    End Sub

    Private Sub tbAudEq4_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq4.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, tbAudEq4.Value)

    End Sub

    Private Sub tbAudEq5_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq5.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, tbAudEq5.Value)

    End Sub

    Private Sub tbAudEq6_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq6.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, tbAudEq6.Value)

    End Sub

    Private Sub tbAudEq7_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq7.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, tbAudEq7.Value)

    End Sub

    Private Sub tbAudEq8_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq8.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, tbAudEq8.Value)

    End Sub

    Private Sub tbAudEq9_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq9.Scroll

        VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, tbAudEq9.Value)

    End Sub

    Private Sub tbAudTrueBass_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudTrueBass.Scroll

        VideoCapture1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, False, tbAudTrueBass.Value)

    End Sub

    Private Sub tbAudRelease_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudRelease.Scroll

        VideoCapture1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub cbAudEqualizerPreset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudEqualizerPreset.SelectedIndexChanged

        VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerPreset.SelectedIndex)
        btAudEqRefresh_Click(sender, e)

    End Sub

    Private Sub cbAudSound3DEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudSound3DEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked)

    End Sub

    Private Sub cbAudTrueBassEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudTrueBassEnabled.CheckedChanged

        VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked)

    End Sub

    Private Sub tbAudDynAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudDynAmp.Scroll

        VideoCapture1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, False)

    End Sub

    Private Sub llVideoTutorials_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub VideoCapture1_OnTVTunerTuneChannels(ByVal sender As System.Object, ByVal e As TVTunerTuneChannelsEventArgs) Handles VideoCapture1.OnTVTunerTuneChannels

        BeginInvoke(Sub()
                        Application.DoEvents()

                        pbChannels.Value = e.Progress

                        If e.SignalPresent Then
                            cbTVChannel.Items.Add(e.Channel.ToString())

                            If e.Channel = -1 Then

                                pbChannels.Value = 0
                                MessageBox.Show("AutoTune complete")

                            End If
                        End If

                        Application.DoEvents()
                    End Sub)

    End Sub

    Private Delegate Sub MotionDelegate(ByVal e As MotionDetectionEventArgs)

    Private Sub MotionDelegateMethod(ByVal e As MotionDetectionEventArgs)

        Dim s As String = String.Empty

        Dim k As Integer
        For Each b As Byte In e.Matrix
            s += b.ToString("D3") + " "

            If (k = VideoCapture1.Motion_Detection.Matrix_Width - 1) Then
                k = 0
                s += Environment.NewLine
            Else
                k += 1
            End If
        Next

        mmMotDetMatrix.Text = s.Trim()
        pbMotionLevel.Value = e.Level

    End Sub

    Private Sub VideoCapture1_OnMotion(ByVal sender As System.Object, ByVal e As MotionDetectionEventArgs) Handles VideoCapture1.OnMotion

        Dim motdel As MotionDelegate = New MotionDelegate(AddressOf MotionDelegateMethod)
        BeginInvoke(motdel, e)

    End Sub

    Private Delegate Sub VUDelegate(ByVal e As VUMeterEventArgs)

    Private Sub VUDelegateMethod(ByVal e As VUMeterEventArgs)

        If (VideoCapture1.State = PlaybackState.Free) Then
            Return
        End If

        peakMeterCtrl1.SetData(e.MeterData, 0, 19)

    End Sub

    Private Sub VideoCapture1_OnAudioVUMeter(ByVal sender As System.Object, ByVal e As VUMeterEventArgs) Handles VideoCapture1.OnAudioVUMeter

        BeginInvoke(New VUDelegate(AddressOf VUDelegateMethod), e)

    End Sub

    ' ReSharper disable once MemberCanBePrivate.Global
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub VideoCapture1_OnObjectDetection(ByVal sender As System.Object, ByVal e As MotionDetectionExEventArgs) Handles VideoCapture1.OnMotionDetectionEx

        Dim motdel As AFMotionDelegate = New AFMotionDelegate(AddressOf AFMotionDelegateMethod)
        BeginInvoke(motdel, e.Level)

    End Sub

    Private Delegate Sub AFMotionDelegate(ByVal level As System.Single)

    Private Sub AFMotionDelegateMethod(ByVal level As System.Single)

        pbAFMotionLevel.Value = level * 100

    End Sub

    Private Sub cbAFMotionDetection_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbMotionDetectionEx.CheckedChanged

        ConfigureMotionDetectionEx()

    End Sub

    Private Async Sub btSeparateCaptureStart_Click(sender As System.Object, e As EventArgs) Handles btSeparateCaptureStart.Click

        Await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text)

    End Sub

    Private Async Sub btSeparateCaptureStop_Click(sender As System.Object, e As EventArgs) Handles btSeparateCaptureStop.Click

        Await VideoCapture1.SeparateCapture_StopAsync()

    End Sub

    Private Async Sub btSeparateCaptureChangeFilename_Click(sender As System.Object, e As EventArgs) Handles btSeparateCaptureChangeFilename.Click

        Await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text)

    End Sub


    Private Sub btPIPAddIPCamera_Click(sender As System.Object, e As EventArgs) Handles btPIPAddIPCamera.Click

        Dim ipCameraSource As IPCameraSourceSettings = SelectIPCameraSource()

        VideoCapture1.PIP_Sources_Add_IPCamera(
            ipCameraSource,
            Convert.ToInt32(edPIPScreenCapLeft.Text),
            Convert.ToInt32(edPIPScreenCapTop.Text),
            Convert.ToInt32(edPIPScreenCapWidth.Text),
            Convert.ToInt32(edPIPScreenCapHeight.Text))

        cbPIPDevices.Items.Add("IP Capture")

    End Sub

    Private Sub btPIPAddScreenCapture_Click(sender As System.Object, e As EventArgs) Handles btPIPAddScreenCapture.Click

        Dim screenSource As ScreenCaptureSourceSettings = SelectScreenSource()

        VideoCapture1.PIP_Sources_Add_ScreenSource(
            screenSource,
            Convert.ToInt32(edPIPScreenCapLeft.Text),
            Convert.ToInt32(edPIPScreenCapTop.Text),
            Convert.ToInt32(edPIPScreenCapWidth.Text),
            Convert.ToInt32(edPIPScreenCapHeight.Text))

        cbPIPDevices.Items.Add("Screen Capture")

    End Sub

    Private Sub btPIPDevicesClear_Click(sender As System.Object, e As EventArgs) Handles btPIPDevicesClear.Click

        VideoCapture1.PIP_Sources_Clear()
        cbPIPDevices.Items.Clear()

    End Sub

    Private Async Sub btPIPUpdate_Click(sender As System.Object, e As EventArgs) Handles btPIPUpdate.Click

        If (cbPIPDevices.SelectedIndex <> -1) Then
            Dim rect As Rectangle = New Rectangle(
                Convert.ToInt32(edPIPLeft.Text),
                Convert.ToInt32(edPIPTop.Text),
                Convert.ToInt32(edPIPWidth.Text),
                Convert.ToInt32(edPIPHeight.Text))
            Await VideoCapture1.PIP_Sources_SetSourcePositionAsync(cbPIPDevices.SelectedIndex, rect)
        Else
            MessageBox.Show("Select device!")
        End If

    End Sub

    Private Sub btPIPSetOutputSize_Click(sender As System.Object, e As EventArgs) Handles btPIPSetOutputSize.Click

        VideoCapture1.PIP_CustomOutputSize_Set(Convert.ToInt32(edPIPOutputWidth.Text), Convert.ToInt32(edPIPOutputHeight.Text))

    End Sub

    Private Async Sub btPIPSet_Click(sender As System.Object, e As EventArgs) Handles btPIPSet.Click

        If (cbPIPDevices.SelectedIndex <> -1) Then
            Await VideoCapture1.PIP_Sources_SetSourceSettingsAsync(cbPIPDevices.SelectedIndex, tbPIPTransparency.Value, False, False)
        Else
            MessageBox.Show("Select device!")
        End If

    End Sub

    Private Async Sub btSeparateCapturePause_Click(sender As System.Object, e As EventArgs) Handles btSeparateCapturePause.Click

        Await VideoCapture1.SeparateCapture_PauseAsync()

    End Sub

    Private Async Sub btSeparateCaptureResume_Click(sender As System.Object, e As EventArgs) Handles btSeparateCaptureResume.Click

        Await VideoCapture1.SeparateCapture_ResumeAsync()

    End Sub

    Private Sub btDVBTTune_Click(sender As System.Object, e As EventArgs) Handles btDVBTTune.Click

        If (Not IsNothing(VideoCapture1.BDA_Source) And VideoCapture1.BDA_Source.SourceType = BDAType.DVBT) Then

            Dim bdaTuningParameters As BDATuningParameters = New BDATuningParameters

            bdaTuningParameters.Frequency = Convert.ToInt32(edDVBTFrequency.Text)
            bdaTuningParameters.ONID = Convert.ToInt32(edDVBTONID.Text)
            bdaTuningParameters.SID = Convert.ToInt32(edDVBTSID.Text)
            bdaTuningParameters.TSID = Convert.ToInt32(edDVBTTSID.Text)

            VideoCapture1.BDA_SetParameters(bdaTuningParameters)

        End If

    End Sub

    Private Sub cbZoom_CheckedChanged(sender As Object, e As EventArgs) Handles cbZoom.CheckedChanged

        Dim zoomEffect As IVideoEffectZoom
        Dim effect = VideoCapture1.Video_Effects_Get("Zoom")
        If (IsNothing(effect)) Then
            zoomEffect = New VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoom.Checked)
            VideoCapture1.Video_Effects_Add(zoomEffect)
        Else
            zoomEffect = effect
        End If

        If (IsNothing(zoomEffect)) Then
            MessageBox.Show("Unable to configure zoom effect.")
            Return
        End If

        zoomEffect.ZoomX = zoom
        zoomEffect.ZoomY = zoom
        zoomEffect.ShiftX = zoomShiftX
        zoomEffect.ShiftY = zoomShiftY
        zoomEffect.Enabled = cbZoom.Checked

    End Sub


    Private Sub btEffZoomIn_Click(sender As Object, e As EventArgs) Handles btEffZoomIn.Click

        zoom += 0.1
        zoom = Math.Min(zoom, 5)

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomOut_Click(sender As Object, e As EventArgs) Handles btEffZoomOut.Click

        zoom -= 0.1
        zoom = Math.Max(zoom, 1)

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomUp_Click(sender As Object, e As EventArgs) Handles btEffZoomUp.Click

        zoomShiftY += 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomDown_Click(sender As Object, e As EventArgs) Handles btEffZoomDown.Click

        zoomShiftY -= 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomRight_Click(sender As Object, e As EventArgs) Handles btEffZoomRight.Click

        zoomShiftX += 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomLeft_Click(sender As Object, e As EventArgs) Handles btEffZoomLeft.Click

        zoomShiftX -= 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub cbPan_CheckedChanged(sender As Object, e As EventArgs) Handles cbPan.CheckedChanged

        Dim pan As IVideoEffectPan
        Dim effect = VideoCapture1.Video_Effects_Get("Pan")
        If (IsNothing(effect)) Then
            pan = New VideoEffectPan(True)
            VideoCapture1.Video_Effects_Add(pan)
        Else
            pan = effect
        End If

        If (IsNothing(pan)) Then
            MessageBox.Show("Unable to configure pan effect.")
            Return
        End If

        pan.Enabled = cbPan.Checked
        pan.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStartTime.Text))
        pan.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStopTime.Text))
        pan.StartX = Convert.ToInt32(edPanSourceLeft.Text)
        pan.StartY = Convert.ToInt32(edPanSourceTop.Text)
        pan.StartWidth = Convert.ToInt32(edPanSourceWidth.Text)
        pan.StartHeight = Convert.ToInt32(edPanSourceHeight.Text)
        pan.StopX = Convert.ToInt32(edPanDestLeft.Text)
        pan.StopY = Convert.ToInt32(edPanDestTop.Text)
        pan.StopWidth = Convert.ToInt32(edPanDestWidth.Text)
        pan.StopHeight = Convert.ToInt32(edPanDestHeight.Text)

    End Sub

    Private Sub btBarcodeReset_Click(sender As Object, e As EventArgs) Handles btBarcodeReset.Click

        edBarcode.Text = String.Empty
        edBarcodeMetadata.Text = String.Empty
        VideoCapture1.Barcode_Reader_Enabled = True

    End Sub

    Private Sub VideoCapture1_OnBarcodeDetected(sender As Object, e As BarcodeEventArgs) Handles VideoCapture1.OnBarcodeDetected

        e.DetectorEnabled = False

        BeginInvoke(New BarcodeDelegate(AddressOf BarcodeDelegateMethod), e)

    End Sub

    Private Delegate Sub BarcodeDelegate(ByVal value As BarcodeEventArgs)

    Private Sub BarcodeDelegateMethod(ByVal value As BarcodeEventArgs)

        edBarcode.Text = value.Value
        edBarcodeMetadata.Text = String.Empty

        For Each o As KeyValuePair(Of BarcodeResultMetadataType, Object) In value.Metadata

            edBarcodeMetadata.Text += o.Key.ToString() + ": " + o.Value.ToString() + Environment.NewLine

        Next

    End Sub

    Private Sub btAddAdditionalAudioSource_Click(sender As Object, e As EventArgs) Handles btAddAdditionalAudioSource.Click

        VideoCapture1.Additional_Audio_CaptureDevice_Add(cbAdditionalAudioSource.Text)
        MessageBox.Show(cbAdditionalAudioSource.Text + " added")

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then

            edPIPFileSoureFilename.Text = openFileDialog1.FileName

        End If

    End Sub

    Private Sub btPIPFileSourceAdd_Click(sender As Object, e As EventArgs) Handles btPIPFileSourceAdd.Click

        VideoCapture1.PIP_Sources_Add_VideoFile(
    edPIPFileSoureFilename.Text,
    Convert.ToInt32(edPIPFileLeft.Text),
    Convert.ToInt32(edPIPFileTop.Text),
    Convert.ToInt32(edPIPFileWidth.Text),
    Convert.ToInt32(edPIPFileHeight.Text))
        cbPIPDevices.Items.Add("File source")

    End Sub

    Private Sub cbFadeInOut_CheckedChanged(sender As Object, e As EventArgs) Handles cbFadeInOut.CheckedChanged

        If (rbFadeIn.Checked) Then
            Dim fadeIn As IVideoEffectFadeIn
            Dim effect = VideoCapture1.Video_Effects_Get("FadeIn")
            If (IsNothing(effect)) Then
                fadeIn = New VideoEffectFadeIn(cbFadeInOut.Checked)
                VideoCapture1.Video_Effects_Add(fadeIn)
            Else
                fadeIn = effect
            End If

            If (IsNothing(fadeIn)) Then
                MessageBox.Show("Unable to configure fade-in effect.")
                Return
            End If

            fadeIn.Enabled = cbFadeInOut.Checked
            fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text))
            fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text))
        Else
            Dim fadeOut As IVideoEffectFadeOut
            Dim effect = VideoCapture1.Video_Effects_Get("FadeOut")
            If (IsNothing(effect)) Then
                fadeOut = New VideoEffectFadeOut(cbFadeInOut.Checked)
                VideoCapture1.Video_Effects_Add(fadeOut)
            Else
                fadeOut = effect
            End If

            If (IsNothing(fadeOut)) Then
                MessageBox.Show("Unable to configure fade-out effect.")
                Return
            End If

            fadeOut.Enabled = cbFadeInOut.Checked
            fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text))
            fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text))
        End If

    End Sub

    Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer)
        Process.Start(startInfo)

    End Sub

    Private Sub btBDAChannelScanningStart_Click(sender As Object, e As EventArgs) Handles btBDAChannelScanningStart.Click

        lvBDAChannels.Items.Clear()
        VideoCapture1.BDA_ScanChannels()

    End Sub

    Private Sub VideoCapture1_OnBDAChannelFound(sender As Object, e As BDAChannelEventArgs) Handles VideoCapture1.OnBDAChannelFound

        BeginInvoke(Sub()
                        Application.DoEvents()

                        Dim list As String() = New String() {
            e.Channel.Name,
        e.Channel.Frequency.ToString(CultureInfo.InvariantCulture),
        e.Channel.AudioPid.ToString(CultureInfo.InvariantCulture),
        e.Channel.VideoPid.ToString(CultureInfo.InvariantCulture),
        e.Channel.ServId.ToString(CultureInfo.InvariantCulture),
        e.Channel.SymbolRate.ToString(CultureInfo.InvariantCulture)}

                        Dim lvi As ListViewItem = New ListViewItem(list)

                        lvBDAChannels.Items.Add(lvi)

                        Application.DoEvents()
                    End Sub)
    End Sub

    Private Sub linkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel4.LinkClicked

        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder)
        Process.Start(startInfo)

    End Sub

    Private Sub VideoCapture1_OnFaceDetected(sender As Object, e As AFFaceDetectionEventArgs) Handles VideoCapture1.OnFaceDetected

        BeginInvoke(New FaceDelegate(AddressOf FaceDelegateMethod), e)

    End Sub

    Private Delegate Sub FaceDelegate(ByVal value As AFFaceDetectionEventArgs)

    Private Sub FaceDelegateMethod(ByVal value As AFFaceDetectionEventArgs)

        edFaceTrackingFaces.Text = String.Empty

        For Each faceRectangle As Rectangle In value.FaceRectangles

            edFaceTrackingFaces.Text += "(" + faceRectangle.Left + ", " + faceRectangle.Top + "), (" + faceRectangle.Width + ", " + faceRectangle.Height + ")" + Environment.NewLine
        Next

    End Sub


#Region "Full screen"

    Dim fullScreen As Boolean

    Dim windowLeft As Integer

    Dim windowTop As Integer

    Dim windowWidth As Integer

    Dim windowHeight As Integer

    Dim controlLeft As Integer

    Dim controlTop As Integer

    Dim controlWidth As Integer

    Dim controlHeight As Integer

    Private Async Sub btFullScreen_Click(sender As Object, e As EventArgs) Handles btFullScreen.Click

        If (Not fullScreen) Then
            ' going fullscreen
            fullScreen = True

            ' saving coordinates
            windowLeft = Left
            windowTop = Top
            windowWidth = Width
            windowHeight = Height

            controlLeft = VideoView1.Left
            controlTop = VideoView1.Top
            controlWidth = VideoView1.Width
            controlHeight = VideoView1.Height

            ' resizing window
            Left = 0
            Top = 0
            Width = Screen.AllScreens(0).WorkingArea.Width
            Height = Screen.AllScreens(0).WorkingArea.Height

            TopMost = True
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Maximized

            ' resizing control
            VideoView1.Left = 0
            VideoView1.Top = 0
            VideoView1.Width = Width
            VideoView1.Height = Height

            Await VideoCapture1.Video_Renderer_UpdateAsync()
        Else
            ' going normal screen
            fullScreen = False

            ' restoring control
            VideoView1.Left = controlLeft
            VideoView1.Top = controlTop
            VideoView1.Width = controlWidth
            VideoView1.Height = controlHeight

            ' restoring window
            Left = windowLeft
            Top = windowTop
            Width = windowWidth
            Height = windowHeight

            TopMost = False
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Normal

            Await VideoCapture1.Video_Renderer_UpdateAsync()
        End If

    End Sub

    Private Sub VideoView1_MouseDown(sender As Object, e As MouseEventArgs) Handles VideoView1.MouseDown
        If (fullScreen) Then
            btFullScreen_Click(sender, e)
        End If
    End Sub

#End Region


    Private Sub linkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel5.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.IISSmoothStreaming)
        Process.Start(startInfo)
    End Sub

    Private Sub tbVUMeterAmplification_Scroll(sender As Object, e As EventArgs) Handles tbVUMeterAmplification.Scroll
        VideoCapture1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value
    End Sub

    Private Sub tbVUMeterBoost_Scroll(sender As Object, e As EventArgs) Handles tbVUMeterBoost.Scroll
        volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F
        volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F

        waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F
        waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F
    End Sub

    Private Sub VideoCapture1_OnAudioVUMeterProVolume(sender As Object, e As AudioLevelEventArgs) Handles VideoCapture1.OnAudioVUMeterProVolume
        BeginInvoke(Sub()
                        volumeMeter1.Amplitude = e.ChannelLevelsDb(0)
                        waveformPainter1.AddMax(e.ChannelLevels(0) / 100.0F)

                        If (e.ChannelLevelsDb.Length > 1) Then

                            volumeMeter2.Amplitude = e.ChannelLevelsDb(1)
                            waveformPainter2.AddMax(e.ChannelLevels(1) / 100.0F)

                        End If
                    End Sub)
    End Sub

    Private Sub cbLiveRotation_CheckedChanged(sender As Object, e As EventArgs) Handles cbLiveRotation.CheckedChanged

        Dim rotate As IVideoEffectRotate
        Dim effect = VideoCapture1.Video_Effects_Get("Rotate")
        If (IsNothing(effect)) Then
            rotate = New VideoEffectRotate(
                    cbLiveRotation.Checked,
                    tbLiveRotationAngle.Value,
                    cbLiveRotationStretch.Checked)
            VideoCapture1.Video_Effects_Add(rotate)
        Else
            rotate = effect
        End If

        If (IsNothing(rotate)) Then
            MessageBox.Show("Unable to configure rotate effect.")
            Return
        End If

        rotate.Enabled = cbLiveRotation.Checked
        rotate.Angle = tbLiveRotationAngle.Value
        rotate.Stretch = cbLiveRotationStretch.Checked

    End Sub

    Private Sub tbLiveRotationAngle_Scroll(sender As Object, e As EventArgs) Handles tbLiveRotationAngle.Scroll
        cbLiveRotation_CheckedChanged(sender, e)
    End Sub

    Private Sub cbLiveRotationStretch_CheckedChanged(sender As Object, e As EventArgs) Handles cbLiveRotationStretch.CheckedChanged
        cbLiveRotation_CheckedChanged(sender, e)
    End Sub

    Private Async Sub cbDirect2DRotate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDirect2DRotate.SelectedIndexChanged
        VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)
        Await VideoCapture1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub pnVideoRendererBGColor_Click(sender As Object, e As EventArgs) Handles pnVideoRendererBGColor.Click

        colorDialog1.Color = pnVideoRendererBGColor.BackColor

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then

            pnVideoRendererBGColor.BackColor = colorDialog1.Color

            VideoCapture1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor
            Await VideoCapture1.Video_Renderer_UpdateAsync()

        End If

    End Sub

    Private Sub cbCustomVideoSourceCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomVideoSourceCategory.SelectedIndexChanged

        cbCustomVideoSourceFilter.Items.Clear()

        If (cbCustomVideoSourceCategory.SelectedIndex = 0) Then

            Dim filters = VideoCapture1.Video_CaptureDevices
            For Each item As VideoCaptureDeviceInfo In filters
                cbCustomVideoSourceFilter.Items.Add(item.Name)
            Next

            If (filters.Count > 0) Then
                cbCustomVideoSourceFilter.SelectedIndex = 0
            End If

        ElseIf (cbCustomVideoSourceCategory.SelectedIndex = 1) Then

            Dim filters = VideoCapture1.DirectShow_Filters
            For Each item As String In filters
                cbCustomVideoSourceFilter.Items.Add(item)
            Next

            If (filters.Count > 0) Then
                cbCustomVideoSourceFilter.SelectedIndex = 0
            End If

        End If

    End Sub

    Private Sub cbCustomAudioSourceCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomAudioSourceCategory.SelectedIndexChanged

        cbCustomAudioSourceFilter.Items.Clear()
        cbCustomAudioSourceFilter.Items.Add(String.Empty)

        If (cbCustomAudioSourceCategory.SelectedIndex = 0) Then

            Dim filters = VideoCapture1.Audio_CaptureDevices
            For Each item As AudioCaptureDeviceInfo In filters
                cbCustomAudioSourceFilter.Items.Add(item.Name)
            Next

            If (filters.Count > 0) Then
                cbCustomAudioSourceFilter.SelectedIndex = 0
            End If

        ElseIf (cbCustomAudioSourceCategory.SelectedIndex = 1) Then

            Dim filters = VideoCapture1.DirectShow_Filters
            For Each item As String In filters
                cbCustomAudioSourceFilter.Items.Add(item)
            Next

            If (filters.Count > 0) Then

                cbCustomAudioSourceFilter.SelectedIndex = 0

            End If
        End If
    End Sub

    Private Sub cbCustomVideoSourceFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomVideoSourceFilter.SelectedIndexChanged

        If (Not String.IsNullOrEmpty(cbCustomVideoSourceFilter.Text)) Then
            cbCustomVideoSourceFormat.Items.Clear()
            cbCustomVideoSourceFrameRate.Items.Clear()

            Dim formats As List(Of VideoCaptureDeviceFormat) = Nothing

            If (cbCustomVideoSourceCategory.SelectedIndex = 0) Then
                VideoCapture1.DirectShow_Filter_GetVideoFormats(
                    FilterCategoryX.VideoCaptureSource,
                    cbCustomVideoSourceFilter.Text,
                    MediaTypeCategory.Video,
                     formats)
            Else
                VideoCapture1.DirectShow_Filter_GetVideoFormats(
                    FilterCategoryX.DirectShowFilters,
                    cbCustomVideoSourceFilter.Text,
                    MediaTypeCategory.Video,
                     formats)
            End If

            For Each format As VideoCaptureDeviceFormat In formats
                cbCustomVideoSourceFormat.Items.Add(format.Name)
            Next
        End If

    End Sub

    Private Sub cbCustomAudioSourceFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomAudioSourceFilter.SelectedIndexChanged

        If (Not String.IsNullOrEmpty(cbCustomAudioSourceFilter.Text)) Then
            cbCustomAudioSourceFormat.Items.Clear()

            Dim formats As List(Of String) = Nothing

            If (cbCustomAudioSourceCategory.SelectedIndex = 0) Then
                VideoCapture1.DirectShow_Filter_GetAudioFormats(
                    FilterCategoryX.AudioCaptureSource,
                    cbCustomAudioSourceFilter.Text,
                    MediaTypeCategory.Audio,
                    formats)
            Else
                VideoCapture1.DirectShow_Filter_GetAudioFormats(
                    FilterCategoryX.DirectShowFilters,
                    cbCustomAudioSourceFilter.Text,
                    MediaTypeCategory.Audio,
                     formats)
            End If

            For Each format As String In formats
                cbCustomAudioSourceFormat.Items.Add(format)
            Next
        End If

    End Sub

    Private Async Sub cbAudioNormalize_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioNormalize.CheckedChanged

        Await VideoCapture1.Audio_Enhancer_NormalizeAsync(cbAudioNormalize.Checked)

    End Sub

    Private Async Sub cbAudioAutoGain_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioAutoGain.CheckedChanged

        Await VideoCapture1.Audio_Enhancer_AutoGainAsync(cbAudioAutoGain.Checked)

    End Sub

    Private Async Function ApplyAudioInputGainsAsync() As Task
        Dim gains As AudioEnhancerGains = New AudioEnhancerGains()

        gains.L = tbAudioInputGainL.Value / 10.0F
        gains.C = tbAudioInputGainC.Value / 10.0F
        gains.R = tbAudioInputGainR.Value / 10.0F
        gains.SL = tbAudioInputGainSL.Value / 10.0F
        gains.SR = tbAudioInputGainSR.Value / 10.0F
        gains.LFE = tbAudioInputGainLFE.Value / 10.0F

        Await VideoCapture1.Audio_Enhancer_InputGainsAsync(gains)
    End Function

    Private Async Function ApplyAudioOutputGainsAsync() As Task
        Dim gains As AudioEnhancerGains = New AudioEnhancerGains

        gains.L = tbAudioOutputGainL.Value / 10.0F
        gains.C = tbAudioOutputGainC.Value / 10.0F
        gains.R = tbAudioOutputGainR.Value / 10.0F
        gains.SL = tbAudioOutputGainSL.Value / 10.0F
        gains.SR = tbAudioOutputGainSR.Value / 10.0F
        gains.LFE = tbAudioOutputGainLFE.Value / 10.0F

        Await VideoCapture1.Audio_Enhancer_OutputGainsAsync(gains)
    End Function

    Private Async Sub tbAudioInputGainL_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainL.Scroll

        lbAudioInputGainL.Text = (tbAudioInputGainL.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioInputGainC_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainC.Scroll

        lbAudioInputGainC.Text = (tbAudioInputGainC.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioInputGainR_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainR.Scroll

        lbAudioInputGainR.Text = (tbAudioInputGainR.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioInputGainSL_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainSL.Scroll

        lbAudioInputGainSL.Text = (tbAudioInputGainSL.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioInputGainSR_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainSR.Scroll

        lbAudioInputGainSR.Text = (tbAudioInputGainSR.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioInputGainLFE_Scroll(sender As Object, e As EventArgs) Handles tbAudioInputGainLFE.Scroll

        lbAudioInputGainLFE.Text = (tbAudioInputGainLFE.Value / 10.0F).ToString("F1")

        Await ApplyAudioInputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainL_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainL.Scroll

        lbAudioOutputGainL.Text = (tbAudioOutputGainL.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainC_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainC.Scroll

        lbAudioOutputGainC.Text = (tbAudioOutputGainC.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainR_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainR.Scroll

        lbAudioOutputGainR.Text = (tbAudioOutputGainR.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainSL_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainSL.Scroll

        lbAudioOutputGainSL.Text = (tbAudioOutputGainSL.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainSR_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainSR.Scroll

        lbAudioOutputGainSR.Text = (tbAudioOutputGainSR.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioOutputGainLFE_Scroll(sender As Object, e As EventArgs) Handles tbAudioOutputGainLFE.Scroll

        lbAudioOutputGainLFE.Text = (tbAudioOutputGainLFE.Value / 10.0F).ToString("F1")

        Await ApplyAudioOutputGainsAsync()

    End Sub

    Private Async Sub tbAudioTimeshift_Scroll(sender As Object, e As EventArgs) Handles tbAudioTimeshift.Scroll
        lbAudioTimeshift.Text = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms"

        Await VideoCapture1.Audio_Enhancer_TimeshiftAsync(tbAudioTimeshift.Value)
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

    Private Delegate Sub FFMPEGInfoDelegate(ByVal message As String)

    Private Sub FFMPEGInfoDelegateMethod(ByVal message As String)

        mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine

    End Sub

    Private Sub VideoCapture1_OnFFMPEGInfo(sender As Object, e As FFMPEGInfoEventArgs) Handles VideoCapture1.OnFFMPEGInfo

        Dim del As FFMPEGInfoDelegate = New FFMPEGInfoDelegate(AddressOf FFMPEGInfoDelegateMethod)
        BeginInvoke(del, e.Message)

    End Sub

    Private Sub btEncryptionOpenFile_Click(sender As Object, e As EventArgs) Handles btEncryptionOpenFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then

            edEncryptionKeyFile.Text = openFileDialog1.FileName

        End If

    End Sub

    Private Sub imgTagCover_Click(sender As Object, e As EventArgs) Handles imgTagCover.Click

        If (openFileDialog2.ShowDialog() = DialogResult.OK) Then

            imgTagCover.LoadAsync(openFileDialog2.FileName)
            imgTagCover.Tag = openFileDialog2.FileName

        End If

    End Sub

    Private Sub cbDecklinkCaptureDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDecklinkCaptureDevice.SelectedIndexChanged

        cbDecklinkCaptureVideoFormat.Items.Clear()

        Dim deviceItem = (From device In VideoCapture1.Decklink_CaptureDevices Where device.Name = cbDecklinkCaptureDevice.Text)?.FirstOrDefault()
        If Not IsNothing(deviceItem) Then
            Dim formats = deviceItem.VideoFormats

            For Each format As DecklinkVideoFormat In formats

                cbDecklinkCaptureVideoFormat.Items.Add(format.Name)

            Next

            If (cbDecklinkCaptureVideoFormat.Items.Count = 0) Then

                cbDecklinkCaptureVideoFormat.Items.Add("No input connected")

            End If

            cbDecklinkCaptureVideoFormat.SelectedIndex = 0
            ' cbVideoInputFormat_SelectedIndexChanged(null, null)
        End If

    End Sub

    Private Sub btAudioChannelMapperClear_Click(sender As Object, e As EventArgs) Handles btAudioChannelMapperClear.Click

        audioChannelMapperItems.Clear()
        lbAudioChannelMapperRoutes.Items.Clear()

    End Sub

    Private Sub btAudioChannelMapperAddNewRoute_Click(sender As Object, e As EventArgs) Handles btAudioChannelMapperAddNewRoute.Click

        Dim item As AudioChannelMapperItem = New AudioChannelMapperItem()
        item.SourceChannel = Convert.ToInt32(edAudioChannelMapperSourceChannel.Text)
        item.TargetChannel = Convert.ToInt32(edAudioChannelMapperTargetChannel.Text)
        item.TargetChannelVolume = tbAudioChannelMapperVolume.Value / 1000.0F

        audioChannelMapperItems.Add(item)

        lbAudioChannelMapperRoutes.Items.Add(
                "Source: " + edAudioChannelMapperSourceChannel.Text + ", target: " + edAudioChannelMapperTargetChannel.Text + ", volume: " + (tbAudioChannelMapperVolume.Value / 1000.0F).ToString("F2"))

    End Sub

    Private Sub linkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel11.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube)
        Process.Start(startInfo)

    End Sub

    Private Delegate Sub NetworkStopDelegate()

    Private Async Sub NetworkStopDelegateMethod()

        Await VideoCapture1.StopAsync()

        MessageBox.Show("Network source stopped or disconnected!")

    End Sub

    Private Sub VideoCapture1_OnNetworkSourceDisconnect(sender As Object, e As EventArgs) Handles VideoCapture1.OnNetworkSourceDisconnect

        Dim del As NetworkStopDelegate = New NetworkStopDelegate(AddressOf NetworkStopDelegateMethod)
        BeginInvoke(del, e)

    End Sub

    Private Sub tbGPULightness_Scroll(sender As Object, e As EventArgs) Handles tbGPULightness.Scroll

        Dim intf As IGPUVideoEffectBrightness
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Brightness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectBrightness(True, tbGPULightness.Value)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbGPULightness.Value
                intf.Update()
            End If
        End If

    End Sub

    Private Sub tbGPUSaturation_Scroll(sender As Object, e As EventArgs) Handles tbGPUSaturation.Scroll

        Dim intf As IGPUVideoEffectSaturation
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Saturation")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectSaturation(True, tbGPUSaturation.Value)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbGPUSaturation.Value
                intf.Update()
            End If
        End If

    End Sub

    Private Sub tbGPUContrast_Scroll(sender As Object, e As EventArgs) Handles tbGPUContrast.Scroll

        Dim intf As IGPUVideoEffectContrast
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Contrast")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectContrast(True, tbGPUContrast.Value)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbGPUContrast.Value
                intf.Update()
            End If
        End If

    End Sub

    Private Sub tbGPUDarkness_Scroll(sender As Object, e As EventArgs) Handles tbGPUDarkness.Scroll

        Dim intf As IGPUVideoEffectDarkness
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Darkness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDarkness(True, tbGPUDarkness.Value)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Value = tbGPUDarkness.Value
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUGreyscale_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUGreyscale.CheckedChanged

        Dim intf As IGPUVideoEffectGrayscale
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectGrayscale(cbGPUGreyscale.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUGreyscale.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUInvert_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUInvert.CheckedChanged

        Dim intf As IGPUVideoEffectInvert
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Invert")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectInvert(cbGPUInvert.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUInvert.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUNightVision_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUNightVision.CheckedChanged

        Dim intf As IGPUVideoEffectNightVision
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("NightVision")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectNightVision(cbGPUNightVision.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUNightVision.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUPixelate_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUPixelate.CheckedChanged

        Dim intf As IGPUVideoEffectPixelate
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Pixelate")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectPixelate(cbGPUPixelate.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUPixelate.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUDenoise_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUDenoise.CheckedChanged

        Dim intf As IGPUVideoEffectDenoise
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Denoise")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDenoise(cbGPUDenoise.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUDenoise.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUDeinterlace_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUDeinterlace.CheckedChanged

        Dim intf As IGPUVideoEffectDeinterlaceBlend
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("DeinterlaceBlend")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUDeinterlace.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Sub cbGPUOldMovie_CheckedChanged(sender As Object, e As EventArgs) Handles cbGPUOldMovie.CheckedChanged

        Dim intf As IGPUVideoEffectOldMovie
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("OldMovie")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectOldMovie(cbGPUOldMovie.Checked)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUOldMovie.Checked
                intf.Update()
            End If
        End If

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

    Private Sub pnPIPChromaKeyColor_Click(sender As Object, e As EventArgs) Handles pnPIPChromaKeyColor.Click

        colorDialog1.Color = pnPIPChromaKeyColor.BackColor

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            pnPIPChromaKeyColor.BackColor = colorDialog1.Color
        End If

    End Sub

    Private Sub tbPIPChromaKeyTolerance1_Scroll(sender As Object, e As EventArgs) Handles tbPIPChromaKeyTolerance1.Scroll

        lbPIPChromaKeyTolerance1.Text = tbPIPChromaKeyTolerance1.Value.ToString()

    End Sub

    Private Sub tbPIPChromaKeyTolerance2_Scroll(sender As Object, e As EventArgs) Handles tbPIPChromaKeyTolerance2.Scroll

        lbPIPChromaKeyTolerance2.Text = tbPIPChromaKeyTolerance2.Value.ToString()

    End Sub


    Private Sub cbAudioInputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAudioInputFormat.SelectedIndexChanged

    End Sub

    Private Sub btSelectHLSOutputFolder_Click(sender As Object, e As EventArgs) Handles btSelectHLSOutputFolder.Click
        If (folderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            edHLSOutputFolder.Text = folderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub lbHLSConfigure_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbHLSConfigure.LinkClicked
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("explorer.exe", HelpLinks.HLSStreaming)
        Process.Start(startInfo)
    End Sub

    Private Sub cbOutputFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputFormat.SelectedIndexChanged

        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 1
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv")
            Case 2
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv")
            Case 3
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 4
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav")
            Case 5
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3")
            Case 6
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a")
            Case 7
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma")
            Case 8
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac")
            Case 9
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 10
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 11
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 12
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 13
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 14
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mpg")
            Case 15
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv")
            Case 16
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 17
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 18
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 19
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm")
            Case 20
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 21
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 22
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 23
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 24
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif")
            Case 25
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc")
            Case 26
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts")
            Case 27
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov")
        End Select
    End Sub

    Private Sub btOutputConfigure_Click(sender As Object, e As EventArgs) Handles btOutputConfigure.Click
        Select Case (cbOutputFormat.SelectedIndex)
            Case 0
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 1
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 2
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
                End If

                wmvSettingsDialog.WMA = False
                wmvSettingsDialog.ShowDialog(Me)
            Case 3
                If (dvSettingsDialog Is Nothing) Then
                    dvSettingsDialog = New DVSettingsDialog()
                End If

                dvSettingsDialog.ShowDialog(Me)
            Case 4
                If (pcmSettingsDialog Is Nothing) Then
                    pcmSettingsDialog = New PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray())
                End If

                pcmSettingsDialog.ShowDialog(Me)
            Case 5
                If (mp3SettingsDialog Is Nothing) Then
                    mp3SettingsDialog = New MP3SettingsDialog()
                End If

                mp3SettingsDialog.ShowDialog(Me)
            Case 6
                If (m4aSettingsDialog Is Nothing) Then
                    m4aSettingsDialog = New M4ASettingsDialog()
                End If

                m4aSettingsDialog.ShowDialog(Me)
            Case 7
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoCapture1)
                End If

                wmvSettingsDialog.WMA = True
                wmvSettingsDialog.ShowDialog(Me)
            Case 8
                If (flacSettingsDialog Is Nothing) Then
                    flacSettingsDialog = New FLACSettingsDialog()
                End If

                flacSettingsDialog.ShowDialog(Me)
            Case 9
                If (oggVorbisSettingsDialog Is Nothing) Then
                    oggVorbisSettingsDialog = New OggVorbisSettingsDialog()
                End If

                oggVorbisSettingsDialog.ShowDialog(Me)
            Case 10
                If (speexSettingsDialog Is Nothing) Then
                    speexSettingsDialog = New SpeexSettingsDialog()
                End If

                speexSettingsDialog.ShowDialog(Me)
            Case 11
                If (customFormatSettingsDialog Is Nothing) Then
                    customFormatSettingsDialog = New CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray())
                End If

                customFormatSettingsDialog.ShowDialog(Me)
            Case 12
            Case 13
            Case 14
            Case 15
                MessageBox.Show("No settings available for selected output format.")
            Case 16
            Case 17
            Case 18
                If (customFormatSettingsDialog Is Nothing) Then
                    customFormatSettingsDialog = New CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray())
                End If

                customFormatSettingsDialog.ShowDialog(Me)
            Case 19
                If (webmSettingsDialog Is Nothing) Then
                    webmSettingsDialog = New WebMSettingsDialog()
                End If

                webmSettingsDialog.ShowDialog(Me)
            Case 20
                If (ffmpegSettingsDialog Is Nothing) Then
                    ffmpegSettingsDialog = New FFMPEGSettingsDialog()
                End If

                ffmpegSettingsDialog.ShowDialog(Me)
            Case 21
                If (ffmpegEXESettingsDialog Is Nothing) Then
                    ffmpegEXESettingsDialog = New FFMPEGEXESettingsDialog()
                End If

                ffmpegEXESettingsDialog.ShowDialog(Me)
            Case 22
                If (mp4SettingsDialog Is Nothing) Then
                    mp4SettingsDialog = New MP4SettingsDialog()
                End If

                mp4SettingsDialog.ShowDialog(Me)
            Case 23
                If (mp4HWSettingsDialog Is Nothing) Then
                    mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
                End If

                mp4HWSettingsDialog.ShowDialog(Me)
            Case 24
                If (gifSettingsDialog Is Nothing) Then
                    gifSettingsDialog = New GIFSettingsDialog()
                End If

                gifSettingsDialog.ShowDialog(Me)
            Case 25
                If (mp4SettingsDialog Is Nothing) Then
                    mp4SettingsDialog = New MP4SettingsDialog()
                End If

                mp4SettingsDialog.ShowDialog(Me)
            Case 26
                If (mpegTSSettingsDialog Is Nothing) Then
                    mpegTSSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS)
                End If

                mpegTSSettingsDialog.ShowDialog(Me)
            Case 27
                If (movSettingsDialog Is Nothing) Then
                    movSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV)
                End If

                movSettingsDialog.ShowDialog(Me)
        End Select
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

    Private Sub btImageLogoRemove_Click(sender As Object, e As EventArgs) Handles btImageLogoRemove.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            VideoCapture1.Video_Effects_Remove(lbImageLogos.SelectedItem)
            lbImageLogos.Items.Remove(lbImageLogos.SelectedItem)
        End If
    End Sub

    Private Sub btImageLogoEdit_Click(sender As Object, e As EventArgs) Handles btImageLogoEdit.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New ImageLogoSettingsDialog()
            Dim effect = VideoCapture1.Video_Effects_Get(lbImageLogos.SelectedItem)

            dlg.Attach(effect)
            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btImageLogoAdd_Click(sender As Object, e As EventArgs) Handles btImageLogoAdd.Click
        Dim dlg = New ImageLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoCapture1)
        Dim effect = New VideoEffectImageLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbImageLogos.Items.Add(effect.Name)

        dlg.Fill(effect)
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btTextLogoEdit_Click(sender As Object, e As EventArgs) Handles btTextLogoEdit.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New TextLogoSettingsDialog()
            Dim effect = VideoCapture1.Video_Effects_Get(lbTextLogos.SelectedItem)
            dlg.Attach(effect)

            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btTextLogoRemove_Click(sender As Object, e As EventArgs) Handles btTextLogoRemove.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            VideoCapture1.Video_Effects_Remove(lbTextLogos.SelectedItem)
            lbTextLogos.Items.Remove(lbTextLogos.SelectedItem)
        End If
    End Sub

    Private Sub btTextLogoAdd_Click(sender As Object, e As EventArgs) Handles btTextLogoAdd.Click
        Dim dlg = New TextLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoCapture1)
        Dim effect = New VideoEffectTextLogo(True, effectName)

        VideoCapture1.Video_Effects_Add(effect)
        lbTextLogos.Items.Add(effect.Name)
        dlg.Fill(effect)

        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Async Sub btCCPanApply_Click(sender As Object, e As EventArgs) Handles btCCPanApply.Click
        Dim flags = CameraControlFlags.None

        If (cbCCPanManual.Checked) Then
            flags = flags Or CameraControlFlags.Manual
        End If

        If (cbCCPanAuto.Checked) Then
            flags = flags Or CameraControlFlags.Auto
        End If

        If (cbCCPanRelative.Checked) Then
            flags = flags Or CameraControlFlags.Relative
        End If

        Await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Pan, New VideoCaptureDeviceCameraControlValue(tbCCPan.Value, flags))
    End Sub

    Private Async Sub btCCZoomApply_Click(sender As Object, e As EventArgs) Handles btCCZoomApply.Click
        Dim flags = CameraControlFlags.None

        If (cbCCZoomManual.Checked) Then
            flags = flags Or CameraControlFlags.Manual
        End If

        If (cbCCZoomAuto.Checked) Then
            flags = flags Or CameraControlFlags.Auto
        End If

        If (cbCCZoomRelative.Checked) Then
            flags = flags Or CameraControlFlags.Relative
        End If

        Await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Zoom, New VideoCaptureDeviceCameraControlValue(tbCCZoom.Value, flags))
    End Sub

    Private Async Sub btCCTiltApply_Click(sender As Object, e As EventArgs) Handles btCCTiltApply.Click
        Dim flags = CameraControlFlags.None

        If (cbCCTiltManual.Checked) Then
            flags = flags Or CameraControlFlags.Manual
        End If

        If (cbCCTiltAuto.Checked) Then
            flags = flags Or CameraControlFlags.Auto
        End If

        If (cbCCTiltRelative.Checked) Then
            flags = flags Or CameraControlFlags.Relative
        End If

        Await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Tilt, New VideoCaptureDeviceCameraControlValue(tbCCTilt.Value, flags))
    End Sub

    Private Async Sub btCCFocusApply_Click(sender As Object, e As EventArgs) Handles btCCFocusApply.Click
        Dim flags = CameraControlFlags.None

        If (cbCCFocusManual.Checked) Then
            flags = flags Or CameraControlFlags.Manual
        End If

        If (cbCCFocusAuto.Checked) Then
            flags = flags Or CameraControlFlags.Auto
        End If

        If (cbCCFocusRelative.Checked) Then
            flags = flags Or CameraControlFlags.Relative
        End If

        Await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Focus, New VideoCaptureDeviceCameraControlValue(tbCCFocus.Value, flags))
    End Sub

    Private Async Sub btCCReadValues_Click(sender As Object, e As EventArgs) Handles btCCReadValues.Click
        Dim pan As VideoCaptureDeviceCameraControlRanges = Await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Pan)
        If (Not IsNothing(pan)) Then
            tbCCPan.Minimum = pan.Min
            tbCCPan.Maximum = pan.Max
            tbCCPan.SmallChange = pan.Step
            tbCCPan.Value = pan.Default
            lbCCPanMin.Text = "Min: " + Convert.ToString(pan.Min)
            lbCCPanMax.Text = "Max: " + Convert.ToString(pan.Max)
            lbCCPanCurrent.Text = "Current: " + Convert.ToString(pan.Default)

            cbCCPanManual.Checked = (pan.Flags And CameraControlFlags.Manual) = CameraControlFlags.Manual
            cbCCPanAuto.Checked = (pan.Flags And CameraControlFlags.Auto) = CameraControlFlags.Auto
            cbCCPanRelative.Checked = (pan.Flags And CameraControlFlags.Relative) = CameraControlFlags.Relative
        End If

        Dim tilt As VideoCaptureDeviceCameraControlRanges = Await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Tilt)
        If (Not IsNothing(tilt)) Then
            tbCCTilt.Minimum = tilt.Min
            tbCCTilt.Maximum = tilt.Max
            tbCCTilt.SmallChange = tilt.Step
            tbCCTilt.Value = tilt.Default
            lbCCTiltMin.Text = "Min: " + Convert.ToString(tilt.Min)
            lbCCTiltMax.Text = "Max: " + Convert.ToString(tilt.Max)
            lbCCTiltCurrent.Text = "Current: " + Convert.ToString(tilt.Default)

            cbCCTiltManual.Checked = (tilt.Flags And CameraControlFlags.Manual) = CameraControlFlags.Manual
            cbCCTiltAuto.Checked = (tilt.Flags And CameraControlFlags.Auto) = CameraControlFlags.Auto
            cbCCTiltRelative.Checked = (tilt.Flags And CameraControlFlags.Relative) = CameraControlFlags.Relative
        End If

        Dim focus As VideoCaptureDeviceCameraControlRanges = Await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Focus)
        If (Not IsNothing(focus)) Then
            tbCCFocus.Minimum = focus.Min
            tbCCFocus.Maximum = focus.Max
            tbCCFocus.SmallChange = focus.Step
            tbCCFocus.Value = focus.Default
            lbCCFocusMin.Text = "Min: " + Convert.ToString(focus.Min)
            lbCCFocusMax.Text = "Max: " + Convert.ToString(focus.Max)
            lbCCFocusCurrent.Text = "Current: " + Convert.ToString(focus.Default)

            cbCCFocusManual.Checked = (focus.Flags And CameraControlFlags.Manual) = CameraControlFlags.Manual
            cbCCFocusAuto.Checked = (focus.Flags And CameraControlFlags.Auto) = CameraControlFlags.Auto
            cbCCFocusRelative.Checked = (focus.Flags And CameraControlFlags.Relative) = CameraControlFlags.Relative
        End If

        Dim zoomRange As VideoCaptureDeviceCameraControlRanges = Await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Zoom)
        If (Not IsNothing(zoomRange)) Then
            tbCCZoom.Minimum = zoomRange.Min
            tbCCZoom.Maximum = zoomRange.Max
            tbCCZoom.SmallChange = zoomRange.Step
            tbCCZoom.Value = zoomRange.Default
            lbCCZoomMin.Text = "Min: " + Convert.ToString(zoomRange.Min)
            lbCCZoomMax.Text = "Max: " + Convert.ToString(zoomRange.Max)
            lbCCZoomCurrent.Text = "Current: " + Convert.ToString(zoomRange.Default)

            cbCCZoomManual.Checked = (zoomRange.Flags And CameraControlFlags.Manual) = CameraControlFlags.Manual
            cbCCZoomAuto.Checked = (zoomRange.Flags And CameraControlFlags.Auto) = CameraControlFlags.Auto
            cbCCZoomRelative.Checked = (zoomRange.Flags And CameraControlFlags.Relative) = CameraControlFlags.Relative
        End If
    End Sub

    Private Sub btOSDClearLayer_Click(sender As Object, e As EventArgs) Handles btOSDClearLayer.Click
        If (lbOSDLayers.SelectedIndex <> -1) Then
            VideoCapture1.OSD_Layers_Clear(lbOSDLayers.SelectedIndex)
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If
    End Sub

    Private Sub btOSDRenderLayers_Click(sender As Object, e As EventArgs) Handles btOSDRenderLayers.Click
        VideoCapture1.OSD_Layers_Render()
    End Sub

    Private Sub lbOSDLayers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lbOSDLayers.ItemCheck
        VideoCapture1.OSD_Layers_Enable(e.Index, e.NewValue = CheckState.Checked)
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

    Private Sub tbGPUBlur_Scroll(sender As Object, e As EventArgs) Handles tbGPUBlur.Scroll
        Dim intf As IGPUVideoEffectBlur
        Dim effect = VideoCapture1.Video_Effects_GPU_Get("Blur")
        If (effect Is Nothing) Then
            intf = New GPUVideoEffectBlur(tbGPUBlur.Value > 0, tbGPUBlur.Value)
            VideoCapture1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (intf IsNot Nothing) Then
                intf.Enabled = tbGPUBlur.Value > 0
                intf.Value = tbGPUBlur.Value
                intf.Update()
            End If
        End If
    End Sub

    Private Sub tbChromaKeyThresholdSensitivity_Scroll(sender As Object, e As EventArgs) Handles tbChromaKeyThresholdSensitivity.Scroll
        ConfigureChromaKey()
    End Sub

    Private Sub tbChromaKeySmoothing_Scroll(sender As Object, e As EventArgs) Handles tbChromaKeySmoothing.Scroll
        ConfigureChromaKey()
    End Sub

    Private Sub pnChromaKeyColor_MouseDown(sender As Object, e As MouseEventArgs) Handles pnChromaKeyColor.MouseDown
        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            pnChromaKeyColor.BackColor = colorDialog1.Color
            ConfigureChromaKey()
        End If
    End Sub

    Private Sub btChromaKeySelectBGImage_Click(sender As Object, e As EventArgs) Handles btChromaKeySelectBGImage.Click
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edChromaKeyImage.Text = openFileDialog1.FileName
            ConfigureChromaKey()
        End If
    End Sub

    Private Sub lbNDI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbNDI.LinkClicked, linkLabel6.LinkClicked
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

    Private Sub btVirtualCameraRegister_Click(sender As Object, e As EventArgs) Handles btVirtualCameraRegister.Click
        btVirtualCameraRegister.Enabled = Not VideoCapture1.CustomRedist_VirtualCameraRegister()
    End Sub

    Private Sub llXiphX86_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llXiphX86.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86)
        Process.Start(startInfo)
    End Sub

    Private Sub llXiphX64_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llXiphX64.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64)
        Process.Start(startInfo)
    End Sub

    Private Sub cbPIPFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPIPFormat.SelectedIndexChanged
        If (String.IsNullOrEmpty(cbPIPFormat.Text)) Then
            Return
        End If

        If (cbPIPDevice.SelectedIndex <> -1) Then
            Dim deviceItem As VideoCaptureDeviceInfo = (From info In VideoCapture1.Video_CaptureDevices Where info.Name = cbPIPDevice.Text)?.FirstOrDefault()
            If (deviceItem Is Nothing) Then
                Return
            End If

            Dim videoFormat As VideoCaptureDeviceFormat = (From Format In deviceItem.VideoFormats Where Format.Name = cbPIPFormat.Text)?.FirstOrDefault()
            If (videoFormat Is Nothing) Then
                Return
            End If

            cbPIPFrameRate.Items.Clear()
            For Each frameRate As VideoFrameRate In videoFormat.FrameRates
                cbPIPFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture))
            Next

            If (cbPIPFrameRate.Items.Count > 0) Then
                cbPIPFrameRate.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyEngine()
    End Sub
End Class

' ReSharper restore InconsistentNaming