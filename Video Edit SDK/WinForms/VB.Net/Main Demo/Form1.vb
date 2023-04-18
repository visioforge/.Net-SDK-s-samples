' ReSharper disable InconsistentNaming

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
Imports VisioForge.Core.Types.Output
Imports VisioForge.Core.Types.VideoEdit
Imports VisioForge.Core.Types.VideoEffects
Imports VisioForge.Core.Types.VideoProcessing
Imports VisioForge.Core.UI
Imports VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
Imports VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
Imports VisioForge.Core.VideoEdit
Imports VisioForge.Libs.Types

Public Class Form1
    Private Const AUDIO_EFFECT_ID_AMPLIFY As String = "amplify"

    Private Const AUDIO_EFFECT_ID_EQ As String = "eq"

    Private Const AUDIO_EFFECT_ID_DYN_AMPLIFY As String = "dyn_amplify"

    Private Const AUDIO_EFFECT_ID_SOUND_3D As String = "sound3d"

    Private Const AUDIO_EFFECT_ID_TRUE_BASS As String = "true_bass"

    Private Const AUDIO_EFFECT_ID_PITCH_SHIFT As String = "pitch_shift"

    Private mp4HWSettingsDialog As HWEncodersOutputSettingsDialog

    Private mp4SettingsDialog As MP4SettingsDialog

    Private aviSettingsDialog As AVISettingsDialog

    Private wmvSettingsDialog As WMVSettingsDialog

    Private dvSettingsDialog As DVSettingsDialog

    Private pcmSettingsDialog As PCMSettingsDialog

    Private mp3SettingsDialog As MP3SettingsDialog

    Private webmSettingsDialog As WebMSettingsDialog

    Private ffmpegSettingsDialog As FFMPEGSettingsDialog

    Private ffmpegEXESettingsDialog As FFMPEGEXESettingsDialog

    Private flacSettingsDialog As FLACSettingsDialog

    Private customFormatSettingsDialog As CustomFormatSettingsDialog

    Private oggVorbisSettingsDialog As OggVorbisSettingsDialog

    Private speexSettingsDialog As SpeexSettingsDialog

    Private m4aSettingsDialog As M4ASettingsDialog

    Private gifSettingsDialog As GIFSettingsDialog

    Private ReadOnly audioChannelMapperItems As List(Of AudioChannelMapperItem) = New List(Of AudioChannelMapperItem)

    ' Zoom
    Private zoom As Double = 1.0

    Private zoomShiftX As Integer = 0

    Private zoomShiftY As Integer = 0

    Private WithEvents VideoEdit1 As VideoEditCore

    Private Sub CreateEngine()
        Dim vv As IVideoView = VideoView1
        VideoEdit1 = New VideoEditCore(vv)
    End Sub

    Private Sub DestroyEngine()
        VideoEdit1.Dispose()
        VideoEdit1 = Nothing
    End Sub

    Private Function GetFileExt(ByVal fileName As String) As String

        Dim k As Integer
        k = fileName.LastIndexOf(".", StringComparison.Ordinal)
        GetFileExt = fileName.Substring(k, fileName.Length - k)

    End Function

    Private Sub btClearList_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btClearList.Click

        lbFiles.Items.Clear()
        VideoEdit1.Input_Clear_List()

    End Sub

    Private Async Sub btAddInputFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAddInputFile.Click

        Dim s As String

        If (OpenDialog1.ShowDialog() = DialogResult.OK) Then

            VideoEdit1.Video_FrameRate = New VideoFrameRate(Convert.ToDouble(cbFrameRate.Text, CultureInfo.InvariantCulture))

            ' resize if required
            Dim customWidth = 0
            Dim customHeight = 0

            If (cbResize.Checked) Then
                customWidth = Convert.ToInt32(edWidth.Text)
                customHeight = Convert.ToInt32(edHeight.Text)
            End If

            s = OpenDialog1.FileName

            lbFiles.Items.Add(s)

            If ((String.Compare(GetFileExt(s), ".BMP", True) = 0) Or (String.Compare(GetFileExt(s), ".JPG", True) = 0) Or (String.Compare(GetFileExt(s), ".JPEG", True) = 0) Or (String.Compare(GetFileExt(s), ".GIF", True) = 0) Or (String.Compare(GetFileExt(s), ".PNG", True) = 0)) Then

                If (cbAddFullFile.Checked) Then

                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), Nothing, VideoEditStretchMode.Letterbox)
                    Else
                        Await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), VideoEditStretchMode.Letterbox)
                    End If

                Else
                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)), Nothing, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight)
                    Else
                        Await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), VideoEditStretchMode.Letterbox, 0, customWidth, customHeight)
                    End If
                End If

            ElseIf ((String.Compare(GetFileExt(s), ".WAV", True) = 0) Or (String.Compare(GetFileExt(s), ".MP3", True) = 0) Or (String.Compare(GetFileExt(s), ".OGG", True) = 0) Or (String.Compare(GetFileExt(s), ".WMA", True) = 0)) Then

                If (cbAddFullFile.Checked) Then
                    Dim audioFile = New AudioSource(s, Nothing, Nothing, String.Empty, 0, tbSpeed.Value / 100.0)
                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, Nothing, 0)
                    Else
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0)
                    End If
                Else
                    Dim audioFile = New AudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), String.Empty, 0, tbSpeed.Value / 100.0)
                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, Nothing, 0)
                    Else
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0)
                    End If
                End If
            Else
                If (cbAddFullFile.Checked) Then
                    Dim videoFile = New VideoSource(
                                s, Nothing, Nothing, VideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0)
                    Dim audioFile = New AudioSource(s, Nothing, Nothing, String.Empty, 0, tbSpeed.Value / 100.0)

                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddVideoFileAsync(videoFile, Nothing, 0, customWidth, customHeight)
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, Nothing, 0)
                    Else
                        Await VideoEdit1.Input_AddVideoFileAsync(videoFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0, customWidth, customHeight)
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0)
                    End If
                Else
                    Dim videoFile = New VideoSource(
                                s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), VideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0)
                    Dim audioFile = New AudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), String.Empty, 0, tbSpeed.Value / 100.0)

                    If (cbInsertAfterPreviousFile.Checked) Then
                        Await VideoEdit1.Input_AddVideoFileAsync(videoFile, Nothing, 0, customWidth, customHeight)
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, Nothing, 0)
                    Else
                        Await VideoEdit1.Input_AddVideoFileAsync(videoFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0, customWidth, customHeight)
                        Await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0)
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub btSelectOutput_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectOutput.Click

        If SaveDialog1.ShowDialog() = DialogResult.OK Then
            edOutput.Text = SaveDialog1.FileName
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        CreateEngine()

        Text += $" (SDK v{VideoEdit1.SDK_Version})"

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")
        edOutputFileCut.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")
        edOutputFileJoin.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4")
        VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        Tag = 1

        cbFrameRate.SelectedIndex = 0
        cbOutputVideoFormat.SelectedIndex = 15
        cbRotate.SelectedIndex = 0
        cbBarcodeType.SelectedIndex = 0
        cbNetworkStreamingMode.SelectedIndex = 0
        cbDirect2DRotate.SelectedIndex = 0
        cbMuxStreamsType.SelectedIndex = 0
        cbMotDetHLColor.SelectedIndex = 0

        cbDecklinkOutputAnalog.SelectedIndex = 0
        cbDecklinkOutputBlackToDeck.SelectedIndex = 0
        cbDecklinkOutputComponentLevels.SelectedIndex = 0
        cbDecklinkOutputDownConversion.SelectedIndex = 0
        cbDecklinkOutputDualLink.SelectedIndex = 0
        cbDecklinkOutputHDTVPulldown.SelectedIndex = 0
        cbDecklinkOutputNTSC.SelectedIndex = 0
        cbDecklinkOutputSingleField.SelectedIndex = 0

        pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128)

        For Each item As String In VideoEdit1.DirectShow_Filters()
            cbFilters.Items.Add(item)
        Next

        cbFilters.SelectedIndex = 0

        For i As Integer = 0 To VideoEdit1.Video_Transition_Names().Count - 1
            cbTransitionName.Items.Add(VideoEdit1.Video_Transition_Names().Item(i))
        Next
        cbTransitionName.SelectedIndex = 0

        Dim genres As List(Of String) = New List(Of String)
        For Each s As String In VideoEdit1.Tags_GetDefaultAudioGenres()
            genres.Add(s)
        Next

        For Each s As String In VideoEdit1.Tags_GetDefaultVideoGenres()
            genres.Add(s)
        Next

        genres.Sort()

        For Each genre As String In genres
            cbTagGenre.Items.Add(genre)
        Next

        cbTagGenre.Text = "Rock"

        ' ReSharper disable once CoVariantArrayConversion
        cbAudEqualizerPreset.Items.AddRange(VideoEdit1.Audio_Effects_Equalizer_Presets().ToArray())
        cbAudEqualizerPreset.SelectedIndex = 0

    End Sub

    Private Sub VideoEdit1_OnStop(ByVal sender As System.Object, ByVal e As StopEventArgs) Handles VideoEdit1.OnStop
        Invoke(Sub()
                   ProgressBar1.Value = 0

                   lbFiles.Items.Clear()

                   lbTransitions.Items.Clear()

                   'clear VU Meters
                   Dim data(19) As Int32

                   peakMeterCtrl1.SetData(data, 0, 19)
                   peakMeterCtrl1.Stop()
                   waveformPainter1.Clear()
                   waveformPainter2.Clear()

                   volumeMeter1.Clear()
                   volumeMeter2.Clear()

                   lbImageLogos.Items.Clear()
                   lbTextLogos.Items.Clear()
               End Sub)

        VideoEdit1.Input_Clear_List()
        VideoEdit1.Video_Transition_Clear()
        VideoEdit1.Video_Effects_Clear()

        If (e.Successful) Then
            MessageBox.Show(Me, "Completed successfully", String.Empty, MessageBoxButtons.OK)
        Else
            MessageBox.Show(Me, "Stopped with error", String.Empty, MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub ConfigureDecklink()

        If cbDecklinkOutput.Checked Then
            VideoEdit1.Decklink_Output = New DecklinkOutputSettings()
            VideoEdit1.Decklink_Output.DVEncoding = cbDecklinkDV.Checked
            VideoEdit1.Decklink_Output.AnalogOutputIREUSA = cbDecklinkOutputNTSC.SelectedIndex = 0
            VideoEdit1.Decklink_Output.AnalogOutputSMPTE = cbDecklinkOutputComponentLevels.SelectedIndex = 0
            VideoEdit1.Decklink_Output.BlackToDeckInCapture = cbDecklinkOutputBlackToDeck.SelectedIndex
            VideoEdit1.Decklink_Output.DualLinkOutputMode = cbDecklinkOutputDualLink.SelectedIndex
            VideoEdit1.Decklink_Output.HDTVPulldownOnOutput = cbDecklinkOutputHDTVPulldown.SelectedIndex
            VideoEdit1.Decklink_Output.SingleFieldOutputForSynchronousFrames = cbDecklinkOutputSingleField.SelectedIndex
            VideoEdit1.Decklink_Output.VideoOutputDownConversionMode = cbDecklinkOutputDownConversion.SelectedIndex
            VideoEdit1.Decklink_Output.VideoOutputDownConversionModeAnalogUsed = cbDecklinkOutputDownConversionAnalogOutput.Checked
            VideoEdit1.Decklink_Output.AnalogOutput = cbDecklinkOutputAnalog.SelectedIndex
        Else
            VideoEdit1.Decklink_Output = Nothing
        End If

    End Sub

    Private Sub ConfigureObjectTracking()
        If (cbAFMotionDetection.Checked) Then
            VideoEdit1.Motion_DetectionEx = New MotionDetectionExSettings()
            If (cbAFMotionHighlight.Checked) Then
                VideoEdit1.Motion_DetectionEx.ProcessorType = MotionProcessorType.MotionAreaHighlighting
            Else
                VideoEdit1.Motion_DetectionEx.ProcessorType = MotionProcessorType.None
            End If
        Else
            VideoEdit1.Motion_DetectionEx = Nothing
        End If
    End Sub

    Private Sub ConfigureVideoRenderer()

        If rbVMR9.Checked Then
            VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
        ElseIf rbEVR.Checked Then
            VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
        ElseIf (rbDirect2D.Checked) Then
            VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
        Else
            VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.None
        End If

        If (cbStretch.Checked) Then
            VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch
        Else
            VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox
        End If

        VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)

        VideoEdit1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor
        VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked

    End Sub

    Private Sub ConfigureVUMeter()

        VideoEdit1.Audio_VUMeter_Enabled = cbVUMeter.Checked
        VideoEdit1.Audio_VUMeter_Pro_Enabled = cbVUMeterPro.Checked

        If (VideoEdit1.Audio_VUMeter_Pro_Enabled) Then

            VideoEdit1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value

            volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F
            volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F

            waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F
            waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F

        End If
    End Sub

    Private Sub SetMP4HWOutput(ByRef mp4Output As MP4HWOutput)
        If (mp4HWSettingsDialog Is Nothing) Then
            mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
        End If

        mp4HWSettingsDialog.SaveSettings(mp4Output)
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
    Private Sub SetWMAOutput(ByRef wmaOutput As WMAOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoEdit1)
        End If

        wmvSettingsDialog.WMA = True
        wmvSettingsDialog.SaveSettings(wmaOutput)
    End Sub

    Private Sub SetWMVOutput(ByRef wmvOutput As WMVOutput)
        If (wmvSettingsDialog Is Nothing) Then
            wmvSettingsDialog = New WMVSettingsDialog(VideoEdit1)
        End If

        wmvSettingsDialog.WMA = False
        wmvSettingsDialog.SaveSettings(wmvOutput)
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
            pcmSettingsDialog = New PCMSettingsDialog(VideoEdit1.Audio_Codecs.ToArray())
        End If

        pcmSettingsDialog.SaveSettings(acmOutput)
    End Sub

    Private Sub SetCustomOutput(ByRef customOutput As CustomOutput)
        If (customFormatSettingsDialog Is Nothing) Then
            customFormatSettingsDialog = New CustomFormatSettingsDialog(
                VideoEdit1.Video_Codecs.ToArray(),
                VideoEdit1.Audio_Codecs.ToArray(),
                VideoEdit1.DirectShow_Filters.ToArray())
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
                VideoEdit1.Video_Codecs.ToArray(),
                VideoEdit1.Audio_Codecs.ToArray())
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
                VideoEdit1.Video_Codecs.ToArray(),
                    VideoEdit1.Audio_Codecs.ToArray())
        End If

        aviSettingsDialog.SaveSettings(mkvOutput)

        If (mkvOutput.Audio_UseMP3Encoder) Then
            Dim mp3Output = New MP3Output()
            SetMP3Output(mp3Output)
            mkvOutput.MP3 = mp3Output
        End If
    End Sub


    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        VideoEdit1.Debug_Mode = cbDebugMode.Checked
        VideoEdit1.Debug_Telemetry = cbTelemetry.Checked

        zoom = 1.0
        zoomShiftX = 0
        zoomShiftY = 0

        mmLog.Clear()

        If (rbConvert.Checked) Then
            VideoEdit1.Mode = VideoEditMode.Convert
        Else
            VideoEdit1.Mode = VideoEditMode.Preview
        End If

        VideoEdit1.Video_Resize = cbResize.Checked

        If (VideoEdit1.Video_Resize) Then

            VideoEdit1.Video_Resize_Width = Convert.ToInt32(edWidth.Text)
            VideoEdit1.Video_Resize_Height = Convert.ToInt32(edHeight.Text)

        End If

        If (cbCrop.Checked) Then
            VideoEdit1.Video_Crop = New VideoCropSettings(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text))
        Else
            VideoEdit1.Video_Crop = Nothing
        End If

        If (cbSubtitlesEnabled.Checked) Then
            VideoEdit1.Video_Subtitles = New SubtitlesSettings(edSubtitlesFilename.Text)
        Else
            VideoEdit1.Video_Subtitles = Nothing
        End If

        VideoEdit1.Video_FrameRate = New VideoFrameRate(Convert.ToDouble(cbFrameRate.Text))

        ConfigureVideoRenderer()

        ' Network streaming
        VideoEdit1.Network_Streaming_Enabled = cbNetworkStreaming.Checked

        If VideoEdit1.Network_Streaming_Enabled Then

            Select Case (cbNetworkStreamingMode.SelectedIndex)

                Case 0
                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.WMV

                    If (rbNetworkStreamingUseMainWMVSettings.Checked) Then

                        Dim wmvOutput As WMVOutput = New WMVOutput()
                        SetWMVOutput(wmvOutput)
                        VideoEdit1.Network_Streaming_Output = wmvOutput

                    Else

                        Dim wmvOutput As WMVOutput = New WMVOutput()
                        wmvOutput.Mode = WMVMode.ExternalProfile
                        wmvOutput.External_Profile_FileName = edNetworkStreamingWMVProfile.Text
                        VideoEdit1.Network_Streaming_Output = wmvOutput

                    End If

                    VideoEdit1.Network_Streaming_WMV_Maximum_Clients = Convert.ToInt32(edMaximumClients.Text)
                    VideoEdit1.Network_Streaming_Network_Port = Convert.ToInt32(edWMVNetworkPort.Text)

                Case 1

                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW
                    VideoEdit1.Network_Streaming_URL = edNetworkRTSPURL.Text

                Case 2

                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.RTMP_FFMPEG_EXE

                    Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                    If (rbNetworkUDPFFMPEG.Checked) Then

                        ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)

                    Else

                        SetFFMPEGEXEOutput(ffmpegOutput)

                    End If

                    ffmpegOutput.OutputMuxer = OutputMuxer.FLV

                    VideoEdit1.Network_Streaming_Output = ffmpegOutput
                    VideoEdit1.Network_Streaming_URL = edNetworkRTMPURL.Text
                Case 3
                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.NDI

                    Dim ndiOutput = New NDIOutput(edNDIName.Text)
                    VideoEdit1.Network_Streaming_Output = ndiOutput
                    edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}"
                Case 4
                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.UDP_FFMPEG_EXE

                    Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                    If (rbNetworkUDPFFMPEG.Checked) Then

                        ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)

                    Else

                        SetFFMPEGEXEOutput(ffmpegOutput)

                    End If

                    ffmpegOutput.OutputMuxer = OutputMuxer.MPEGTS
                    VideoEdit1.Network_Streaming_Output = ffmpegOutput

                    VideoEdit1.Network_Streaming_URL = edNetworkUDPURL.Text
                Case 5
                    If (rbNetworkSSSoftware.Checked) Then

                        VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.SSF_H264_AAC_SW

                    Else

                        VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.SSF_FFMPEG_EXE

                        Dim ffmpegOutput As FFMPEGEXEOutput = New FFMPEGEXEOutput()

                        If (rbNetworkSSFFMPEGDefault.Checked) Then

                            ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, True)

                        Else

                            SetFFMPEGEXEOutput(ffmpegOutput)

                        End If

                        ffmpegOutput.OutputMuxer = OutputMuxer.ISMV
                        VideoEdit1.Network_Streaming_Output = ffmpegOutput

                    End If

                    VideoEdit1.Network_Streaming_URL = edNetworkSSURL.Text
                Case 6
                    VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.External
            End Select

            VideoEdit1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.Checked

        End If

        VideoEdit1.Output_Filename = edOutput.Text

        Dim outputFormat = VideoEditOutputFormat.AVI
        Select Case cbOutputVideoFormat.SelectedIndex
            Case 0
                outputFormat = VideoEditOutputFormat.AVI

                Dim aviOutput = New AVIOutput()
                SetAVIOutput(aviOutput)
                VideoEdit1.Output_Format = aviOutput
            Case 1
                outputFormat = VideoEditOutputFormat.MKVv1

                Dim mkvOutput = New MKVv1Output()
                SetMKVOutput(mkvOutput)
                VideoEdit1.Output_Format = mkvOutput
            Case 2
                outputFormat = VideoEditOutputFormat.WMV

                Dim wmvOutput As WMVOutput = New WMVOutput
                SetWMVOutput(wmvOutput)
                VideoEdit1.Output_Format = wmvOutput
            Case 3
                outputFormat = VideoEditOutputFormat.DV

                Dim dvOutput = New DVOutput()
                SetDVOutput(dvOutput)
                VideoEdit1.Output_Format = dvOutput
            Case 4
                outputFormat = VideoEditOutputFormat.PCM_ACM

                Dim acmOutput = New ACMOutput()
                SetACMOutput(acmOutput)
                VideoEdit1.Output_Format = acmOutput
            Case 5
                outputFormat = VideoEditOutputFormat.MP3

                Dim mp3Output = New MP3Output()
                SetMP3Output(mp3Output)
                VideoEdit1.Output_Format = mp3Output
            Case 6
                outputFormat = VideoEditOutputFormat.M4A

                Dim m4aOutput = New M4AOutput()
                SetM4AOutput(m4aOutput)
                VideoEdit1.Output_Format = m4aOutput
            Case 7
                outputFormat = VideoEditOutputFormat.WMA

                Dim wmaOutput As WMAOutput = New WMAOutput()
                SetWMAOutput(wmaOutput)
                VideoEdit1.Output_Format = wmaOutput
            Case 8
                outputFormat = VideoEditOutputFormat.OggVorbis

                Dim oggVorbisOutput = New OGGVorbisOutput()
                SetOGGOutput(oggVorbisOutput)
                VideoEdit1.Output_Format = oggVorbisOutput
            Case 9
                outputFormat = VideoEditOutputFormat.FLAC

                Dim flacOutput = New FLACOutput()
                SetFLACOutput(flacOutput)
                VideoEdit1.Output_Format = flacOutput
            Case 10
                outputFormat = VideoEditOutputFormat.Speex

                Dim speexOutput = New SpeexOutput()
                SetSpeexOutput(speexOutput)
                VideoEdit1.Output_Format = speexOutput
            Case 11
                outputFormat = VideoEditOutputFormat.Custom

                Dim customOutput = New CustomOutput()
                SetCustomOutput(customOutput)
                VideoEdit1.Output_Format = customOutput
            Case 12
                outputFormat = VideoEditOutputFormat.WebM

                Dim webmOutput = New WebMOutput()
                SetWebMOutput(webmOutput)
                VideoEdit1.Output_Format = webmOutput
            Case 13
                outputFormat = VideoEditOutputFormat.FFMPEG

                Dim ffmpegOutput = New FFMPEGOutput()
                SetFFMPEGOutput(ffmpegOutput)
                VideoEdit1.Output_Format = ffmpegOutput
            Case 14
                outputFormat = VideoEditOutputFormat.FFMPEG_EXE

                Dim ffmpegOutput = New FFMPEGEXEOutput()
                SetFFMPEGEXEOutput(ffmpegOutput)
                VideoEdit1.Output_Format = ffmpegOutput
            Case 15
                outputFormat = VideoEditOutputFormat.MP4
            Case 16
                outputFormat = VideoEditOutputFormat.MP4_HW

                Dim mp4Output = New MP4HWOutput()
                SetMP4HWOutput(mp4Output)
                VideoEdit1.Output_Format = mp4Output
            Case 17
                outputFormat = VideoEditOutputFormat.AnimatedGIF

                Dim gifOutput = New AnimatedGIFOutput()
                SetGIFOutput(gifOutput)
                VideoEdit1.Output_Format = gifOutput
            Case 18
                outputFormat = VideoEditOutputFormat.Encrypted
        End Select

        If ((outputFormat = VideoEditOutputFormat.MP4) Or
            ((outputFormat = VideoEditOutputFormat.Encrypted) And (rbEncryptedH264SW.Checked)) Or
                    (VideoEdit1.Network_Streaming_Enabled And (VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW))) Then

            Dim mp4Output As MP4Output = New MP4Output()
            SetMP4Output(mp4Output)

            ' encryption
            If (outputFormat = VideoEditOutputFormat.Encrypted) Then

                mp4Output.Encryption = True
                mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC

                If (rbEncryptionKeyString.Checked) Then

                    mp4Output.Encryption_KeyType = EncryptionKeyType.String
                    mp4Output.Encryption_Key = edEncryptionKeyString.Text

                ElseIf (rbEncryptionKeyFile.Checked) Then

                    mp4Output.Encryption_KeyType = EncryptionKeyType.File
                    mp4Output.Encryption_Key = edEncryptionKeyFile.Text

                Else

                    mp4Output.Encryption_KeyType = EncryptionKeyType.Binary
                    mp4Output.Encryption_Key = VideoEdit1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text)

                End If

                If (rbEncryptionModeAES128.Checked) Then
                    mp4Output.Encryption_Mode = EncryptionMode.V8_AES128
                Else
                    mp4Output.Encryption_Mode = EncryptionMode.V9_AES256
                End If
            End If

            VideoEdit1.Output_Format = mp4Output
        End If

        VideoEdit1.Audio_Preview_Enabled = True

        ' Audio enhancement
        VideoEdit1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.Checked
        If (VideoEdit1.Audio_Enhancer_Enabled) Then

            Await VideoEdit1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.Checked)
            Await VideoEdit1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.Checked)

            Await ApplyAudioInputGainsAsync()
            Await ApplyAudioOutputGainsAsync()

            Await VideoEdit1.Audio_Enhancer_TimeshiftAsync(-1, tbAudioTimeshift.Value)

        End If

        ' VU meter
        ConfigureVUMeter()

        ' Audio channels mapping
        If (cbAudioChannelMapperEnabled.Checked) Then
            VideoEdit1.Audio_Channel_Mapper = New AudioChannelMapperSettings()
            VideoEdit1.Audio_Channel_Mapper.Routes = audioChannelMapperItems.ToArray()
            VideoEdit1.Audio_Channel_Mapper.OutputChannelsCount = Convert.ToInt32(edAudioChannelMapperOutputChannels.Text)
        Else
            VideoEdit1.Audio_Channel_Mapper = Nothing
        End If

        'Audio processing
        VideoEdit1.Audio_Effects_Clear(-1)
        VideoEdit1.Audio_Effects_Enabled = cbAudioEffectsEnabled.Checked
        If (VideoEdit1.Audio_Effects_Enabled) Then

            VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)
            VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero)

            tbAudAmplifyAmp_Scroll(sender, e)
            tbAudDynAmp_Scroll(sender, e)
            tbAudAttack_Scroll(sender, e)
            tbAudRelease_Scroll(sender, e)
            tbAud3DSound_Scroll(sender, e)
            tbAudTrueBass_Scroll(sender, e)

            tbAudEq0_Scroll(sender, e)
            tbAudEq1_Scroll(sender, e)
            tbAudEq2_Scroll(sender, e)
            tbAudEq3_Scroll(sender, e)
            tbAudEq4_Scroll(sender, e)
            tbAudEq5_Scroll(sender, e)
            tbAudEq6_Scroll(sender, e)
            tbAudEq7_Scroll(sender, e)
            tbAudEq8_Scroll(sender, e)
            tbAudEq9_Scroll(sender, e)

        End If

        ' Virtual camera output
        VideoEdit1.Virtual_Camera_Output_Enabled = cbVirtualCamera.Checked

        ' Video effects CPU
        AddVideoEffects()

        ' Video effects GPU
        VideoEdit1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.Checked

        ' chroma key
        ConfigureChromaKey()

        'motion detection
        ConfigureMotionDetection()

        ' Barcode detection
        VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked
        VideoEdit1.Barcode_Reader_Type = cbBarcodeType.SelectedIndex

        ' Decklink output
        ConfigureDecklink()

        ' Object tracking 
        ConfigureObjectTracking()

        ' video rotation
        Select Case cbRotate.SelectedIndex
            Case 0
                VideoEdit1.Video_Rotation = RotateMode.RotateNone
            Case 1
                VideoEdit1.Video_Rotation = RotateMode.Rotate90
            Case 2
                VideoEdit1.Video_Rotation = RotateMode.Rotate180
            Case 3
                VideoEdit1.Video_Rotation = RotateMode.Rotate270
        End Select

        ' tags
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

            VideoEdit1.Tags = tags

        End If

        Await VideoEdit1.StartAsync()

        lbTransitions.Items.Clear()

        edNetworkURL.Text = VideoEdit1.Network_Streaming_URL

    End Sub

    Private Sub AddVideoEffects()
        VideoEdit1.Video_Effects_Enabled = cbEffects.Checked

        'Deinterlace
        If cbDeinterlace.Checked Then

            If rbDeintBlendEnabled.Checked Then
                Dim blend As IVideoEffectDeinterlaceBlend
                Dim effect = VideoEdit1.Video_Effects_Get("DeinterlaceBlend")
                If (IsNothing(effect)) Then
                    blend = New VideoEffectDeinterlaceBlend(True)
                    VideoEdit1.Video_Effects_Add(blend)
                Else
                    blend = effect
                End If

                If (IsNothing(blend)) Then

                    MessageBox.Show(Me, "Unable to configure deinterlace blend effect.")
                    Return
                End If

                blend.Threshold1 = Convert.ToInt32(edDeintBlendThreshold1.Text)
                blend.Threshold2 = Convert.ToInt32(edDeintBlendThreshold2.Text)
                blend.Constants1 = Convert.ToInt32(edDeintBlendConstants1.Text) / 10.0
                blend.Constants2 = Convert.ToInt32(edDeintBlendConstants2.Text) / 10.0
            ElseIf (rbDeintCAVTEnabled.Checked) Then
                Dim cavt As IVideoEffectDeinterlaceCAVT
                Dim effect = VideoEdit1.Video_Effects_Get("DeinterlaceCAVT")
                If (IsNothing(effect)) Then
                    cavt = New VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.Checked, Convert.ToInt32(edDeintCAVTThreshold.Text))
                    VideoEdit1.Video_Effects_Add(cavt)
                Else
                    cavt = effect
                End If

                If (IsNothing(cavt)) Then
                    MessageBox.Show(Me, "Unable to configure deinterlace CAVT effect.")
                    Return
                End If

                cavt.Threshold = Convert.ToInt32(edDeintCAVTThreshold.Text)
            Else
                Dim triangle As IVideoEffectDeinterlaceTriangle
                Dim effect = VideoEdit1.Video_Effects_Get("DeinterlaceTriangle")
                If (IsNothing(effect)) Then
                    triangle = New VideoEffectDeinterlaceTriangle(True, Convert.ToByte(edDeintTriangleWeight.Text))
                    VideoEdit1.Video_Effects_Add(triangle)
                Else
                    triangle = effect
                End If

                If (IsNothing(triangle)) Then
                    MessageBox.Show(Me, "Unable to configure deinterlace triangle effect.")
                    Return
                End If

                triangle.Weight = Convert.ToByte(edDeintTriangleWeight.Text)
            End If

        End If

        'Denoise
        If cbDenoise.Checked And VideoEdit1.Mode Then

            If (rbDenoiseCAST.Checked) Then
                Dim cast As IVideoEffectDenoiseCAST
                Dim effect = VideoEdit1.Video_Effects_Get("DenoiseCAST")
                If (IsNothing(effect)) Then
                    cast = New VideoEffectDenoiseCAST(True)
                    VideoEdit1.Video_Effects_Add(cast)
                Else
                    cast = effect
                End If

                If (IsNothing(cast)) Then
                    MessageBox.Show(Me, "Unable to configure denoise CAST effect.")
                    Return
                End If
            Else
                Dim mosquito As IVideoEffectDenoiseMosquito
                Dim effect = VideoEdit1.Video_Effects_Get("DenoiseMosquito")
                If (IsNothing(effect)) Then
                    mosquito = New VideoEffectDenoiseMosquito(True)
                    VideoEdit1.Video_Effects_Add(mosquito)
                Else
                    mosquito = effect
                End If

                If (IsNothing(mosquito)) Then
                    MessageBox.Show(Me, "Unable to configure denoise mosquito effect.")
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

        If cbVideoFadeInOut.Checked Then
            cbFadeInOut_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Async Sub btStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStop.Click

        Await VideoEdit1.StopAsync()

        lbFiles.Items.Clear()
        VideoEdit1.Input_Clear_List()

        ProgressBar1.Value = 0

        'clear VU Meters
        Dim data(19) As Int32

        peakMeterCtrl1.SetData(data, 0, 19)
        peakMeterCtrl1.Stop()
        waveformPainter1.Clear()
        waveformPainter2.Clear()

        volumeMeter1.Clear()
        volumeMeter2.Clear()

        VideoEdit1.Video_Effects_Clear()
        lbImageLogos.Items.Clear()
        lbTextLogos.Items.Clear()

    End Sub

    Private Sub btAddTransition_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAddTransition.Click

        Dim id As Integer

        'get id
        id = VideoEdit1.Video_Transition_GetIDFromName(cbTransitionName.Text)

        'add transition
        VideoEdit1.Video_Transition_Add(TimeSpan.FromMilliseconds(Convert.ToInt64(edTransStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt64(edTransStopTime.Text)), id)

        'add to list
        lbTransitions.Items.Add(cbTransitionName.Text + "(Start: " + edTransStartTime.Text + ", stop: " + edTransStopTime.Text + ")")

    End Sub

    Private Sub cbGreyscale_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbGreyscale.CheckedChanged

        Dim intf As IVideoEffectGrayscale
        Dim effect = VideoEdit1.Video_Effects_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New VideoEffectGrayscale(cbGreyscale.Checked)
            VideoEdit1.Video_Effects_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGreyscale.Checked
            End If
        End If

    End Sub

    Private Sub cbInvert_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbInvert.CheckedChanged

        Dim invert As IVideoEffectInvert
        Dim effect = VideoEdit1.Video_Effects_Get("Invert")
        If (IsNothing(effect)) Then
            invert = New VideoEffectInvert(cbInvert.Checked)
            VideoEdit1.Video_Effects_Add(invert)
        Else
            invert = effect
            If (invert IsNot Nothing) Then
                invert.Enabled = cbInvert.Checked
            End If
        End If

    End Sub

    Private Async Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Await VideoEdit1.StopAsync()
        DestroyEngine()
    End Sub

    Private Sub tbDarkness_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbDarkness.Scroll

        Dim darkness As IVideoEffectDarkness
        Dim effect = VideoEdit1.Video_Effects_Get("Darkness")
        If (IsNothing(effect)) Then
            darkness = New VideoEffectDarkness(True, tbDarkness.Value)
            VideoEdit1.Video_Effects_Add(darkness)
        Else
            darkness = effect
            If (darkness IsNot Nothing) Then
                darkness.Value = tbDarkness.Value
            End If
        End If

    End Sub

    Private Sub tbLightness_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbLightness.Scroll

        Dim lightness As IVideoEffectLightness
        Dim effect = VideoEdit1.Video_Effects_Get("Lightness")
        If (IsNothing(effect)) Then
            lightness = New VideoEffectLightness(True, tbLightness.Value)
            VideoEdit1.Video_Effects_Add(lightness)
        Else
            lightness = effect
            If (lightness IsNot Nothing) Then
                lightness.Value = tbLightness.Value
            End If
        End If

    End Sub

    Private Sub tbSaturation_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbSaturation.Scroll

        Dim saturation As IVideoEffectSaturation
        Dim effect = VideoEdit1.Video_Effects_Get("Saturation")
        If (IsNothing(effect)) Then
            saturation = New VideoEffectSaturation(tbSaturation.Value)
            VideoEdit1.Video_Effects_Add(saturation)
        Else

            saturation = effect
            If (saturation IsNot Nothing) Then
                saturation.Value = tbSaturation.Value
            End If
        End If

    End Sub

    Private Sub tbContrast_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbContrast.Scroll

        Dim contrast As IVideoEffectContrast
        Dim effect = VideoEdit1.Video_Effects_Get("Contrast")
        If (IsNothing(effect)) Then
            contrast = New VideoEffectContrast(True, tbContrast.Value)
            VideoEdit1.Video_Effects_Add(contrast)
        Else
            contrast = effect
            If (contrast IsNot Nothing) Then
                contrast.Value = tbContrast.Value
            End If
        End If

    End Sub

    Private Sub cbFilters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbFilters.SelectedIndexChanged

        If (cbFilters.SelectedIndex <> -1) Then

            Dim sName As String = cbFilters.Text
            btFilterSettings.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))

        End If

    End Sub

    Private Sub btFilterAdd_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btFilterAdd.Click

        If (cbFilters.SelectedIndex <> -1) Then

            VideoEdit1.Video_Filters_Add(New CustomProcessingFilter(cbFilters.Text))
            lbFilters.Items.Add(cbFilters.Text)

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

        If (lbFilters.SelectedIndex <> -1) Then

            Dim sName As String = lbFilters.Text
            btFilterSettings2.Enabled = (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.Default)) Or (FilterDialogHelper.DirectShow_Filter_HasDialog(sName, PropertyPageType.CompressorConfig))

        End If

    End Sub

    Private Sub btFilterSettings2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btFilterSettings2.Click

        If (lbFilters.SelectedIndex <> -1) Then

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
        VideoEdit1.Video_Filters_Clear()

    End Sub


    Private Sub cbAudAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudAmplifyEnabled.CheckedChanged

        VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked)

    End Sub

    Private Sub tbAudAmplifyAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAmplifyAmp.Scroll

        VideoEdit1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, False)

    End Sub

    Private Sub cbAudEqualizerEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudEqualizerEnabled.CheckedChanged

        VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked)

    End Sub

    Private Sub tbAudEq0_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq0.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, tbAudEq0.Value)

    End Sub

    Private Sub tbAudEq1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq1.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, tbAudEq1.Value)

    End Sub

    Private Sub tbAudEq2_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq2.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, tbAudEq2.Value)

    End Sub

    Private Sub tbAudEq3_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq3.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, tbAudEq3.Value)

    End Sub

    Private Sub tbAudEq4_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq4.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, tbAudEq4.Value)

    End Sub

    Private Sub tbAudEq5_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq5.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, tbAudEq5.Value)

    End Sub

    Private Sub tbAudEq6_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq6.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, tbAudEq6.Value)

    End Sub

    Private Sub tbAudEq7_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq7.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, tbAudEq7.Value)

    End Sub

    Private Sub tbAudEq8_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq8.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, tbAudEq8.Value)

    End Sub

    Private Sub tbAudEq9_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudEq9.Scroll

        VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, tbAudEq9.Value)

    End Sub

    Private Sub cbAudEqualizerPreset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudEqualizerPreset.SelectedIndexChanged

        VideoEdit1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerPreset.SelectedIndex)
        btAudEqRefresh_Click(sender, e)

    End Sub

    Private Sub btAudEqRefresh_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAudEqRefresh.Click

        tbAudEq0.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0)
        tbAudEq1.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1)
        tbAudEq2.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2)
        tbAudEq3.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3)
        tbAudEq4.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4)
        tbAudEq5.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5)
        tbAudEq6.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6)
        tbAudEq7.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7)
        tbAudEq8.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8)
        tbAudEq9.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9)

    End Sub

    Private Sub cbAudDynamicAmplifyEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudDynamicAmplifyEnabled.CheckedChanged

        VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked)

    End Sub

    Private Sub tbAudDynAmp_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudDynAmp.Scroll

        VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudAttack_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudAttack.Scroll

        VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub tbAudRelease_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudRelease.Scroll

        VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value)

    End Sub

    Private Sub cbAudSound3DEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudSound3DEnabled.CheckedChanged

        VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked)

    End Sub

    Private Sub tbAud3DSound_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAud3DSound.Scroll

        VideoEdit1.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, tbAud3DSound.Value)

    End Sub

    Private Sub cbAudTrueBassEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbAudTrueBassEnabled.CheckedChanged

        VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked)

    End Sub

    Private Sub tbAudTrueBass_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbAudTrueBass.Scroll

        VideoEdit1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, False, tbAudTrueBass.Value)

    End Sub

    Private Sub rbVR_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles rbVMR9.CheckedChanged, rbNone.CheckedChanged, rbEVR.CheckedChanged, rbDirect2D.CheckedChanged

        cbScreenFlipVertical.Enabled = rbVMR9.Checked Or rbDirect2D.Checked
        cbScreenFlipHorizontal.Enabled = rbVMR9.Checked Or rbDirect2D.Checked

        If Tag = 1 Then

            If (rbVMR9.Checked) Then
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9
            ElseIf (rbEVR.Checked) Then
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR
            ElseIf (rbDirect2D.Checked) Then
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D
            Else
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.None
            End If

        End If

    End Sub

    Private Async Sub cbStretch_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbStretch.CheckedChanged

        If (cbStretch.Checked) Then
            VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch
        Else
            VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox
        End If

        Await VideoEdit1.Video_Renderer_UpdateAsync()

    End Sub

    Private Async Sub cbScreenFlipVertical_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbScreenFlipVertical.CheckedChanged

        VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked
        Await VideoEdit1.Video_Renderer_UpdateAsync()

    End Sub

    Private Async Sub cbScreenFlipHorizontal_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbScreenFlipHorizontal.CheckedChanged

        VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked
        Await VideoEdit1.Video_Renderer_UpdateAsync()

    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub tbSpeed_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbSpeed.Scroll

        lbSpeed.Text = Convert.ToInt32(tbSpeed.Value) + "%"

    End Sub

    Private Sub tbSeeking_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbSeeking.Scroll

        VideoEdit1.Position_Set(TimeSpan.FromMilliseconds(tbSeeking.Value))

    End Sub

    Private Sub VideoEdit1_OnStart(ByVal sender As Object, ByVal e As EventArgs) Handles VideoEdit1.OnStart
        Invoke(Sub()
                   tbSeeking.Maximum = VideoEdit1.Duration().TotalMilliseconds
               End Sub)
    End Sub

    Private Sub VideoEdit1_OnProgress(ByVal sender As Object, ByVal e As ProgressEventArgs) Handles VideoEdit1.OnProgress
        Invoke(Sub()
                   ProgressBar1.Value = e.Progress
               End Sub)
    End Sub

    Private Sub VideoEdit1_OnError(ByVal sender As Object, ByVal e As ErrorsEventArgs) Handles VideoEdit1.OnError
        Invoke(Sub()
                   mmLog.Text = mmLog.Text + e.Message + Environment.NewLine
               End Sub)
    End Sub

    Private Sub ConfigureMotionDetection()
        If (cbMotDetEnabled.Checked) Then
            VideoEdit1.Motion_Detection = New MotionDetectionSettings()
            VideoEdit1.Motion_Detection.Enabled = cbMotDetEnabled.Checked
            VideoEdit1.Motion_Detection.Compare_Red = cbCompareRed.Checked
            VideoEdit1.Motion_Detection.Compare_Green = cbCompareGreen.Checked
            VideoEdit1.Motion_Detection.Compare_Blue = cbCompareBlue.Checked
            VideoEdit1.Motion_Detection.Compare_Greyscale = cbCompareGreyscale.Checked
            VideoEdit1.Motion_Detection.Highlight_Color = cbMotDetHLColor.SelectedIndex
            VideoEdit1.Motion_Detection.Highlight_Enabled = cbMotDetHLEnabled.Checked
            VideoEdit1.Motion_Detection.Highlight_Threshold = tbMotDetHLThreshold.Value
            VideoEdit1.Motion_Detection.FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text)
            VideoEdit1.Motion_Detection.Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text)
            VideoEdit1.Motion_Detection.Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text)
            VideoEdit1.Motion_Detection.DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked
            VideoEdit1.Motion_Detection.DropFrames_Threshold = tbMotDetDropFramesThreshold.Value
            VideoEdit1.MotionDetection_Update()
        Else
            VideoEdit1.Motion_Detection = Nothing
        End If
    End Sub

    Private Sub btMotDetUpdateSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMotDetUpdateSettings.Click
        ConfigureMotionDetection()
    End Sub

    Private Delegate Sub MotionDelegate(ByVal e As MotionDetectionEventArgs)

    Private Sub MotionDelegateMethod(ByVal e As MotionDetectionEventArgs)

        Dim s As String = String.Empty

        Dim k As Integer
        For Each b As Byte In e.Matrix
            s += b.ToString("D3") + " "

            If (k = VideoEdit1.Motion_Detection.Matrix_Width - 1) Then
                k = 0
                s += Environment.NewLine
            Else
                k += 1
            End If
        Next

        mmMotDetMatrix.Text = s.Trim()
        pbMotionLevel.Value = e.Level

    End Sub

    Private Sub MediaPlayer1_OnMotion(ByVal sender As Object, ByVal e As MotionDetectionEventArgs) Handles VideoEdit1.OnMotionDetection

        Dim motdel As MotionDelegate = New MotionDelegate(AddressOf MotionDelegateMethod)
        BeginInvoke(motdel, e)

    End Sub

    Private Sub cbAFMotionDetection_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAFMotionDetection.CheckedChanged

        ConfigureObjectTracking()

    End Sub

    Private Sub cbAFMotionHighlight_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAFMotionHighlight.CheckedChanged

        ConfigureObjectTracking()

    End Sub

    Private Sub VideoEdit1_OnObjectDetection(ByVal sender As Object, ByVal e As MotionDetectionExEventArgs) Handles VideoEdit1.OnMotionDetectionEx

        Dim motdel As AFMotionDelegate = New AFMotionDelegate(AddressOf AFMotionDelegateMethod)
        BeginInvoke(motdel, e.Level)

    End Sub

    Private Delegate Sub AFMotionDelegate(ByVal level As Single)

    Private Sub AFMotionDelegateMethod(ByVal level As Single)

        pbAFMotionLevel.Value = level * 100

    End Sub

    Private Sub cbZoom_CheckedChanged(sender As Object, e As EventArgs) Handles cbZoom.CheckedChanged

        Dim zoomEffect As IVideoEffectZoom
        Dim effect = VideoEdit1.Video_Effects_Get("Zoom")
        If (IsNothing(effect)) Then
            zoomEffect = New VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoom.Checked)
            VideoEdit1.Video_Effects_Add(zoomEffect)
        Else
            zoomEffect = effect
        End If

        If (IsNothing(zoomEffect)) Then
            MessageBox.Show(Me, "Unable to configure zoom effect.")
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

    Private Sub btEffZoomDown_Click(sender As Object, e As EventArgs) Handles btEffZoomDown.Click

        zoomShiftY += 20

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

    Private Sub btEffZoomUp_Click(sender As Object, e As EventArgs) Handles btEffZoomUp.Click

        zoomShiftY += 20

        cbZoom_CheckedChanged(Nothing, Nothing)

    End Sub

    Private Sub cbPan_CheckedChanged(sender As Object, e As EventArgs) Handles cbPan.CheckedChanged

        Dim pan As IVideoEffectPan
        Dim effect = VideoEdit1.Video_Effects_Get("Pan")
        If (IsNothing(effect)) Then
            pan = New VideoEffectPan(True)
            VideoEdit1.Video_Effects_Add(pan)
        Else
            pan = effect
        End If

        If (IsNothing(pan)) Then
            MessageBox.Show(Me, "Unable to configure pan effect.")
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
        VideoEdit1.Barcode_Reader_Enabled = True

    End Sub

    Private Sub VideoEdit1_OnBarcodeDetected(sender As Object, e As BarcodeEventArgs) Handles VideoEdit1.OnBarcodeDetected

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

    Private Sub btRefreshClients_Click(sender As Object, e As EventArgs) Handles btRefreshClients.Click

        Dim dns1 As String = "", address As String = ""

        Dim port As Integer = 0

        lbNetworkClients.Items.Clear()

        For i As Integer = 0 To VideoEdit1.Network_Streaming_WMV_Clients_GetCount - 1

            VideoEdit1.Network_Streaming_WMV_Clients_GetInfo(i, port, address, dns1)

            Dim client As String = "ID: " + i + ", Port: " + port + ", Address: " + address + ", DNS: " + dns1
            lbNetworkClients.Items.Add(client)

        Next i

    End Sub

    Private Sub btSelectWMVProfileNetwork_Click(sender As Object, e As EventArgs) Handles btSelectWMVProfileNetwork.Click

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Sub cbFadeInOut_CheckedChanged(sender As Object, e As EventArgs) Handles cbVideoFadeInOut.CheckedChanged

        If (rbVideoFadeIn.Checked) Then
            Dim fadeIn As IVideoEffectFadeIn
            Dim effect = VideoEdit1.Video_Effects_Get("FadeIn")
            If (IsNothing(effect)) Then
                fadeIn = New VideoEffectFadeIn(cbVideoFadeInOut.Checked)
                VideoEdit1.Video_Effects_Add(fadeIn)
            Else
                fadeIn = effect
            End If

            If (IsNothing(fadeIn)) Then
                MessageBox.Show(Me, "Unable to configure fade-in effect.")
                Return
            End If

            fadeIn.Enabled = cbVideoFadeInOut.Checked
            fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStartTime.Text))
            fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStopTime.Text))
        Else
            Dim fadeOut As IVideoEffectFadeOut
            Dim effect = VideoEdit1.Video_Effects_Get("FadeOut")
            If (IsNothing(effect)) Then
                fadeOut = New VideoEffectFadeOut(cbVideoFadeInOut.Checked)
                VideoEdit1.Video_Effects_Add(fadeOut)
            Else
                fadeOut = effect
            End If

            If (IsNothing(fadeOut)) Then
                MessageBox.Show(Me, "Unable to configure fade-out effect.")
                Return
            End If

            fadeOut.Enabled = cbVideoFadeInOut.Checked
            fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStartTime.Text))
            fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStopTime.Text))
        End If

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer)
        Process.Start(startInfo)

    End Sub

