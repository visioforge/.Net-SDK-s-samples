Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tbBalance1 = New System.Windows.Forms.TrackBar()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tbVolume1 = New System.Windows.Forms.TrackBar()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbLicensing = New System.Windows.Forms.CheckBox()
        Me.mmError = New System.Windows.Forms.TextBox()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.btDVDControlRootMenu = New System.Windows.Forms.Button()
        Me.btDVDControlTitleMenu = New System.Windows.Forms.Button()
        Me.cbDVDControlSubtitles = New System.Windows.Forms.ComboBox()
        Me.label19 = New System.Windows.Forms.Label()
        Me.cbDVDControlAudio = New System.Windows.Forms.ComboBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.cbDVDControlChapter = New System.Windows.Forms.ComboBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.cbDVDControlTitle = New System.Windows.Forms.ComboBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbLoop = New System.Windows.Forms.CheckBox()
        Me.btNextFrame = New System.Windows.Forms.Button()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.label16 = New System.Windows.Forms.Label()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.tbTimeline = New System.Windows.Forms.TrackBar()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btSelectFile = New System.Windows.Forms.Button()
        Me.edFilename = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        Me.groupBox4.SuspendLayout()
        CType(Me.tbBalance1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVolume1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTimeline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox4
        '
        Me.groupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox4.Controls.Add(Me.label7)
        Me.groupBox4.Controls.Add(Me.tbBalance1)
        Me.groupBox4.Controls.Add(Me.label6)
        Me.groupBox4.Controls.Add(Me.tbVolume1)
        Me.groupBox4.Location = New System.Drawing.Point(874, 277)
        Me.groupBox4.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox4.Size = New System.Drawing.Size(442, 206)
        Me.groupBox4.TabIndex = 34
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Audio output"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(218, 54)
        Me.label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(90, 25)
        Me.label7.TabIndex = 11
        Me.label7.Text = "Balance"
        '
        'tbBalance1
        '
        Me.tbBalance1.BackColor = System.Drawing.SystemColors.Window
        Me.tbBalance1.Location = New System.Drawing.Point(224, 85)
        Me.tbBalance1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbBalance1.Maximum = 100
        Me.tbBalance1.Minimum = -100
        Me.tbBalance1.Name = "tbBalance1"
        Me.tbBalance1.Size = New System.Drawing.Size(170, 90)
        Me.tbBalance1.TabIndex = 10
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(32, 54)
        Me.label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(84, 25)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Volume"
        '
        'tbVolume1
        '
        Me.tbVolume1.BackColor = System.Drawing.SystemColors.Window
        Me.tbVolume1.Location = New System.Drawing.Point(38, 85)
        Me.tbVolume1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbVolume1.Maximum = 100
        Me.tbVolume1.Minimum = 20
        Me.tbVolume1.Name = "tbVolume1"
        Me.tbVolume1.Size = New System.Drawing.Size(170, 90)
        Me.tbVolume1.TabIndex = 8
        Me.tbVolume1.Value = 80
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.cbLicensing)
        Me.groupBox1.Controls.Add(Me.mmError)
        Me.groupBox1.Controls.Add(Me.cbDebugMode)
        Me.groupBox1.Location = New System.Drawing.Point(874, 23)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox1.Size = New System.Drawing.Size(442, 242)
        Me.groupBox1.TabIndex = 33
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Errors and warnings"
        '
        'cbLicensing
        '
        Me.cbLicensing.AutoSize = True
        Me.cbLicensing.Location = New System.Drawing.Point(212, 37)
        Me.cbLicensing.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbLicensing.Name = "cbLicensing"
        Me.cbLicensing.Size = New System.Drawing.Size(177, 29)
        Me.cbLicensing.TabIndex = 4
        Me.cbLicensing.Text = "Licensing info"
        Me.cbLicensing.UseVisualStyleBackColor = True
        '
        'mmError
        '
        Me.mmError.Location = New System.Drawing.Point(12, 81)
        Me.mmError.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.mmError.Multiline = True
        Me.mmError.Name = "mmError"
        Me.mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.mmError.Size = New System.Drawing.Size(414, 146)
        Me.mmError.TabIndex = 3
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(12, 37)
        Me.cbDebugMode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(166, 29)
        Me.cbDebugMode.TabIndex = 2
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(190, 1067)
        Me.label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(500, 26)
        Me.label1.TabIndex = 32
        Me.label1.Text = "Much more features are shown in Main Demo!"
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.btDVDControlRootMenu)
        Me.groupBox3.Controls.Add(Me.btDVDControlTitleMenu)
        Me.groupBox3.Controls.Add(Me.cbDVDControlSubtitles)
        Me.groupBox3.Controls.Add(Me.label19)
        Me.groupBox3.Controls.Add(Me.cbDVDControlAudio)
        Me.groupBox3.Controls.Add(Me.label21)
        Me.groupBox3.Controls.Add(Me.cbDVDControlChapter)
        Me.groupBox3.Controls.Add(Me.label18)
        Me.groupBox3.Controls.Add(Me.cbDVDControlTitle)
        Me.groupBox3.Controls.Add(Me.label17)
        Me.groupBox3.Location = New System.Drawing.Point(30, 888)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox3.Size = New System.Drawing.Size(832, 150)
        Me.groupBox3.TabIndex = 31
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "DVD"
        '
        'btDVDControlRootMenu
        '
        Me.btDVDControlRootMenu.Location = New System.Drawing.Point(670, 92)
        Me.btDVDControlRootMenu.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btDVDControlRootMenu.Name = "btDVDControlRootMenu"
        Me.btDVDControlRootMenu.Size = New System.Drawing.Size(150, 44)
        Me.btDVDControlRootMenu.TabIndex = 9
        Me.btDVDControlRootMenu.Text = "Root menu"
        Me.btDVDControlRootMenu.UseVisualStyleBackColor = True
        '
        'btDVDControlTitleMenu
        '
        Me.btDVDControlTitleMenu.Location = New System.Drawing.Point(670, 40)
        Me.btDVDControlTitleMenu.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btDVDControlTitleMenu.Name = "btDVDControlTitleMenu"
        Me.btDVDControlTitleMenu.Size = New System.Drawing.Size(150, 44)
        Me.btDVDControlTitleMenu.TabIndex = 8
        Me.btDVDControlTitleMenu.Text = "Title menu"
        Me.btDVDControlTitleMenu.UseVisualStyleBackColor = True
        '
        'cbDVDControlSubtitles
        '
        Me.cbDVDControlSubtitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVDControlSubtitles.FormattingEnabled = True
        Me.cbDVDControlSubtitles.Location = New System.Drawing.Point(434, 96)
        Me.cbDVDControlSubtitles.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDVDControlSubtitles.Name = "cbDVDControlSubtitles"
        Me.cbDVDControlSubtitles.Size = New System.Drawing.Size(220, 33)
        Me.cbDVDControlSubtitles.TabIndex = 7
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Location = New System.Drawing.Point(336, 102)
        Me.label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(95, 25)
        Me.label19.TabIndex = 6
        Me.label19.Text = "Subtitles"
        '
        'cbDVDControlAudio
        '
        Me.cbDVDControlAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVDControlAudio.FormattingEnabled = True
        Me.cbDVDControlAudio.Location = New System.Drawing.Point(434, 44)
        Me.cbDVDControlAudio.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDVDControlAudio.Name = "cbDVDControlAudio"
        Me.cbDVDControlAudio.Size = New System.Drawing.Size(220, 33)
        Me.cbDVDControlAudio.TabIndex = 5
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(336, 50)
        Me.label21.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(67, 25)
        Me.label21.TabIndex = 4
        Me.label21.Text = "Audio"
        '
        'cbDVDControlChapter
        '
        Me.cbDVDControlChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVDControlChapter.FormattingEnabled = True
        Me.cbDVDControlChapter.Location = New System.Drawing.Point(110, 96)
        Me.cbDVDControlChapter.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDVDControlChapter.Name = "cbDVDControlChapter"
        Me.cbDVDControlChapter.Size = New System.Drawing.Size(192, 33)
        Me.cbDVDControlChapter.TabIndex = 3
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(12, 102)
        Me.label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(88, 25)
        Me.label18.TabIndex = 2
        Me.label18.Text = "Chapter"
        '
        'cbDVDControlTitle
        '
        Me.cbDVDControlTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDVDControlTitle.FormattingEnabled = True
        Me.cbDVDControlTitle.Location = New System.Drawing.Point(110, 44)
        Me.cbDVDControlTitle.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDVDControlTitle.Name = "cbDVDControlTitle"
        Me.cbDVDControlTitle.Size = New System.Drawing.Size(192, 33)
        Me.cbDVDControlTitle.TabIndex = 1
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(12, 50)
        Me.label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(53, 25)
        Me.label17.TabIndex = 0
        Me.label17.Text = "Title"
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.cbLoop)
        Me.groupBox2.Controls.Add(Me.btNextFrame)
        Me.groupBox2.Controls.Add(Me.btStop)
        Me.groupBox2.Controls.Add(Me.btPause)
        Me.groupBox2.Controls.Add(Me.btResume)
        Me.groupBox2.Controls.Add(Me.btStart)
        Me.groupBox2.Controls.Add(Me.tbSpeed)
        Me.groupBox2.Controls.Add(Me.label16)
        Me.groupBox2.Controls.Add(Me.lbTime)
        Me.groupBox2.Controls.Add(Me.tbTimeline)
        Me.groupBox2.Location = New System.Drawing.Point(30, 704)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.groupBox2.Size = New System.Drawing.Size(832, 173)
        Me.groupBox2.TabIndex = 30
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Controls"
        '
        'cbLoop
        '
        Me.cbLoop.AutoSize = True
        Me.cbLoop.Location = New System.Drawing.Point(660, 119)
        Me.cbLoop.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbLoop.Name = "cbLoop"
        Me.cbLoop.Size = New System.Drawing.Size(92, 29)
        Me.cbLoop.TabIndex = 9
        Me.cbLoop.Text = "Loop"
        Me.cbLoop.UseVisualStyleBackColor = True
        '
        'btNextFrame
        '
        Me.btNextFrame.Location = New System.Drawing.Point(498, 112)
        Me.btNextFrame.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btNextFrame.Name = "btNextFrame"
        Me.btNextFrame.Size = New System.Drawing.Size(150, 44)
        Me.btNextFrame.TabIndex = 8
        Me.btNextFrame.Text = "Next frame"
        Me.btNextFrame.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(360, 112)
        Me.btStop.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(92, 44)
        Me.btStop.TabIndex = 7
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Location = New System.Drawing.Point(244, 112)
        Me.btPause.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(104, 44)
        Me.btPause.TabIndex = 6
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'btResume
        '
        Me.btResume.Location = New System.Drawing.Point(110, 112)
        Me.btResume.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(122, 44)
        Me.btResume.TabIndex = 5
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = True
        '
        'btStart
        '
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(12, 112)
        Me.btStart.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(86, 44)
        Me.btStart.TabIndex = 4
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(642, 52)
        Me.tbSpeed.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbSpeed.Maximum = 25
        Me.tbSpeed.Minimum = 5
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(178, 90)
        Me.tbSpeed.TabIndex = 3
        Me.tbSpeed.Value = 10
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(644, 21)
        Me.label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(74, 25)
        Me.label16.TabIndex = 2
        Me.label16.Text = "Speed"
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Location = New System.Drawing.Point(438, 52)
        Me.lbTime.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(186, 25)
        Me.lbTime.TabIndex = 1
        Me.lbTime.Text = "00:00:00/00:00:00"
        '
        'tbTimeline
        '
        Me.tbTimeline.Location = New System.Drawing.Point(12, 37)
        Me.tbTimeline.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbTimeline.Maximum = 100
        Me.tbTimeline.Name = "tbTimeline"
        Me.tbTimeline.Size = New System.Drawing.Size(414, 90)
        Me.tbTimeline.TabIndex = 0
        '
        'linkLabel1
        '
        Me.linkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.Location = New System.Drawing.Point(642, 12)
        Me.linkLabel1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(219, 25)
        Me.linkLabel1.TabIndex = 29
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Watch video tutorials!"
        '
        'btSelectFile
        '
        Me.btSelectFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSelectFile.Location = New System.Drawing.Point(816, 44)
        Me.btSelectFile.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(46, 44)
        Me.btSelectFile.TabIndex = 28
        Me.btSelectFile.Text = "..."
        Me.btSelectFile.UseVisualStyleBackColor = True
        '
        'edFilename
        '
        Me.edFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edFilename.Location = New System.Drawing.Point(30, 48)
        Me.edFilename.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.edFilename.Name = "edFilename"
        Me.edFilename.Size = New System.Drawing.Size(770, 31)
        Me.edFilename.TabIndex = 27
        Me.edFilename.Text = "D:\VIDEO_TS\VIDEO_TS.IFO"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(24, 17)
        Me.label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(189, 25)
        Me.label14.TabIndex = 26
        Me.label14.Text = "DVD IFO file name"
        '
        'timer1
        '
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(30, 104)
        Me.VideoView1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(832, 588)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 35
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1340, 1112)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.btSelectFile)
        Me.Controls.Add(Me.edFilename)
        Me.Controls.Add(Me.label14)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form1"
        Me.Text = "Media Player SDK .Net - DVD Player Demo"
        Me.groupBox4.ResumeLayout(false)
        Me.groupBox4.PerformLayout
        CType(Me.tbBalance1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbVolume1,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.groupBox3.ResumeLayout(false)
        Me.groupBox3.PerformLayout
        Me.groupBox2.ResumeLayout(false)
        Me.groupBox2.PerformLayout
        CType(Me.tbSpeed,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbTimeline,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tbBalance1 As System.Windows.Forms.TrackBar
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tbVolume1 As System.Windows.Forms.TrackBar
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents mmError As System.Windows.Forms.TextBox
    Private WithEvents cbDebugMode As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btDVDControlRootMenu As System.Windows.Forms.Button
    Private WithEvents btDVDControlTitleMenu As System.Windows.Forms.Button
    Private WithEvents cbDVDControlSubtitles As System.Windows.Forms.ComboBox
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents cbDVDControlAudio As System.Windows.Forms.ComboBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents cbDVDControlChapter As System.Windows.Forms.ComboBox
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbDVDControlTitle As System.Windows.Forms.ComboBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents cbLoop As System.Windows.Forms.CheckBox
    Private WithEvents btNextFrame As System.Windows.Forms.Button
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btPause As System.Windows.Forms.Button
    Private WithEvents btResume As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents tbSpeed As System.Windows.Forms.TrackBar
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents lbTime As System.Windows.Forms.Label
    Private WithEvents tbTimeline As System.Windows.Forms.TrackBar
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents btSelectFile As System.Windows.Forms.Button
    Private WithEvents edFilename As System.Windows.Forms.TextBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents cbLicensing As CheckBox
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
