' ReSharper disable InconsistentNaming

Imports System.IO
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

    Private Async Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll

        If (Convert.ToInt32(timer1.Tag) = 0) Then
            Await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        End If

    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmError.Text = String.Empty

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

            MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _fileStream.Length, videoPresent, audioPresent)
            MediaPlayer1.Source_MemoryStream = New MemoryStreamSource(_stream, videoPresent, audioPresent, _fileStream.Length)
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

        timer1.Tag = 1
        tbTimeline.Maximum = (Await MediaPlayer1.Duration_TimeAsync()).TotalSeconds

        Dim value As Integer = (Await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds
        If ((value > 0) And (value < tbTimeline.Maximum)) Then
            tbTimeline.Value = value
        End If

        lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

        timer1.Tag = 0

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