' ReSharper disable InconsistentNaming

Imports VisioForge.Controls.UI
Imports VisioForge.Types
Imports VisioForge.Controls.UI.WinForms
Imports System.IO

Public Class Form1

    Dim WithEvents form2 As Form2

    Private Sub form2_SizeChanged() Handles form2.OnWindowSizeChanged
        MediaPlayer1.MultiScreen_UpdateSize(0, form2.Screen.Width, form2.Screen.Height)
    End Sub

    Private Sub MediaPlayer1_OnLicenseRequired(sender As Object, e As LicenseEventArgs) Handles MediaPlayer1.OnLicenseRequired
        form2.LogLicensing(e.Message)
    End Sub

    Private Sub btSelectFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSelectFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilename.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Sub tbTimeline_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles tbTimeline.Scroll

        If (Convert.ToInt32(timer1.Tag) = 0) Then
            MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value))
        End If

    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        MediaPlayer1.FilenamesOrURL.Add(edFilename.Text)
        MediaPlayer1.Audio_PlayAudio = True
        MediaPlayer1.Info_UseLibMediaInfo = True
        MediaPlayer1.Source_Mode = VFMediaPlayerSource.LAV

        MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device"

        If (MediaPlayer1.Filter_Supported_EVR()) Then
            MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR
        ElseIf (MediaPlayer1.Filter_Supported_VMR9()) Then
            MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9
        Else
            MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer
        End If

        MediaPlayer1.MultiScreen_Enabled = True
        MediaPlayer1.MultiScreen_Clear()
        MediaPlayer1.MultiScreen_AddScreen(form2.Screen.Handle, form2.Screen.Width, form2.Screen.Height)

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

        form2.Screen.Invalidate()

    End Sub

    Private Sub btNextFrame_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btNextFrame.Click

        MediaPlayer1.NextFrame()

    End Sub

    Private Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSpeed.Scroll

        MediaPlayer1.SetSpeed(tbSpeed.Value / 10.0)

    End Sub

    Private Sub tbVolume1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbVolume1.Scroll

        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

    End Sub

    Private Sub tbBalance1_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbBalance1.Scroll

        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        form2 = New Form2

        form2.Text += " (SDK v" + MediaPlayer1.SDK_Version.ToString() + ", " + MediaPlayer1.SDK_State + ")"

        form2.Show()

    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer1.Tick

        timer1.Tag = 1
        tbTimeline.Maximum = MediaPlayer1.Duration_Time().TotalSeconds

        Dim value As Integer
        value = MediaPlayer1.Position_Get_Time().TotalSeconds
        If ((value > 0) And (value < tbTimeline.Maximum)) Then
            tbTimeline.Value = value
        End If

        lbTime.Text = MediaPlayer.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

        timer1.Tag = 0

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As System.Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

    End Sub

    Private Sub MediaPlayer1_OnError(sender As Object, e As ErrorsEventArgs) Handles MediaPlayer1.OnError

        Invoke(Sub()
                   form2.Log(e.Message)
               End Sub)

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btStop_Click(Nothing, Nothing)
    End Sub
End Class

' ReSharper restore InconsistentNaming