Namespace VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
    Partial Class ImageLogoSettingsDialog
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.btClose = New System.Windows.Forms.Button()
            Me.btUpdate = New System.Windows.Forms.Button()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.imgPreview = New System.Windows.Forms.PictureBox()
            Me.pnImageLogoColorKey = New System.Windows.Forms.Panel()
            Me.cbImageLogoUseColorKey = New System.Windows.Forms.CheckBox()
            Me.label154 = New System.Windows.Forms.Label()
            Me.tbImageLogoTransp = New System.Windows.Forms.TrackBar()
            Me.groupBox22 = New System.Windows.Forms.GroupBox()
            Me.cbImageLogoShowAlways = New System.Windows.Forms.CheckBox()
            Me.edImageLogoStopTime = New System.Windows.Forms.TextBox()
            Me.lbGraphicLogoStopTime = New System.Windows.Forms.Label()
            Me.edImageLogoStartTime = New System.Windows.Forms.TextBox()
            Me.lbGraphicLogoStartTime = New System.Windows.Forms.Label()
            Me.groupBox23 = New System.Windows.Forms.GroupBox()
            Me.edImageLogoTop = New System.Windows.Forms.TextBox()
            Me.label155 = New System.Windows.Forms.Label()
            Me.edImageLogoLeft = New System.Windows.Forms.TextBox()
            Me.label156 = New System.Windows.Forms.Label()
            Me.btSelectImage = New System.Windows.Forms.Button()
            Me.label157 = New System.Windows.Forms.Label()
            Me.edImageLogoFilename = New System.Windows.Forms.TextBox()
            Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
            Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
            Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.panel1.SuspendLayout()
            CType(Me.imgPreview, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tbImageLogoTransp, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox22.SuspendLayout()
            Me.groupBox23.SuspendLayout()
            Me.SuspendLayout()
            '
            ' btClose
            '
            Me.btClose.Location = New System.Drawing.Point(468, 218)
            Me.btClose.Name = "btClose"
            Me.btClose.Size = New System.Drawing.Size(75, 23)
            Me.btClose.TabIndex = 66
            Me.btClose.Text = "Close"
            Me.btClose.UseVisualStyleBackColor = True
            AddHandler Me.btClose.Click, AddressOf Me.btClose_Click
            '
            ' btUpdate
            '
            Me.btUpdate.Location = New System.Drawing.Point(11, 218)
            Me.btUpdate.Name = "btUpdate"
            Me.btUpdate.Size = New System.Drawing.Size(75, 23)
            Me.btUpdate.TabIndex = 65
            Me.btUpdate.Text = "Update"
            Me.btUpdate.UseVisualStyleBackColor = True
            AddHandler Me.btUpdate.Click, AddressOf Me.btUpdate_Click
            '
            ' panel1
            '
            Me.panel1.BackColor = System.Drawing.SystemColors.Control
            Me.panel1.Controls.Add(Me.imgPreview)
            Me.panel1.Controls.Add(Me.pnImageLogoColorKey)
            Me.panel1.Controls.Add(Me.cbImageLogoUseColorKey)
            Me.panel1.Controls.Add(Me.label154)
            Me.panel1.Controls.Add(Me.tbImageLogoTransp)
            Me.panel1.Controls.Add(Me.groupBox22)
            Me.panel1.Controls.Add(Me.groupBox23)
            Me.panel1.Controls.Add(Me.btSelectImage)
            Me.panel1.Controls.Add(Me.label157)
            Me.panel1.Controls.Add(Me.edImageLogoFilename)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panel1.Location = New System.Drawing.Point(0, 0)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(555, 212)
            Me.panel1.TabIndex = 67
            '
            ' imgPreview
            '
            Me.imgPreview.BackColor = System.Drawing.Color.Black
            Me.imgPreview.Location = New System.Drawing.Point(302, 12)
            Me.imgPreview.Name = "imgPreview"
            Me.imgPreview.Size = New System.Drawing.Size(241, 182)
            Me.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.imgPreview.TabIndex = 74
            Me.imgPreview.TabStop = False
            '
            ' pnImageLogoColorKey
            '
            Me.pnImageLogoColorKey.BackColor = System.Drawing.Color.Fuchsia
            Me.pnImageLogoColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnImageLogoColorKey.Location = New System.Drawing.Point(246, 153)
            Me.pnImageLogoColorKey.Name = "pnImageLogoColorKey"
            Me.pnImageLogoColorKey.Size = New System.Drawing.Size(24, 24)
            Me.pnImageLogoColorKey.TabIndex = 73
            AddHandler Me.pnImageLogoColorKey.Click, AddressOf Me.pnGraphicLogoColorKey_Click
            '
            ' cbImageLogoUseColorKey
            '
            Me.cbImageLogoUseColorKey.AutoSize = True
            Me.cbImageLogoUseColorKey.Location = New System.Drawing.Point(132, 158)
            Me.cbImageLogoUseColorKey.Name = "cbImageLogoUseColorKey"
            Me.cbImageLogoUseColorKey.Size = New System.Drawing.Size(91, 17)
            Me.cbImageLogoUseColorKey.TabIndex = 72
            Me.cbImageLogoUseColorKey.Text = "Use color key"
            Me.cbImageLogoUseColorKey.UseVisualStyleBackColor = True
            '
            ' label154
            '
            Me.label154.AutoSize = True
            Me.label154.Location = New System.Drawing.Point(16, 134)
            Me.label154.Name = "label154"
            Me.label154.Size = New System.Drawing.Size(72, 13)
            Me.label154.TabIndex = 71
            Me.label154.Text = "Transparency"
            '
            ' tbImageLogoTransp
            '
            Me.tbImageLogoTransp.BackColor = System.Drawing.SystemColors.Window
            Me.tbImageLogoTransp.Location = New System.Drawing.Point(11, 149)
            Me.tbImageLogoTransp.Maximum = 255
            Me.tbImageLogoTransp.Name = "tbImageLogoTransp"
            Me.tbImageLogoTransp.Size = New System.Drawing.Size(104, 45)
            Me.tbImageLogoTransp.TabIndex = 70
            '
            ' groupBox22
            '
            Me.groupBox22.Controls.Add(Me.cbImageLogoShowAlways)
            Me.groupBox22.Controls.Add(Me.edImageLogoStopTime)
            Me.groupBox22.Controls.Add(Me.lbGraphicLogoStopTime)
            Me.groupBox22.Controls.Add(Me.edImageLogoStartTime)
            Me.groupBox22.Controls.Add(Me.lbGraphicLogoStartTime)
            Me.groupBox22.Location = New System.Drawing.Point(116, 45)
            Me.groupBox22.Name = "groupBox22"
            Me.groupBox22.Size = New System.Drawing.Size(173, 76)
            Me.groupBox22.TabIndex = 69
            Me.groupBox22.TabStop = False
            Me.groupBox22.Text = "Duration"
            '
            ' cbImageLogoShowAlways
            '
            Me.cbImageLogoShowAlways.AutoSize = True
            Me.cbImageLogoShowAlways.Checked = True
            Me.cbImageLogoShowAlways.CheckState = System.Windows.Forms.CheckState.Checked
            Me.cbImageLogoShowAlways.Location = New System.Drawing.Point(13, 48)
            Me.cbImageLogoShowAlways.Name = "cbImageLogoShowAlways"
            Me.cbImageLogoShowAlways.Size = New System.Drawing.Size(88, 17)
            Me.cbImageLogoShowAlways.TabIndex = 35
            Me.cbImageLogoShowAlways.Text = "Show always"
            Me.cbImageLogoShowAlways.UseVisualStyleBackColor = True
            AddHandler Me.cbImageLogoShowAlways.CheckedChanged, AddressOf Me.cbImageLogoShowAlways_CheckedChanged
            '
            ' edImageLogoStopTime
            '
            Me.edImageLogoStopTime.Enabled = False
            Me.edImageLogoStopTime.Location = New System.Drawing.Point(117, 19)
            Me.edImageLogoStopTime.Name = "edImageLogoStopTime"
            Me.edImageLogoStopTime.Size = New System.Drawing.Size(39, 20)
            Me.edImageLogoStopTime.TabIndex = 34
            Me.edImageLogoStopTime.Text = "10000"
            Me.edImageLogoStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            ' lbGraphicLogoStopTime
            '
            Me.lbGraphicLogoStopTime.AutoSize = True
            Me.lbGraphicLogoStopTime.Enabled = False
            Me.lbGraphicLogoStopTime.Location = New System.Drawing.Point(88, 22)
            Me.lbGraphicLogoStopTime.Name = "lbGraphicLogoStopTime"
            Me.lbGraphicLogoStopTime.Size = New System.Drawing.Size(29, 13)
            Me.lbGraphicLogoStopTime.TabIndex = 33
            Me.lbGraphicLogoStopTime.Text = "Stop"
            '
            ' edImageLogoStartTime
            '
            Me.edImageLogoStartTime.Enabled = False
            Me.edImageLogoStartTime.Location = New System.Drawing.Point(43, 19)
            Me.edImageLogoStartTime.Name = "edImageLogoStartTime"
            Me.edImageLogoStartTime.Size = New System.Drawing.Size(39, 20)
            Me.edImageLogoStartTime.TabIndex = 32
            Me.edImageLogoStartTime.Text = "0"
            Me.edImageLogoStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            ' lbGraphicLogoStartTime
            '
            Me.lbGraphicLogoStartTime.AutoSize = True
            Me.lbGraphicLogoStartTime.Enabled = False
            Me.lbGraphicLogoStartTime.Location = New System.Drawing.Point(10, 22)
            Me.lbGraphicLogoStartTime.Name = "lbGraphicLogoStartTime"
            Me.lbGraphicLogoStartTime.Size = New System.Drawing.Size(29, 13)
            Me.lbGraphicLogoStartTime.TabIndex = 31
            Me.lbGraphicLogoStartTime.Text = "Start"
            '
            ' groupBox23
            '
            Me.groupBox23.Controls.Add(Me.edImageLogoTop)
            Me.groupBox23.Controls.Add(Me.label155)
            Me.groupBox23.Controls.Add(Me.edImageLogoLeft)
            Me.groupBox23.Controls.Add(Me.label156)
            Me.groupBox23.Location = New System.Drawing.Point(13, 45)
            Me.groupBox23.Name = "groupBox23"
            Me.groupBox23.Size = New System.Drawing.Size(97, 76)
            Me.groupBox23.TabIndex = 68
            Me.groupBox23.TabStop = False
            Me.groupBox23.Text = "Position"
            '
            ' edImageLogoTop
            '
            Me.edImageLogoTop.Location = New System.Drawing.Point(47, 45)
            Me.edImageLogoTop.Name = "edImageLogoTop"
            Me.edImageLogoTop.Size = New System.Drawing.Size(39, 20)
            Me.edImageLogoTop.TabIndex = 32
            Me.edImageLogoTop.Text = "50"
            Me.edImageLogoTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            ' label155
            '
            Me.label155.AutoSize = True
            Me.label155.Location = New System.Drawing.Point(14, 48)
            Me.label155.Name = "label155"
            Me.label155.Size = New System.Drawing.Size(26, 13)
            Me.label155.TabIndex = 31
            Me.label155.Text = "Top"
            '
            ' edImageLogoLeft
            '
            Me.edImageLogoLeft.Location = New System.Drawing.Point(47, 19)
            Me.edImageLogoLeft.Name = "edImageLogoLeft"
            Me.edImageLogoLeft.Size = New System.Drawing.Size(39, 20)
            Me.edImageLogoLeft.TabIndex = 30
            Me.edImageLogoLeft.Text = "50"
            Me.edImageLogoLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            ' label156
            '
            Me.label156.AutoSize = True
            Me.label156.Location = New System.Drawing.Point(14, 22)
            Me.label156.Name = "label156"
            Me.label156.Size = New System.Drawing.Size(25, 13)
            Me.label156.TabIndex = 29
            Me.label156.Text = "Left"
            '
            ' btSelectImage
            '
            Me.btSelectImage.Location = New System.Drawing.Point(265, 10)
            Me.btSelectImage.Name = "btSelectImage"
            Me.btSelectImage.Size = New System.Drawing.Size(24, 23)
            Me.btSelectImage.TabIndex = 67
            Me.btSelectImage.Text = "..."
            Me.btSelectImage.UseVisualStyleBackColor = True
            AddHandler Me.btSelectImage.Click, AddressOf Me.btSelectImage_Click
            '
            ' label157
            '
            Me.label157.AutoSize = True
            Me.label157.Location = New System.Drawing.Point(12, 15)
            Me.label157.Name = "label157"
            Me.label157.Size = New System.Drawing.Size(52, 13)
            Me.label157.TabIndex = 66
            Me.label157.Text = "File name"
            '
            ' edImageLogoFilename
            '
            Me.edImageLogoFilename.Location = New System.Drawing.Point(70, 12)
            Me.edImageLogoFilename.Name = "edImageLogoFilename"
            Me.edImageLogoFilename.Size = New System.Drawing.Size(189, 20)
            Me.edImageLogoFilename.TabIndex = 65
            Me.edImageLogoFilename.Text = "c:\samples\!logo32.png"
            '
            ' openFileDialog2
            '
            Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
            '
            ' linkLabel1
            '
            Me.linkLabel1.AutoSize = True
            Me.linkLabel1.Location = New System.Drawing.Point(204, 223)
            Me.linkLabel1.Name = "linkLabel1"
            Me.linkLabel1.Size = New System.Drawing.Size(117, 13)
            Me.linkLabel1.TabIndex = 68
            Me.linkLabel1.TabStop = True
            Me.linkLabel1.Text = "Get dialog source code"
            AddHandler Me.linkLabel1.LinkClicked, AddressOf Me.linkLabel1_LinkClicked
            '
            ' ImageLogoSettingsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(555, 253)
            Me.Controls.Add(Me.linkLabel1)
            Me.Controls.Add(Me.panel1)
            Me.Controls.Add(Me.btClose)
            Me.Controls.Add(Me.btUpdate)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ImageLogoSettingsDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.Text = "Image logo settings"
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            CType(Me.imgPreview, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tbImageLogoTransp, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox22.ResumeLayout(False)
            Me.groupBox22.PerformLayout()
            Me.groupBox23.ResumeLayout(False)
            Me.groupBox23.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region
        Private btClose As System.Windows.Forms.Button
        Private btUpdate As System.Windows.Forms.Button
        Private panel1 As System.Windows.Forms.Panel
        Private imgPreview As System.Windows.Forms.PictureBox
        Private pnImageLogoColorKey As System.Windows.Forms.Panel
        Private cbImageLogoUseColorKey As System.Windows.Forms.CheckBox
        Private label154 As System.Windows.Forms.Label
        Private tbImageLogoTransp As System.Windows.Forms.TrackBar
        Private groupBox22 As System.Windows.Forms.GroupBox
        Private cbImageLogoShowAlways As System.Windows.Forms.CheckBox
        Private edImageLogoStopTime As System.Windows.Forms.TextBox
        Private lbGraphicLogoStopTime As System.Windows.Forms.Label
        Private edImageLogoStartTime As System.Windows.Forms.TextBox
        Private lbGraphicLogoStartTime As System.Windows.Forms.Label
        Private groupBox23 As System.Windows.Forms.GroupBox
        Private edImageLogoTop As System.Windows.Forms.TextBox
        Private label155 As System.Windows.Forms.Label
        Private edImageLogoLeft As System.Windows.Forms.TextBox
        Private label156 As System.Windows.Forms.Label
        Private btSelectImage As System.Windows.Forms.Button
        Private label157 As System.Windows.Forms.Label
        Private edImageLogoFilename As System.Windows.Forms.TextBox
        Private colorDialog1 As System.Windows.Forms.ColorDialog
        Private openFileDialog2 As System.Windows.Forms.OpenFileDialog
        Private linkLabel1 As System.Windows.Forms.LinkLabel
    End Class
End Namespace
