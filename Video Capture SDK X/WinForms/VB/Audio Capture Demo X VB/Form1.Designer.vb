<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
#Region "Windows Form Designer generated code"
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        components = New ComponentModel.Container()

        tabControl1 = New TabControl()
        tabPage1 = New TabPage()
        rbSystemAudio = New RadioButton()
        cbAudioInputDevice = New ComboBox()
        label1 = New Label()
        cbAudioInputFormat = New ComboBox()
        rbLoopback = New RadioButton()
        cbAudioLoopbackDevice = New ComboBox()
        label2 = New Label()
        cbPlayAudio = New CheckBox()
        cbAudioOutputDevice = New ComboBox()
        label3 = New Label()
        tbAudioVolume = New TrackBar()
        tabPage2 = New TabPage()
        label7 = New Label()
        label8 = New Label()
        cbOutputFormat = New ComboBox()
        edOutput = New TextBox()
        btSelectOutput = New Button()
        btOutputConfigure = New Button()
        label9 = New Label()
        tabPage4 = New TabPage()
        mmLog = New TextBox()
        cbDebugMode = New CheckBox()
        btStart = New Button()
        btStop = New Button()
        llVideoTutorials = New LinkLabel()
        cbMode = New ComboBox()
        lbTimestamp = New Label()

        tabControl1.SuspendLayout()
        tabPage1.SuspendLayout()
        CType(tbAudioVolume, ComponentModel.ISupportInitialize).BeginInit()
        tabPage2.SuspendLayout()
        tabPage4.SuspendLayout()
        SuspendLayout()

        ' tabControl1
        tabControl1.Controls.Add(tabPage1)
        tabControl1.Controls.Add(tabPage2)
        tabControl1.Controls.Add(tabPage4)
        tabControl1.Location = New Point(15, 12)
        tabControl1.Name = "tabControl1"
        tabControl1.SelectedIndex = 0
        tabControl1.Size = New Size(391, 544)
        tabControl1.TabIndex = 0

        ' tabPage1
        tabPage1.Controls.Add(rbSystemAudio)
        tabPage1.Controls.Add(cbAudioInputDevice)
        tabPage1.Controls.Add(label1)
        tabPage1.Controls.Add(cbAudioInputFormat)
        tabPage1.Controls.Add(rbLoopback)
        tabPage1.Controls.Add(cbAudioLoopbackDevice)
        tabPage1.Controls.Add(label2)
        tabPage1.Controls.Add(cbPlayAudio)
        tabPage1.Controls.Add(cbAudioOutputDevice)
        tabPage1.Controls.Add(label3)
        tabPage1.Controls.Add(tbAudioVolume)
        tabPage1.Location = New Point(4, 24)
        tabPage1.Name = "tabPage1"
        tabPage1.Padding = New Padding(3)
        tabPage1.Size = New Size(383, 516)
        tabPage1.TabIndex = 0
        tabPage1.Text = "Input & output devices"
        tabPage1.UseVisualStyleBackColor = True

        ' rbSystemAudio
        rbSystemAudio.AutoSize = True
        rbSystemAudio.Checked = True
        rbSystemAudio.Location = New Point(10, 10)
        rbSystemAudio.Name = "rbSystemAudio"
        rbSystemAudio.Size = New Size(95, 19)
        rbSystemAudio.TabIndex = 0
        rbSystemAudio.TabStop = True
        rbSystemAudio.Text = "Input device"

        ' cbAudioInputDevice
        cbAudioInputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioInputDevice.Location = New Point(10, 35)
        cbAudioInputDevice.Name = "cbAudioInputDevice"
        cbAudioInputDevice.Size = New Size(350, 23)
        cbAudioInputDevice.TabIndex = 1

        ' label1
        label1.AutoSize = True
        label1.Location = New Point(10, 65)
        label1.Name = "label1"
        label1.Size = New Size(80, 15)
        label1.TabIndex = 2
        label1.Text = "Input format"

        ' cbAudioInputFormat
        cbAudioInputFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioInputFormat.Location = New Point(10, 85)
        cbAudioInputFormat.Name = "cbAudioInputFormat"
        cbAudioInputFormat.Size = New Size(350, 23)
        cbAudioInputFormat.TabIndex = 3

        ' rbLoopback
        rbLoopback.AutoSize = True
        rbLoopback.Location = New Point(10, 130)
        rbLoopback.Name = "rbLoopback"
        rbLoopback.Size = New Size(237, 19)
        rbLoopback.TabIndex = 4
        rbLoopback.Text = "Loopback capture from output device"

        ' cbAudioLoopbackDevice
        cbAudioLoopbackDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioLoopbackDevice.Location = New Point(10, 155)
        cbAudioLoopbackDevice.Name = "cbAudioLoopbackDevice"
        cbAudioLoopbackDevice.Size = New Size(350, 23)
        cbAudioLoopbackDevice.TabIndex = 5

        ' label2
        label2.AutoSize = True
        label2.Location = New Point(10, 200)
        label2.Name = "label2"
        label2.Size = New Size(120, 15)
        label2.TabIndex = 6
        label2.Text = "Audio output device"

        ' cbPlayAudio
        cbPlayAudio.AutoSize = True
        cbPlayAudio.Checked = True
        cbPlayAudio.CheckState = CheckState.Checked
        cbPlayAudio.Location = New Point(260, 200)
        cbPlayAudio.Name = "cbPlayAudio"
        cbPlayAudio.Size = New Size(84, 19)
        cbPlayAudio.TabIndex = 7
        cbPlayAudio.Text = "Play Audio"

        ' cbAudioOutputDevice
        cbAudioOutputDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cbAudioOutputDevice.Location = New Point(10, 225)
        cbAudioOutputDevice.Name = "cbAudioOutputDevice"
        cbAudioOutputDevice.Size = New Size(350, 23)
        cbAudioOutputDevice.TabIndex = 8

        ' label3
        label3.AutoSize = True
        label3.Location = New Point(10, 265)
        label3.Name = "label3"
        label3.Size = New Size(50, 15)
        label3.TabIndex = 9
        label3.Text = "Volume"

        ' tbAudioVolume
        tbAudioVolume.Location = New Point(80, 260)
        tbAudioVolume.Maximum = 100
        tbAudioVolume.Minimum = 20
        tbAudioVolume.Name = "tbAudioVolume"
        tbAudioVolume.Size = New Size(280, 45)
        tbAudioVolume.TabIndex = 10
        tbAudioVolume.Value = 80

        ' tabPage2
        tabPage2.Controls.Add(label7)
        tabPage2.Controls.Add(label8)
        tabPage2.Controls.Add(cbOutputFormat)
        tabPage2.Controls.Add(edOutput)
        tabPage2.Controls.Add(btSelectOutput)
        tabPage2.Controls.Add(btOutputConfigure)
        tabPage2.Controls.Add(label9)
        tabPage2.Location = New Point(4, 24)
        tabPage2.Name = "tabPage2"
        tabPage2.Padding = New Padding(3)
        tabPage2.Size = New Size(383, 516)
        tabPage2.TabIndex = 1
        tabPage2.Text = "Output"
        tabPage2.UseVisualStyleBackColor = True

        ' label7
        label7.AutoSize = True
        label7.Location = New Point(10, 10)
        label7.Name = "label7"
        label7.Size = New Size(45, 15)
        label7.TabIndex = 0
        label7.Text = "Format"

        ' cbOutputFormat
        cbOutputFormat.DropDownStyle = ComboBoxStyle.DropDownList
        cbOutputFormat.Items.AddRange(New Object() {"PCM/ACM", "MP3", "WMA", "Ogg Vorbis", "FLAC", "Speex", "M4A (AAC)"})
        cbOutputFormat.Location = New Point(10, 35)
        cbOutputFormat.Name = "cbOutputFormat"
        cbOutputFormat.SelectedIndex = 1
        cbOutputFormat.Size = New Size(251, 23)
        cbOutputFormat.TabIndex = 1

        ' label9
        label9.AutoSize = True
        label9.Location = New Point(10, 65)
        label9.Name = "label9"
        label9.Size = New Size(300, 15)
        label9.TabIndex = 2
        label9.Text = "You can use dialog or code to configure format settings"

        ' btOutputConfigure
        btOutputConfigure.Location = New Point(10, 90)
        btOutputConfigure.Name = "btOutputConfigure"
        btOutputConfigure.Size = New Size(75, 23)
        btOutputConfigure.TabIndex = 3
        btOutputConfigure.Text = "Configure"

        ' label8
        label8.AutoSize = True
        label8.Location = New Point(10, 130)
        label8.Name = "label8"
        label8.Size = New Size(60, 15)
        label8.TabIndex = 4
        label8.Text = "File name"

        ' edOutput
        edOutput.Location = New Point(10, 155)
        edOutput.Name = "edOutput"
        edOutput.Size = New Size(332, 23)
        edOutput.TabIndex = 5

        ' btSelectOutput
        btSelectOutput.Location = New Point(347, 155)
        btSelectOutput.Name = "btSelectOutput"
        btSelectOutput.Size = New Size(28, 23)
        btSelectOutput.TabIndex = 6
        btSelectOutput.Text = "..."

        ' tabPage4
        tabPage4.Controls.Add(mmLog)
        tabPage4.Controls.Add(cbDebugMode)
        tabPage4.Location = New Point(4, 24)
        tabPage4.Name = "tabPage4"
        tabPage4.Size = New Size(383, 516)
        tabPage4.TabIndex = 2
        tabPage4.Text = "Log"
        tabPage4.UseVisualStyleBackColor = True

        ' cbDebugMode
        cbDebugMode.AutoSize = True
        cbDebugMode.Location = New Point(270, 10)
        cbDebugMode.Name = "cbDebugMode"
        cbDebugMode.Size = New Size(98, 19)
        cbDebugMode.TabIndex = 0
        cbDebugMode.Text = "Debug Mode"

        ' mmLog
        mmLog.Location = New Point(11, 35)
        mmLog.Multiline = True
        mmLog.Name = "mmLog"
        mmLog.ScrollBars = ScrollBars.Vertical
        mmLog.Size = New Size(364, 475)
        mmLog.TabIndex = 1

        ' btStart
        btStart.Location = New Point(247, 567)
        btStart.Name = "btStart"
        btStart.Size = New Size(75, 23)
        btStart.TabIndex = 1
        btStart.Text = "Start"

        ' btStop
        btStop.Location = New Point(331, 567)
        btStop.Name = "btStop"
        btStop.Size = New Size(75, 23)
        btStop.TabIndex = 2
        btStop.Text = "Stop"

        ' llVideoTutorials
        llVideoTutorials.AutoSize = True
        llVideoTutorials.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        llVideoTutorials.Location = New Point(316, 0)
        llVideoTutorials.Name = "llVideoTutorials"
        llVideoTutorials.Size = New Size(90, 15)
        llVideoTutorials.TabIndex = 3
        llVideoTutorials.TabStop = True
        llVideoTutorials.Text = "Video tutorial"

        ' cbMode
        cbMode.DropDownStyle = ComboBoxStyle.DropDownList
        cbMode.Items.AddRange(New Object() {"Preview", "Capture"})
        cbMode.Location = New Point(15, 567)
        cbMode.Name = "cbMode"
        cbMode.SelectedIndex = 0
        cbMode.Size = New Size(74, 23)
        cbMode.TabIndex = 4

        ' lbTimestamp
        lbTimestamp.AutoSize = True
        lbTimestamp.Location = New Point(103, 571)
        lbTimestamp.Name = "lbTimestamp"
        lbTimestamp.Size = New Size(139, 15)
        lbTimestamp.TabIndex = 5
        lbTimestamp.Text = "Recording time: 00:00:00"

        ' Form1
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(427, 605)
        Controls.Add(tabControl1)
        Controls.Add(btStart)
        Controls.Add(btStop)
        Controls.Add(llVideoTutorials)
        Controls.Add(cbMode)
        Controls.Add(lbTimestamp)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Audio Capture Demo X - Video Capture SDK .Net"
        tabControl1.ResumeLayout(False)
        tabPage1.ResumeLayout(False)
        tabPage1.PerformLayout()
        CType(tbAudioVolume, ComponentModel.ISupportInitialize).EndInit()
        tabPage2.ResumeLayout(False)
        tabPage2.PerformLayout()
        tabPage4.ResumeLayout(False)
        tabPage4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

    Friend WithEvents tabControl1 As TabControl
    Friend WithEvents tabPage1 As TabPage
    Friend WithEvents rbSystemAudio As RadioButton
    Friend WithEvents cbAudioInputDevice As ComboBox
    Friend WithEvents label1 As Label
    Friend WithEvents cbAudioInputFormat As ComboBox
    Friend WithEvents rbLoopback As RadioButton
    Friend WithEvents cbAudioLoopbackDevice As ComboBox
    Friend WithEvents label2 As Label
    Friend WithEvents cbPlayAudio As CheckBox
    Friend WithEvents cbAudioOutputDevice As ComboBox
    Friend WithEvents label3 As Label
    Friend WithEvents tbAudioVolume As TrackBar
    Friend WithEvents tabPage2 As TabPage
    Friend WithEvents label7 As Label
    Friend WithEvents label8 As Label
    Friend WithEvents cbOutputFormat As ComboBox
    Friend WithEvents edOutput As TextBox
    Friend WithEvents btSelectOutput As Button
    Friend WithEvents btOutputConfigure As Button
    Friend WithEvents label9 As Label
    Friend WithEvents tabPage4 As TabPage
    Friend WithEvents mmLog As TextBox
    Friend WithEvents cbDebugMode As CheckBox
    Friend WithEvents btStart As Button
    Friend WithEvents btStop As Button
    Friend WithEvents llVideoTutorials As LinkLabel
    Friend WithEvents cbMode As ComboBox
    Friend WithEvents lbTimestamp As Label
End Class
