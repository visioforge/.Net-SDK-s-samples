<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        btSelectOutput = New Button()
        edOutput = New TextBox()
        label15 = New Label()
        label1 = New Label()
        cbFrameRate = New ComboBox()
        label3 = New Label()
        edHeight = New TextBox()
        edWidth = New TextBox()
        label2 = New Label()
        Label4 = New Label()
        rbPreview = New RadioButton()
        btStop = New Button()
        btStart = New Button()
        btClearList = New Button()
        btAddInputFile = New Button()
        lbFiles = New ListBox()
        label10 = New Label()
        ProgressBar1 = New ProgressBar()
        rbConvert = New RadioButton()
        VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        SuspendLayout()
        ' 
        ' btSelectOutput
        ' 
        btSelectOutput.Location = New Point(415, 196)
        btSelectOutput.Margin = New Padding(4, 6, 4, 6)
        btSelectOutput.Name = "btSelectOutput"
        btSelectOutput.Size = New Size(43, 44)
        btSelectOutput.TabIndex = 68
        btSelectOutput.Text = "..."
        btSelectOutput.UseVisualStyleBackColor = True
        ' 
        ' edOutput
        ' 
        edOutput.Location = New Point(136, 203)
        edOutput.Margin = New Padding(4, 6, 4, 6)
        edOutput.Name = "edOutput"
        edOutput.Size = New Size(271, 31)
        edOutput.TabIndex = 67
        edOutput.Text = "output.mp4"
        ' 
        ' label15
        ' 
        label15.AutoSize = True
        label15.Location = New Point(21, 203)
        label15.Margin = New Padding(4, 0, 4, 0)
        label15.Name = "label15"
        label15.Size = New Size(97, 25)
        label15.TabIndex = 66
        label15.Text = "Output file"
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Location = New Point(21, 148)
        label1.Margin = New Padding(4, 0, 4, 0)
        label1.Name = "label1"
        label1.Size = New Size(437, 25)
        label1.TabIndex = 65
        label1.Text = "The MP4 output will be used with the default settings."
        ' 
        ' cbFrameRate
        ' 
        cbFrameRate.DropDownStyle = ComboBoxStyle.DropDownList
        cbFrameRate.FormattingEnabled = True
        cbFrameRate.Items.AddRange(New Object() {"1", "2", "5", "10", "12", "15", "20", "25", "30"})
        cbFrameRate.Location = New Point(136, 76)
        cbFrameRate.Margin = New Padding(4, 6, 4, 6)
        cbFrameRate.Name = "cbFrameRate"
        cbFrameRate.Size = New Size(77, 33)
        cbFrameRate.TabIndex = 64
        ' 
        ' label3
        ' 
        label3.AutoSize = True
        label3.Location = New Point(21, 79)
        label3.Margin = New Padding(4, 0, 4, 0)
        label3.Name = "label3"
        label3.Size = New Size(96, 25)
        label3.TabIndex = 63
        label3.Text = "Frame rate"
        ' 
        ' edHeight
        ' 
        edHeight.Location = New Point(256, 28)
        edHeight.Margin = New Padding(4, 6, 4, 6)
        edHeight.Name = "edHeight"
        edHeight.Size = New Size(77, 31)
        edHeight.TabIndex = 62
        edHeight.Text = "720"
        ' 
        ' edWidth
        ' 
        edWidth.Location = New Point(136, 28)
        edWidth.Margin = New Padding(4, 6, 4, 6)
        edWidth.Name = "edWidth"
        edWidth.Size = New Size(77, 31)
        edWidth.TabIndex = 61
        edWidth.Text = "1280"
        ' 
        ' label2
        ' 
        label2.AutoSize = True
        label2.Location = New Point(225, 32)
        label2.Margin = New Padding(4, 0, 4, 0)
        label2.Name = "label2"
        label2.Size = New Size(20, 25)
        label2.TabIndex = 60
        label2.Text = "x"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(21, 31)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 25)
        Label4.TabIndex = 69
        Label4.Text = "Resolution"
        ' 
        ' rbPreview
        ' 
        rbPreview.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbPreview.AutoSize = True
        rbPreview.Checked = True
        rbPreview.Location = New Point(670, 678)
        rbPreview.Margin = New Padding(4, 6, 4, 6)
        rbPreview.Name = "rbPreview"
        rbPreview.Size = New Size(97, 29)
        rbPreview.TabIndex = 95
        rbPreview.TabStop = True
        rbPreview.Text = "Preview"
        rbPreview.UseVisualStyleBackColor = True
        ' 
        ' btStop
        ' 
        btStop.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btStop.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(204))
        btStop.Location = New Point(1089, 668)
        btStop.Margin = New Padding(4, 6, 4, 6)
        btStop.Name = "btStop"
        btStop.Size = New Size(97, 44)
        btStop.TabIndex = 94
        btStop.Text = "Stop"
        btStop.UseVisualStyleBackColor = True
        ' 
        ' btStart
        ' 
        btStart.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btStart.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(204))
        btStart.Location = New Point(976, 668)
        btStart.Margin = New Padding(4, 6, 4, 6)
        btStart.Name = "btStart"
        btStart.Size = New Size(97, 44)
        btStart.TabIndex = 93
        btStart.Text = "Start"
        btStart.UseVisualStyleBackColor = True
        ' 
        ' btClearList
        ' 
        btClearList.Location = New Point(1077, 124)
        btClearList.Margin = New Padding(4, 6, 4, 6)
        btClearList.Name = "btClearList"
        btClearList.Size = New Size(107, 44)
        btClearList.TabIndex = 92
        btClearList.Text = "Clear"
        btClearList.UseVisualStyleBackColor = True
        ' 
        ' btAddInputFile
        ' 
        btAddInputFile.Location = New Point(1077, 69)
        btAddInputFile.Margin = New Padding(4, 6, 4, 6)
        btAddInputFile.Name = "btAddInputFile"
        btAddInputFile.Size = New Size(107, 44)
        btAddInputFile.TabIndex = 91
        btAddInputFile.Text = "Add"
        btAddInputFile.UseVisualStyleBackColor = True
        ' 
        ' lbFiles
        ' 
        lbFiles.FormattingEnabled = True
        lbFiles.ItemHeight = 25
        lbFiles.Location = New Point(493, 69)
        lbFiles.Margin = New Padding(4, 6, 4, 6)
        lbFiles.Name = "lbFiles"
        lbFiles.Size = New Size(573, 104)
        lbFiles.TabIndex = 90
        ' 
        ' label10
        ' 
        label10.AutoSize = True
        label10.Location = New Point(489, 27)
        label10.Margin = New Padding(4, 0, 4, 0)
        label10.Name = "label10"
        label10.Size = New Size(94, 25)
        label10.TabIndex = 89
        label10.Text = "Input files:"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ProgressBar1.Location = New Point(493, 742)
        ProgressBar1.Margin = New Padding(4, 6, 4, 6)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(691, 44)
        ProgressBar1.TabIndex = 88
        ' 
        ' rbConvert
        ' 
        rbConvert.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbConvert.AutoSize = True
        rbConvert.Location = New Point(493, 678)
        rbConvert.Margin = New Padding(4, 6, 4, 6)
        rbConvert.Name = "rbConvert"
        rbConvert.Size = New Size(148, 29)
        rbConvert.TabIndex = 87
        rbConvert.Text = "Convert video"
        rbConvert.UseVisualStyleBackColor = True
        ' 
        ' VideoView1
        ' 
        VideoView1.BackColor = Color.Black
        VideoView1.Location = New Point(493, 196)
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(691, 453)
        VideoView1.TabIndex = 96
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1215, 809)
        Controls.Add(VideoView1)
        Controls.Add(rbPreview)
        Controls.Add(btStop)
        Controls.Add(btStart)
        Controls.Add(btClearList)
        Controls.Add(btAddInputFile)
        Controls.Add(lbFiles)
        Controls.Add(label10)
        Controls.Add(ProgressBar1)
        Controls.Add(rbConvert)
        Controls.Add(Label4)
        Controls.Add(btSelectOutput)
        Controls.Add(edOutput)
        Controls.Add(label15)
        Controls.Add(label1)
        Controls.Add(cbFrameRate)
        Controls.Add(label3)
        Controls.Add(edHeight)
        Controls.Add(edWidth)
        Controls.Add(label2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "VisioForge Video Edit SDK .Net - Video From Images"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents btSelectOutput As Button
    Private WithEvents edOutput As TextBox
    Private WithEvents label15 As Label
    Private WithEvents label1 As Label
    Private WithEvents cbFrameRate As ComboBox
    Private WithEvents label3 As Label
    Private WithEvents edHeight As TextBox
    Private WithEvents edWidth As TextBox
    Private WithEvents label2 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents rbPreview As RadioButton
    Private WithEvents btStop As Button
    Private WithEvents btStart As Button
    Private WithEvents btClearList As Button
    Private WithEvents btAddInputFile As Button
    Private WithEvents lbFiles As ListBox
    Private WithEvents label10 As Label
    Private WithEvents ProgressBar1 As ProgressBar
    Private WithEvents rbConvert As RadioButton
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView

End Class
