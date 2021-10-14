' ReSharper disable InconsistentNaming

Imports VisioForge.Controls.MediaPlayer
Imports VisioForge.Controls.UI
Imports VisioForge.Types
Imports VisioForge.Controls.UI.WinForms
Imports System.IO

Public Class Form1

    Dim WithEvents MediaPlayer1 As MediaPlayerCore

    Private Sub btSelectFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilename.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll

        If (Convert.ToInt32(timer1.Tag) = 0) Then
            MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value))
        End If

    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmError.Clear()

        MediaPlayer1.FilenamesOrURL.Add(edFilename.Text)
        MediaPlayer1.Audio_PlayAudio = True
        MediaPlayer1.Info_UseLibMediaInfo = True

        MediaPlayer1.Source_Mode = VFMediaPlayerSource.File_DS
        MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device"

        MediaPlayer1.Video_Renderer.VideoRendererInternal = VFVideoRendererInternal.None

        MediaPlayer1.Debug_Mode = cbDebugMode.Checked

        Await MediaPlayer1.PlayAsync()

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

    Private Sub tbVolume1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume1.Scroll

        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

    End Sub

    Private Sub tbBalance1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance1.Scroll

        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        MediaPlayer1 = New MediaPlayerCore()

        Text += $" (SDK v{MediaPlayer1.SDK_Version})"
        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer1.Tick

        timer1.Tag = 1
        tbTimeline.Maximum = MediaPlayer1.Duration_Time().TotalSeconds

        Dim value As Integer = MediaPlayer1.Position_Get_Time().TotalSeconds
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

    Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub MediaPlayer1_OnError(sender As Object, e As ErrorsEventArgs) Handles MediaPlayer1.OnError

        Invoke(Sub()
                   mmError.Text = mmError.Text + e.Message + Environment.NewLine
               End Sub)

    End Sub

    Private Sub MediaPlayer1_OnLicenseRequired(sender As Object, e As LicenseEventArgs) Handles MediaPlayer1.OnLicenseRequired

        Invoke(Sub()
                   If cbLicensing.Checked Then
                       mmError.Text = mmError.Text + "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine
                   End If
               End Sub)

    End Sub

    Private Sub MediaPlayer1_OnStop(sender As Object, e As MediaPlayerStopEventArgs) Handles MediaPlayer1.OnStop

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btStop_Click(Nothing, Nothing)
    End Sub
End Class

' ReSharper restore InconsistentNaming