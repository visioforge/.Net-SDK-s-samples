<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        btStart = New Button()
        btStop = New Button()
        cbDebugMode = New CheckBox()
        cbIPCameraType = New ComboBox()
        cbIPURL = New ComboBox()
        edIPLogin = New TextBox()
        edIPPassword = New TextBox()
        lbTimestamp = New Label()
        mmLog = New TextBox()
        SuspendLayout()
        ' 
        ' VideoView1
        ' 
        VideoView1.BackColor = Color.Black
        VideoView1.Location = New Point(17, 20)
        VideoView1.Margin = New Padding(4, 5, 4, 5)
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(857, 667)
        VideoView1.TabIndex = 0
        ' 
        ' btStart
        ' 
        btStart.Location = New Point(17, 917)
        btStart.Margin = New Padding(4, 5, 4, 5)
        btStart.Name = "btStart"
        btStart.Size = New Size(107, 38)
        btStart.TabIndex = 1
        btStart.Text = "Start"
        ' 
        ' btStop
        ' 
        btStop.Location = New Point(133, 917)
        btStop.Margin = New Padding(4, 5, 4, 5)
        btStop.Name = "btStop"
        btStop.Size = New Size(107, 38)
        btStop.TabIndex = 2
        btStop.Text = "Stop"
        ' 
        ' cbDebugMode
        ' 
        cbDebugMode.AutoSize = True
        cbDebugMode.Location = New Point(900, 700)
        cbDebugMode.Margin = New Padding(4, 5, 4, 5)
        cbDebugMode.Name = "cbDebugMode"
        cbDebugMode.Size = New Size(144, 29)
        cbDebugMode.TabIndex = 3
        cbDebugMode.Text = "Debug Mode"
        ' 
        ' cbIPCameraType
        ' 
        cbIPCameraType.DropDownStyle = ComboBoxStyle.DropDownList
        cbIPCameraType.Items.AddRange(New Object() {"Auto", "RTSP", "HTTP/MJPEG"})
        cbIPCameraType.Location = New Point(900, 20)
        cbIPCameraType.Margin = New Padding(4, 5, 4, 5)
        cbIPCameraType.Name = "cbIPCameraType"
        cbIPCameraType.Size = New Size(423, 33)
        cbIPCameraType.TabIndex = 5
        ' 
        ' cbIPURL
        ' 
        cbIPURL.FormattingEnabled = True
        cbIPURL.Location = New Point(900, 68)
        cbIPURL.Margin = New Padding(4, 5, 4, 5)
        cbIPURL.Name = "cbIPURL"
        cbIPURL.Size = New Size(423, 33)
        cbIPURL.TabIndex = 6
        ' 
        ' edIPLogin
        ' 
        edIPLogin.Location = New Point(900, 117)
        edIPLogin.Margin = New Padding(4, 5, 4, 5)
        edIPLogin.Name = "edIPLogin"
        edIPLogin.PlaceholderText = "Login"
        edIPLogin.Size = New Size(423, 31)
        edIPLogin.TabIndex = 7
        ' 
        ' edIPPassword
        ' 
        edIPPassword.Location = New Point(900, 165)
        edIPPassword.Margin = New Padding(4, 5, 4, 5)
        edIPPassword.Name = "edIPPassword"
        edIPPassword.PasswordChar = "*"c
        edIPPassword.PlaceholderText = "Password"
        edIPPassword.Size = New Size(423, 31)
        edIPPassword.TabIndex = 8
        ' 
        ' lbTimestamp
        ' 
        lbTimestamp.AutoSize = True
        lbTimestamp.Location = New Point(286, 923)
        lbTimestamp.Margin = New Padding(4, 0, 4, 0)
        lbTimestamp.Name = "lbTimestamp"
        lbTimestamp.Size = New Size(209, 25)
        lbTimestamp.TabIndex = 9
        lbTimestamp.Text = "Recording time: 00:00:00"
        ' 
        ' mmLog
        ' 
        mmLog.Location = New Point(900, 783)
        mmLog.Margin = New Padding(4, 5, 4, 5)
        mmLog.Multiline = True
        mmLog.Name = "mmLog"
        mmLog.ScrollBars = ScrollBars.Vertical
        mmLog.Size = New Size(423, 114)
        mmLog.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1336, 1000)
        Controls.Add(VideoView1)
        Controls.Add(btStart)
        Controls.Add(btStop)
        Controls.Add(cbDebugMode)
        Controls.Add(cbIPCameraType)
        Controls.Add(cbIPURL)
        Controls.Add(edIPLogin)
        Controls.Add(edIPPassword)
        Controls.Add(lbTimestamp)
        Controls.Add(mmLog)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        Text = "IP Capture Demo X - Video Capture SDK .Net"
        ResumeLayout(False)
        PerformLayout()
    End Sub


    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
    Friend WithEvents btStart As Button
    Friend WithEvents btStop As Button
    Friend WithEvents cbDebugMode As CheckBox
    Friend WithEvents cbIPCameraType As ComboBox
    Friend WithEvents cbIPURL As ComboBox
    Friend WithEvents edIPLogin As TextBox
    Friend WithEvents edIPPassword As TextBox
    Friend WithEvents lbTimestamp As Label
    Friend WithEvents mmLog As TextBox
End Class
