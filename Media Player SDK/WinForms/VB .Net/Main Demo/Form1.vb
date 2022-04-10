Imports System.Globalization
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.Types.VideoEffects ' ReSharper disable InconsistentNaming

Imports System.IO
Imports VisioForge.Core.MediaInfo
Imports VisioForge.Core.MediaPlayer
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.MediaPlayer
Imports System.Drawing.Imaging
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoProcessing
Imports VisioForge.Core.Types.AudioEffects
Imports VisioForge.Core.Types
Imports VisioForge.Core
Imports System.Threading.Tasks
Imports VisioForge.Core.Helpers
Imports VisioForge.Libs.Types

Public Class Form1
    Private Const AUDIO_EFFECT_ID_AMPLIFY As String = "amplify"

    Private Const AUDIO_EFFECT_ID_EQ As String = "eq"

    Private Const AUDIO_EFFECT_ID_DYN_AMPLIFY As String = "dyn_amplify"

    Private Const AUDIO_EFFECT_ID_SOUND_3D As String = "sound3d"

    Private Const AUDIO_EFFECT_ID_TRUE_BASS As String = "true_bass"

    Private Const AUDIO_EFFECT_ID_PITCH_SHIFT As String = "pitch_shift"

    Private ReadOnly audioChannelMapperItems As List(Of AudioChannelMapperItem) = New List(Of AudioChannelMapperItem)

    ' Zoom
    Dim zoom As Double = 1.0

    Dim zoomShiftX As Integer = 0

    Dim zoomShiftY As Integer = 0

    ReadOnly multiscreenWindows As List(Of Form) = New List(Of Form)

    Private ReadOnly MediaInfo As MediaInfoReader = New MediaInfoReader

    Private WithEvents MediaPlayer1 As MediaPlayerCore

    Private Sub CreateEngine()
        Dim vv As IVideoView = VideoView1
        MediaPlayer1 = New MediaPlayerCore(vv)
    End Sub

    Private Sub DestroyEngine()
        MediaPlayer1.Dispose()
        MediaPlayer1 = Nothing
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()
        Text += $" (SDK v{MediaPlayer1.SDK_Version}), VB.Net"

        ' set combobox indexes
        cbSourceMode.SelectedIndex = 0
        cbImageType.SelectedIndex = 1
        cbMotDetHLColor.SelectedIndex = 1
        cbBarcodeType.SelectedIndex = 0
        cbDirect2DRotate.SelectedIndex = 0

        rbMotionDetectionExProcessor.SelectedIndex = 1
        rbMotionDetectionExDetector.SelectedIndex = 1

        pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128)

        For Each device As String In MediaPlayer1.Audio_OutputDevices

            cbAudioOutputDevice.Items.Add(device)

        Next

        If (cbAudioOutputDevice.Items.Count > 0) Then

            cbAudioOutputDevice.SelectedIndex = 0

        End If

        For Each filter As String In MediaPlayer1.DirectShow_Filters()

            cbCustomVideoDecoder.Items.Add(filter)
            cbCustomAudioDecoder.Items.Add(filter)
            cbCustomSplitter.Items.Add(filter)
            cbFilters.Items.Add(filter)

        Next

        If (cbFilters.Items.Count > 0) Then

            cbFilters.SelectedIndex = 0
            cbFilters_SelectedIndexChanged(Nothing, Nothing)

        End If

        rbEVR.Enabled = FilterDialogHelper.Filter_Supported_EVR()
        rbVMR9.Enabled = FilterDialogHelper.Filter_Supported_VMR9()

        rbVR_CheckedChanged(sender, e)

        ' ReSharper disable once CoVariantArrayConversion
        cbAudEqualizerPreset.Items.AddRange(MediaPlayer1.Audio_Effects_Equalizer_Presets().ToArray())
        cbAudEqualizerPreset.SelectedIndex = 0

        edScreenshotsFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
    End Sub

    Private Sub tbLightness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbLightness.Scroll

        Dim lightness As IVideoEffectLightness
        Dim effect = MediaPlayer1.Video_Effects_Get("Lightness")
        If (IsNothing(effect)) Then
            lightness = New VideoEffectLightness(True, tbLightness.Value)
            MediaPlayer1.Video_Effects_Add(lightness)
        Else
            lightness = effect
            If (lightness IsNot Nothing) Then
                lightness.Value = tbLightness.Value
            End If
        End If

    End Sub

    Private Sub tbSaturation_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSaturation.Scroll

        Dim saturation As IVideoEffectSaturation
        Dim effect = MediaPlayer1.Video_Effects_Get("Saturation")
        If (IsNothing(effect)) Then
            saturation = New VideoEffectSaturation(tbSaturation.Value)
            MediaPlayer1.Video_Effects_Add(saturation)
        Else

            saturation = effect
            If (saturation IsNot Nothing) Then
                saturation.Value = tbSaturation.Value
            End If
        End If

    End Sub

    Private Sub tbDarkness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbDarkness.Scroll

        Dim darkness As IVideoEffectDarkness
        Dim effect = MediaPlayer1.Video_Effects_Get("Darkness")
        If (IsNothing(effect)) Then
            darkness = New VideoEffectDarkness(True, tbDarkness.Value)
            MediaPlayer1.Video_Effects_Add(darkness)
        Else
            darkness = effect
            If (darkness IsNot Nothing) Then
                darkness.Value = tbDarkness.Value
            End If
        End If

    End Sub

    Private Sub cbGreyscale_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbGreyscale.CheckedChanged

        Dim grayscale As IVideoEffectGrayscale
        Dim effect = MediaPlayer1.Video_Effects_Get("Grayscale")
        If (IsNothing(effect)) Then
            grayscale = New VideoEffectGrayscale(cbGreyscale.Checked)
            MediaPlayer1.Video_Effects_Add(grayscale)
        Else
            grayscale = effect
            If (grayscale IsNot Nothing) Then
                grayscale.Enabled = cbGreyscale.Checked
            End If
        End If

    End Sub

    Private Sub cbInvert_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbInvert.CheckedChanged

        Dim invert As IVideoEffectInvert
        Dim effect = MediaPlayer1.Video_Effects_Get("Invert")
        If (IsNothing(effect)) Then
            invert = New VideoEffectInvert(cbInvert.Checked)
            MediaPlayer1.Video_Effects_Add(invert)
        Else
            invert = effect
            If (invert IsNot Nothing) Then
                invert.Enabled = cbInvert.Checked
            End If
        End If

    End Sub

    Private Sub btOSDClearLayers_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDClearLayers.Click

        MediaPlayer1.OSD_Layers_Clear()
        lbOSDLayers.Items.Clear()

    End Sub

    Private Sub btOSDLayerAdd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDLayerAdd.Click

        MediaPlayer1.OSD_Layers_Create(
            Convert.ToInt32(edOSDLayerLeft.Text),
            Convert.ToInt32(edOSDLayerTop.Text),
            Convert.ToInt32(edOSDLayerWidth.Text),
            Convert.ToInt32(edOSDLayerHeight.Text),
            True)
        lbOSDLayers.Items.Add("layer " + Convert.ToString(lbOSDLayers.Items.Count + 1), CheckState.Checked)

    End Sub

    Private Sub btOSDSelectImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSelectImage.Click

        If (openFileDialog2.ShowDialog() = DialogResult.OK) Then
            edOSDImageFilename.Text = openFileDialog2.FileName
        End If
    End Sub

    Private Sub pnOSDColorKey_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles pnOSDColorKey.Click

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            pnOSDColorKey.BackColor = colorDialog1.Color
        End If

    End Sub

    Private Sub btOSDImageDraw_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDImageDraw.Click

        If (lbOSDLayers.SelectedIndex <> -1) Then
            If (cbOSDImageTranspColor.Checked) Then
                MediaPlayer1.OSD_Layers_Draw_Image(lbOSDLayers.SelectedIndex, edOSDImageFilename.Text, Convert.ToInt32(edOSDImageLeft.Text), Convert.ToInt32(edOSDImageTop.Text), True, pnOSDColorKey.BackColor)
            Else
                MediaPlayer1.OSD_Layers_Draw_Image(lbOSDLayers.SelectedIndex, edOSDImageFilename.Text, Convert.ToInt32(edOSDImageLeft.Text), Convert.ToInt32(edOSDImageTop.Text), False, Color.Empty)
            End If
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub btOSDSelectFont_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSelectFont.Click

        If (fontDialog1.ShowDialog() = DialogResult.OK) Then
            edOSDText.Font = fontDialog1.Font
            edOSDText.ForeColor = fontDialog1.Color
        End If

    End Sub

    Private Sub btOSDTextDraw_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDTextDraw.Click

        If (lbOSDLayers.SelectedIndex <> -1) Then
            Dim fnt As Font = edOSDText.Font
            Dim color As Color = edOSDText.ForeColor

            MediaPlayer1.OSD_Layers_Draw_Text(lbOSDLayers.SelectedIndex, Convert.ToInt32(edOSDTextLeft.Text), Convert.ToInt32(edOSDTextTop.Text), edOSDText.Text, fnt, color)
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub btOSDSetTransp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btOSDSetTransp.Click

        If (lbOSDLayers.SelectedIndex <> -1) Then
            MediaPlayer1.OSD_Layers_SetTransparency(lbOSDLayers.SelectedIndex, tbOSDTranspLevel.Value)
            MediaPlayer1.OSD_Layers_Render()
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If

    End Sub

    Private Sub rbVR_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbVMR9.CheckedChanged, rbNone.CheckedChanged, rbEVR.CheckedChanged, rbDirect2D.CheckedChanged

        If MediaPlayer1 Is Nothing Then
            Return
        End If

        cbScreenFlipVertical.Enabled = rbVMR9.Checked Or rbDirect2D.Checked
        cbScreenFlipHorizontal.Enabled = rbVMR9.Checked Or rbDirect2D.Checked

        If (rbVMR9.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
        ElseIf (rbEVR.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
        ElseIf (rbDirect2D.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
        Else
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None
        End If

    End Sub

    Private Sub btSelectScreenshotsFolder_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectScreenshotsFolder.Click

        If (folderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            edScreenshotsFolder.Text = folderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Async Sub btSaveScreenshot_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSaveScreenshot.Click
        Dim dt As DateTime = DateTime.Now

        Dim s As String = dt.Hour.ToString() + "_" + dt.Minute.ToString() + "_" + dt.Second.ToString() + "_" + dt.Millisecond.ToString()

        Dim customWidth = 0
        Dim customHeight = 0

        If (cbScreenshotResize.Checked) Then
            customWidth = Convert.ToInt32(edScreenshotWidth.Text)
            customHeight = Convert.ToInt32(edScreenshotHeight.Text)
        End If

        Select Case (cbImageType.SelectedIndex)
            Case 0
                Await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s, ".bmp"), ImageFormat.Bmp, 0, customWidth, customHeight)
            Case 1
                Await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s, ".jpg"), ImageFormat.Jpeg, tbJPEGQuality.Value, customWidth, customHeight)
            Case 2
                Await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s, ".gif"), ImageFormat.Gif, 0, customWidth, customHeight)
            Case 3
                Await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s, ".png"), ImageFormat.Png, 0, customWidth, customHeight)
            Case 4
                Await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s, ".tiff"), ImageFormat.Tiff, 0, customWidth, customHeight)
        End Select
    End Sub

    Private Sub tbBalance1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance1.Scroll

        If (cbAudioStream1.Checked Or MediaPlayer1.Audio_Streams_AllInOne()) Then
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)
        End If

    End Sub

    Private Sub tbBalance2_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance2.Scroll

        If (cbAudioStream2.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Balance_Set(1, tbBalance2.Value)
        End If

    End Sub

    Private Sub tbBalance3_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance3.Scroll

        If (cbAudioStream3.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Balance_Set(2, tbBalance3.Value)
        End If

    End Sub

    Private Sub tbBalance4_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance4.Scroll

        If (cbAudioStream4.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Balance_Set(3, tbBalance4.Value)
        End If

    End Sub

    Private Async Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSpeed.Scroll

        Await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0)

    End Sub

    Private Sub tbVolume1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume1.Scroll

        If (cbAudioStream1.Checked Or MediaPlayer1.Audio_Streams_AllInOne()) Then
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)
        End If

    End Sub

    Private Async Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll

        If (Convert.ToInt32(timer1.Tag) = 0) Then
            Await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        End If

    End Sub

    Private Sub tbVolume2_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume2.Scroll

        If (cbAudioStream2.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Volume_Set(1, tbVolume2.Value)
        End If

    End Sub

    Private Sub tbVolume3_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume3.Scroll

        If (cbAudioStream3.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Volume_Set(2, tbVolume3.Value)
        End If

    End Sub

    Private Sub tbVolume4_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume4.Scroll

        If (cbAudioStream4.Checked) Then
            MediaPlayer1.Audio_OutputDevice_Volume_Set(3, tbVolume4.Value)
        End If

    End Sub

    Dim memoryFileStream As FileStream = Nothing

    Private Sub LoadToMemory()

        If Not IsNothing(memoryFileStream) Then
            memoryFileStream.Dispose()
            memoryFileStream = Nothing
        End If

        memoryFileStream = New FileStream(edFilenameOrURL.Text, FileMode.Open)
        Dim stream As ManagedIStream = New ManagedIStream(memoryFileStream)

        ' video and audio present in file. tune this settings to play audio files or video files without audio
        MediaPlayer1.Source_MemoryStream = New MemoryStreamSource(stream, True, True, memoryFileStream.Length)
    End Sub

    Private Sub btReadInfo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btReadInfo.Click
        mmInfo.Clear()

        'clear audio controls
        cbAudioStream1.Enabled = False
        cbAudioStream2.Enabled = False
        cbAudioStream3.Enabled = False
        cbAudioStream4.Enabled = False
        tbVolume1.Enabled = False
        tbVolume2.Enabled = False
        tbVolume3.Enabled = False
        tbVolume4.Enabled = False
        tbBalance1.Enabled = False
        tbBalance2.Enabled = False
        tbBalance3.Enabled = False
        tbBalance4.Enabled = False

        MediaInfo.Filename = edFilenameOrURL.Text

        SetSourceMode()

        If ((MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS) Or
            (MediaPlayer1.Source_Mode = MediaPlayerSourceMode.FFMPEG) Or
            (MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV) Or
            (MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Encrypted_File_DS)) Then

            ' "Read info" button
            If IsDBNull(sender) Then
                Dim errorCode As FilePlaybackError
                Dim errorText As String = ""

                If (MediaInfoReader.IsFilePlayable(edFilenameOrURL.Text, errorCode, errorText)) Then
                    mmInfo.Text += "This file is playable" + Environment.NewLine
                Else
                    mmInfo.Text += "This file is not playable" + Environment.NewLine
                End If
            End If

            Dim keyType As EncryptionKeyType
            Dim key As Object
            If (rbEncryptionKeyString.Checked) Then
                keyType = EncryptionKeyType.String
                key = edEncryptionKeyString.Text
            ElseIf (rbEncryptionKeyFile.Checked) Then
                keyType = EncryptionKeyType.File
                key = edEncryptionKeyFile.Text
            Else
                keyType = EncryptionKeyType.Binary
                key = MediaPlayer1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text)
            End If

            MediaInfo.ReadFileInfo(MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Encrypted_File_DS, key, keyType, cbUseLibMediaInfo.Checked)

            For i As Integer = 0 To MediaInfo.VideoStreams.Count - 1
                Dim videoStream = MediaInfo.VideoStreams(i)

                mmInfo.Text += String.Empty & Environment.NewLine
                mmInfo.Text += "Video #" & Convert.ToString(i + 1) & Environment.NewLine
                mmInfo.Text += "Codec: " & videoStream.Codec & Environment.NewLine
                mmInfo.Text += "Duration: " & videoStream.Duration.ToString() & Environment.NewLine
                mmInfo.Text += "Width: " & videoStream.Width & Environment.NewLine
                mmInfo.Text += "Height: " & videoStream.Height & Environment.NewLine
                mmInfo.Text += "FOURCC: " & videoStream.FourCC & Environment.NewLine
                mmInfo.Text += "Aspect Ratio: " & $"{videoStream.AspectRatio.Item1}:{videoStream.AspectRatio.Item2}" & Environment.NewLine
                mmInfo.Text += "Frame rate: " & videoStream.FrameRate.Value & Environment.NewLine
                mmInfo.Text += "Bitrate: " & videoStream.Bitrate & Environment.NewLine
                mmInfo.Text += "Frames count: " & videoStream.FramesCount & Environment.NewLine
            Next

            For i As Integer = 0 To MediaInfo.AudioStreams.Count - 1
                Dim audioStream = MediaInfo.AudioStreams(i)

                mmInfo.Text += String.Empty + Environment.NewLine
                mmInfo.Text += "Audio #" & Convert.ToString(i + 1) & Environment.NewLine
                mmInfo.Text += "Codec: " & audioStream.Codec & Environment.NewLine
                mmInfo.Text += "Codec info: " & audioStream.CodecInfo & Environment.NewLine
                mmInfo.Text += "Duration: " & audioStream.Duration.ToString() & Environment.NewLine
                mmInfo.Text += "Bitrate: " & audioStream.Bitrate & Environment.NewLine
                mmInfo.Text += "Channels: " & audioStream.Channels & Environment.NewLine
                mmInfo.Text += "Sample rate: " & audioStream.SampleRate & Environment.NewLine
                mmInfo.Text += "BPS: " & audioStream.BPS & Environment.NewLine
                mmInfo.Text += "Language: " & audioStream.Language & Environment.NewLine
            Next

            For i As Integer = 0 To MediaInfo.Subtitles.Count - 1
                Dim textStream = MediaInfo.Subtitles(i)

                mmInfo.Text += String.Empty & Environment.NewLine
                mmInfo.Text += "Text #" & Convert.ToString(i + 1) & Environment.NewLine
                mmInfo.Text += "Codec: " & textStream.Codec & Environment.NewLine
                mmInfo.Text += "Name: " & textStream.Name & Environment.NewLine
                mmInfo.Text += "Language: " & textStream.Language & Environment.NewLine
            Next

            ' timeline
            If (MediaInfo.VideoStreams.Count > 0) Then
                tbTimeline.Maximum = MediaInfo.VideoStreams(0).Duration.TotalSeconds
            ElseIf (MediaInfo.AudioStreams.Count > 0) Then
                tbTimeline.Maximum = MediaInfo.AudioStreams(0).Duration.TotalSeconds
            End If

            ' set audio streams tab
            Dim count As Integer = MediaInfo.AudioStreams.Count
            Dim oneOutput As Boolean = MediaInfo.Audio_Streams_AllInOne

            cbAudioStream1.Enabled = True
            cbAudioStream1.Checked = True
            tbVolume1.Enabled = True
            tbBalance1.Enabled = True

            If (count = 0) Then
                Return
            End If

            If (count > 1) Then

                cbAudioStream2.Enabled = True
                cbAudioStream2.Checked = False
                tbVolume2.Enabled = Not oneOutput
                tbBalance2.Enabled = Not oneOutput

            End If

            If (count > 2) Then

                cbAudioStream3.Enabled = True
                cbAudioStream3.Checked = False
                tbVolume3.Enabled = Not oneOutput
                tbBalance3.Enabled = Not oneOutput

            End If

            If (count > 3) Then

                cbAudioStream4.Enabled = True
                cbAudioStream4.Checked = False
                tbVolume4.Enabled = Not oneOutput
                tbBalance4.Enabled = Not oneOutput

            End If

            ' additional audio streams added from Other audio files
            Dim count2 As Integer = MediaPlayer1.Audio_AdditionalStreams_GetCount()

            If (count2 = 0) Then

                Return

            End If

            Dim count3 As Integer = count2

            If ((count2 + count >= 4) And (count3 > 0)) Then

                cbAudioStream4.Enabled = True
                cbAudioStream4.Checked = True
                tbVolume4.Enabled = True
                tbBalance4.Enabled = True
                count3 = count3 - 1

            End If

            If ((count2 + count >= 3) And (count3 > 0)) Then

                cbAudioStream3.Enabled = True
                cbAudioStream3.Checked = True
                tbVolume3.Enabled = True
                tbBalance3.Enabled = True
                count3 = count3 - 1

            End If

            If ((count2 + count >= 2) And (count3 > 0)) Then

                cbAudioStream2.Enabled = True
                cbAudioStream2.Checked = True
                tbVolume2.Enabled = True
                tbBalance2.Enabled = True
                count3 = count3 - 1

            End If

            If ((count2 + count >= 1) And (count3 > 0)) Then

                cbAudioStream1.Enabled = True
                cbAudioStream1.Checked = True
                tbVolume1.Enabled = True
                tbBalance1.Enabled = True

            End If

        Else

            cbAudioStream1.Enabled = True
            cbAudioStream1.Checked = True
            tbVolume1.Enabled = True
            tbBalance1.Enabled = True

        End If

    End Sub

    Private Async Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer1.Tick

        timer1.Tag = 1
        tbTimeline.Maximum = (Await MediaPlayer1.Duration_TimeAsync()).TotalSeconds

        Dim value As Integer = (Await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds
        If ((value > 0) And (value < tbTimeline.Maximum)) Then

            tbTimeline.Value = value

        End If

        lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

        timer1.Tag = 0

    End Sub

    Private Async Sub FillAdjustRanges()
        'updating adjust settings
        Dim brightness = Await MediaPlayer1.Video_Renderer_VideoAdjust_GetRangesAsync(VideoRendererAdjustment.Brightness)
        If Not IsNothing(brightness) Then
            tbAdjBrightness.Minimum = brightness.Min * 10
            tbAdjBrightness.Maximum = brightness.Max * 10
            tbAdjBrightness.SmallChange = brightness.Step * 10

            Dim def As Integer = brightness.Default * 10

            If (def > brightness.Max * 10) Then
                def = brightness.Max * 10
            End If

            If (def < brightness.Min * 10) Then
                def = brightness.Min * 10
            End If

            tbAdjBrightness.Value = def
            lbAdjBrightnessMin.Text = "Min: " + Convert.ToString(brightness.Min)
            lbAdjBrightnessMax.Text = "Max: " + Convert.ToString(brightness.Max)
            lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(brightness.Default)
        End If

        Dim hue = Await MediaPlayer1.Video_Renderer_VideoAdjust_GetRangesAsync(VideoRendererAdjustment.Hue)
        If Not IsNothing(hue) Then
            tbAdjHue.Minimum = hue.Min * 10
            tbAdjHue.Maximum = hue.Max * 10
            tbAdjHue.SmallChange = hue.Step * 10

            Dim def As Integer = hue.Default * 10
            If (def > hue.Max * 10) Then
                def = hue.Max * 10
            End If

            If (def < hue.Min * 10) Then
                def = hue.Min * 10
            End If

            tbAdjHue.Value = def
            lbAdjHueMin.Text = "Min: " + Convert.ToString(hue.Min)
            lbAdjHueMax.Text = "Max: " + Convert.ToString(hue.Max)
            lbAdjHueCurrent.Text = "Current: " + Convert.ToString(hue.Default)
        End If

        Dim saturation = Await MediaPlayer1.Video_Renderer_VideoAdjust_GetRangesAsync(VideoRendererAdjustment.Saturation)
        If Not IsNothing(saturation) Then
            tbAdjSaturation.Minimum = saturation.Min * 10
            tbAdjSaturation.Maximum = saturation.Max * 10
            tbAdjSaturation.SmallChange = saturation.Step * 10

            Dim def As Integer = saturation.Default * 10

            If (def > saturation.Max * 10) Then
                def = saturation.Max * 10
            End If

            If (def < saturation.Min * 10) Then
                def = saturation.Min * 10
            End If

            tbAdjSaturation.Value = def
            lbAdjSaturationMin.Text = "Min: " + Convert.ToString(saturation.Min)
            lbAdjSaturationMax.Text = "Max: " + Convert.ToString(saturation.Max)
            lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(saturation.Default)
        End If

        Dim contrast = Await MediaPlayer1.Video_Renderer_VideoAdjust_GetRangesAsync(VideoRendererAdjustment.Contrast)
        If Not IsNothing(contrast) Then
            tbAdjContrast.Minimum = contrast.Min * 10
            tbAdjContrast.Maximum = contrast.Max * 10
            tbAdjContrast.SmallChange = contrast.Step * 10

            Dim def As Integer = contrast.Default * 10

            If (def > contrast.Max * 10) Then
                def = contrast.Max * 10
            End If

            If (def < contrast.Min * 10) Then
                def = contrast.Min * 10
            End If

            tbAdjContrast.Value = def
            lbAdjContrastMin.Text = "Min: " + Convert.ToString(contrast.Min)
            lbAdjContrastMax.Text = "Max: " + Convert.ToString(contrast.Max)
            lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(contrast.Default)
        End If
    End Sub

    Private Sub ConfigureObjectTracking()
        If (cbMotionDetectionEx.Checked) Then
            MediaPlayer1.Motion_DetectionEx = New MotionDetectionExSettings()
            MediaPlayer1.Motion_DetectionEx.ProcessorType = rbMotionDetectionExProcessor.SelectedIndex
            MediaPlayer1.Motion_DetectionEx.DetectorType = rbMotionDetectionExDetector.SelectedIndex
        Else
            MediaPlayer1.Motion_DetectionEx = Nothing
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

    Private Sub SetSourceMode()
        Select Case (cbSourceMode.SelectedIndex)
            Case 0
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV
            Case 1
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.GPU

                If (rbGPUIntel.Checked) Then
                    MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.IntelQuickSync
                ElseIf (rbGPUNVidia.Checked) Then
                    MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.NvidiaCUVID
                ElseIf (rbGPUDXVANative.Checked) Then
                    MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.DXVA2Native
                ElseIf (rbGPUDXVACopyBack.Checked) Then
                    MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack
                ElseIf (rbGPUDirect3D.Checked) Then
                    MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.Direct3D11
                End If
            Case 2
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.FFMPEG
            Case 3
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS
            Case 4
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_VLC
            Case 5
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.BluRay
            Case 6
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS
                LoadToMemory()
            Case 7
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.MMS_WMV_DS
            Case 8
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.HTTP_RTSP_VLC
            Case 9
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Encrypted_File_DS
            Case 10
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.MIDI
        End Select
    End Sub

    Private Sub AddVideoEffects()
        MediaPlayer1.Video_Effects_Enabled = cbEffects.Checked
        MediaPlayer1.Video_Effects_Clear()
        lbImageLogos.Items.Clear()
        lbTextLogos.Items.Clear()

        ' Deinterlace
        If cbDeinterlace.Checked Then

            If rbDeintBlendEnabled.Checked Then
                Dim blend As IVideoEffectDeinterlaceBlend
                Dim effect = MediaPlayer1.Video_Effects_Get("DeinterlaceBlend")
                If (IsNothing(effect)) Then
                    blend = New VideoEffectDeinterlaceBlend(True)
                    MediaPlayer1.Video_Effects_Add(blend)
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
                Dim effect = MediaPlayer1.Video_Effects_Get("DeinterlaceCAVT")
                If (IsNothing(effect)) Then
                    cavt = New VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.Checked, Convert.ToInt32(edDeintCAVTThreshold.Text))
                    MediaPlayer1.Video_Effects_Add(cavt)
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
                Dim effect = MediaPlayer1.Video_Effects_Get("DeinterlaceTriangle")
                If (effect Is Nothing) Then
                    triangle = New VideoEffectDeinterlaceTriangle(True, Convert.ToByte(edDeintTriangleWeight.Text))
                    MediaPlayer1.Video_Effects_Add(triangle)
                Else
                    triangle = effect
                End If

                If (triangle Is Nothing) Then
                    MessageBox.Show("Unable to configure deinterlace triangle effect.")
                    Return
                End If

                triangle.Weight = Convert.ToByte(edDeintTriangleWeight.Text)
            End If

        End If

        'Denoise
        If cbDenoise.Checked Then

            If (rbDenoiseCAST.Checked) Then
                Dim cast As IVideoEffectDenoiseCAST
                Dim effect = MediaPlayer1.Video_Effects_Get("DenoiseCAST")
                If (effect Is Nothing) Then
                    cast = New VideoEffectDenoiseCAST(True)
                    MediaPlayer1.Video_Effects_Add(cast)
                Else
                    cast = effect
                End If

                If (cast Is Nothing) Then
                    MessageBox.Show("Unable to configure denoise CAST effect.")
                    Return
                End If
            Else
                Dim mosquito As IVideoEffectDenoiseMosquito
                Dim effect = MediaPlayer1.Video_Effects_Get("DenoiseMosquito")
                If (effect Is Nothing) Then
                    mosquito = New VideoEffectDenoiseMosquito(True)
                    MediaPlayer1.Video_Effects_Add(mosquito)
                Else
                    mosquito = effect
                End If

                If (mosquito Is Nothing) Then
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

        If cbFlipX.Checked Then
            cbFlipX_CheckedChanged(Nothing, Nothing)
        End If

        If cbFlipY.Checked Then
            cbFlipY_CheckedChanged(Nothing, Nothing)
        End If

        If cbFadeInOut.Checked Then
            cbFadeInOut_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        MediaPlayer1.Debug_Mode = cbDebugMode.Checked
        MediaPlayer1.Debug_Telemetry = cbTelemetry.Checked

        zoom = 1.0
        zoomShiftX = 0
        zoomShiftY = 0

        mmLog.Clear()

        MediaPlayer1.Info_UseLibMediaInfo = cbUseLibMediaInfo.Checked

        If (rbVideoDecoderDefault.Checked) Then
            MediaPlayer1.Custom_Video_Decoder = String.Empty
        ElseIf (rbVideoDecoderFFDShow.Checked) Then
            MediaPlayer1.Custom_Video_Decoder = "ffdshow Video Decoder"
        ElseIf (rbVideoDecoderMS.Checked) Then
            MediaPlayer1.Custom_Video_Decoder = "Microsoft DTV-DVD Video Decoder"
        ElseIf (rbVideoDecoderVFH264.Checked) Then
            MediaPlayer1.Custom_Video_Decoder = "VisioForge H264 Decoder"
        ElseIf (rbVideoDecoderCustom.Checked) Then
            MediaPlayer1.Custom_Video_Decoder = cbCustomVideoDecoder.Text
        End If

        If (rbSplitterCustom.Checked) Then
            MediaPlayer1.Custom_Splitter = cbCustomSplitter.Text
        Else
            MediaPlayer1.Custom_Splitter = String.Empty
        End If

        If (rbAudioDecoderDefault.Checked) Then
            MediaPlayer1.Custom_Audio_Decoder = String.Empty
        ElseIf (rbAudioDecoderCustom.Checked) Then
            MediaPlayer1.Custom_Audio_Decoder = cbCustomAudioDecoder.Text
        End If

        If (lbSourceFiles.Items.Count = 0) Then
            MessageBox.Show("Playlist is empty!")
        End If

        For Each item As Object In lbSourceFiles.Items
            MediaPlayer1.FilenamesOrURL.Add(item.ToString())
        Next

        MediaPlayer1.Loop = cbLoop.Checked
        MediaPlayer1.Audio_PlayAudio = cbPlayAudio.Checked

        MediaPlayer1.Video_Renderer.Aspect_Ratio_X = Convert.ToInt32(edAspectRatioX.Text)
        MediaPlayer1.Video_Renderer.Aspect_Ratio_Y = Convert.ToInt32(edAspectRatioY.Text)
        MediaPlayer1.Video_Renderer.Aspect_Ratio_Override = cbAspectRatioUseCustom.Checked

        MediaPlayer1.OSD_Enabled = cbOSDEnabled.Checked

        SetSourceMode()

        btReadInfo_Click(sender, e)

        MediaPlayer1.Audio_OutputDevice = cbAudioOutputDevice.Text

        If (rbVMR9.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
        ElseIf (rbEVR.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
        ElseIf (rbDirect2D.Checked) Then
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
        Else
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None
        End If

        MediaPlayer1.Virtual_Camera_Output_Enabled = rbVirtualCameraOutput.Checked

        MediaPlayer1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)
        MediaPlayer1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        MediaPlayer1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked

        ' Audio enhancement
        MediaPlayer1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.Checked
        If (MediaPlayer1.Audio_Enhancer_Enabled) Then

            Await MediaPlayer1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.Checked)
            Await MediaPlayer1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.Checked)

            Await ApplyAudioInputGainsAsync()
            Await ApplyAudioOutputGainsAsync()

            Await MediaPlayer1.Audio_Enhancer_TimeshiftAsync(-1, tbAudioTimeshift.Value)
        End If

        ' Audio channels mapping
        If (cbAudioChannelMapperEnabled.Checked) Then
            MediaPlayer1.Audio_Channel_Mapper = New AudioChannelMapperSettings()
            MediaPlayer1.Audio_Channel_Mapper.Routes = audioChannelMapperItems.ToArray()
            MediaPlayer1.Audio_Channel_Mapper.OutputChannelsCount = Convert.ToInt32(edAudioChannelMapperOutputChannels.Text)
        Else
            MediaPlayer1.Audio_Channel_Mapper = Nothing
        End If

        ' Audio processing
        MediaPlayer1.Audio_Effects_Clear(-1)
        MediaPlayer1.Audio_Effects_Enabled = cbAudioEffectsEnabled.Checked

        If (MediaPlayer1.Audio_Effects_Enabled) Then

            MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)

        End If

        ' Multiscreen
        MediaPlayer1.MultiScreen_Clear()
        MediaPlayer1.MultiScreen_Enabled = cbMultiscreenDrawOnPanels.Checked Or cbMultiscreenDrawOnExternalDisplays.Checked

        If (cbMultiscreenDrawOnPanels.Checked) Then
            MediaPlayer1.MultiScreen_AddScreen(pnScreen1.Handle, pnScreen1.Width, pnScreen1.Height)
            MediaPlayer1.MultiScreen_AddScreen(pnScreen2.Handle, pnScreen2.Width, pnScreen2.Height)
        End If

        If (cbMultiscreenDrawOnExternalDisplays.Checked) Then

            If (Screen.AllScreens.Length > 1) Then

                For i As Integer = 1 To Screen.AllScreens.Length
                    Dim additinalWindow1 As Form = New Form()
                    ShowOnScreen(additinalWindow1, i)
                    MediaPlayer1.MultiScreen_AddScreen(additinalWindow1.Handle, additinalWindow1.Width, additinalWindow1.Height)
                    multiscreenWindows.Add(additinalWindow1)
                Next
            End If
        End If

        ' VU meters
        MediaPlayer1.Audio_VUMeter_Pro_Enabled = cbVUMeterPro.Checked

        If (MediaPlayer1.Audio_VUMeter_Pro_Enabled) Then

            MediaPlayer1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value

            volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F
            volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F

            waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F
            waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F

        End If

        ' Video effects GPU
        MediaPlayer1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.Checked

        ' Video effects
        AddVideoEffects()

        MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = True

        ' Barcode detection
        MediaPlayer1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked
        MediaPlayer1.Barcode_Reader_Type = cbBarcodeType.SelectedIndex

        ' Motion detection
        ConfigureMotionDetection()

        ' Object detection
        ConfigureObjectTracking()

        ' chroma key
        ConfigureChromaKey()

        ' Encryption
        If (rbEncryptionKeyString.Checked) Then

            MediaPlayer1.Encryption_KeyType = EncryptionKeyType.String
            MediaPlayer1.Encryption_Key = edEncryptionKeyString.Text

        ElseIf (rbEncryptionKeyFile.Checked) Then

            MediaPlayer1.Encryption_KeyType = EncryptionKeyType.File
            MediaPlayer1.Encryption_Key = edEncryptionKeyFile.Text

        Else

            MediaPlayer1.Encryption_KeyType = EncryptionKeyType.Binary
            MediaPlayer1.Encryption_Key = MediaPlayer1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text)

        End If

        Await MediaPlayer1.PlayAsync()

        FillAdjustRanges()

        ' set audio volume for each stream
        If (MediaPlayer1.Source_Mode <> MediaPlayerSourceMode.MMS_WMV_DS) Then

            Dim count As Integer = MediaPlayer1.Audio_Streams_Count()

            If (count > 0) Then

                MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)
                MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

            End If

            ' independent audio output for each audio stream
            If (Not MediaPlayer1.Audio_Streams_AllInOne()) Then

                If (count > 1) Then

                    MediaPlayer1.Audio_OutputDevice_Balance_Set(1, tbBalance2.Value)
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(1, tbVolume2.Value)
                    Await MediaPlayer1.Audio_Streams_SetAsync(1, False) 'disable stream

                End If

                If (count > 2) Then

                    MediaPlayer1.Audio_OutputDevice_Balance_Set(2, tbBalance3.Value)
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(2, tbVolume3.Value)
                    Await MediaPlayer1.Audio_Streams_SetAsync(2, False) 'disable stream

                End If

                If (count > 3) Then

                    MediaPlayer1.Audio_OutputDevice_Balance_Set(3, tbBalance4.Value)
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(3, tbVolume4.Value)
                    Await MediaPlayer1.Audio_Streams_SetAsync(3, False) 'disable stream

                End If
            Else

                tbBalance2.Enabled = False
                tbVolume2.Enabled = False

                tbBalance3.Enabled = False
                tbVolume3.Enabled = False

                tbBalance4.Enabled = False
                tbVolume4.Enabled = False

            End If

        Else

            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

        End If

        timer1.Enabled = True

    End Sub

    Private Sub btSelectFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilenameOrURL.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Async Sub btZoomIn_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomIn.Click
        MediaPlayer1.Video_Renderer.Zoom_Ratio = MediaPlayer1.Video_Renderer.Zoom_Ratio + 5
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomOut_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomOut.Click
        MediaPlayer1.Video_Renderer.Zoom_Ratio = MediaPlayer1.Video_Renderer.Zoom_Ratio - 5
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftDown_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftDown.Click
        MediaPlayer1.Video_Renderer.Zoom_ShiftY = MediaPlayer1.Video_Renderer.Zoom_ShiftY - 2
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftLeft_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftLeft.Click
        MediaPlayer1.Video_Renderer.Zoom_ShiftX = MediaPlayer1.Video_Renderer.Zoom_ShiftX - 2
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftRight_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftRight.Click
        MediaPlayer1.Video_Renderer.Zoom_ShiftX = MediaPlayer1.Video_Renderer.Zoom_ShiftX + 2
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomShiftUp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btZoomShiftUp.Click
        MediaPlayer1.Video_Renderer.Zoom_ShiftY = MediaPlayer1.Video_Renderer.Zoom_ShiftY + 2
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btZoomReset_Click(sender As Object, e As EventArgs) Handles btZoomReset.Click
        MediaPlayer1.Video_Renderer.Zoom_Ratio = 0
        MediaPlayer1.Video_Renderer.Zoom_ShiftX = 0
        MediaPlayer1.Video_Renderer.Zoom_ShiftY = 0
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub cbAudioStream1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioStream1.CheckedChanged

        Await MediaPlayer1.Audio_Streams_SetAsync(0, cbAudioStream1.Checked)
        If (cbAudioStream1.Checked) Then

            tbVolume1_Scroll(sender, e)

            If (MediaPlayer1.Audio_Streams_AllInOne()) Then
                cbAudioStream2.Checked = False
                cbAudioStream3.Checked = False
                cbAudioStream4.Checked = False
            End If

        End If

    End Sub

    Private Async Sub cbAudioStream2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioStream2.CheckedChanged

        Await MediaPlayer1.Audio_Streams_SetAsync(1, cbAudioStream2.Checked)

        If (cbAudioStream2.Checked) Then

            tbVolume2_Scroll(sender, e)

            If (MediaPlayer1.Audio_Streams_AllInOne()) Then
                cbAudioStream1.Checked = False
                cbAudioStream3.Checked = False
                cbAudioStream4.Checked = False
            End If

        End If

    End Sub

    Private Async Sub cbAudioStream3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioStream3.CheckedChanged

        Await MediaPlayer1.Audio_Streams_SetAsync(2, cbAudioStream3.Checked)

        If (cbAudioStream3.Checked) Then

            tbVolume3_Scroll(sender, e)

            If (MediaPlayer1.Audio_Streams_AllInOne()) Then
                cbAudioStream1.Checked = False
                cbAudioStream2.Checked = False
                cbAudioStream4.Checked = False
            End If

        End If

    End Sub

    Private Async Sub cbAudioStream4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudioStream4.CheckedChanged

        Await MediaPlayer1.Audio_Streams_SetAsync(3, cbAudioStream4.Checked)

        If (cbAudioStream4.Checked) Then

            tbVolume4_Scroll(sender, e)

            If (MediaPlayer1.Audio_Streams_AllInOne()) Then
                cbAudioStream1.Checked = False
                cbAudioStream2.Checked = False
                cbAudioStream3.Checked = False
            End If

        End If

    End Sub

    Private Async Sub cbScreenFlipHorizontal_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbScreenFlipHorizontal.CheckedChanged
        MediaPlayer1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub cbScreenFlipVertical_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbScreenFlipVertical.CheckedChanged
        MediaPlayer1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub cbStretch_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch.CheckedChanged
        If (cbStretch.Checked) Then

            MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch

        Else

            MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox

        End If

        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Async Sub btStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStop.Click

        Await MediaPlayer1.StopAsync()

        timer1.Enabled = False
        tbTimeline.Value = 0

        waveformPainter1.Clear()
        waveformPainter2.Clear()

        volumeMeter1.Clear()
        volumeMeter2.Clear()

        If cbMultiscreenDrawOnPanels.Checked Then
            pnScreen1.Refresh()
            pnScreen2.Refresh()
        End If

        For Each form As Form In multiscreenWindows
            form.Close()
            ' form.Dispose()
        Next

        multiscreenWindows.Clear()

    End Sub

    Private Async Sub btResume_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btResume.Click

        Await MediaPlayer1.ResumeAsync()

    End Sub

    Private Async Sub btPause_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btPause.Click

        Await MediaPlayer1.PauseAsync()

    End Sub

    Private Sub btNextFrame_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btNextFrame.Click

        MediaPlayer1.NextFrame()

    End Sub

    Private Sub tbContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbContrast.Scroll

        Dim contrast As IVideoEffectContrast
        Dim effect = MediaPlayer1.Video_Effects_Get("Contrast")
        If (effect Is Nothing) Then
            contrast = New VideoEffectContrast(True, tbContrast.Value)
            MediaPlayer1.Video_Effects_Add(contrast)
        Else
            contrast = effect
            If (contrast IsNot Nothing) Then
                contrast.Value = tbContrast.Value
            End If
        End If

    End Sub

    Private Async Sub cbAspectRatioUseCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAspectRatioUseCustom.CheckedChanged
        MediaPlayer1.Video_Renderer.Aspect_Ratio_Override = cbAspectRatioUseCustom.Checked
        MediaPlayer1.Video_Renderer.Aspect_Ratio_X = Convert.ToInt32(edAspectRatioX.Text)
        MediaPlayer1.Video_Renderer.Aspect_Ratio_Y = Convert.ToInt32(edAspectRatioY.Text)
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Sub btAudEqRefresh_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAudEqRefresh.Click

        tbAudEq0.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0)
        tbAudEq1.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1)
        tbAudEq2.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2)
        tbAudEq3.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3)
        tbAudEq4.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4)
        tbAudEq5.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5)
        tbAudEq6.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6)
        tbAudEq7.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7)
        tbAudEq8.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8)
        tbAudEq9.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9)

    End Sub

    Private Sub cbAudAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudAmplifyEnabled.CheckedChanged

        MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked)

    End Sub

    Private Sub cbAudDynamicAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudDynamicAmplifyEnabled.CheckedChanged

        MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked)

    End Sub

    Private Sub cbAudEqualizerEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudEqualizerEnabled.CheckedChanged

        MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked)

    End Sub

    Private Sub cbAudEqualizerPreset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudEqualizerPreset.SelectedIndexChanged

        MediaPlayer1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerPreset.SelectedIndex)
        btAudEqRefresh_Click(sender, e)

    End Sub

    Private Sub cbAudSound3DEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudSound3DEnabled.CheckedChanged

        MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked)

    End Sub

    Private Sub cbAudTrueBassEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudTrueBassEnabled.CheckedChanged

        MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked)

    End Sub

    Private Sub tbAud3DSound_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAud3DSound.Scroll

        MediaPlayer1.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, tbAud3DSound.Value)

    End Sub

    Private Sub tbAudAmplifyAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAmplifyAmp.Scroll

        MediaPlayer1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, False)

    End Sub

    Private Sub tbAudAttack_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAttack.Scroll

        MediaPlayer1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudDynAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudDynAmp.Scroll

        MediaPlayer1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudRelease_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudRelease.Scroll

        MediaPlayer1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudEq0_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq0.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, tbAudEq0.Value)

    End Sub

    Private Sub tbAudEq1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq1.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, tbAudEq1.Value)

    End Sub

    Private Sub tbAudEq2_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq2.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, tbAudEq2.Value)

    End Sub

    Private Sub tbAudEq3_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq3.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, tbAudEq3.Value)

    End Sub

    Private Sub tbAudEq4_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq4.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, tbAudEq4.Value)

    End Sub

    Private Sub tbAudEq5_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq5.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, tbAudEq5.Value)

    End Sub

    Private Sub tbAudEq6_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq6.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, tbAudEq6.Value)

    End Sub

    Private Sub tbAudEq7_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq7.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, tbAudEq7.Value)

    End Sub

    Private Sub tbAudEq8_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq8.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, tbAudEq8.Value)

    End Sub

    Private Sub tbAudEq9_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq9.Scroll

        MediaPlayer1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, tbAudEq9.Value)

    End Sub

    Private Sub tbAudTrueBass_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudTrueBass.Scroll

        MediaPlayer1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, False, tbAudTrueBass.Value)

    End Sub

    Private Sub tbJPEGQuality_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbJPEGQuality.Scroll

        lbJPEGQuality.Text = tbJPEGQuality.Value.ToString()

    End Sub

    Private Sub MediaPlayer1_OnError(ByVal sender As System.Object, ByVal e As ErrorsEventArgs) Handles MediaPlayer1.OnError

        BeginInvoke(Sub()
                        mmLog.Text = mmLog.Text + e.Message + Environment.NewLine
                    End Sub)

    End Sub

    Private Delegate Sub AFStopDelegate()

    Private Async Sub AFStopDelegateMethod()

        tbTimeline.Value = 0

        'playlist used, we still need to call from GUI thread, using delegate
        If (MediaPlayer1.FilenamesOrURL.Count > 0) Then
            Await MediaPlayer1.PlayAsync()
        End If

    End Sub

    Private Sub MediaPlayer1_OnStop(ByVal sender As System.Object, ByVal e As EventArgs) Handles MediaPlayer1.OnStop

        Dim motdel As AFStopDelegate = New AFStopDelegate(AddressOf AFStopDelegateMethod)
        BeginInvoke(motdel, Nothing)

    End Sub

    Private Async Sub tbAdjBrightness_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjBrightness.Scroll
        Await MediaPlayer1.Video_Renderer_VideoAdjust_SetValueAsync(VideoRendererAdjustment.Brightness, (tbAdjBrightness.Value / 10.0))
        lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(tbAdjBrightness.Value / 10.0)
    End Sub

    Private Async Sub tbAdjContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjContrast.Scroll
        Await MediaPlayer1.Video_Renderer_VideoAdjust_SetValueAsync(VideoRendererAdjustment.Contrast, (tbAdjContrast.Value / 10.0))
        lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(tbAdjContrast.Value / 10.0)
    End Sub

    Private Async Sub tbAdjHue_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjHue.Scroll
        Await MediaPlayer1.Video_Renderer_VideoAdjust_SetValueAsync(VideoRendererAdjustment.Hue, (tbAdjHue.Value / 10.0))
        lbAdjHueCurrent.Text = "Current: " + Convert.ToString(tbAdjHue.Value / 10.0)
    End Sub

    Private Async Sub tbAdjSaturation_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAdjSaturation.Scroll
        Await MediaPlayer1.Video_Renderer_VideoAdjust_SetValueAsync(VideoRendererAdjustment.Saturation, (tbAdjSaturation.Value / 10.0))
        lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(tbAdjSaturation.Value / 10.0)
    End Sub

    Private Sub ConfigureMotionDetection()
        If (cbMotDetEnabled.Checked) Then
            MediaPlayer1.Motion_Detection = New MotionDetectionSettings()
            MediaPlayer1.Motion_Detection.Enabled = cbMotDetEnabled.Checked
            MediaPlayer1.Motion_Detection.Compare_Red = cbCompareRed.Checked
            MediaPlayer1.Motion_Detection.Compare_Green = cbCompareGreen.Checked
            MediaPlayer1.Motion_Detection.Compare_Blue = cbCompareBlue.Checked
            MediaPlayer1.Motion_Detection.Compare_Greyscale = cbCompareGreyscale.Checked
            MediaPlayer1.Motion_Detection.Highlight_Color = cbMotDetHLColor.SelectedIndex
            MediaPlayer1.Motion_Detection.Highlight_Enabled = cbMotDetHLEnabled.Checked
            MediaPlayer1.Motion_Detection.Highlight_Threshold = tbMotDetHLThreshold.Value
            MediaPlayer1.Motion_Detection.FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text)
            MediaPlayer1.Motion_Detection.Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text)
            MediaPlayer1.Motion_Detection.Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text)
            MediaPlayer1.Motion_Detection.DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked
            MediaPlayer1.Motion_Detection.DropFrames_Threshold = tbMotDetDropFramesThreshold.Value
            MediaPlayer1.MotionDetection_Update()
        Else
            MediaPlayer1.Motion_Detection = Nothing
        End If
    End Sub

    Private Sub btMotDetUpdateSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMotDetUpdateSettings.Click
        ConfigureMotionDetection()
    End Sub

    Private Sub btChromaKeySelectBGImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btChromaKeySelectBGImage.Click
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edChromaKeyImage.Text = openFileDialog1.FileName
            ConfigureChromaKey()
        End If
    End Sub

    Private Sub cbAFMotionDetection_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbMotionDetectionEx.CheckedChanged

        ConfigureObjectTracking()

    End Sub

    Private Delegate Sub AFMotionDelegate(ByVal level As System.Single)

    Private Sub AFMotionDelegateMethod(ByVal level As System.Single)

        pbAFMotionLevel.Value = level * 100

    End Sub

    Private Sub MediaPlayer1_OnObjectDetection(ByVal sender As System.Object, ByVal e As MotionDetectionExEventArgs) Handles MediaPlayer1.OnMotionDetectionEx

        Dim motdel As AFMotionDelegate = New AFMotionDelegate(AddressOf AFMotionDelegateMethod)
        BeginInvoke(motdel, e.Level)

    End Sub

    Private Sub ConfigureChromaKey()
        If (Not IsNothing(MediaPlayer1.ChromaKey)) Then
            MediaPlayer1.ChromaKey.Dispose()
            MediaPlayer1.ChromaKey = Nothing
        End If

        If (cbChromaKeyEnabled.Checked) Then
            If (Not File.Exists(edChromaKeyImage.Text)) Then
                MessageBox.Show("Chroma-key background file doesn't exists.")
                Return
            End If

            MediaPlayer1.ChromaKey = New ChromaKeySettings(New Bitmap(edChromaKeyImage.Text))
            MediaPlayer1.ChromaKey.Smoothing = tbChromaKeySmoothing.Value / 1000.0F
            MediaPlayer1.ChromaKey.ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000.0F
            MediaPlayer1.ChromaKey.Color = pnChromaKeyColor.BackColor
        Else
            MediaPlayer1.ChromaKey = Nothing
        End If
    End Sub

    Private Delegate Sub MotionDelegate(ByVal e As MotionDetectionEventArgs)

    Private Sub MotionDelegateMethod(ByVal e As MotionDetectionEventArgs)

        Dim s As String = String.Empty

        Dim k As Integer
        For Each b As Byte In e.Matrix
            s += b.ToString("D3") + " "

            If (k = MediaPlayer1.Motion_Detection.Matrix_Width - 1) Then
                k = 0
                s += Environment.NewLine
            Else
                k += 1
            End If
        Next

        mmMotDetMatrix.Text = s.Trim()
        pbMotionLevel.Value = e.Level

    End Sub

    Private Sub MediaPlayer1_OnMotion(ByVal sender As System.Object, ByVal e As MotionDetectionEventArgs) Handles MediaPlayer1.OnMotion

        Dim motdel As MotionDelegate = New MotionDelegate(AddressOf MotionDelegateMethod)
        BeginInvoke(motdel, e)

    End Sub

    Private Sub cbStretch1_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbStretch1.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Sub cbFlipVertical1_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbFlipVertical1.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Sub cbFlipHorizontal1_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbFlipHorizontal1.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(0, cbStretch1.Checked, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked)

    End Sub

    Private Sub cbStretch2_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbStretch2.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Sub cbFlipVertical2_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbFlipVertical2.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Sub cbFlipHorizontal2_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbFlipHorizontal2.CheckedChanged

        MediaPlayer1.MultiScreen_SetParameters(1, cbStretch2.Checked, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked)

    End Sub

    Private Sub cbZoom_CheckedChanged(sender As System.Object, e As EventArgs) Handles cbZoom.CheckedChanged

        Dim zoomEffect As IVideoEffectZoom
        Dim effect = MediaPlayer1.Video_Effects_Get("Zoom")
        If (effect Is Nothing) Then
            zoomEffect = New VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoom.Checked)
            MediaPlayer1.Video_Effects_Add(zoomEffect)
        Else
            zoomEffect = effect
        End If

        If (zoomEffect Is Nothing) Then
            MessageBox.Show("Unable to configure zoom effect.")
            Return
        End If

        zoomEffect.ZoomX = zoom
        zoomEffect.ZoomY = zoom
        zoomEffect.ShiftX = zoomShiftX
        zoomEffect.ShiftY = zoomShiftY
        zoomEffect.Enabled = cbZoom.Checked

    End Sub

    Private Sub btEffZoomIn_Click(sender As System.Object, e As EventArgs) Handles btEffZoomIn.Click

        zoom += 0.1
        zoom = Math.Min(zoom, 5)

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomOut_Click(sender As System.Object, e As EventArgs) Handles btEffZoomOut.Click

        zoom -= 0.1
        zoom = Math.Max(zoom, 1)

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomUp_Click(sender As System.Object, e As EventArgs) Handles btEffZoomUp.Click

        zoomShiftY += 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomDown_Click(sender As System.Object, e As EventArgs) Handles btEffZoomDown.Click

        zoomShiftY -= 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomRight_Click(sender As System.Object, e As EventArgs) Handles btEffZoomRight.Click

        zoomShiftX += 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub btEffZoomLeft_Click(sender As System.Object, e As EventArgs) Handles btEffZoomLeft.Click

        zoomShiftX -= 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub cbPan_CheckedChanged(sender As Object, e As EventArgs) Handles cbPan.CheckedChanged

        Dim pan As IVideoEffectPan
        Dim effect = MediaPlayer1.Video_Effects_Get("Pan")
        If (effect Is Nothing) Then
            pan = New VideoEffectPan(True)
            MediaPlayer1.Video_Effects_Add(pan)
        Else
            pan = effect
        End If

        If (pan Is Nothing) Then
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
        MediaPlayer1.Barcode_Reader_Enabled = True

    End Sub

    Private Sub MediaPlayer1_OnBarcodeDetected(sender As Object, e As BarcodeEventArgs) Handles MediaPlayer1.OnBarcodeDetected

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

    Private Sub btAddFileToPlaylist_Click(sender As Object, e As EventArgs) Handles btAddFileToPlaylist.Click

        lbSourceFiles.Items.Add(edFilenameOrURL.Text)

    End Sub

    Private Sub cbFadeInOut_CheckedChanged(sender As Object, e As EventArgs) Handles cbFadeInOut.CheckedChanged

        If (rbFadeIn.Checked) Then
            Dim fadeIn As IVideoEffectFadeIn
            Dim effect = MediaPlayer1.Video_Effects_Get("FadeIn")
            If (effect Is Nothing) Then
                fadeIn = New VideoEffectFadeIn(cbFadeInOut.Checked)
                MediaPlayer1.Video_Effects_Add(fadeIn)
            Else
                fadeIn = effect
            End If

            If (fadeIn Is Nothing) Then
                MessageBox.Show("Unable to configure fade-in effect.")
                Return
            End If

            fadeIn.Enabled = cbFadeInOut.Checked
            fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text))
            fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text))
        Else
            Dim fadeOut As IVideoEffectFadeOut
            Dim effect = MediaPlayer1.Video_Effects_Get("FadeOut")
            If (effect Is Nothing) Then
                fadeOut = New VideoEffectFadeOut(cbFadeInOut.Checked)
                MediaPlayer1.Video_Effects_Add(fadeOut)
            Else
                fadeOut = effect
            End If

            If (fadeOut Is Nothing) Then
                MessageBox.Show("Unable to configure fade-out effect.")
                Return
            End If

            fadeOut.Enabled = cbFadeInOut.Checked
            fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text))
            fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text))
        End If

    End Sub

    Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

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

            Await MediaPlayer1.Video_Renderer_UpdateAsync()
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

            Await MediaPlayer1.Video_Renderer_UpdateAsync()
        End If
    End Sub

    Private Sub MediaPlayer1_MouseDown(sender As Object, e As MouseEventArgs) Handles VideoView1.MouseDown

        If (fullScreen) Then

            btFullScreen_Click(sender, e)

        End If

    End Sub

