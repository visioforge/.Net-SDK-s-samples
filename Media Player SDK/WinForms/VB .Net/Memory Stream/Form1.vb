' ReSharper disable InconsistentNaming

Imports System.IO
Imports System.Runtime.InteropServices
Imports VisioForge.Core.UI
Imports VisioForge.Core
Imports VisioForge.Core.Types
Imports VisioForge.Core.MediaPlayer
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.MediaPlayer
Imports VisioForge.Core.DirectShow.Helpers
Imports VisioForge.Core.MediaInfo
Imports System.Threading.Tasks

Public Class Form1
    Private _stream As ManagedIStream

    Private _fileStream As FileStream

    Private _memoryStream As MemoryStream

    Private _memorySource() As Byte

    Private WithEvents MediaPlayer1 As MediaPlayerCore

        ''' <summary>
        ''' Create engine.
        ''' </summary>
    Private Sub CreateEngine()
        MediaPlayer1 = New MediaPlayerCore(VideoView1)
    End Sub

        ''' <summary>
        ''' Destroy engine.
        ''' </summary>
    Private Sub DestroyEngine()
        MediaPlayer1.Dispose()
        MediaPlayer1 = Nothing
    End Sub

    Private Const TbmGetChannelRect As Integer = &H41A
    Private Const TbmGetThumbRect As Integer = &H419

    Private _timelineThumbDrag As Boolean

    Private _timelinePageStep As Boolean

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, ByRef lParam As RECT) As IntPtr
    End Function

    ''' <summary>
    ''' The channel and thumb rectangles of a track bar, in client coordinates.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    ''' <summary>
    ''' Moves the thumb to the clicked point.
    ''' </summary>
    Private Sub ClickToPosition(e As MouseEventArgs)
        Dim thumb As New RECT()
        SendMessage(tbTimeline.Handle, TbmGetThumbRect, IntPtr.Zero, thumb)

        Dim channel As New RECT()
        SendMessage(tbTimeline.Handle, TbmGetChannelRect, IntPtr.Zero, channel)

        ' The thumb centre travels from the channel's left edge to its right edge minus the thumb.
        Dim thumbWidth = thumb.Right - thumb.Left
        ' A track bar narrower than its thumb has no travel to map the click onto.
        If channel.Right - channel.Left - thumbWidth <= 0 Then
            Return
        End If

        Dim value = tbTimeline.Minimum + CInt(Math.Round((e.X - (channel.Left + thumbWidth / 2.0)) * (tbTimeline.Maximum - tbTimeline.Minimum) / (channel.Right - channel.Left - thumbWidth)))
        tbTimeline.Value = Math.Max(tbTimeline.Minimum, Math.Min(tbTimeline.Maximum, value))
    End Sub

    ''' <summary>
    ''' A click on the track seeks to the clicked point; a press on the thumb is a drag.
    ''' </summary>
    Private Async Sub tbTimeline_MouseDown(sender As Object, e As MouseEventArgs) Handles tbTimeline.MouseDown
        If (e.Button <> MouseButtons.Left OrElse tbTimeline.Maximum <= tbTimeline.Minimum) Then
            Return
        End If

        ' A page step means the native control took the press on the channel: a click.
        If (Not _timelinePageStep) Then
            Dim thumb As New RECT()
            SendMessage(tbTimeline.Handle, TbmGetThumbRect, IntPtr.Zero, thumb)

            If (e.X >= thumb.Left AndAlso e.X < thumb.Right) Then
                _timelineThumbDrag = True
                Return
            End If
        End If

        _timelinePageStep = False
        ClickToPosition(e)

        Await SeekToTimelineAsync()
    End Sub

    ''' <summary>
    ''' Ends a thumb drag.
    ''' </summary>
    Private Sub tbTimeline_MouseUp(sender As Object, e As MouseEventArgs) Handles tbTimeline.MouseUp
        _timelinePageStep = False
        _timelineThumbDrag = False
    End Sub

    Private Async Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll
        ' The page step of a click arrives before MouseDown, which reads it to tell a click from a thumb press.
        If (MouseButtons = MouseButtons.Left AndAlso Not _timelineThumbDrag) Then
            _timelinePageStep = True
            Return
        End If

        Await SeekToTimelineAsync()
    End Sub

    ''' <summary>
    ''' Seeks to the timeline value.
    ''' </summary>
    Private Async Function SeekToTimelineAsync() As Task
        Try
            Await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Function

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmError.Text = String.Empty

        If (Not System.IO.File.Exists(edFilename.Text)) Then
            MessageBox.Show(Me, "Please select a video file.")
            Return
        End If

        Dim audioPresent As Boolean
        Dim videoPresent As Boolean

        If (rbSTreamTypeFile.Checked) Then
            _fileStream = New FileStream(edFilename.Text, FileMode.Open)
            _stream = New ManagedIStream(_fileStream)

            MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _fileStream.Length, videoPresent, audioPresent)
            MediaPlayer1.Source_MemoryStream = New MemoryStreamSource(_stream, videoPresent, audioPresent, _fileStream.Length)
        Else
            _memorySource = File.ReadAllBytes(edFilename.Text)
            _memoryStream = New MemoryStream(_memorySource)
            _stream = New ManagedIStream(_memoryStream)

            MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _memoryStream.Length, videoPresent, audioPresent)
            MediaPlayer1.Source_MemoryStream = New MemoryStreamSource(_stream, videoPresent, audioPresent, _memoryStream.Length)
        End If

        MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS

        If (audioPresent) Then
            MediaPlayer1.Audio_PlayAudio = True
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device"
        Else
            MediaPlayer1.Audio_PlayAudio = False
        End If

        If (videoPresent) Then
            MediaPlayer1.Video_Renderer_SetAuto()
        Else
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None
        End If

        MediaPlayer1.Debug_Mode = cbDebugMode.Checked
        Await MediaPlayer1.PlayAsync()

        tbTimeline.Maximum = (Await MediaPlayer1.Duration_TimeAsync()).TotalSeconds
        timer1.Enabled = True
    End Sub

        ''' <summary>
        ''' Form 1 load.
        ''' </summary>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()

        Text += $" (SDK v{MediaPlayer1.SDK_Version})"
        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

    End Sub

    Private Async Sub btResume_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btResume.Click

        Await MediaPlayer1.ResumeAsync()

    End Sub

    Private Async Sub btPause_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btPause.Click

        Await MediaPlayer1.PauseAsync()

    End Sub

    Private Async Sub btStop_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStop.Click

        Await MediaPlayer1.StopAsync()

        timer1.Enabled = False
        tbTimeline.Value = 0
        lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

        _fileStream?.Dispose()
        _fileStream = Nothing

        _memoryStream?.Dispose()
        _memoryStream = Nothing

        _memorySource = Nothing
        _stream = Nothing

    End Sub

        ''' <summary>
        ''' Bt next frame click.
        ''' </summary>
    Private Sub btNextFrame_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btNextFrame.Click

        MediaPlayer1.NextFrame()

    End Sub

    Private Async Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSpeed.Scroll

        Await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0)

    End Sub

        ''' <summary>
        ''' Tb volume 1 scroll.
        ''' </summary>
    Private Sub tbVolume1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume1.Scroll

        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

    End Sub

        ''' <summary>
        ''' Tb balance 1 scroll.
        ''' </summary>
    Private Sub tbBalance1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance1.Scroll

        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)

    End Sub

    Private Async Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Leave the timeline alone while the user holds it: a range change recreates its handle and ends the drag.
        If tbTimeline.Capture Then
            Return
        End If

        tbTimeline.Maximum = (Await MediaPlayer1.Duration_TimeAsync()).TotalSeconds

        Dim value As Integer = (Await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds

        ' Playback has stopped: keep the reset label.
        If Not timer1.Enabled Then
            Return
        End If

        If ((value > 0) And (value < tbTimeline.Maximum)) Then
            tbTimeline.Value = value
        End If

        lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

    End Sub

        ''' <summary>
        ''' Media player 1 on error.
        ''' </summary>
    Private Sub MediaPlayer1_OnError(sender As System.Object, e As ErrorsEventArgs) Handles MediaPlayer1.OnError

        Invoke(Sub()
                   mmError.Text = mmError.Text + e.Message + Environment.NewLine
               End Sub)

    End Sub

        ''' <summary>
        ''' Link label 1 link clicked.
        ''' </summary>
    Private Sub linkLabel1_LinkClicked(sender As System.Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

        ''' <summary>
        ''' Form 1 form closing.
        ''' </summary>
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btStop_Click(Nothing, Nothing)

        DestroyEngine()
    End Sub

        ''' <summary>
        ''' Bt select file click.
        ''' </summary>
    Private Sub btSelectFile_Click(sender As Object, e As EventArgs) Handles btSelectFile.Click
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilename.Text = openFileDialog1.FileName
        End If
    End Sub
End Class

' ReSharper restore InconsistentNaming