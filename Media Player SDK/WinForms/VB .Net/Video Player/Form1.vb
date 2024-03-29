' ReSharper disable InconsistentNaming

Imports System.IO
Imports System.Threading.Tasks
Imports VisioForge.Core.MediaPlayer
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.MediaPlayer
Imports VisioForge.Core.UI

Public Class Form1
    Private WithEvents MediaPlayer1 As MediaPlayerCore

    Private Sub CreateEngine()
        MediaPlayer1 = New MediaPlayerCore(VideoView1)
    End Sub

    Private Sub DestroyEngine()
        MediaPlayer1.Dispose()
        MediaPlayer1 = Nothing
    End Sub

    Private Sub btSelectFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectFile.Click
        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilename.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Async Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll
        If (Convert.ToInt32(timer1.Tag) = 0) Then
            Await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        End If
    End Sub

    Private Async Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSpeed.Scroll
        Await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0)
    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmError.Clear()

        MediaPlayer1.Playlist_Clear()
        MediaPlayer1.Playlist_Add(edFilename.Text)

        MediaPlayer1.Loop = cbLoop.Checked
        MediaPlayer1.Audio_PlayAudio = True
        MediaPlayer1.Info_UseLibMediaInfo = True

        Select Case (cbSourceMode.SelectedIndex)
            Case 0
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV
            Case 1
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS
            Case 2
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.FFMPEG
            Case 3
                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_VLC
        End Select

        MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device"

        MediaPlayer1.Video_Renderer_SetAuto()

        MediaPlayer1.Debug_Mode = cbDebugMode.Checked

        Await MediaPlayer1.PlayAsync()

        'set audio volume for each stream
        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)
        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

        timer1.Enabled = True

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

    End Sub

    Private Sub btNextFrame_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btNextFrame.Click

        MediaPlayer1.NextFrame()

    End Sub

    Private Sub tbBalance1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance1.Scroll

        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)

    End Sub

    Private Sub tbVolume1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume1.Scroll

        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

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

    Private Sub MediaPlayer1_OnStop(ByVal sender As System.Object, ByVal e As EventArgs) Handles MediaPlayer1.OnStop

        Invoke(Sub()
                   tbTimeline.Value = 0
               End Sub)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()

        Text += $" (SDK v{MediaPlayer1.SDK_Version})"
        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        cbSourceMode.SelectedIndex = 0

    End Sub

    Private Sub linkLabel1_LinkClicked(sender As System.Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub MediaPlayer1_OnError(sender As System.Object, e As ErrorsEventArgs) Handles MediaPlayer1.OnError

        Invoke(Sub()
                   mmError.Text = mmError.Text + e.Message + Environment.NewLine
               End Sub)

    End Sub

    Private Sub btPreviousFrame_Click(sender As Object, e As EventArgs) Handles btPreviousFrame.Click
        MediaPlayer1.PreviousFrame()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btStop_Click(Nothing, Nothing)

        DestroyEngine()
    End Sub

    Private Sub linkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI)
        Process.Start(startInfo)
    End Sub

    Private Sub linkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) 
        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI)
        Process.Start(startInfo)
    End Sub
End Class

' ReSharper restore InconsistentNaming