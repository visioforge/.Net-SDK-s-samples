Imports System.IO
Imports VisioForge.Core
Imports VisioForge.Core.Helpers
Imports VisioForge.Core.Types.Events
Imports VisioForge.Core.Types.X.AudioRenderers
Imports VisioForge.Core.Types.X.Output
Imports VisioForge.Core.Types.X.Sources
Imports VisioForge.Core.VideoCaptureX
Imports VisioForge.Core.UI

Public Class Form1
    Private VideoCapture1 As VideoCaptureCoreX
    Private WithEvents tmRecording As New Timers.Timer(1000)

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += " [INITIALIZING SDK...]"
        Me.Enabled = False
        Await VisioForgeX.InitSDKAsync()
        Me.Enabled = True
        Me.Text = Me.Text.Replace(" [INITIALIZING SDK...]", "")

        VideoCapture1 = New VideoCaptureCoreX(VideoView1)
        AddHandler VideoCapture1.OnError, AddressOf VideoCapture1_OnError
        AddHandler VideoCapture1.OnStop, AddressOf VideoCapture1_OnStop

        Me.Text += $" (SDK v{VideoCaptureCoreX.SDK_Version})"

        ' Populate IP engine types
        cbIPCameraType.SelectedIndex = 0

        ' Set default URL
        cbIPURL.Text = "rtsp://192.168.1.100:554/stream"
    End Sub

    Private Async Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        Try
            mmLog.Clear()

            VideoCapture1.Debug_Mode = cbDebugMode.Checked
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")

            ' Configure IP camera source
            Dim audioEnabled As Boolean = False
            Select Case cbIPCameraType.SelectedIndex
                Case 0
                    ' Auto
                    Dim uri = New Uri(cbIPURL.Text)
                    If Not String.IsNullOrEmpty(edIPLogin.Text) AndAlso Not String.IsNullOrEmpty(edIPPassword.Text) Then
                        uri = New UriBuilder(uri) With {.UserName = edIPLogin.Text, .Password = edIPPassword.Text}.Uri
                    End If

                    Dim uni = Await UniversalSourceSettings.CreateAsync(uri)
                    VideoCapture1.Video_Source = uni
                    audioEnabled = uni.RenderAudio

                Case 1
                    ' RTSP
                    Dim rtsp = Await RTSPSourceSettings.CreateAsync(New Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text, True)
                    VideoCapture1.Video_Source = rtsp
                    audioEnabled = rtsp.AudioEnabled

                Case 2
                    ' HTTP MJPEG
                    Dim mjpeg = Await HTTPMJPEGSourceSettings.CreateAsync(New Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text)
                    VideoCapture1.Video_Source = mjpeg
                    audioEnabled = False

                Case Else
                    MessageBox.Show("Selected engine not yet implemented in this demo", "Info")
                    Return
            End Select

            VideoCapture1.Audio_Record = audioEnabled
            VideoCapture1.Audio_Play = audioEnabled

            Await VideoCapture1.StartAsync()

            tmRecording.Start()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btStop_Click(sender As Object, e As EventArgs) Handles btStop.Click
        Try
            tmRecording.Stop()
            Await VideoCapture1.StopAsync()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tmRecording_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tmRecording.Elapsed
        Dim ts = VideoCapture1.Duration()
        If Math.Abs(ts.TotalMilliseconds) < 0.01 Then Return

        If Me.InvokeRequired Then
            Me.Invoke(Sub() lbTimestamp.Text = "Duration: " & ts.ToString("hh\:mm\:ss"))
        Else
            lbTimestamp.Text = "Duration: " & ts.ToString("hh\:mm\:ss")
        End If
    End Sub

    Private Sub Log(txt As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() mmLog.Text &= txt & Environment.NewLine)
        Else
            mmLog.Text &= txt & Environment.NewLine
        End If
    End Sub

    Private Sub VideoCapture1_OnError(sender As Object, e As ErrorsEventArgs)
        Log("Error: " & e.Message)
    End Sub

    Private Sub VideoCapture1_OnStop(sender As Object, e As EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() lbTimestamp.Text = "Duration: 00:00:00")
        Else
            lbTimestamp.Text = "Duration: 00:00:00"
        End If
    End Sub

    Private Sub llVideoTutorials_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim startInfo = New ProcessStartInfo(HelpLinks.VideoTutorials) With {.UseShellExecute = True}
        Process.Start(startInfo)
    End Sub

    Private Async Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If VideoCapture1 IsNot Nothing Then
            Await VideoCapture1.DisposeAsync()
            VideoCapture1 = Nothing
        End If
        VisioForgeX.DestroySDK()
    End Sub
End Class
