' ReSharper disable InconsistentNaming

Imports System.IO
Imports VisioForge.Controls.UI
Imports VisioForge.Types
Imports VisioForge.Controls.UI.WinForms

Public Class Form1


    Public Function GetFileExt(ByVal FileName As String) As String

        Dim k As Integer
        k = FileName.LastIndexOf(".", StringComparison.Ordinal)
        GetFileExt = FileName.Substring(k, FileName.Length - k)

    End Function

    Public Function ChangeFileExt(ByVal FileName As String, ByVal Ext As String) As String

        ChangeFileExt = FileName.Replace(GetFileExt(FileName), Ext)

    End Function

    Private Sub btClearList_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btClearList.Click

        lbFiles.Items.Clear()
        VideoEdit1.Sources_Clear()

    End Sub

    Private Sub btAddInputFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAddInputFile.Click

        If (OpenDialog1.ShowDialog() = DialogResult.OK) Then

            Dim s As String = OpenDialog1.FileName

            lbFiles.Items.Add(s)

            Dim videoDuration As TimeSpan
            Dim audioDuration As TimeSpan
            VideoEdit.GetFileLength(s, videoDuration, audioDuration)

            VideoEdit1.Sources_AddFile(s, videoDuration.TotalMilliseconds > 0, audioDuration.TotalMilliseconds > 0)

        End If

    End Sub

    Private Sub btSelectOutput_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectOutput.Click

        If SaveDialog1.ShowDialog() = DialogResult.OK Then

            edOutput.Text = SaveDialog1.FileName

        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        Text += " (SDK v" + VideoEdit1.SDK_Version.ToString() + ", " + VideoEdit1.SDK_State + ")"

        edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.avi"
        VideoEdit1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\"

        cbFrameRate.SelectedIndex = 7
        cbOutputVideoFormat.SelectedIndex = 1
        cbMotDetHLColor.SelectedIndex = 1
        cbBarcodeType.SelectedIndex = 0

        cbAspectRatio.SelectedIndex = 0
        cbAudioBitrate.SelectedIndex = 8
        cbAudioChannels.SelectedIndex = 1
        cbAudioEncoder.SelectedIndex = 0
        cbVideoEncoder.SelectedIndex = 1
        cbAudioSampleRate.SelectedIndex = 0
        cbContainer.SelectedIndex = 0

        pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128)

    End Sub

    Public Delegate Sub AFProgressDelegate(ByVal progress As Int32)

    Public Sub AFProgressDelegateMethod(ByVal progress As Int32)

        'If (ProgressBar1.Value < progress) Then

        ProgressBar1.Value = progress

        'End If
    End Sub

    Public Delegate Sub MotionDelegate(ByVal e As MotionDetectionEventArgs)

    Public Sub MotionDelegateMethod(ByVal e As MotionDetectionEventArgs)

        Dim s As String = String.Empty
        For Each b As Byte In e.Matrix

            s += b + " "

        Next

        mmMotDetMatrix.Text = s.Trim()
        pbMotionLevel.Value = e.Level

    End Sub

    Private Sub VideoEdit1_OnMotion(sender As Object, e As MotionDetectionEventArgs) Handles VideoEdit1.OnMotion

        BeginInvoke(New MotionDelegate(AddressOf MotionDelegateMethod), e)

    End Sub

    Private Sub VideoEdit1_OnProgress(sender As Object, e As ProgressEventArgs) Handles VideoEdit1.OnProgress

        BeginInvoke(New AFProgressDelegate(AddressOf AFProgressDelegateMethod), e.Progress)

    End Sub

    Public Delegate Sub AFStopDelegate()

    Public Sub AFStopDelegateMethod()

        ProgressBar1.Value = 0
        VideoEdit1.Sources_Clear()
        lbFiles.Items.Clear()

        MessageBox.Show("Complete", String.Empty, MessageBoxButtons.OK)

    End Sub

    Private Sub VideoEdit1_OnStop(ByVal sender As System.Object, ByVal e As EventArgs) Handles VideoEdit1.OnStop

        BeginInvoke(New AFStopDelegate(AddressOf AFStopDelegateMethod))

    End Sub

    Private Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmLog.Clear()

        VideoEdit1.Debug_Mode = cbDebugMode.Checked

        VideoEdit1.Video_Effects_Clear()

        VideoEdit1.Output_Filename = edOutput.Text

        VideoEdit1.Profile = cbOutputVideoFormat.SelectedIndex

        VideoEdit1.Output_Audio_Channels = cbAudioChannels.SelectedIndex
        VideoEdit1.Output_Audio_SampleRate = Convert.ToInt32(cbAudioSampleRate.Text)
        VideoEdit1.Output_Audio_Bitrate = Convert.ToInt32(cbAudioBitrate.Text) * 1000
        VideoEdit1.Output_Audio_Encoder = cbAudioEncoder.SelectedIndex

        VideoEdit1.Output_Video_AspectRatio = cbAspectRatio.SelectedIndex
        VideoEdit1.Output_Video_Bitrate = Convert.ToInt32(edTargetBitrate.Text) * 1000
        VideoEdit1.Output_Video_BufferSize = Convert.ToInt32(edBufferSize.Text) * 1000
        VideoEdit1.Output_Video_Bitrate_Min = Convert.ToInt32(edMinimalBitrate.Text) * 1000
        VideoEdit1.Output_Video_Bitrate_Max = Convert.ToInt32(edMaximalBitrate.Text) * 1000
        VideoEdit1.Output_Video_Encoder = cbVideoEncoder.SelectedIndex
        VideoEdit1.Output_Video_FrameRate = cbFrameRate.SelectedIndex

        VideoEdit1.Output_Muxer = cbContainer.SelectedIndex

        If (cbResize.Checked) Then

            VideoEdit1.Output_Video_Width = Convert.ToInt32(edWidth.Text)
            VideoEdit1.Output_Video_Height = Convert.ToInt32(edHeight.Text)

        Else

            VideoEdit1.Output_Video_Width = 0
            VideoEdit1.Output_Video_Height = 0

        End If

        ' Audio processing
        VideoEdit1.Audio_Effects_Clear()

        If (cbAudAmplifyEnabled.Checked) Then

            VideoEdit1.Audio_Effects_Add_Volume(tbAudAmplifyAmp.Value / 100.0)

        End If

        If (cbAudEchoEnabled.Checked) Then

            VideoEdit1.Audio_Effects_Add_Echo(
                tbAudDelayGainIn.Value / 100.0,
                tbAudDelayGainOut.Value / 100.0,
                tbAudDelay.Value,
                tbAudDelayGainDecay.Value / 100.0)

        End If

        ' Video processing
        VideoEdit1.Video_Effects_Clear()

        If (cbVideoEffects.Checked) Then

            VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Lightness, TimeSpan.Zero, TimeSpan.Zero, tbLightness.Value, 0)
            VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Contrast, TimeSpan.Zero, TimeSpan.Zero, tbContrast.Value, 0)
            VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Saturation, TimeSpan.Zero, TimeSpan.Zero, tbSaturation.Value, 0)

            If (cbInvert.Checked) Then

                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Invert, TimeSpan.Zero, TimeSpan.Zero, 0, 0)


                If (cbGreyscale.Checked) Then

                    VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Greyscale, TimeSpan.Zero, TimeSpan.Zero, 0, 0)

                End If

                If (cbGraphicLogo.Checked) Then

                    If (Not cbGraphicLogoShowAlways.Checked) Then

                        VideoEdit1.Video_Effects_Add_ImageLogo(
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edGraphicLogoStartTime.Text)),
                                                      TimeSpan.FromMilliseconds(Convert.ToInt32(edGraphicLogoStopTime.Text)),
                            edGraphicLogoFilename.Text,
                            Convert.ToInt32(edGraphicLogoLeft.Text),
                            Convert.ToInt32(edGraphicLogoTop.Text))

                    End If
                Else

                    VideoEdit1.Video_Effects_Add_ImageLogo(
                        TimeSpan.Zero,
                        TimeSpan.Zero,
                        edGraphicLogoFilename.Text,
                        Convert.ToInt32(edGraphicLogoLeft.Text),
                        Convert.ToInt32(edGraphicLogoTop.Text))
                End If
            End If

            If (cbTextLogo.Checked) Then

                If (Not cbTextLogoShowAlways.Checked) Then

                    VideoEdit1.Video_Effects_Add_TextLogo(
                        TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStartTime.Text)),
                                                  TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStopTime.Text)),
                        edTextLogoValue.Text,
                        Convert.ToInt32(edTextLogoLeft.Text),
                        Convert.ToInt32(edTextLogoTop.Text),
                        FontDialog1.Font,
                        FontDialog1.Color,
                        Color.Transparent)

                Else

                    VideoEdit1.Video_Effects_Add_TextLogo(
                        TimeSpan.Zero,
                        TimeSpan.Zero,
                        edTextLogoValue.Text,
                        Convert.ToInt32(edTextLogoLeft.Text),
                        Convert.ToInt32(edTextLogoTop.Text),
                        FontDialog1.Font,
                        FontDialog1.Color,
                        Color.Transparent)
                End If
            End If

            If (cbDeinterlace.Checked) Then

                VideoEdit1.Video_Effects_Add_Deinterlace()

            End If

            If (cbDenoise.Checked) Then

                VideoEdit1.Video_Effects_Add_3DDenoise()

            End If
        End If

        If (cbZoom.Checked) Then

            Dim zoom As Double = tbZoom.Value / 10.0
            VideoEdit1.Video_Effects_Add_Zoom(TimeSpan.Zero, TimeSpan.Zero, zoom, zoom, 0, 0)

        End If

        If (cbPan.Checked) Then

            VideoEdit1.Video_Effects_Add_Pan(
                TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStartTime.Text)),
                                          TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStopTime.Text)),
                Convert.ToInt32(edPanSourceLeft.Text),
                Convert.ToInt32(edPanSourceTop.Text),
                Convert.ToInt32(edPanSourceWidth.Text),
                Convert.ToInt32(edPanSourceHeight.Text),
                Convert.ToInt32(edPanDestLeft.Text),
                Convert.ToInt32(edPanDestTop.Text),
                Convert.ToInt32(edPanDestWidth.Text),
                Convert.ToInt32(edPanDestHeight.Text))

        End If

        If cbFadeInOut.Checked Then

            If (rbFadeIn.Checked) Then

                VideoEdit1.Video_Effects_Add_Simple(
                    VFVideoEffectType.FadeIn,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                                              TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                    0,
                    0)

            Else

                VideoEdit1.Video_Effects_Add_Simple(
                    VFVideoEffectType.FadeOut,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                                              TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                    0,
                    0)

            End If

        End If

        ' motion detection
        btMotDetUpdateSettings_Click(sender, e)

        ' Object detection
        ConfigureObjectTracking()

        ' Chroma key
        ConfigureChromaKey()

        ' Barcode detection
        VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked
        VideoEdit1.Barcode_Reader_Type = cbBarcodeType.SelectedIndex

        VideoEdit1.Start()

    End Sub

    Private Sub ConfigureChromaKey()
        If (Not IsNothing(VideoEdit1.ChromaKey)) Then
            VideoEdit1.ChromaKey.Dispose()
            VideoEdit1.ChromaKey = Nothing
        End If

        If (cbChromaKeyEnabled.Checked) Then
            If (Not File.Exists(edChromaKeyImage.Text)) Then
                MessageBox.Show("Chroma-key background file doesn't exists.")
                Return
            End If

            VideoEdit1.ChromaKey = New ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
            VideoEdit1.ChromaKey.Smoothing = tbChromaKeySmoothing.Value / 1000.0F
            VideoEdit1.ChromaKey.ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000.0F
            VideoEdit1.ChromaKey.Color = pnChromaKeyColor.BackColor
        Else

            VideoEdit1.ChromaKey = Nothing
        End If
    End Sub

    Private Sub ConfigureObjectTracking()

        If (cbAFMotionDetection.Checked) Then
            VideoEdit1.Object_Detection = New MotionDetectionExSettings()
            If (cbAFMotionHighlight.Checked) Then
                VideoEdit1.Object_Detection.ProcessorType = MotionProcessorType.MotionAreaHighlighting
            Else
                VideoEdit1.Object_Detection.ProcessorType = MotionProcessorType.None
            End If
        Else
            VideoEdit1.Object_Detection = Nothing
        End If
    End Sub

    Private Sub btStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStop.Click

        VideoEdit1.Stop()
        ProgressBar1.Value = 0

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        VideoEdit1.Stop()

    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub AFErrorDelegateMethod(ByVal e As VisioForge.Types.ErrorsEventArgs)

        mmLog.Text = mmLog.Text + e.Message + Environment.NewLine
    End Sub

    Public Delegate Sub AFErrorDelegate(ByVal e As VisioForge.Types.ErrorsEventArgs)

    Private Sub VideoEdit1_OnError(ByVal sender As System.Object, ByVal e As VisioForge.Types.ErrorsEventArgs) Handles VideoEdit1.OnError

        BeginInvoke(New AFErrorDelegate(AddressOf AFErrorDelegateMethod), e)

    End Sub

    Private Sub btMotDetUpdateSettings_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btMotDetUpdateSettings.Click

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
        Else
            VideoEdit1.Motion_Detection = Nothing
        End If

    End Sub

    Private Sub VideoEdit1_OnAForgeMotionDetection(ByVal sender As System.Object, ByVal e As VisioForge.Types.MotionDetectionExEventArgs) Handles VideoEdit1.OnObjectDetection

        Dim motdel As AFMotionDelegate = New AFMotionDelegate(AddressOf AFMotionDelegateMethod)
        BeginInvoke(motdel, e.Level)

    End Sub

    Public Delegate Sub AFMotionDelegate(ByVal level As System.Single)

    Public Sub AFMotionDelegateMethod(ByVal level As System.Single)

        pbAFMotionLevel.Value = level * 100

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

        For Each o As KeyValuePair(Of VFBarcodeResultMetadataType, Object) In value.Metadata

            edBarcodeMetadata.Text += o.Key.ToString() + ": " + o.Value.ToString() + Environment.NewLine

        Next

    End Sub

    Private Sub btSelectImage_Click1(sender As Object, e As EventArgs) Handles btSelectImage.Click

        If (openFileDialog2.ShowDialog() = DialogResult.OK) Then

            edGraphicLogoFilename.Text = openFileDialog2.FileName

        End If

    End Sub

    Private Sub cbAFMotionDetection_CheckedChanged1(sender As Object, e As EventArgs) Handles cbAFMotionDetection.CheckedChanged

        ConfigureObjectTracking()

    End Sub

    Private Sub cbAFMotionHighlight_CheckedChanged1(sender As Object, e As EventArgs) Handles cbAFMotionHighlight.CheckedChanged

        ConfigureObjectTracking()

    End Sub

    Private Sub btChromaKeySelectBGImage_Click(sender As Object, e As EventArgs) Handles btChromaKeySelectBGImage.Click 
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edChromaKeyImage.Text = openFileDialog1.FileName
            ConfigureChromaKey()
        End If
    End Sub

    Private Sub btFont_Click1(sender As Object, e As EventArgs) Handles btFont.Click

        FontDialog1.ShowDialog()

    End Sub

    Private Sub cbFadeInOut_CheckedChanged(sender As Object, e As EventArgs) Handles cbFadeInOut.CheckedChanged

        If (rbFadeIn.Checked) Then

            VideoEdit1.Video_Effects_Add_Simple(
                VFVideoEffectType.FadeIn,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                                          TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                0,
                0)

        Else

            VideoEdit1.Video_Effects_Add_Simple(
                VFVideoEffectType.FadeOut,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                                          TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                0,
                0)

        End If

    End Sub

    Private Sub VideoEdit1_OnLicenseRequired(sender As Object, e As LicenseEventArgs) Handles VideoEdit1.OnLicenseRequired

        If cbLicensing.Checked Then
            mmLog.Text = mmLog.Text + "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine
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
End Class

' ReSharper restore InconsistentNaming