#Region "Full screen"

    Private fullScreen As Boolean

    Private windowLeft As Integer

    Private windowTop As Integer

    Private windowWidth As Integer

    Private windowHeight As Integer

    Private controlLeft As Integer

    Private controlTop As Integer

    Private controlWidth As Integer

    Private controlHeight As Integer

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

            Await VideoEdit1.Video_Renderer_UpdateAsync()

        Else
            ' going normal screen
            fullScreen = False

            ' restoring window
            Left = windowLeft
            Top = windowTop
            Width = windowWidth
            Height = windowHeight

            TopMost = False
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Normal

            ' restoring control
            VideoView1.Left = controlLeft
            VideoView1.Top = controlTop
            VideoView1.Width = controlWidth
            VideoView1.Height = controlHeight

            Await VideoEdit1.Video_Renderer_UpdateAsync()

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

    Private Async Sub pnVideoRendererBGColor_Click(sender As Object, e As EventArgs) Handles pnVideoRendererBGColor.Click

        colorDialog1.Color = pnVideoRendererBGColor.BackColor

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            pnVideoRendererBGColor.BackColor = colorDialog1.Color
            VideoEdit1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor
            Await VideoEdit1.Video_Renderer_UpdateAsync()
        End If

    End Sub

    Private Async Sub cbDirect2DRotate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDirect2DRotate.SelectedIndexChanged

        VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text)
        Await VideoEdit1.Video_Renderer_UpdateAsync()

    End Sub

    Private Async Sub cbAudioNormalize_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioNormalize.CheckedChanged

        Await VideoEdit1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.Checked)

    End Sub

    Private Async Sub cbAudioAutoGain_CheckedChanged(sender As Object, e As EventArgs) Handles cbAudioAutoGain.CheckedChanged

        Await VideoEdit1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.Checked)

    End Sub

    Private Async Function ApplyAudioInputGainsAsync() As Task
        Dim gains As AudioEnhancerGains = New AudioEnhancerGains()
        gains.L = tbAudioInputGainL.Value / 10.0F
        gains.C = tbAudioInputGainC.Value / 10.0F
        gains.R = tbAudioInputGainR.Value / 10.0F
        gains.SL = tbAudioInputGainSL.Value / 10.0F
        gains.SR = tbAudioInputGainSR.Value / 10.0F
        gains.LFE = tbAudioInputGainLFE.Value / 10.0F

        Await VideoEdit1.Audio_Enhancer_InputGainsAsync(-1, gains)
    End Function

    Private Async Function ApplyAudioOutputGainsAsync() As Task
        Dim gains As AudioEnhancerGains = New AudioEnhancerGains
        gains.L = tbAudioOutputGainL.Value / 10.0F
        gains.C = tbAudioOutputGainC.Value / 10.0F
        gains.R = tbAudioOutputGainR.Value / 10.0F
        gains.SL = tbAudioOutputGainSL.Value / 10.0F
        gains.SR = tbAudioOutputGainSR.Value / 10.0F
        gains.LFE = tbAudioOutputGainLFE.Value / 10.0F

        Await VideoEdit1.Audio_Enhancer_OutputGainsAsync(-1, gains)
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

        Await VideoEdit1.Audio_Enhancer_TimeshiftAsync(-1, tbAudioTimeshift.Value)

    End Sub

    Private Delegate Sub FFMPEGInfoDelegate(ByVal message As String)

    Private Sub FFMPEGInfoDelegateMethod(ByVal message As String)

        mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine

    End Sub

    Private Sub VideoEdit1_OnFFMPEGInfo(sender As Object, e As FFMPEGInfoEventArgs) Handles VideoEdit1.OnFFMPEGInfo

        Dim del As FFMPEGInfoDelegate = New FFMPEGInfoDelegate(AddressOf FFMPEGInfoDelegateMethod)
        BeginInvoke(del, e)

    End Sub

    Private Sub btEncryptionOpenFile_Click(sender As Object, e As EventArgs) Handles btEncryptionOpenFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then

            edEncryptionKeyFile.Text = openFileDialog1.FileName

        End If

    End Sub

    Private Sub btAddInputFile2_Click(sender As Object, e As EventArgs) Handles btAddInputFile2.Click

        If (OpenDialog1.ShowDialog() = DialogResult.OK) Then

            Dim s = OpenDialog1.FileName

            edSourceFileToCut.Text = s

            Dim extNew = Path.GetExtension(s).ToLowerInvariant()
            Dim extOld = Path.GetExtension(edOutputFileCut.Text).ToLowerInvariant()
            edOutputFileCut.Text = edOutputFileCut.Text.Replace(extOld, extNew)

        End If

    End Sub

    Private Sub btSelectOutputCut_Click(sender As Object, e As EventArgs) Handles btSelectOutputCut.Click

        If (SaveDialog1.ShowDialog() = DialogResult.OK) Then

            edOutputFileCut.Text = SaveDialog1.FileName

        End If

    End Sub

    Private Sub btSelectOutputJoin_Click(sender As Object, e As EventArgs) Handles btSelectOutputJoin.Click

        If (SaveDialog1.ShowDialog() = DialogResult.OK) Then

            edOutputFileJoin.Text = SaveDialog1.FileName

        End If

    End Sub

    Private Async Sub btStartCut_Click(sender As Object, e As EventArgs) Handles btStartCut.Click

        Await VideoEdit1.FastEdit_CutFileAsync(
                edSourceFileToCut.Text,
                 TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTimeCut.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTimeCut.Text)),
                edOutputFileCut.Text)

    End Sub

    Private Async Sub btStartJoin_Click(sender As Object, e As EventArgs) Handles btStartJoin.Click

        Dim files = New List(Of String)

        For Each item As Object In files
            files.Add(item.ToString())
        Next

        Await VideoEdit1.FastEdit_JoinFilesAsync(
                files.ToArray(),
                edOutputFileCut.Text)

    End Sub

    Private Async Sub btStopJoin_Click(sender As Object, e As EventArgs) Handles btStopJoin.Click

        Await VideoEdit1.FastEdit_StopAsync()

    End Sub

    Private Async Sub btStopCut_Click(sender As Object, e As EventArgs) Handles btStopCut.Click

        Await VideoEdit1.FastEdit_StopAsync()

    End Sub

    Private Sub btClearList3_Click(sender As Object, e As EventArgs) Handles btClearList3.Click

        lbFiles2.Items.Clear()

    End Sub

    Private Sub imgTagCover_Click(sender As Object, e As EventArgs) Handles imgTagCover.Click

        If (openFileDialog2.ShowDialog() = DialogResult.OK) Then

            imgTagCover.LoadAsync(openFileDialog2.FileName)
            imgTagCover.Tag = openFileDialog2.FileName

        End If

    End Sub

    Private Sub btMuxStreamsSelectFile_Click(sender As Object, e As EventArgs) Handles btMuxStreamsSelectFile.Click

        If (OpenDialog1.ShowDialog() = DialogResult.OK) Then

            edMuxStreamsSourceFile.Text = OpenDialog1.FileName

        End If

    End Sub

    Private Sub btMuxStreamsAdd_Click(sender As Object, e As EventArgs) Handles btMuxStreamsAdd.Click

        Dim prefix
        If (cbMuxStreamsType.SelectedIndex = 0) Then

            prefix = "v"

        ElseIf (cbMuxStreamsType.SelectedIndex = 1) Then

            prefix = "a"

        Else

            prefix = cbMuxStreamsType.Text

        End If

        lbMuxStreamsList.Items.Add(prefix + ": " + edMuxStreamsSourceFile.Text)

    End Sub

    Private Async Sub btStartMux_Click(sender As Object, e As EventArgs) Handles btStartMux.Click

        Dim streams As List(Of FFMPEGStream) = New List(Of FFMPEGStream)

        For Each item As String In lbMuxStreamsList.Items

            Dim prefix = item.Substring(0, 1)
            Dim filename = item.Substring(3)

            Dim stream = New FFMPEGStream()
            stream.Filename = filename
            stream.ID = prefix

            streams.Add(stream)

        Next

        Await VideoEdit1.FastEdit_MuxStreamsAsync(streams, cbMuxStreamsShortest.Checked, edMuxStreamsOutputFile.Text)

    End Sub

    Private Sub btMuxStreamsClear_Click(sender As Object, e As EventArgs) Handles btMuxStreamsClear.Click

        lbMuxStreamsList.Items.Clear()

    End Sub

    Private Sub btMuxStreamsSelectOutput_Click(sender As Object, e As EventArgs) Handles btMuxStreamsSelectOutput.Click

        If (SaveDialog1.ShowDialog() = DialogResult.OK) Then

            edMuxStreamsOutputFile.Text = SaveDialog1.FileName

        End If

    End Sub

    Private Async Sub btStopMux_Click(sender As Object, e As EventArgs) Handles btStopMux.Click

        Await VideoEdit1.FastEdit_StopAsync()

    End Sub

    Private Sub cbDebugMode_CheckedChanged(sender As Object, e As EventArgs) Handles cbDebugMode.CheckedChanged

        VideoEdit1.Debug_Mode = cbDebugMode.Checked

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

    Private Sub linkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel11.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube)
        Process.Start(startInfo)

    End Sub

    Private Sub btSubtitlesSelectFile_Click(sender As Object, e As EventArgs) Handles btSubtitlesSelectFile.Click

        If (openFileDialogSubtitles.ShowDialog() = DialogResult.OK) Then
            edSubtitlesFilename.Text = openFileDialogSubtitles.FileName
        End If

    End Sub

    Private Sub tbGPULightness_Scroll(sender As Object, e As EventArgs) Handles tbGPULightness.Scroll

        Dim intf As IGPUVideoEffectBrightness
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Brightness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectBrightness(True, tbGPULightness.Value)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Saturation")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectSaturation(True, tbGPUSaturation.Value)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Contrast")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectContrast(True, tbGPUContrast.Value)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Darkness")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDarkness(True, tbGPUDarkness.Value)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Grayscale")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectGrayscale(cbGPUGreyscale.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Invert")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectInvert(cbGPUInvert.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("NightVision")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectNightVision(cbGPUNightVision.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Pixelate")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectPixelate(cbGPUPixelate.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Denoise")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDenoise(cbGPUDenoise.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("DeinterlaceBlend")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
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
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("OldMovie")
        If (IsNothing(effect)) Then
            intf = New GPUVideoEffectOldMovie(cbGPUOldMovie.Checked)
            VideoEdit1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (Not IsNothing(intf)) Then
                intf.Enabled = cbGPUOldMovie.Checked
                intf.Update()
            End If
        End If

    End Sub

    Private Delegate Sub VUDelegate(ByVal e As VUMeterEventArgs)

    Private Sub VUDelegateMethod(ByVal e As VUMeterEventArgs)
        If (VideoEdit1.State = PlaybackState.Free) Then
            Return
        End If

        peakMeterCtrl1.SetData(e.MeterData, 0, 19)
    End Sub

    Private Sub VideoEdit1_OnAudioVUMeter(sender As Object, e As VUMeterEventArgs) Handles VideoEdit1.OnAudioVUMeter
        Invoke(New VUDelegate(AddressOf VUDelegateMethod), e)
    End Sub

    Private Sub VideoEdit1_OnAudioVUMeterProVolume(sender As Object, e As AudioLevelEventArgs) Handles VideoEdit1.OnAudioVUMeterProVolume
        Invoke(Sub()
                   volumeMeter1.Amplitude = e.ChannelLevelsDb(0)
                   waveformPainter1.AddMax(e.ChannelLevels(0) / 100.0F)

                   If (e.ChannelLevelsDb.Length > 1) Then
                       volumeMeter2.Amplitude = e.ChannelLevelsDb(1)
                       waveformPainter2.AddMax(e.ChannelLevels(1) / 100.0F)
                   End If
               End Sub)
    End Sub

    Private Sub btConfigure_Click(sender As Object, e As EventArgs) Handles btConfigure.Click
        Select Case (cbOutputVideoFormat.SelectedIndex)
            Case 0
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 1
                If (aviSettingsDialog Is Nothing) Then
                    aviSettingsDialog = New AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray())
                End If

                aviSettingsDialog.ShowDialog(Me)
            Case 2
                If (wmvSettingsDialog Is Nothing) Then
                    wmvSettingsDialog = New WMVSettingsDialog(VideoEdit1)
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
                    pcmSettingsDialog = New PCMSettingsDialog(VideoEdit1.Audio_Codecs.ToArray())
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
                    wmvSettingsDialog = New WMVSettingsDialog(VideoEdit1)
                End If

                wmvSettingsDialog.WMA = True
                wmvSettingsDialog.ShowDialog(Me)
            Case 8
                If (oggVorbisSettingsDialog Is Nothing) Then
                    oggVorbisSettingsDialog = New OggVorbisSettingsDialog()
                End If

                oggVorbisSettingsDialog.ShowDialog(Me)
            Case 9
                If (flacSettingsDialog Is Nothing) Then
                    flacSettingsDialog = New FLACSettingsDialog()
                End If

                flacSettingsDialog.ShowDialog(Me)
            Case 10
                If (speexSettingsDialog Is Nothing) Then
                    speexSettingsDialog = New SpeexSettingsDialog()
                End If

                speexSettingsDialog.ShowDialog(Me)
            Case 11
                If (customFormatSettingsDialog Is Nothing) Then
                    customFormatSettingsDialog = New CustomFormatSettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray(), VideoEdit1.DirectShow_Filters.ToArray())
                End If

                customFormatSettingsDialog.ShowDialog(Me)
            Case 12
                If (webmSettingsDialog Is Nothing) Then
                    webmSettingsDialog = New WebMSettingsDialog()
                End If

                webmSettingsDialog.ShowDialog(Me)
            Case 13
                If (ffmpegSettingsDialog Is Nothing) Then
                    ffmpegSettingsDialog = New FFMPEGSettingsDialog()
                End If

                ffmpegSettingsDialog.ShowDialog(Me)
            Case 14
                If (ffmpegEXESettingsDialog Is Nothing) Then
                    ffmpegEXESettingsDialog = New FFMPEGEXESettingsDialog()
                End If

                ffmpegEXESettingsDialog.ShowDialog(Me)
            Case 15
                If (mp4SettingsDialog Is Nothing) Then
                    mp4SettingsDialog = New MP4SettingsDialog()
                End If

                mp4SettingsDialog.ShowDialog(Me)
            Case 16
                If (mp4HWSettingsDialog Is Nothing) Then
                    mp4HWSettingsDialog = New HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4)
                End If

                mp4HWSettingsDialog.ShowDialog(Me)
            Case 17
                If (gifSettingsDialog Is Nothing) Then
                    gifSettingsDialog = New GIFSettingsDialog()
                End If

                gifSettingsDialog.ShowDialog(Me)
            Case 18
                If (mp4SettingsDialog Is Nothing) Then
                    mp4SettingsDialog = New MP4SettingsDialog()
                End If

                mp4SettingsDialog.ShowDialog(Me)
        End Select
    End Sub

    Private Sub cbOutputVideoFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutputVideoFormat.SelectedIndexChanged
        Select Case (cbOutputVideoFormat.SelectedIndex)
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
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 9
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac")
            Case 10
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg")
            Case 11
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 12
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm")
            Case 13
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 14
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi")
            Case 15
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 16
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4")
            Case 17
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif")
            Case 18
                edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc")
        End Select
    End Sub

    Private Sub cbFlipX_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipX.CheckedChanged
        Dim flip As IVideoEffectFlipDown
        Dim effect = VideoEdit1.Video_Effects_Get("FlipDown")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipHorizontal(cbFlipX.Checked)
            VideoEdit1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipX.Checked
            End If
        End If
    End Sub

    Private Sub cbFlipY_CheckedChanged(sender As Object, e As EventArgs) Handles cbFlipY.CheckedChanged
        Dim flip As IVideoEffectFlipRight
        Dim effect = VideoEdit1.Video_Effects_Get("FlipRight")
        If (effect Is Nothing) Then
            flip = New VideoEffectFlipVertical(cbFlipY.Checked)
            VideoEdit1.Video_Effects_Add(flip)
        Else
            flip = effect
            If (flip IsNot Nothing) Then
                flip.Enabled = cbFlipY.Checked
            End If
        End If
    End Sub

    Private Sub btImageLogoRemove_Click(sender As Object, e As EventArgs) Handles btImageLogoRemove.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            VideoEdit1.Video_Effects_Remove(lbImageLogos.SelectedItem)
            lbImageLogos.Items.Remove(lbImageLogos.SelectedItem)
        End If
    End Sub

    Private Sub btImageLogoEdit_Click(sender As Object, e As EventArgs) Handles btImageLogoEdit.Click
        If (lbImageLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New ImageLogoSettingsDialog()
            Dim effect = VideoEdit1.Video_Effects_Get(lbImageLogos.SelectedItem)

            dlg.Attach(effect)
            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btImageLogoAdd_Click(sender As Object, e As EventArgs) Handles btImageLogoAdd.Click
        Dim dlg = New ImageLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoEdit1)
        Dim effect = New VideoEffectImageLogo(True, effectName)

        VideoEdit1.Video_Effects_Add(effect)
        lbImageLogos.Items.Add(effect.Name)

        dlg.Fill(effect)
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btTextLogoEdit_Click(sender As Object, e As EventArgs) Handles btTextLogoEdit.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            Dim dlg = New TextLogoSettingsDialog()
            Dim effect = VideoEdit1.Video_Effects_Get(lbTextLogos.SelectedItem)
            dlg.Attach(effect)

            dlg.ShowDialog(Me)
            dlg.Dispose()
        End If
    End Sub

    Private Sub btTextLogoRemove_Click(sender As Object, e As EventArgs) Handles btTextLogoRemove.Click
        If (lbTextLogos.SelectedItem IsNot Nothing) Then
            VideoEdit1.Video_Effects_Remove(lbTextLogos.SelectedItem)
            lbTextLogos.Items.Remove(lbTextLogos.SelectedItem)
        End If
    End Sub

    Private Sub btTextLogoAdd_Click(sender As Object, e As EventArgs) Handles btTextLogoAdd.Click
        Dim dlg = New TextLogoSettingsDialog()

        Dim effectName = dlg.GenerateNewEffectName(VideoEdit1)
        Dim effect = New VideoEffectTextLogo(True, effectName)

        VideoEdit1.Video_Effects_Add(effect)
        lbTextLogos.Items.Add(effect.Name)
        dlg.Fill(effect)

        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub tbGPUBlur_Scroll(sender As Object, e As EventArgs) Handles tbGPUBlur.Scroll
        Dim intf As IGPUVideoEffectBlur
        Dim effect = VideoEdit1.Video_Effects_GPU_Get("Blur")
        If (effect Is Nothing) Then
            intf = New GPUVideoEffectBlur(tbGPUBlur.Value > 0, tbGPUBlur.Value)
            VideoEdit1.Video_Effects_GPU_Add(intf)
        Else
            intf = effect
            If (intf IsNot Nothing) Then
                intf.Enabled = tbGPUBlur.Value > 0
                intf.Value = tbGPUBlur.Value
                intf.Update()
            End If
        End If
    End Sub

    Private Sub ConfigureChromaKey()
        If (Not IsNothing(VideoEdit1.ChromaKey)) Then
            VideoEdit1.ChromaKey.Dispose()
            VideoEdit1.ChromaKey = Nothing
        End If

        If (cbChromaKeyEnabled.Checked) Then
            If (Not File.Exists(edChromaKeyImage.Text)) Then
                MessageBox.Show(Me, "Chroma-key background file doesn't exists.")
                Return
            End If

            VideoEdit1.ChromaKey = New ChromaKeySettings(New Bitmap(edChromaKeyImage.Text))
            VideoEdit1.ChromaKey.Smoothing = tbChromaKeySmoothing.Value / 1000.0F
            VideoEdit1.ChromaKey.ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000.0F
            VideoEdit1.ChromaKey.Color = pnChromaKeyColor.BackColor
        Else

            VideoEdit1.ChromaKey = Nothing
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

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor)
        Process.Start(startInfo)
    End Sub

    Private Sub llXiphX64_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llXiphX64.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64)
        Process.Start(startInfo)
    End Sub

    Private Sub llXiphX86_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llXiphX86.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86)
        Process.Start(startInfo)
    End Sub

    Private Sub llDecoders_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llDecoders.LinkClicked
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistLAVx64)
        Process.Start(startInfo)
    End Sub
End Class

' ReSharper restore InconsistentNaming