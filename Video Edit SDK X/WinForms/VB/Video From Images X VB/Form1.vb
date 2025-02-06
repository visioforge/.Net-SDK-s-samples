Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports VisioForge.Core
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.VideoEditX

Public Class Form1
    Private WithEvents VideoEdit1 As VideoEditCoreX

    Private Sub btSelectOutput_Click(sender As Object, e As EventArgs) Handles btSelectOutput.Click
        Dim sfd As New SaveFileDialog With {
            .Filter = "MP4 files|*.mp4",
            .FilterIndex = 0,
            .RestoreDirectory = True
        }

        If sfd.ShowDialog() = DialogResult.OK Then
            edOutput.Text = sfd.FileName
        End If
    End Sub

    Private Sub CreateEngine()
        VideoEdit1 = New VideoEditCoreX(VideoView1)
    End Sub

    Private Sub DestroyEngine()
        If (VideoEdit1 IsNot Nothing) Then
            VideoEdit1.Dispose()
            VideoEdit1 = Nothing
        End If
    End Sub


    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' We have to initialize the engine on start
        Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]"
        Me.Enabled = False
        Await VisioForgeX.InitSDKAsync()
        Me.Enabled = True
        Text = Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "")

        CreateEngine()

        Text += $" (SDK v{VideoEditCoreX.SDK_Version})"

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4")
        VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

        cbFrameRate.SelectedIndex = 7
    End Sub

    Private Sub VideoEdit1_OnError(sender As Object, e As ErrorsEventArgs) Handles VideoEdit1.OnError
        Debug.WriteLine("Error: " + e.Message)
    End Sub

    Private Sub VideoEdit1_OnStop(sender As Object, e As StopEventArgs) Handles VideoEdit1.OnStop
        Invoke(Sub()
                   ProgressBar1.Value = 0
                   lbFiles.Items.Clear()
                   If (e.Successful) Then
                       MessageBox.Show(Me, "Completed successfully", String.Empty, MessageBoxButtons.OK)
                   Else
                       MessageBox.Show(Me, "Stopped with error", String.Empty, MessageBoxButtons.OK)
                   End If
               End Sub)
    End Sub

    Private Sub VideoEdit1_OnProgress(sender As Object, e As ProgressEventArgs) Handles VideoEdit1.OnProgress
        Invoke(Sub()
                   ProgressBar1.Value = e.Progress
               End Sub)
    End Sub

    Private Sub btAddInputFile_Click(sender As Object, e As EventArgs) Handles btAddInputFile.Click
        ' Set output video size
        VideoEdit1.Output_VideoSize = New VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text))

        ' Set output video frame rate
        Dim frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture)
        If (frameRate <> 0) Then
            VideoEdit1.Output_VideoFrameRate = New VideoFrameRate(frameRate)
        End If

        ' Open image files
        Dim ofd As New OpenFileDialog With {
            .Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
            .Multiselect = True
        }

        If ofd.ShowDialog() = DialogResult.OK Then
            For Each s As String In ofd.FileNames
                lbFiles.Items.Add(s)
                If FilenameHelper.IsImageFile(s) Then
                    VideoEdit1.Input_AddImageFile(s, TimeSpan.FromMilliseconds(2000))
                End If
            Next
        End If
    End Sub
    Private Sub btClearList_Click(sender As Object, e As EventArgs) Handles btClearList.Click
        lbFiles.Items.Clear()
        VideoEdit1.Input_Clear_List()
    End Sub

    Private Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        ' Apply capture parameters
        If (rbPreview.Checked) Then
            VideoEdit1.Output_Format = Nothing
        Else
            ' Create MP4 output with default settings
            Dim mp4 = New MP4Output(edOutput.Text)
            VideoEdit1.Output_Format = mp4
        End If

        VideoEdit1.Start()
    End Sub

    Private Sub btStop_Click(sender As Object, e As EventArgs) Handles btStop.Click
        VideoEdit1.Stop()
        ProgressBar1.Value = 0

        VideoEdit1.Input_Clear_List()
        lbFiles.Items.Clear()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        DestroyEngine()

        VisioForgeX.DestroySDK()
    End Sub
End Class
