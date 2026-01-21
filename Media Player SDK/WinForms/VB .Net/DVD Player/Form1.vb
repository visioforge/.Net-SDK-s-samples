' ReSharper disable InconsistentNaming

Imports System.IO
Imports System.Threading.Tasks
Imports VisioForge.Core.MediaInfo
Imports VisioForge.Core.MediaPlayer
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.MediaInfo
Imports VisioForge.Core.Types.MediaPlayer
Imports VisioForge.Core.UI

Public Class Form1

    Private ReadOnly MediaInfo As DVDInfoReader = New DVDInfoReader

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

        ''' <summary>
        ''' Bt select file click.
        ''' </summary>
    Private Sub btSelectFile_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btSelectFile.Click

        If (openFileDialog1.ShowDialog() = DialogResult.OK) Then
            edFilename.Text = openFileDialog1.FileName
        End If

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

    Private Async Sub tbTimeline_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbTimeline.Scroll

        If (Convert.ToInt32(timer1.Tag) = 0) Then
            Await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value))
        End If

    End Sub

    Private Async Sub tbSpeed_Scroll(ByVal sender As System.Object, ByVal e As EventArgs) Handles tbSpeed.Scroll

        Await MediaPlayer1.DVD_SetSpeedAsync(tbSpeed.Value / 10.0, False)

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

        ''' <summary>
        ''' Bt next frame click.
        ''' </summary>
    Private Sub btNextFrame_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btNextFrame.Click

        MediaPlayer1.NextFrame()

    End Sub

    Private Async Sub cbDVDControlTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs)

        If (cbDVDControlTitle.SelectedIndex <> -1) Then

            'fill info
            cbDVDControlAudio.Items.Clear()
            cbDVDControlSubtitles.Items.Clear()
            cbDVDControlChapter.Items.Clear()

            Dim title As DVDTitleInfo = MediaInfo.Info.Titles(cbDVDControlTitle.SelectedIndex)

            For i As Integer = 0 To title.NumberOfChapters - 1
                cbDVDControlChapter.Items.Add("Chapter " + Convert.ToString(i + 1))
            Next

            If (cbDVDControlChapter.Items.Count > 0) Then
                cbDVDControlChapter.SelectedIndex = 0
            End If

            For i As Integer = 0 To title.MainAttributes.NumberOfAudioStreams - 1
                Dim audioStream As DVDAudioAttributes = title.MainAttributes.AudioAttributes(0)
                Dim s As String = audioStream.AudioFormat

                s = s + " - "
                s = s + audioStream.NumberOfChannels + "ch" + " - "
                s = s + audioStream.Language

                cbDVDControlAudio.Items.Add(s)
            Next

            If (cbDVDControlAudio.Items.Count > 0) Then
                cbDVDControlAudio.SelectedIndex = 0
            End If

            cbDVDControlSubtitles.Items.Add("Disabled")

            For i As Integer = 0 To title.MainAttributes.NumberOfSubpictureStreams - 1
                cbDVDControlSubtitles.Items.Add(title.MainAttributes.SubpictureAttributes(i).Language)
            Next

            cbDVDControlSubtitles.SelectedIndex = 0

            If (Not IsDBNull(sender)) Then 'if null we just enumerate titles and chapters
                'play title
                Await MediaPlayer1.DVD_Title_PlayAsync(cbDVDControlTitle.SelectedIndex)
                tbTimeline.Maximum = (Await MediaPlayer1.DVD_Title_GetDurationAsync()).TotalSeconds
            End If
        End If

    End Sub

    Private Async Sub cbDVDControlAudio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbDVDControlAudio.SelectedIndexChanged

        If (cbDVDControlAudio.SelectedIndex > 0) Then
            Await MediaPlayer1.DVD_Select_AudioStreamAsync(cbDVDControlAudio.SelectedIndex)
        End If

    End Sub

    Private Async Sub cbDVDControlChapter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbDVDControlChapter.SelectedIndexChanged

        If (cbDVDControlChapter.SelectedIndex > 0) Then
            Await MediaPlayer1.DVD_Chapter_SelectAsync(cbDVDControlChapter.SelectedIndex)
        End If

    End Sub

    Private Async Sub cbDVDControlSubtitles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles cbDVDControlSubtitles.SelectedIndexChanged

        If (cbDVDControlSubtitles.SelectedIndex > 0) Then
            Await MediaPlayer1.DVD_Select_SubpictureStreamAsync(cbDVDControlSubtitles.SelectedIndex - 1)

            ' 0 - x - subtitles
            ' -1 - disable subtitles
        End If

    End Sub

    Private Async Sub btDVDControlTitleMenu_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVDControlTitleMenu.Click

        Await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Title)

    End Sub

    Private Async Sub btDVDControlRootMenu_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDVDControlRootMenu.Click

        Await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Root)

    End Sub

    Private Async Sub btStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btStart.Click

        mmError.Clear()

        MediaPlayer1.Playlist_Clear()
        MediaPlayer1.Playlist_Add(edFilename.Text)
        MediaPlayer1.Loop = cbLoop.Checked
        MediaPlayer1.Audio_PlayAudio = True

        MediaPlayer1.Source_Mode = MediaPlayerSourceMode.DVD_DS

        ' read DVD info
        cbDVDControlTitle.Items.Clear()
        cbDVDControlChapter.Items.Clear()
        cbDVDControlAudio.Items.Clear()
        cbDVDControlSubtitles.Items.Clear()

        MediaInfo.Filename = edFilename.Text
        MediaInfo.ReadDVDInfo()

        For i As Integer = 0 To MediaInfo.Info.Disc_NumOfTitles - 1
            cbDVDControlTitle.Items.Add("Title " + (i + 1))
        Next

        MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device"

        MediaPlayer1.Video_Renderer_SetAuto()

        MediaPlayer1.Debug_Mode = cbDebugMode.Checked

        Await MediaPlayer1.PlayAsync()

        'DVD
        'select and play first title
        Dim null1 As DBNull = Nothing
        If (cbDVDControlTitle.Items.Count > 0) Then
            cbDVDControlTitle.SelectedIndex = 0
            cbDVDControlTitle_SelectedIndexChanged(null1, e)
        End If

        'show title menu
        Await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Title)

        MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value)
        MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value)

        timer1.Enabled = True

    End Sub

        ''' <summary>
        ''' Media player 1 on stop.
        ''' </summary>
    Private Sub MediaPlayer1_OnStop(ByVal sender As System.Object, ByVal e As EventArgs) Handles MediaPlayer1.OnStop

        Invoke(Sub()
                   tbTimeline.Value = 0
               End Sub)

    End Sub

    Private Async Sub timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles timer1.Tick

        timer1.Tag = 1
        tbTimeline.Maximum = (Await MediaPlayer1.Duration_TimeAsync()).TotalSeconds

        Dim value As Integer = (Await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds
        If ((value > 0) And (value < tbTimeline.Maximum)) Then
            tbTimeline.Value = value
        End If

        lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum)

        If (MediaPlayer1.DVD_Chapter_GetCurrent() <> cbDVDControlChapter.SelectedIndex) Then
            cbDVDControlChapter.SelectedIndex = MediaPlayer1.DVD_Chapter_GetCurrent()
        End If

        timer1.Tag = 0

    End Sub

        ''' <summary>
        ''' Form 1 load.
        ''' </summary>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        CreateEngine()

        Text += $" (SDK v{MediaPlayer1.SDK_Version})"
        MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

    End Sub

        ''' <summary>
        ''' Link label 1 link clicked.
        ''' </summary>
    Private Sub linkLabel1_LinkClicked(sender As System.Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked

        Dim startInfo = New ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials)
        Process.Start(startInfo)

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
        ''' Media player 1 on dvd playback error.
        ''' </summary>
    Private Sub MediaPlayer1_OnDVDPlaybackError(sender As System.Object, e As DVDEventArgs) Handles MediaPlayer1.OnDVDPlaybackError

        Invoke(Sub()
                   mmError.Text = mmError.Text + e.Message + Environment.NewLine
               End Sub)

    End Sub

        ''' <summary>
        ''' Form 1 form closing.
        ''' </summary>
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btStop_Click(Nothing, Nothing)

        DestroyEngine()
    End Sub
End Class

' ReSharper restore InconsistentNaming