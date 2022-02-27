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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.mmError = New System.Windows.Forms.TextBox()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tbBalance1 = New System.Windows.Forms.TrackBar()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tbVolume1 = New System.Windows.Forms.TrackBar()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btStop = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btStart = New System.Windows.Forms.Button()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.tbTimeline = New System.Windows.Forms.TrackBar()
        Me.btSelectFile = New System.Windows.Forms.Button()
        Me.edFilename = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.timer1 = New System.Windows.Forms.Timer()
        Me.cbLicensing = New System.Windows.Forms.CheckBox()
        CType(Me.tbBalance1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tbVolume1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.groupBox2.SuspendLayout
        CType(Me.tbTimeline,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = true
        Me.linkLabel1.Location = New System.Drawing.Point(281, 7)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(110, 13)
        Me.linkLabel1.TabIndex = 29
        Me.linkLabel1.TabStop = true
        Me.linkLabel1.Text = "Watch video tutorials!"
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.label1.Location = New System.Drawing.Point(67, 334)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(244, 13)
        Me.label1.TabIndex = 28
        Me.label1.Text = "Much more features are shown in Main Demo!"
        '
        'mmError
        '
        Me.mmError.Location = New System.Drawing.Point(15, 247)
        Me.mmError.Multiline = true
        Me.mmError.Name = "mmError"
        Me.mmError.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.mmError.Size = New System.Drawing.Size(371, 78)
        Me.mmError.TabIndex = 27
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = true
        Me.cbDebugMode.Location = New System.Drawing.Point(15, 224)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(87, 17)
        Me.cbDebugMode.TabIndex = 26
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = true
        '
        'label7
        '
        Me.label7.AutoSize = true
        Me.label7.Location = New System.Drawing.Point(105, 151)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(46, 13)
        Me.label7.TabIndex = 25
        Me.label7.Text = "Balance"
        '
        'tbBalance1
        '
        Me.tbBalance1.BackColor = System.Drawing.SystemColors.Window
        Me.tbBalance1.Location = New System.Drawing.Point(108, 167)
        Me.tbBalance1.Maximum = 100
        Me.tbBalance1.Minimum = -100
        Me.tbBalance1.Name = "tbBalance1"
        Me.tbBalance1.Size = New System.Drawing.Size(85, 45)
        Me.tbBalance1.TabIndex = 24
        '
        'label6
        '
        Me.label6.AutoSize = true
        Me.label6.Location = New System.Drawing.Point(12, 151)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(42, 13)
        Me.label6.TabIndex = 23
        Me.label6.Text = "Volume"
        '
        'tbVolume1
        '
        Me.tbVolume1.BackColor = System.Drawing.SystemColors.Window
        Me.tbVolume1.Location = New System.Drawing.Point(15, 167)
        Me.tbVolume1.Maximum = 100
        Me.tbVolume1.Minimum = 20
        Me.tbVolume1.Name = "tbVolume1"
        Me.tbVolume1.Size = New System.Drawing.Size(85, 45)
        Me.tbVolume1.TabIndex = 22
        Me.tbVolume1.Value = 80
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btStop)
        Me.groupBox2.Controls.Add(Me.btPause)
        Me.groupBox2.Controls.Add(Me.btResume)
        Me.groupBox2.Controls.Add(Me.btStart)
        Me.groupBox2.Controls.Add(Me.lbTime)
        Me.groupBox2.Controls.Add(Me.tbTimeline)
        Me.groupBox2.Location = New System.Drawing.Point(15, 52)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(371, 90)
        Me.groupBox2.TabIndex = 21
        Me.groupBox2.TabStop = false
        Me.groupBox2.Text = "Controls"
        '
        'btStop
        '
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btStop.Location = New System.Drawing.Point(180, 58)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(46, 23)
        Me.btStop.TabIndex = 7
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = true
        '
        'btPause
        '
        Me.btPause.Location = New System.Drawing.Point(122, 58)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(52, 23)
        Me.btPause.TabIndex = 6
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = true
        '
        'btResume
        '
        Me.btResume.Location = New System.Drawing.Point(55, 58)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(61, 23)
        Me.btResume.TabIndex = 5
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = true
        '
        'btStart
        '
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204,Byte))
        Me.btStart.Location = New System.Drawing.Point(6, 58)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(43, 23)
        Me.btStart.TabIndex = 4
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = true
        '
        'lbTime
        '
        Me.lbTime.AutoSize = true
        Me.lbTime.Location = New System.Drawing.Point(219, 27)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(96, 13)
        Me.lbTime.TabIndex = 1
        Me.lbTime.Text = "00:00:00/00:00:00"
        '
        'tbTimeline
        '
        Me.tbTimeline.Location = New System.Drawing.Point(6, 19)
        Me.tbTimeline.Maximum = 100
        Me.tbTimeline.Name = "tbTimeline"
        Me.tbTimeline.Size = New System.Drawing.Size(207, 45)
        Me.tbTimeline.TabIndex = 0
        '
        'btSelectFile
        '
        Me.btSelectFile.Location = New System.Drawing.Point(363, 23)
        Me.btSelectFile.Name = "btSelectFile"
        Me.btSelectFile.Size = New System.Drawing.Size(23, 23)
        Me.btSelectFile.TabIndex = 20
        Me.btSelectFile.Text = "..."
        Me.btSelectFile.UseVisualStyleBackColor = true
        '
        'edFilename
        '
        Me.edFilename.Location = New System.Drawing.Point(15, 25)
        Me.edFilename.Name = "edFilename"
        Me.edFilename.Size = New System.Drawing.Size(342, 20)
        Me.edFilename.TabIndex = 19
        Me.edFilename.Text = "c:\1.mp3"
        '
        'label14
        '
        Me.label14.AutoSize = true
        Me.label14.Location = New System.Drawing.Point(12, 9)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(52, 13)
        Me.label14.TabIndex = 18
        Me.label14.Text = "File name"
        '
        'timer1
        '
        '
        'cbLicensing
        '
        Me.cbLicensing.AutoSize = true
        Me.cbLicensing.Location = New System.Drawing.Point(118, 224)
        Me.cbLicensing.Name = "cbLicensing"
        Me.cbLicensing.Size = New System.Drawing.Size(91, 17)
        Me.cbLicensing.TabIndex = 31
        Me.cbLicensing.Text = "Licensing info"
        Me.cbLicensing.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 356)
        Me.Controls.Add(Me.cbLicensing)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.mmError)
        Me.Controls.Add(Me.cbDebugMode)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.tbBalance1)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.tbVolume1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.btSelectFile)
        Me.Controls.Add(Me.edFilename)
        Me.Controls.Add(Me.label14)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "Media Player SDK .Net - Audio Player Demo"
        CType(Me.tbBalance1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbVolume1,System.ComponentModel.ISupportInitialize).EndInit
        Me.groupBox2.ResumeLayout(false)
        Me.groupBox2.PerformLayout
        CType(Me.tbTimeline,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents mmError As System.Windows.Forms.TextBox
    Private WithEvents cbDebugMode As System.Windows.Forms.CheckBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tbBalance1 As System.Windows.Forms.TrackBar
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tbVolume1 As System.Windows.Forms.TrackBar
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents btPause As System.Windows.Forms.Button
    Private WithEvents btResume As System.Windows.Forms.Button
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents lbTime As System.Windows.Forms.Label
    Private WithEvents tbTimeline As System.Windows.Forms.TrackBar
    Private WithEvents btSelectFile As System.Windows.Forms.Button
    Private WithEvents edFilename As System.Windows.Forms.TextBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents cbLicensing As CheckBox
End Class
