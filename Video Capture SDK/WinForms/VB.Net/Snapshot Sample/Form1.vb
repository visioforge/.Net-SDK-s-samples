' Simple Snapshot Sample - Video Capture SDK .Net

Imports System.Linq
Imports System.Threading.Tasks
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.VideoCapture
Imports VisioForge.Core.VideoCapture

Public Class Form1
    Private WithEvents VideoCapture1 As VideoCaptureCore

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Async Function CreateEngineAsync() As Task(Of VideoCaptureCore)
        VideoCapture1 = Await VideoCaptureCore.CreateAsync(VideoView1)
        Return VideoCapture1
    End Function

    Private Sub DestroyEngine()
        VideoCapture1.Dispose()
        VideoCapture1 = Nothing
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

            ' Try to select 1280x720 as default resolution
            Dim defaultFormatIndex As Integer = -1
            For i As Integer = 0 To cbVideoInputFormat.Items.Count - 1
                Dim formatName = cbVideoInputFormat.Items(i).ToString()
                If formatName.Contains("1280x720") Then
                    defaultFormatIndex = i
                    Exit For
                End If
            Next

            If defaultFormatIndex >= 0 Then
                cbVideoInputFormat.SelectedIndex = defaultFormatIndex
            ElseIf cbVideoInputFormat.Items.Count > 0 Then
                cbVideoInputFormat.SelectedIndex = 0
            End If

            cbVideoInputFormat_SelectedIndexChanged(Nothing, Nothing)
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
                cbVideoInputFrameRate.Items.Add(frameRate.ToString(Globalization.CultureInfo.CurrentCulture))
            Next

            ' Try to select 25 fps as default
            Dim defaultFpsIndex As Integer = -1
            For i As Integer = 0 To cbVideoInputFrameRate.Items.Count - 1
                Dim fpsText = cbVideoInputFrameRate.Items(i).ToString()
                If fpsText = "25" OrElse fpsText.StartsWith("25.") Then
                    defaultFpsIndex = i
                    Exit For
                End If
            Next

            If defaultFpsIndex >= 0 Then
                cbVideoInputFrameRate.SelectedIndex = defaultFpsIndex
            ElseIf (cbVideoInputFrameRate.Items.Count > 0) Then
                cbVideoInputFrameRate.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Async Sub btStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStart.Click
        ' Validate device selection
        If cbVideoInputDevice.SelectedIndex = -1 Then
            Return
        End If

        ' Enable still frames grabber
        VideoCapture1.Video_Still_Frames_Grabber_Enabled = True

        ' Disable audio
        VideoCapture1.Audio_RecordAudio = False
        VideoCapture1.Audio_PlayAudio = False

        ' Set video renderer
        VideoCapture1.Video_Renderer_SetAuto()

        ' Configure video capture device
        VideoCapture1.Video_CaptureDevice = New VideoCaptureSource(cbVideoInputDevice.Text)
        VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text
        VideoCapture1.Video_CaptureDevice.Format_UseBest = False

        If cbVideoInputFrameRate.SelectedIndex <> -1 Then
            Dim frameRate As Double
            If Double.TryParse(cbVideoInputFrameRate.Text, frameRate) Then
                VideoCapture1.Video_CaptureDevice.FrameRate = New VideoFrameRate(frameRate)
            End If
        End If

        ' Set mode to preview only (no capture)
        VideoCapture1.Mode = VideoCaptureMode.VideoPreview

        Await VideoCapture1.StartAsync()
    End Sub

    Private Async Sub btStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btStop.Click
        Await VideoCapture1.StopAsync()
    End Sub

    Private Sub btSnapshot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSnapshot.Click
        ' Capture current frame and display in PictureBox
        Using capturedImage As Drawing.Bitmap = CType(VideoCapture1.Frame_GetCurrent(), Drawing.Bitmap)
            If capturedImage IsNot Nothing Then
                ' Dispose previous image to avoid memory leaks
                If pbSnapshot.Image IsNot Nothing Then
                    pbSnapshot.Image.Dispose()
                End If
                ' Clone the image since capturedImage will be disposed
                pbSnapshot.Image = CType(capturedImage.Clone(), Drawing.Bitmap)
            End If
        End Using
    End Sub

    Private Async Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Await CreateEngineAsync()

        Text += $" (SDK v{VideoCapture1.SDK_Version})"

        For i As Int32 = 0 To VideoCapture1.Video_CaptureDevices.Count - 1
            cbVideoInputDevice.Items.Add(VideoCapture1.Video_CaptureDevices.Item(i).Name)
        Next

        If cbVideoInputDevice.Items.Count > 0 Then
            cbVideoInputDevice.SelectedIndex = 0
        End If

        cbVideoInputDevice_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Dispose snapshot image
        If pbSnapshot.Image IsNot Nothing Then
            pbSnapshot.Image.Dispose()
            pbSnapshot.Image = Nothing
        End If

        DestroyEngine()
    End Sub
End Class