#End Region

    Private Delegate Sub StopDelegate()

    Private Sub StopDelegateMethod()

        tbTimeline.Value = 0

        waveformPainter1.Clear()
        waveformPainter2.Clear()

        volumeMeter1.Clear()
        volumeMeter2.Clear()

        If Not IsNothing(memoryFileStream) Then

            memoryFileStream.Dispose()
            memoryFileStream = Nothing

        End If

    End Sub


    Private Sub MediaPlayer1_OnStop(sender As Object, e As StopEventArgs) Handles MediaPlayer1.OnStop

        BeginInvoke(New StopDelegate(AddressOf StopDelegateMethod))

    End Sub

    Private Sub btReversePlayback_Click(sender As Object, e As EventArgs) Handles btReversePlayback.Click

        MediaPlayer1.ReversePlayback_CacheSize = Int32.Parse(edReversePlaybackCacheSize.Text)

        If (MediaPlayer1.ReversePlayback_Enabled) Then

            btReversePlayback.Text = "Go to reverse playback mode"
            MediaPlayer1.ReversePlayback_Enabled = False

        Else

            btReversePlayback.Text = "Go to normal playback mode"
            MediaPlayer1.ReversePlayback_Enabled = True

        End If

    End Sub

    Private Sub tbReversePlaybackTrackbar_Scroll(sender As Object, e As EventArgs) Handles tbReversePlaybackTrackbar.Scroll

        MediaPlayer1.ReversePlayback_GoToFrame(tbReversePlaybackTrackbar.Value)

    End Sub

    Private Sub tbVUMeterAmplification_Scroll(sender As Object, e As EventArgs) Handles tbVUMeterAmplification.Scroll

        MediaPlayer1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value

    End Sub

    Private Sub tbVUMeterBoost_Scroll(sender As Object, e As EventArgs) Handles tbVUMeterBoost.Scroll

        volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F
        volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F

        waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F
        waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F

    End Sub

    Private Sub MediaPlayer1_OnAudioVUMeterProVolume(sender As Object, e As AudioLevelEventArgs) Handles MediaPlayer1.OnAudioVUMeterProVolume

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
        Dim effect = MediaPlayer1.Video_Effects_Get("Rotate")
        If (effect Is Nothing) Then
            rotate = New VideoEffectRotate(
                    cbLiveRotation.Checked,
                    tbLiveRotationAngle.Value,
                    cbLiveRotationStretch.Checked)
            MediaPlayer1.Video_Effects_Add(rotate)
        Else
            rotate = effect
        End If

        If (rotate Is Nothing) Then
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

    Private Async Sub pnVideoRendererBGColor_Click(sender As Object, e As EventArgs) Handles pnVideoRendererBGColor.Click
        colorDialog1.Color = pnVideoRendererBGColor.BackColor

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then

            pnVideoRendererBGColor.BackColor = colorDialog1.Color

            MediaPlayer1.Video_Renderer.BackgroundColor = colorDialog1.Color
            Await MediaPlayer1.Video_Renderer_UpdateAsync()
        End If
    End Sub

    Private Async Sub cbDirect2DRotate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDirect2DRotate.SelectedIndexChanged
        MediaPlayer1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)
        Await MediaPlayer1.Video_Renderer_UpdateAsync()
    End Sub

    Private Sub cbFilters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilters.SelectedIndexChanged

        If cbFilters.SelectedIndex <> -1 Then
            Dim sName As String = cbFilters.Text
            btFilterSettings.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))
        End If

    End Sub

    Private Sub btFilterAdd_Click(sender As Object, e As EventArgs) Handles btFilterAdd.Click

        If cbFilters.SelectedIndex <> -1 Then
            MediaPlayer1.Video_Filters_Add(cbFilters.Text)
            lbFilters.Items.Add(cbFilters.Text)
        End If

    End Sub

    Private Sub btFilterSettings_Click(sender As Object, e As EventArgs) Handles btFilterSettings.Click

        Dim sName As String = cbFilters.Text

        If (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Then
            FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
        ElseIf (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)) Then
            FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)
        End If

    End Sub

    Private Sub lbFilters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbFilters.SelectedIndexChanged

        If lbFilters.SelectedIndex <> -1 Then

            Dim sName As String = lbFilters.Text
            btFilterSettings2.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))

        End If

    End Sub

    Private Sub btFilterSettings2_Click(sender As Object, e As EventArgs) Handles btFilterSettings2.Click

        If lbFilters.SelectedIndex <> -1 Then

            Dim sName As String = lbFilters.Text

            If (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.Default)
            ElseIf (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig)) Then
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, sName, PropertyPageType.CompressorConfig)

            End If

        End If

    End Sub

    Private Sub btFilterDelete_Click(sender As Object, e As EventArgs) Handles btFilterDelete.Click

        If lbFilters.SelectedIndex <> -1 Then

            MediaPlayer1.Video_Filters_Delete(lbFilters.Text)
            lbFilters.Items.Remove(lbFilters.Text)

        End If

    End Sub

    Private Sub btFilterDeleteAll_Click(sender As Object, e As EventArgs) Handles btFilterDeleteAll.Click

        lbFilters.Items.Clear()
        MediaPlayer1.Video_Filters_Clear()

    End Sub

    Private Async Sub cbAudioNormalize_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioNormalize.CheckedChanged

        Await MediaPlayer1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.Checked)

    End Sub

    Private Async Sub cbAudioAutoGain_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioAutoGain.CheckedChanged

        Await MediaPlayer1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.Checked)

    End Sub

    Private Async Function ApplyAudioInputGainsAsync() As Task

        Dim gains As AudioEnhancerGains = New AudioEnhancerGains()

        gains.L = tbAudioInputGainL.Value / 10.0F
        gains.C = tbAudioInputGainC.Value / 10.0F
        gains.R = tbAudioInputGainR.Value / 10.0F
        gains.SL = tbAudioInputGainSL.Value / 10.0F
        gains.SR = tbAudioInputGainSR.Value / 10.0F
        gains.LFE = tbAudioInputGainLFE.Value / 10.0F

        Await MediaPlayer1.Audio_Enhancer_InputGainsAsync(-1, gains)

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

    Private Async Function ApplyAudioOutputGainsAsync() As Task

        Dim gains As AudioEnhancerGains = New AudioEnhancerGains

        gains.L = tbAudioOutputGainL.Value / 10.0F
        gains.C = tbAudioOutputGainC.Value / 10.0F
        gains.R = tbAudioOutputGainR.Value / 10.0F
        gains.SL = tbAudioOutputGainSL.Value / 10.0F
        gains.SR = tbAudioOutputGainSR.Value / 10.0F
        gains.LFE = tbAudioOutputGainLFE.Value / 10.0F

        Await MediaPlayer1.Audio_Enhancer_OutputGainsAsync(-1, gains)

    End Function

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

        Await MediaPlayer1.Audio_Enhancer_TimeshiftAsync(-1, tbAudioTimeshift.Value)

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Not IsNothing(memoryFileStream) Then

            memoryFileStream.Dispose()
            memoryFileStream = Nothing

        End If

        btStop_Click(Nothing, Nothing)

        DestroyEngine()

    End Sub

    Private Sub btReadTags_Click(sender As Object, e As EventArgs) Handles btReadTags.Click

        Dim tags = MediaPlayer1.Tags_Read(edFilenameOrURL.Text)

        If (Not IsNothing(tags)) Then

            If (Not IsNothing(tags.Pictures) And tags.Pictures.Length > 0) Then

                imgTags.Image = tags.Pictures(0)

            End If

            edTags.Text = tags.ToString()

        End If

    End Sub

    Private Sub btAudioChannelMapperClear_Click(sender As Object, e As EventArgs) Handles btAudioChannelMapperClear.Click

        audioChannelMapperItems.Clear()
        lbAudioChannelMapperRoutes.Items.Clear()

    End Sub

    Private Sub btAudioChannelMapperAddNewRoute_Click(sender As Object, e As EventArgs) Handles btAudioChannelMapperAddNewRoute.Click

        Dim item = New AudioChannelMapperItem()
        item.SourceChannel = Convert.ToInt32(edAudioChannelMapperSourceChannel.Text)
        item.TargetChannel = Convert.ToInt32(edAudioChannelMapperTargetChannel.Text)
        item.TargetChannelVolume = tbAudioChannelMapperVolume.Value / 1000.0F

        audioChannelMapperItems.Add(item)

        lbAudioChannelMapperRoutes.Items.Add(
                "Source: " + edAudioChannelMapperSourceChannel.Text + ", target: " + edAudioChannelMapperTargetChannel.Text + ", volume: " + (tbAudioChannelMapperVolume.Value / 1000.0F).ToString("F2"))


    End Sub

    Private Sub tbGPULightness_Scroll(sender As Object, e As EventArgs) Handles tbGPULightness.Scroll

        Dim intf As IGPUVideoEffectBrightness
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Brightness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectBrightness(True, tbGPULightness.Value)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Saturation")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectSaturation(True, tbGPUSaturation.Value)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Contrast")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectContrast(True, tbGPUContrast.Value)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Darkness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDarkness(True, tbGPUDarkness.Value)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectGrayscale(cbGPUGreyscale.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Invert")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectInvert(cbGPUInvert.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("NightVision")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectNightVision(cbGPUNightVision.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Pixelate")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectPixelate(cbGPUPixelate.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Denoise")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDenoise(cbGPUDenoise.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("DeinterlaceBlend")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("OldMovie")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectOldMovie(cbGPUOldMovie.Checked)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUOldMovie.Checked
                intf.Update()
            End If
        End If
    End Sub

    Private Sub btReversePlaybackPrevFrame_Click(sender As Object, e As EventArgs) Handles btReversePlaybackPrevFrame.Click
        MediaPlayer1.ReversePlayback_PreviousFrame()
    End Sub

    Private Sub btReversePlaybackNextFrame_Click(sender As Object, e As EventArgs) Handles btReversePlaybackNextFrame.Click
        MediaPlayer1.ReversePlayback_NextFrame()
    End Sub

    Private Sub btPreviousFrame_Click(sender As Object, e As EventArgs) Handles btPreviousFrame.Click
        MediaPlayer1.PreviousFrame()
    End Sub

    Private Sub cbFlipX_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipX.CheckedChanged
        Dim flip As IVideoEffectFlipDown
        Dim effect = MediaPlayer1.Video_Effects_Get("FlipDown")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipHorizontal(cbFlipX.Checked)
            MediaPlayer1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipX.Checked
            End If
        End If
    End Sub

    Private Sub cbFlipY_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipY.CheckedChanged
        Dim flip As IVideoEffectFlipRight
        Dim effect = MediaPlayer1.Video_Effects_Get("FlipRight")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipVertical(cbFlipY.Checked)
            MediaPlayer1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipY.Checked
            End If
        End If
    End Sub

    Private Sub btImageLogoRemove_Click(sender As Object, e As EventArgs) Handles btImageLogoRemove.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            MediaPlayer1.Video_Effects_Remove(lbImageLogos.SelectedItem)
            lbImageLogos.Items.Remove(lbImageLogos.SelectedItem)
        End If
    End Sub

    Private Sub btImageLogoEdit_Click(sender As Object, e As EventArgs) Handles btImageLogoEdit.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New ImageLogoSettingsDialog()
            Dim effect = MediaPlayer1.Video_Effects_Get(lbImageLogos.SelectedItem)

            dlg.Attach(effect)
            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btImageLogoAdd_Click(sender As Object, e As EventArgs) Handles btImageLogoAdd.Click
        Dim dlg = New ImageLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(MediaPlayer1)
        Dim effect = New VideoEffectImageLogo(True, effectName)

        MediaPlayer1.Video_Effects_Add(effect)
        lbImageLogos.Items.Add(effect.Name)

        dlg.Fill(effect)
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btTextLogoEdit_Click(sender As Object, e As EventArgs) Handles btTextLogoEdit.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New TextLogoSettingsDialog()
            Dim effect = MediaPlayer1.Video_Effects_Get(lbTextLogos.SelectedItem)
            dlg.Attach(effect)

            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btTextLogoRemove_Click(sender As Object, e As EventArgs) Handles btTextLogoRemove.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            MediaPlayer1.Video_Effects_Remove(lbTextLogos.SelectedItem)
            lbTextLogos.Items.Remove(lbTextLogos.SelectedItem)
        End If
    End Sub

    Private Sub btTextLogoAdd_Click(sender As Object, e As EventArgs) Handles btTextLogoAdd.Click
        Dim dlg = New TextLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(MediaPlayer1)
        Dim effect = New VideoEffectTextLogo(True, effectName)

        MediaPlayer1.Video_Effects_Add(effect)
        lbTextLogos.Items.Add(effect.Name)
        dlg.Fill(effect)

        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub MediaPlayer1_OnMIDIFileInfo(sender As Object, e As MIDIInfoEventArgs) Handles MediaPlayer1.OnMIDIFileInfo
        BeginInvoke(Sub()
                        edTags.Text += "MIDI Info from OnMIDIFileInfo event:" + Environment.NewLine
                        edTags.Text += e.Info.ToString()
                    End Sub)
    End Sub

    Private Sub btOSDClearLayer_Click(sender As Object, e As EventArgs) Handles btOSDClearLayer.Click
        If (lbOSDLayers.SelectedIndex <> -1) Then
            MediaPlayer1.OSD_Layers_Clear(lbOSDLayers.SelectedIndex)
        Else
            MessageBox.Show(Me, "Please select OSD layer.")
        End If
    End Sub

    Private Sub btOSDRenderLayers_Click(sender As Object, e As EventArgs) Handles btOSDRenderLayers.Click
        MediaPlayer1.OSD_Layers_Render()
    End Sub

    Private Sub lbOSDLayers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lbOSDLayers.ItemCheck
        MediaPlayer1.OSD_Layers_Enable(e.Index, e.NewValue = CheckState.Checked)
    End Sub

    Private Sub btEncryptionOpenFile_Click(sender As Object, e As EventArgs) Handles btEncryptionOpenFile.Click
        If (openFileDialog1.ShowDialog(Me) = DialogResult.OK) Then
            edEncryptionKeyFile.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub mnPlaylist_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles mnPlaylist.ItemClicked
        If (e.ClickedItem.Name = "mnPlaylistRemove") Then
            If (lbSourceFiles.SelectedItem IsNot Nothing) Then
                Dim filename = lbSourceFiles.SelectedItem.ToString()
                MediaPlayer1.FilenamesOrURL.Remove(filename)
                lbSourceFiles.Items.Remove(lbSourceFiles.SelectedItem)
            End If
        ElseIf (e.ClickedItem.Name = "mnPlaylistRemoveAll") Then
            MediaPlayer1.FilenamesOrURL.Clear()
            lbSourceFiles.Items.Clear()
        End If
    End Sub

    Private Sub tbGPUBlur_Scroll(sender As Object, e As EventArgs) Handles tbGPUBlur.Scroll
        Dim intf As IGPUVideoEffectBlur
        Dim effect = MediaPlayer1.Video_Effects_GPU_Get("Blur")
        If (effect Is Nothing) Then
            intf = New GPUVideoEffectBlur(tbGPUBlur.Value > 0, tbGPUBlur.Value)
            MediaPlayer1.Video_Effects_GPU_Add(intf)
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

    Private Sub pnChromaKeyColor_Click(sender As Object, e As EventArgs) Handles pnChromaKeyColor.Click
        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            pnChromaKeyColor.BackColor = colorDialog1.Color
            ConfigureChromaKey()
        End If
    End Sub

    Private Sub linkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel7.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI)
        Process.Start(startInfo)
    End Sub

    Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel2.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI)
        Process.Start(startInfo)
    End Sub
End Class

' ReSharper restore InconsistentNaming