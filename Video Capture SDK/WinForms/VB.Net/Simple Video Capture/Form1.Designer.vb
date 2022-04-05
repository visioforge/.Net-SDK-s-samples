Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If

        _mp4SettingsDialog?.Dispose()
        _mp4SettingsDialog = Nothing

        mp4HWSettingsDialog?.Dispose()
        mp4HWSettingsDialog = Nothing

        mpegTSSettingsDialog?.Dispose()
        mpegTSSettingsDialog = Nothing

        movSettingsDialog?.Dispose()
        movSettingsDialog = Nothing

        aviSettingsDialog?.Dispose()
        aviSettingsDialog = Nothing

        wmvSettingsDialog?.Dispose()
        wmvSettingsDialog = Nothing

        gifSettingsDialog?.Dispose()
        gifSettingsDialog = Nothing

        screenshotSaveDialog?.Dispose()
        screenshotSaveDialog = Nothing

        tmRecording?.Dispose()
        tmRecording = Nothing

        VideoCapture1?.Dispose()
        VideoCapture1 = Nothing

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label231 = New System.Windows.Forms.Label()
        Me.cbAudEqualizerPreset = New System.Windows.Forms.ComboBox()
        Me.label242 = New System.Windows.Forms.Label()
        Me.label230 = New System.Windows.Forms.Label()
        Me.tbAudAmplifyAmp = New System.Windows.Forms.TrackBar()
        Me.label95 = New System.Windows.Forms.Label()
        Me.label243 = New System.Windows.Forms.Label()
        Me.label241 = New System.Windows.Forms.Label()
        Me.label240 = New System.Windows.Forms.Label()
        Me.label239 = New System.Windows.Forms.Label()
        Me.label238 = New System.Windows.Forms.Label()
        Me.label237 = New System.Windows.Forms.Label()
        Me.label236 = New System.Windows.Forms.Label()
        Me.label235 = New System.Windows.Forms.Label()
        Me.label234 = New System.Windows.Forms.Label()
        Me.label233 = New System.Windows.Forms.Label()
        Me.btAudEqRefresh = New System.Windows.Forms.Button()
        Me.tabPage72 = New System.Windows.Forms.TabPage()
        Me.label232 = New System.Windows.Forms.Label()
        Me.tbAudEq9 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq8 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq7 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq6 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq5 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq4 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq3 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq2 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq1 = New System.Windows.Forms.TrackBar()
        Me.tbAudEq0 = New System.Windows.Forms.TrackBar()
        Me.cbAudEqualizerEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.cbMergeTextLogos = New System.Windows.Forms.CheckBox()
        Me.cbMergeImageLogos = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbFlipY = New System.Windows.Forms.CheckBox()
        Me.cbFlipX = New System.Windows.Forms.CheckBox()
        Me.cbInvert = New System.Windows.Forms.CheckBox()
        Me.cbGreyscale = New System.Windows.Forms.CheckBox()
        Me.label201 = New System.Windows.Forms.Label()
        Me.tbDarkness = New System.Windows.Forms.TrackBar()
        Me.label200 = New System.Windows.Forms.Label()
        Me.label199 = New System.Windows.Forms.Label()
        Me.label198 = New System.Windows.Forms.Label()
        Me.tbContrast = New System.Windows.Forms.TrackBar()
        Me.tbLightness = New System.Windows.Forms.TrackBar()
        Me.tbSaturation = New System.Windows.Forms.TrackBar()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btTextLogoAdd = New System.Windows.Forms.Button()
        Me.btLogoRemove = New System.Windows.Forms.Button()
        Me.btLogoEdit = New System.Windows.Forms.Button()
        Me.lbLogos = New System.Windows.Forms.ListBox()
        Me.btImageLogoAdd = New System.Windows.Forms.Button()
        Me.cbAudAmplifyEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage71 = New System.Windows.Forms.TabPage()
        Me.tabControl18 = New System.Windows.Forms.TabControl()
        Me.tabPage76 = New System.Windows.Forms.TabPage()
        Me.tbAudTrueBass = New System.Windows.Forms.TrackBar()
        Me.label254 = New System.Windows.Forms.Label()
        Me.cbAudTrueBassEnabled = New System.Windows.Forms.CheckBox()
        Me.tabPage5 = New System.Windows.Forms.TabPage()
        Me.fontDialog1 = New System.Windows.Forms.FontDialog()
        Me.openFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.cbDebugMode = New System.Windows.Forms.CheckBox()
        Me.mmLog = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cbUseBestVideoInputFormat = New System.Windows.Forms.CheckBox()
        Me.btVideoCaptureDeviceSettings = New System.Windows.Forms.Button()
        Me.label18 = New System.Windows.Forms.Label()
        Me.cbVideoInputFrameRate = New System.Windows.Forms.ComboBox()
        Me.cbVideoInputFormat = New System.Windows.Forms.ComboBox()
        Me.cbVideoInputDevice = New System.Windows.Forms.ComboBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.btSelectOutput = New System.Windows.Forms.Button()
        Me.edOutput = New System.Windows.Forms.TextBox()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btOutputConfigure = New System.Windows.Forms.Button()
        Me.cbOutputFormat = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label55 = New System.Windows.Forms.Label()
        Me.label54 = New System.Windows.Forms.Label()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.tbAudioBalance = New System.Windows.Forms.TrackBar()
        Me.tbAudioVolume = New System.Windows.Forms.TrackBar()
        Me.cbRecordAudio = New System.Windows.Forms.CheckBox()
        Me.cbAudioOutputDevice = New System.Windows.Forms.ComboBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.cbUseBestAudioInputFormat = New System.Windows.Forms.CheckBox()
        Me.btAudioInputDeviceSettings = New System.Windows.Forms.Button()
        Me.cbAudioInputLine = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputFormat = New System.Windows.Forms.ComboBox()
        Me.cbAudioInputDevice = New System.Windows.Forms.ComboBox()
        Me.label22 = New System.Windows.Forms.Label()
        Me.label23 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.btStart = New System.Windows.Forms.Button()
        Me.btStop = New System.Windows.Forms.Button()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.llVideoTutorials = New System.Windows.Forms.LinkLabel()
        Me.label34 = New System.Windows.Forms.Label()
        Me.btSaveScreenshot = New System.Windows.Forms.Button()
        Me.btResume = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.lbTimestamp = New System.Windows.Forms.Label()
        Me.rbCapture = New System.Windows.Forms.RadioButton()
        Me.rbPreview = New System.Windows.Forms.RadioButton()
        Me.VideoView1 = New VisioForge.Core.UI.WinForms.VideoView()
        CType(Me.tbAudAmplifyAmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage72.SuspendLayout()
        CType(Me.tbAudEq9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudEq0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage3.SuspendLayout()
        CType(Me.tbDarkness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage71.SuspendLayout()
        Me.tabControl18.SuspendLayout()
        Me.tabPage76.SuspendLayout()
        CType(Me.tbAudTrueBass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage5.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.tbAudioBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAudioVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'label231
        '
        Me.label231.AutoSize = True
        Me.label231.Location = New System.Drawing.Point(488, 102)
        Me.label231.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label231.Name = "label231"
        Me.label231.Size = New System.Drawing.Size(67, 25)
        Me.label231.TabIndex = 5
        Me.label231.Text = "400%"
        '
        'cbAudEqualizerPreset
        '
        Me.cbAudEqualizerPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudEqualizerPreset.FormattingEnabled = True
        Me.cbAudEqualizerPreset.Location = New System.Drawing.Point(122, 537)
        Me.cbAudEqualizerPreset.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudEqualizerPreset.Name = "cbAudEqualizerPreset"
        Me.cbAudEqualizerPreset.Size = New System.Drawing.Size(398, 33)
        Me.cbAudEqualizerPreset.TabIndex = 25
        '
        'label242
        '
        Me.label242.AutoSize = True
        Me.label242.Location = New System.Drawing.Point(546, 456)
        Me.label242.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label242.Name = "label242"
        Me.label242.Size = New System.Drawing.Size(50, 25)
        Me.label242.TabIndex = 23
        Me.label242.Text = "16K"
        '
        'label230
        '
        Me.label230.AutoSize = True
        Me.label230.Location = New System.Drawing.Point(150, 102)
        Me.label230.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label230.Name = "label230"
        Me.label230.Size = New System.Drawing.Size(67, 25)
        Me.label230.TabIndex = 4
        Me.label230.Text = "100%"
        '
        'tbAudAmplifyAmp
        '
        Me.tbAudAmplifyAmp.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudAmplifyAmp.Location = New System.Drawing.Point(32, 133)
        Me.tbAudAmplifyAmp.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudAmplifyAmp.Maximum = 4000
        Me.tbAudAmplifyAmp.Name = "tbAudAmplifyAmp"
        Me.tbAudAmplifyAmp.Size = New System.Drawing.Size(522, 90)
        Me.tbAudAmplifyAmp.TabIndex = 3
        Me.tbAudAmplifyAmp.TickFrequency = 50
        Me.tbAudAmplifyAmp.Value = 1000
        '
        'label95
        '
        Me.label95.AutoSize = True
        Me.label95.Location = New System.Drawing.Point(26, 102)
        Me.label95.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label95.Name = "label95"
        Me.label95.Size = New System.Drawing.Size(84, 25)
        Me.label95.TabIndex = 2
        Me.label95.Text = "Volume"
        '
        'label243
        '
        Me.label243.AutoSize = True
        Me.label243.Location = New System.Drawing.Point(26, 542)
        Me.label243.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label243.Name = "label243"
        Me.label243.Size = New System.Drawing.Size(74, 25)
        Me.label243.TabIndex = 24
        Me.label243.Text = "Preset"
        '
        'label241
        '
        Me.label241.AutoSize = True
        Me.label241.Location = New System.Drawing.Point(486, 456)
        Me.label241.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label241.Name = "label241"
        Me.label241.Size = New System.Drawing.Size(50, 25)
        Me.label241.TabIndex = 22
        Me.label241.Text = "14K"
        '
        'label240
        '
        Me.label240.AutoSize = True
        Me.label240.Location = New System.Drawing.Point(426, 456)
        Me.label240.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label240.Name = "label240"
        Me.label240.Size = New System.Drawing.Size(50, 25)
        Me.label240.TabIndex = 21
        Me.label240.Text = "12K"
        '
        'label239
        '
        Me.label239.AutoSize = True
        Me.label239.Location = New System.Drawing.Point(372, 456)
        Me.label239.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label239.Name = "label239"
        Me.label239.Size = New System.Drawing.Size(38, 25)
        Me.label239.TabIndex = 20
        Me.label239.Text = "6K"
        '
        'label238
        '
        Me.label238.AutoSize = True
        Me.label238.Location = New System.Drawing.Point(312, 456)
        Me.label238.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label238.Name = "label238"
        Me.label238.Size = New System.Drawing.Size(38, 25)
        Me.label238.TabIndex = 19
        Me.label238.Text = "3K"
        '
        'label237
        '
        Me.label237.AutoSize = True
        Me.label237.Location = New System.Drawing.Point(258, 456)
        Me.label237.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label237.Name = "label237"
        Me.label237.Size = New System.Drawing.Size(38, 25)
        Me.label237.TabIndex = 18
        Me.label237.Text = "1K"
        '
        'label236
        '
        Me.label236.AutoSize = True
        Me.label236.Location = New System.Drawing.Point(198, 456)
        Me.label236.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label236.Name = "label236"
        Me.label236.Size = New System.Drawing.Size(48, 25)
        Me.label236.TabIndex = 17
        Me.label236.Text = "600"
        '
        'label235
        '
        Me.label235.AutoSize = True
        Me.label235.Location = New System.Drawing.Point(138, 456)
        Me.label235.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label235.Name = "label235"
        Me.label235.Size = New System.Drawing.Size(48, 25)
        Me.label235.TabIndex = 16
        Me.label235.Text = "310"
        '
        'label234
        '
        Me.label234.AutoSize = True
        Me.label234.Location = New System.Drawing.Point(78, 456)
        Me.label234.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label234.Name = "label234"
        Me.label234.Size = New System.Drawing.Size(48, 25)
        Me.label234.TabIndex = 15
        Me.label234.Text = "170"
        '
        'label233
        '
        Me.label233.AutoSize = True
        Me.label233.Location = New System.Drawing.Point(26, 456)
        Me.label233.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label233.Name = "label233"
        Me.label233.Size = New System.Drawing.Size(36, 25)
        Me.label233.TabIndex = 14
        Me.label233.Text = "60"
        '
        'btAudEqRefresh
        '
        Me.btAudEqRefresh.Location = New System.Drawing.Point(536, 533)
        Me.btAudEqRefresh.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btAudEqRefresh.Name = "btAudEqRefresh"
        Me.btAudEqRefresh.Size = New System.Drawing.Size(150, 44)
        Me.btAudEqRefresh.TabIndex = 26
        Me.btAudEqRefresh.Text = "Refresh"
        Me.btAudEqRefresh.UseVisualStyleBackColor = True
        '
        'tabPage72
        '
        Me.tabPage72.Controls.Add(Me.btAudEqRefresh)
        Me.tabPage72.Controls.Add(Me.cbAudEqualizerPreset)
        Me.tabPage72.Controls.Add(Me.label243)
        Me.tabPage72.Controls.Add(Me.label242)
        Me.tabPage72.Controls.Add(Me.label241)
        Me.tabPage72.Controls.Add(Me.label240)
        Me.tabPage72.Controls.Add(Me.label239)
        Me.tabPage72.Controls.Add(Me.label238)
        Me.tabPage72.Controls.Add(Me.label237)
        Me.tabPage72.Controls.Add(Me.label236)
        Me.tabPage72.Controls.Add(Me.label235)
        Me.tabPage72.Controls.Add(Me.label234)
        Me.tabPage72.Controls.Add(Me.label233)
        Me.tabPage72.Controls.Add(Me.label232)
        Me.tabPage72.Controls.Add(Me.tbAudEq9)
        Me.tabPage72.Controls.Add(Me.tbAudEq8)
        Me.tabPage72.Controls.Add(Me.tbAudEq7)
        Me.tabPage72.Controls.Add(Me.tbAudEq6)
        Me.tabPage72.Controls.Add(Me.tbAudEq5)
        Me.tabPage72.Controls.Add(Me.tbAudEq4)
        Me.tabPage72.Controls.Add(Me.tbAudEq3)
        Me.tabPage72.Controls.Add(Me.tbAudEq2)
        Me.tabPage72.Controls.Add(Me.tbAudEq1)
        Me.tabPage72.Controls.Add(Me.tbAudEq0)
        Me.tabPage72.Controls.Add(Me.cbAudEqualizerEnabled)
        Me.tabPage72.Location = New System.Drawing.Point(8, 39)
        Me.tabPage72.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage72.Name = "tabPage72"
        Me.tabPage72.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage72.Size = New System.Drawing.Size(698, 707)
        Me.tabPage72.TabIndex = 1
        Me.tabPage72.Text = "Equalizer"
        Me.tabPage72.UseVisualStyleBackColor = True
        '
        'label232
        '
        Me.label232.AutoSize = True
        Me.label232.Location = New System.Drawing.Point(312, 71)
        Me.label232.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label232.Name = "label232"
        Me.label232.Size = New System.Drawing.Size(24, 25)
        Me.label232.TabIndex = 13
        Me.label232.Text = "0"
        '
        'tbAudEq9
        '
        Me.tbAudEq9.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq9.Location = New System.Drawing.Point(552, 102)
        Me.tbAudEq9.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq9.Maximum = 100
        Me.tbAudEq9.Minimum = -100
        Me.tbAudEq9.Name = "tbAudEq9"
        Me.tbAudEq9.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq9.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq9.TabIndex = 12
        Me.tbAudEq9.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq8
        '
        Me.tbAudEq8.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq8.Location = New System.Drawing.Point(494, 102)
        Me.tbAudEq8.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq8.Maximum = 100
        Me.tbAudEq8.Minimum = -100
        Me.tbAudEq8.Name = "tbAudEq8"
        Me.tbAudEq8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq8.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq8.TabIndex = 11
        Me.tbAudEq8.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq7
        '
        Me.tbAudEq7.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq7.Location = New System.Drawing.Point(434, 102)
        Me.tbAudEq7.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq7.Maximum = 100
        Me.tbAudEq7.Minimum = -100
        Me.tbAudEq7.Name = "tbAudEq7"
        Me.tbAudEq7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq7.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq7.TabIndex = 10
        Me.tbAudEq7.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq6
        '
        Me.tbAudEq6.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq6.Location = New System.Drawing.Point(376, 102)
        Me.tbAudEq6.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq6.Maximum = 100
        Me.tbAudEq6.Minimum = -100
        Me.tbAudEq6.Name = "tbAudEq6"
        Me.tbAudEq6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq6.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq6.TabIndex = 9
        Me.tbAudEq6.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq5
        '
        Me.tbAudEq5.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq5.Location = New System.Drawing.Point(318, 102)
        Me.tbAudEq5.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq5.Maximum = 100
        Me.tbAudEq5.Minimum = -100
        Me.tbAudEq5.Name = "tbAudEq5"
        Me.tbAudEq5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq5.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq5.TabIndex = 8
        Me.tbAudEq5.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq4
        '
        Me.tbAudEq4.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq4.Location = New System.Drawing.Point(262, 102)
        Me.tbAudEq4.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq4.Maximum = 100
        Me.tbAudEq4.Minimum = -100
        Me.tbAudEq4.Name = "tbAudEq4"
        Me.tbAudEq4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq4.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq4.TabIndex = 7
        Me.tbAudEq4.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq3
        '
        Me.tbAudEq3.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq3.Location = New System.Drawing.Point(204, 102)
        Me.tbAudEq3.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq3.Maximum = 100
        Me.tbAudEq3.Minimum = -100
        Me.tbAudEq3.Name = "tbAudEq3"
        Me.tbAudEq3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq3.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq3.TabIndex = 6
        Me.tbAudEq3.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq2
        '
        Me.tbAudEq2.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq2.Location = New System.Drawing.Point(146, 102)
        Me.tbAudEq2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq2.Maximum = 100
        Me.tbAudEq2.Minimum = -100
        Me.tbAudEq2.Name = "tbAudEq2"
        Me.tbAudEq2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq2.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq2.TabIndex = 5
        Me.tbAudEq2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq1
        '
        Me.tbAudEq1.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq1.Location = New System.Drawing.Point(88, 102)
        Me.tbAudEq1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq1.Maximum = 100
        Me.tbAudEq1.Minimum = -100
        Me.tbAudEq1.Name = "tbAudEq1"
        Me.tbAudEq1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq1.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq1.TabIndex = 4
        Me.tbAudEq1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudEq0
        '
        Me.tbAudEq0.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudEq0.Location = New System.Drawing.Point(32, 102)
        Me.tbAudEq0.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudEq0.Maximum = 100
        Me.tbAudEq0.Minimum = -100
        Me.tbAudEq0.Name = "tbAudEq0"
        Me.tbAudEq0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbAudEq0.Size = New System.Drawing.Size(90, 348)
        Me.tbAudEq0.TabIndex = 3
        Me.tbAudEq0.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'cbAudEqualizerEnabled
        '
        Me.cbAudEqualizerEnabled.AutoSize = True
        Me.cbAudEqualizerEnabled.Location = New System.Drawing.Point(32, 31)
        Me.cbAudEqualizerEnabled.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudEqualizerEnabled.Name = "cbAudEqualizerEnabled"
        Me.cbAudEqualizerEnabled.Size = New System.Drawing.Size(123, 29)
        Me.cbAudEqualizerEnabled.TabIndex = 2
        Me.cbAudEqualizerEnabled.Text = "Enabled"
        Me.cbAudEqualizerEnabled.UseVisualStyleBackColor = True
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.cbMergeTextLogos)
        Me.tabPage3.Controls.Add(Me.cbMergeImageLogos)
        Me.tabPage3.Controls.Add(Me.Label5)
        Me.tabPage3.Controls.Add(Me.cbFlipY)
        Me.tabPage3.Controls.Add(Me.cbFlipX)
        Me.tabPage3.Controls.Add(Me.cbInvert)
        Me.tabPage3.Controls.Add(Me.cbGreyscale)
        Me.tabPage3.Controls.Add(Me.label201)
        Me.tabPage3.Controls.Add(Me.tbDarkness)
        Me.tabPage3.Controls.Add(Me.label200)
        Me.tabPage3.Controls.Add(Me.label199)
        Me.tabPage3.Controls.Add(Me.label198)
        Me.tabPage3.Controls.Add(Me.tbContrast)
        Me.tabPage3.Controls.Add(Me.tbLightness)
        Me.tabPage3.Controls.Add(Me.tbSaturation)
        Me.tabPage3.Controls.Add(Me.label3)
        Me.tabPage3.Controls.Add(Me.btTextLogoAdd)
        Me.tabPage3.Controls.Add(Me.btLogoRemove)
        Me.tabPage3.Controls.Add(Me.btLogoEdit)
        Me.tabPage3.Controls.Add(Me.lbLogos)
        Me.tabPage3.Controls.Add(Me.btImageLogoAdd)
        Me.tabPage3.Location = New System.Drawing.Point(8, 39)
        Me.tabPage3.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage3.Size = New System.Drawing.Size(740, 780)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Video effects"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'cbMergeTextLogos
        '
        Me.cbMergeTextLogos.AutoSize = True
        Me.cbMergeTextLogos.Location = New System.Drawing.Point(376, 302)
        Me.cbMergeTextLogos.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbMergeTextLogos.Name = "cbMergeTextLogos"
        Me.cbMergeTextLogos.Size = New System.Drawing.Size(287, 29)
        Me.cbMergeTextLogos.TabIndex = 163
        Me.cbMergeTextLogos.Text = "Merge text logos into one"
        Me.cbMergeTextLogos.UseVisualStyleBackColor = True
        '
        'cbMergeImageLogos
        '
        Me.cbMergeImageLogos.AutoSize = True
        Me.cbMergeImageLogos.Location = New System.Drawing.Point(24, 302)
        Me.cbMergeImageLogos.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbMergeImageLogos.Name = "cbMergeImageLogos"
        Me.cbMergeImageLogos.Size = New System.Drawing.Size(310, 29)
        Me.cbMergeImageLogos.TabIndex = 162
        Me.cbMergeImageLogos.Text = "Merge image logos into one"
        Me.cbMergeImageLogos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(122, 710)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(484, 25)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "More effects and settings available in Main Demo"
        '
        'cbFlipY
        '
        Me.cbFlipY.AutoSize = True
        Me.cbFlipY.Location = New System.Drawing.Point(508, 612)
        Me.cbFlipY.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbFlipY.Name = "cbFlipY"
        Me.cbFlipY.Size = New System.Drawing.Size(100, 29)
        Me.cbFlipY.TabIndex = 160
        Me.cbFlipY.Text = "Flip Y"
        Me.cbFlipY.UseVisualStyleBackColor = True
        '
        'cbFlipX
        '
        Me.cbFlipX.AutoSize = True
        Me.cbFlipX.Location = New System.Drawing.Point(388, 612)
        Me.cbFlipX.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbFlipX.Name = "cbFlipX"
        Me.cbFlipX.Size = New System.Drawing.Size(99, 29)
        Me.cbFlipX.TabIndex = 159
        Me.cbFlipX.Text = "Flip X"
        Me.cbFlipX.UseVisualStyleBackColor = True
        '
        'cbInvert
        '
        Me.cbInvert.AutoSize = True
        Me.cbInvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cbInvert.Location = New System.Drawing.Point(268, 612)
        Me.cbInvert.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbInvert.Name = "cbInvert"
        Me.cbInvert.Size = New System.Drawing.Size(97, 29)
        Me.cbInvert.TabIndex = 158
        Me.cbInvert.Text = "Invert"
        Me.cbInvert.UseVisualStyleBackColor = True
        '
        'cbGreyscale
        '
        Me.cbGreyscale.AutoSize = True
        Me.cbGreyscale.Location = New System.Drawing.Point(108, 612)
        Me.cbGreyscale.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbGreyscale.Name = "cbGreyscale"
        Me.cbGreyscale.Size = New System.Drawing.Size(141, 29)
        Me.cbGreyscale.TabIndex = 157
        Me.cbGreyscale.Text = "Greyscale"
        Me.cbGreyscale.UseVisualStyleBackColor = True
        '
        'label201
        '
        Me.label201.AutoSize = True
        Me.label201.Location = New System.Drawing.Point(374, 477)
        Me.label201.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label201.Name = "label201"
        Me.label201.Size = New System.Drawing.Size(103, 25)
        Me.label201.TabIndex = 156
        Me.label201.Text = "Darkness"
        '
        'tbDarkness
        '
        Me.tbDarkness.BackColor = System.Drawing.SystemColors.Window
        Me.tbDarkness.Location = New System.Drawing.Point(374, 513)
        Me.tbDarkness.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbDarkness.Maximum = 255
        Me.tbDarkness.Name = "tbDarkness"
        Me.tbDarkness.Size = New System.Drawing.Size(260, 90)
        Me.tbDarkness.TabIndex = 155
        '
        'label200
        '
        Me.label200.AutoSize = True
        Me.label200.Location = New System.Drawing.Point(102, 477)
        Me.label200.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label200.Name = "label200"
        Me.label200.Size = New System.Drawing.Size(93, 25)
        Me.label200.TabIndex = 154
        Me.label200.Text = "Contrast"
        '
        'label199
        '
        Me.label199.AutoSize = True
        Me.label199.Location = New System.Drawing.Point(374, 377)
        Me.label199.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label199.Name = "label199"
        Me.label199.Size = New System.Drawing.Size(110, 25)
        Me.label199.TabIndex = 153
        Me.label199.Text = "Saturation"
        '
        'label198
        '
        Me.label198.AutoSize = True
        Me.label198.Location = New System.Drawing.Point(102, 377)
        Me.label198.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label198.Name = "label198"
        Me.label198.Size = New System.Drawing.Size(105, 25)
        Me.label198.TabIndex = 152
        Me.label198.Text = "Lightness"
        '
        'tbContrast
        '
        Me.tbContrast.BackColor = System.Drawing.SystemColors.Window
        Me.tbContrast.Location = New System.Drawing.Point(96, 513)
        Me.tbContrast.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbContrast.Maximum = 255
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(260, 90)
        Me.tbContrast.TabIndex = 151
        '
        'tbLightness
        '
        Me.tbLightness.BackColor = System.Drawing.SystemColors.Window
        Me.tbLightness.Location = New System.Drawing.Point(96, 406)
        Me.tbLightness.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbLightness.Maximum = 255
        Me.tbLightness.Name = "tbLightness"
        Me.tbLightness.Size = New System.Drawing.Size(260, 90)
        Me.tbLightness.TabIndex = 150
        '
        'tbSaturation
        '
        Me.tbSaturation.BackColor = System.Drawing.SystemColors.Window
        Me.tbSaturation.Location = New System.Drawing.Point(374, 406)
        Me.tbSaturation.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbSaturation.Maximum = 255
        Me.tbSaturation.Name = "tbSaturation"
        Me.tbSaturation.Size = New System.Drawing.Size(260, 90)
        Me.tbSaturation.TabIndex = 149
        Me.tbSaturation.Value = 255
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(18, 21)
        Me.label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(188, 25)
        Me.label3.TabIndex = 148
        Me.label3.Text = "Text / image logos"
        '
        'btTextLogoAdd
        '
        Me.btTextLogoAdd.Location = New System.Drawing.Point(234, 246)
        Me.btTextLogoAdd.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btTextLogoAdd.Name = "btTextLogoAdd"
        Me.btTextLogoAdd.Size = New System.Drawing.Size(198, 44)
        Me.btTextLogoAdd.TabIndex = 147
        Me.btTextLogoAdd.Text = "Add text logo"
        Me.btTextLogoAdd.UseVisualStyleBackColor = True
        '
        'btLogoRemove
        '
        Me.btLogoRemove.Location = New System.Drawing.Point(596, 246)
        Me.btLogoRemove.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btLogoRemove.Name = "btLogoRemove"
        Me.btLogoRemove.Size = New System.Drawing.Size(118, 44)
        Me.btLogoRemove.TabIndex = 146
        Me.btLogoRemove.Text = "Remove"
        Me.btLogoRemove.UseVisualStyleBackColor = True
        '
        'btLogoEdit
        '
        Me.btLogoEdit.Location = New System.Drawing.Point(466, 246)
        Me.btLogoEdit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btLogoEdit.Name = "btLogoEdit"
        Me.btLogoEdit.Size = New System.Drawing.Size(118, 44)
        Me.btLogoEdit.TabIndex = 145
        Me.btLogoEdit.Text = "Edit"
        Me.btLogoEdit.UseVisualStyleBackColor = True
        '
        'lbLogos
        '
        Me.lbLogos.FormattingEnabled = True
        Me.lbLogos.ItemHeight = 25
        Me.lbLogos.Location = New System.Drawing.Point(24, 52)
        Me.lbLogos.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lbLogos.Name = "lbLogos"
        Me.lbLogos.Size = New System.Drawing.Size(690, 179)
        Me.lbLogos.TabIndex = 144
        '
        'btImageLogoAdd
        '
        Me.btImageLogoAdd.Location = New System.Drawing.Point(24, 246)
        Me.btImageLogoAdd.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btImageLogoAdd.Name = "btImageLogoAdd"
        Me.btImageLogoAdd.Size = New System.Drawing.Size(198, 44)
        Me.btImageLogoAdd.TabIndex = 143
        Me.btImageLogoAdd.Text = "Add image logo"
        Me.btImageLogoAdd.UseVisualStyleBackColor = True
        '
        'cbAudAmplifyEnabled
        '
        Me.cbAudAmplifyEnabled.AutoSize = True
        Me.cbAudAmplifyEnabled.Location = New System.Drawing.Point(32, 31)
        Me.cbAudAmplifyEnabled.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudAmplifyEnabled.Name = "cbAudAmplifyEnabled"
        Me.cbAudAmplifyEnabled.Size = New System.Drawing.Size(123, 29)
        Me.cbAudAmplifyEnabled.TabIndex = 1
        Me.cbAudAmplifyEnabled.Text = "Enabled"
        Me.cbAudAmplifyEnabled.UseVisualStyleBackColor = True
        '
        'tabPage71
        '
        Me.tabPage71.Controls.Add(Me.label231)
        Me.tabPage71.Controls.Add(Me.label230)
        Me.tabPage71.Controls.Add(Me.tbAudAmplifyAmp)
        Me.tabPage71.Controls.Add(Me.label95)
        Me.tabPage71.Controls.Add(Me.cbAudAmplifyEnabled)
        Me.tabPage71.Location = New System.Drawing.Point(8, 39)
        Me.tabPage71.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage71.Name = "tabPage71"
        Me.tabPage71.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage71.Size = New System.Drawing.Size(698, 707)
        Me.tabPage71.TabIndex = 0
        Me.tabPage71.Text = "Amplify"
        Me.tabPage71.UseVisualStyleBackColor = True
        '
        'tabControl18
        '
        Me.tabControl18.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl18.Controls.Add(Me.tabPage71)
        Me.tabControl18.Controls.Add(Me.tabPage72)
        Me.tabControl18.Controls.Add(Me.tabPage76)
        Me.tabControl18.Location = New System.Drawing.Point(14, 12)
        Me.tabControl18.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabControl18.Name = "tabControl18"
        Me.tabControl18.SelectedIndex = 0
        Me.tabControl18.Size = New System.Drawing.Size(714, 754)
        Me.tabControl18.TabIndex = 2
        '
        'tabPage76
        '
        Me.tabPage76.Controls.Add(Me.tbAudTrueBass)
        Me.tabPage76.Controls.Add(Me.label254)
        Me.tabPage76.Controls.Add(Me.cbAudTrueBassEnabled)
        Me.tabPage76.Location = New System.Drawing.Point(8, 39)
        Me.tabPage76.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage76.Name = "tabPage76"
        Me.tabPage76.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage76.Size = New System.Drawing.Size(698, 707)
        Me.tabPage76.TabIndex = 5
        Me.tabPage76.Text = "True bass"
        Me.tabPage76.UseVisualStyleBackColor = True
        '
        'tbAudTrueBass
        '
        Me.tbAudTrueBass.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudTrueBass.Location = New System.Drawing.Point(32, 133)
        Me.tbAudTrueBass.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudTrueBass.Maximum = 10000
        Me.tbAudTrueBass.Name = "tbAudTrueBass"
        Me.tbAudTrueBass.Size = New System.Drawing.Size(522, 90)
        Me.tbAudTrueBass.TabIndex = 21
        Me.tbAudTrueBass.TickFrequency = 250
        '
        'label254
        '
        Me.label254.AutoSize = True
        Me.label254.Location = New System.Drawing.Point(26, 102)
        Me.label254.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label254.Name = "label254"
        Me.label254.Size = New System.Drawing.Size(84, 25)
        Me.label254.TabIndex = 20
        Me.label254.Text = "Volume"
        '
        'cbAudTrueBassEnabled
        '
        Me.cbAudTrueBassEnabled.AutoSize = True
        Me.cbAudTrueBassEnabled.Location = New System.Drawing.Point(32, 31)
        Me.cbAudTrueBassEnabled.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudTrueBassEnabled.Name = "cbAudTrueBassEnabled"
        Me.cbAudTrueBassEnabled.Size = New System.Drawing.Size(123, 29)
        Me.cbAudTrueBassEnabled.TabIndex = 2
        Me.cbAudTrueBassEnabled.Text = "Enabled"
        Me.cbAudTrueBassEnabled.UseVisualStyleBackColor = True
        '
        'tabPage5
        '
        Me.tabPage5.Controls.Add(Me.tabControl18)
        Me.tabPage5.Location = New System.Drawing.Point(8, 39)
        Me.tabPage5.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage5.Size = New System.Drawing.Size(740, 780)
        Me.tabPage5.TabIndex = 4
        Me.tabPage5.Text = "Audio effects"
        Me.tabPage5.UseVisualStyleBackColor = True
        '
        'fontDialog1
        '
        Me.fontDialog1.Color = System.Drawing.Color.White
        Me.fontDialog1.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fontDialog1.FontMustExist = True
        Me.fontDialog1.ShowColor = True
        '
        'openFileDialog2
        '
        Me.openFileDialog2.Filter = "Pictures|*.bmp; *.jpg; *.jpeg; *.jpe; *.png; *.gif; *.tiff;|All files|*.*"
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.cbDebugMode)
        Me.tabPage4.Controls.Add(Me.mmLog)
        Me.tabPage4.Location = New System.Drawing.Point(8, 39)
        Me.tabPage4.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage4.Size = New System.Drawing.Size(740, 780)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "Log"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'cbDebugMode
        '
        Me.cbDebugMode.AutoSize = True
        Me.cbDebugMode.Location = New System.Drawing.Point(28, 25)
        Me.cbDebugMode.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbDebugMode.Name = "cbDebugMode"
        Me.cbDebugMode.Size = New System.Drawing.Size(166, 29)
        Me.cbDebugMode.TabIndex = 81
        Me.cbDebugMode.Text = "Debug mode"
        Me.cbDebugMode.UseVisualStyleBackColor = True
        '
        'mmLog
        '
        Me.mmLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mmLog.Location = New System.Drawing.Point(28, 69)
        Me.mmLog.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.mmLog.Multiline = True
        Me.mmLog.Name = "mmLog"
        Me.mmLog.Size = New System.Drawing.Size(674, 671)
        Me.mmLog.TabIndex = 80
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(678, 177)
        Me.label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 25)
        Me.label1.TabIndex = 128
        Me.label1.Text = "fps"
        '
        'cbUseBestVideoInputFormat
        '
        Me.cbUseBestVideoInputFormat.AutoSize = True
        Me.cbUseBestVideoInputFormat.Location = New System.Drawing.Point(376, 138)
        Me.cbUseBestVideoInputFormat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbUseBestVideoInputFormat.Name = "cbUseBestVideoInputFormat"
        Me.cbUseBestVideoInputFormat.Size = New System.Drawing.Size(129, 29)
        Me.cbUseBestVideoInputFormat.TabIndex = 127
        Me.cbUseBestVideoInputFormat.Text = "Use best"
        Me.cbUseBestVideoInputFormat.UseVisualStyleBackColor = True
        '
        'btVideoCaptureDeviceSettings
        '
        Me.btVideoCaptureDeviceSettings.Location = New System.Drawing.Point(538, 65)
        Me.btVideoCaptureDeviceSettings.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btVideoCaptureDeviceSettings.Name = "btVideoCaptureDeviceSettings"
        Me.btVideoCaptureDeviceSettings.Size = New System.Drawing.Size(132, 44)
        Me.btVideoCaptureDeviceSettings.TabIndex = 126
        Me.btVideoCaptureDeviceSettings.Text = "Settings"
        Me.btVideoCaptureDeviceSettings.UseVisualStyleBackColor = True
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(532, 140)
        Me.label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(116, 25)
        Me.label18.TabIndex = 125
        Me.label18.Text = "Frame rate"
        '
        'cbVideoInputFrameRate
        '
        Me.cbVideoInputFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFrameRate.FormattingEnabled = True
        Me.cbVideoInputFrameRate.Location = New System.Drawing.Point(538, 171)
        Me.cbVideoInputFrameRate.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbVideoInputFrameRate.Name = "cbVideoInputFrameRate"
        Me.cbVideoInputFrameRate.Size = New System.Drawing.Size(126, 33)
        Me.cbVideoInputFrameRate.TabIndex = 124
        '
        'cbVideoInputFormat
        '
        Me.cbVideoInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputFormat.FormattingEnabled = True
        Me.cbVideoInputFormat.Location = New System.Drawing.Point(18, 171)
        Me.cbVideoInputFormat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbVideoInputFormat.Name = "cbVideoInputFormat"
        Me.cbVideoInputFormat.Size = New System.Drawing.Size(490, 33)
        Me.cbVideoInputFormat.TabIndex = 123
        '
        'cbVideoInputDevice
        '
        Me.cbVideoInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVideoInputDevice.FormattingEnabled = True
        Me.cbVideoInputDevice.Location = New System.Drawing.Point(18, 69)
        Me.cbVideoInputDevice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbVideoInputDevice.Name = "cbVideoInputDevice"
        Me.cbVideoInputDevice.Size = New System.Drawing.Size(490, 33)
        Me.cbVideoInputDevice.TabIndex = 122
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(10, 140)
        Me.label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(186, 25)
        Me.label13.TabIndex = 121
        Me.label13.Text = "Video input format"
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.btSelectOutput)
        Me.tabPage2.Controls.Add(Me.edOutput)
        Me.tabPage2.Controls.Add(Me.lbInfo)
        Me.tabPage2.Controls.Add(Me.btOutputConfigure)
        Me.tabPage2.Controls.Add(Me.cbOutputFormat)
        Me.tabPage2.Controls.Add(Me.label4)
        Me.tabPage2.Controls.Add(Me.label7)
        Me.tabPage2.Location = New System.Drawing.Point(8, 39)
        Me.tabPage2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage2.Size = New System.Drawing.Size(740, 780)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Output"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'btSelectOutput
        '
        Me.btSelectOutput.Location = New System.Drawing.Point(680, 300)
        Me.btSelectOutput.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btSelectOutput.Name = "btSelectOutput"
        Me.btSelectOutput.Size = New System.Drawing.Size(48, 44)
        Me.btSelectOutput.TabIndex = 133
        Me.btSelectOutput.Text = "..."
        Me.btSelectOutput.UseVisualStyleBackColor = True
        '
        'edOutput
        '
        Me.edOutput.Location = New System.Drawing.Point(32, 304)
        Me.edOutput.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.edOutput.Name = "edOutput"
        Me.edOutput.Size = New System.Drawing.Size(632, 31)
        Me.edOutput.TabIndex = 132
        Me.edOutput.Text = "c:\capture.avi"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Location = New System.Drawing.Point(26, 112)
        Me.lbInfo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(541, 25)
        Me.lbInfo.TabIndex = 131
        Me.lbInfo.Text = "You can use dialog or code to configure format settings"
        '
        'btOutputConfigure
        '
        Me.btOutputConfigure.Location = New System.Drawing.Point(32, 142)
        Me.btOutputConfigure.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btOutputConfigure.Name = "btOutputConfigure"
        Me.btOutputConfigure.Size = New System.Drawing.Size(150, 44)
        Me.btOutputConfigure.TabIndex = 130
        Me.btOutputConfigure.Text = "Configure"
        Me.btOutputConfigure.UseVisualStyleBackColor = True
        '
        'cbOutputFormat
        '
        Me.cbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutputFormat.FormattingEnabled = True
        Me.cbOutputFormat.Items.AddRange(New Object() {"AVI", "WMV (Windows Media Video)", "MP4 (CPU)", "MP4 (GPU: Intel, Nvidia, AMD/ATI)", "Animated GIF", "MPEG-TS", "MOV"})
        Me.cbOutputFormat.Location = New System.Drawing.Point(32, 58)
        Me.cbOutputFormat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbOutputFormat.Name = "cbOutputFormat"
        Me.cbOutputFormat.Size = New System.Drawing.Size(554, 33)
        Me.cbOutputFormat.TabIndex = 129
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(26, 273)
        Me.label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 25)
        Me.label4.TabIndex = 128
        Me.label4.Text = "File name"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(26, 25)
        Me.label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(79, 25)
        Me.label7.TabIndex = 127
        Me.label7.Text = "Format"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(12, 38)
        Me.label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(189, 25)
        Me.label11.TabIndex = 120
        Me.label11.Text = "Video input device"
        '
        'label55
        '
        Me.label55.AutoSize = True
        Me.label55.Location = New System.Drawing.Point(396, 688)
        Me.label55.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(90, 25)
        Me.label55.TabIndex = 90
        Me.label55.Text = "Balance"
        '
        'label54
        '
        Me.label54.AutoSize = True
        Me.label54.Location = New System.Drawing.Point(14, 688)
        Me.label54.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label54.Name = "label54"
        Me.label54.Size = New System.Drawing.Size(84, 25)
        Me.label54.TabIndex = 88
        Me.label54.Text = "Volume"
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Controls.Add(Me.cbUseBestVideoInputFormat)
        Me.tabPage1.Controls.Add(Me.btVideoCaptureDeviceSettings)
        Me.tabPage1.Controls.Add(Me.label18)
        Me.tabPage1.Controls.Add(Me.cbVideoInputFrameRate)
        Me.tabPage1.Controls.Add(Me.cbVideoInputFormat)
        Me.tabPage1.Controls.Add(Me.cbVideoInputDevice)
        Me.tabPage1.Controls.Add(Me.label13)
        Me.tabPage1.Controls.Add(Me.label11)
        Me.tabPage1.Controls.Add(Me.label55)
        Me.tabPage1.Controls.Add(Me.tbAudioBalance)
        Me.tabPage1.Controls.Add(Me.label54)
        Me.tabPage1.Controls.Add(Me.tbAudioVolume)
        Me.tabPage1.Controls.Add(Me.cbRecordAudio)
        Me.tabPage1.Controls.Add(Me.cbAudioOutputDevice)
        Me.tabPage1.Controls.Add(Me.label15)
        Me.tabPage1.Controls.Add(Me.cbUseBestAudioInputFormat)
        Me.tabPage1.Controls.Add(Me.btAudioInputDeviceSettings)
        Me.tabPage1.Controls.Add(Me.cbAudioInputLine)
        Me.tabPage1.Controls.Add(Me.cbAudioInputFormat)
        Me.tabPage1.Controls.Add(Me.cbAudioInputDevice)
        Me.tabPage1.Controls.Add(Me.label22)
        Me.tabPage1.Controls.Add(Me.label23)
        Me.tabPage1.Controls.Add(Me.label25)
        Me.tabPage1.Location = New System.Drawing.Point(8, 39)
        Me.tabPage1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tabPage1.Size = New System.Drawing.Size(740, 780)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Devices"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'tbAudioBalance
        '
        Me.tbAudioBalance.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioBalance.Location = New System.Drawing.Point(498, 679)
        Me.tbAudioBalance.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudioBalance.Maximum = 100
        Me.tbAudioBalance.Minimum = -100
        Me.tbAudioBalance.Name = "tbAudioBalance"
        Me.tbAudioBalance.Size = New System.Drawing.Size(228, 90)
        Me.tbAudioBalance.TabIndex = 89
        Me.tbAudioBalance.TickFrequency = 5
        Me.tbAudioBalance.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tbAudioVolume
        '
        Me.tbAudioVolume.BackColor = System.Drawing.SystemColors.Window
        Me.tbAudioVolume.Location = New System.Drawing.Point(108, 679)
        Me.tbAudioVolume.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tbAudioVolume.Maximum = 100
        Me.tbAudioVolume.Minimum = 20
        Me.tbAudioVolume.Name = "tbAudioVolume"
        Me.tbAudioVolume.Size = New System.Drawing.Size(232, 90)
        Me.tbAudioVolume.TabIndex = 87
        Me.tbAudioVolume.TickFrequency = 10
        Me.tbAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbAudioVolume.Value = 80
        '
        'cbRecordAudio
        '
        Me.cbRecordAudio.AutoSize = True
        Me.cbRecordAudio.Checked = True
        Me.cbRecordAudio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbRecordAudio.Location = New System.Drawing.Point(506, 594)
        Me.cbRecordAudio.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbRecordAudio.Name = "cbRecordAudio"
        Me.cbRecordAudio.Size = New System.Drawing.Size(220, 29)
        Me.cbRecordAudio.TabIndex = 86
        Me.cbRecordAudio.Text = "Play/Record audio"
        Me.cbRecordAudio.UseVisualStyleBackColor = True
        '
        'cbAudioOutputDevice
        '
        Me.cbAudioOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioOutputDevice.FormattingEnabled = True
        Me.cbAudioOutputDevice.Location = New System.Drawing.Point(18, 627)
        Me.cbAudioOutputDevice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudioOutputDevice.Name = "cbAudioOutputDevice"
        Me.cbAudioOutputDevice.Size = New System.Drawing.Size(704, 33)
        Me.cbAudioOutputDevice.TabIndex = 85
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(12, 596)
        Me.label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(202, 25)
        Me.label15.TabIndex = 84
        Me.label15.Text = "Audio output device"
        '
        'cbUseBestAudioInputFormat
        '
        Me.cbUseBestAudioInputFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUseBestAudioInputFormat.AutoSize = True
        Me.cbUseBestAudioInputFormat.Location = New System.Drawing.Point(597, 437)
        Me.cbUseBestAudioInputFormat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbUseBestAudioInputFormat.Name = "cbUseBestAudioInputFormat"
        Me.cbUseBestAudioInputFormat.Size = New System.Drawing.Size(129, 29)
        Me.cbUseBestAudioInputFormat.TabIndex = 83
        Me.cbUseBestAudioInputFormat.Text = "Use best"
        Me.cbUseBestAudioInputFormat.UseVisualStyleBackColor = True
        '
        'btAudioInputDeviceSettings
        '
        Me.btAudioInputDeviceSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAudioInputDeviceSettings.Location = New System.Drawing.Point(574, 375)
        Me.btAudioInputDeviceSettings.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btAudioInputDeviceSettings.Name = "btAudioInputDeviceSettings"
        Me.btAudioInputDeviceSettings.Size = New System.Drawing.Size(152, 44)
        Me.btAudioInputDeviceSettings.TabIndex = 82
        Me.btAudioInputDeviceSettings.Text = "Settings"
        Me.btAudioInputDeviceSettings.UseVisualStyleBackColor = True
        '
        'cbAudioInputLine
        '
        Me.cbAudioInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputLine.FormattingEnabled = True
        Me.cbAudioInputLine.Location = New System.Drawing.Point(18, 483)
        Me.cbAudioInputLine.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudioInputLine.Name = "cbAudioInputLine"
        Me.cbAudioInputLine.Size = New System.Drawing.Size(318, 33)
        Me.cbAudioInputLine.TabIndex = 81
        '
        'cbAudioInputFormat
        '
        Me.cbAudioInputFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAudioInputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputFormat.FormattingEnabled = True
        Me.cbAudioInputFormat.Location = New System.Drawing.Point(366, 481)
        Me.cbAudioInputFormat.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudioInputFormat.Name = "cbAudioInputFormat"
        Me.cbAudioInputFormat.Size = New System.Drawing.Size(356, 33)
        Me.cbAudioInputFormat.TabIndex = 80
        '
        'cbAudioInputDevice
        '
        Me.cbAudioInputDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAudioInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAudioInputDevice.FormattingEnabled = True
        Me.cbAudioInputDevice.Location = New System.Drawing.Point(18, 379)
        Me.cbAudioInputDevice.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.cbAudioInputDevice.Name = "cbAudioInputDevice"
        Me.cbAudioInputDevice.Size = New System.Drawing.Size(540, 33)
        Me.cbAudioInputDevice.TabIndex = 79
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(12, 440)
        Me.label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(160, 25)
        Me.label22.TabIndex = 78
        Me.label22.Text = "Audio input line"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(12, 333)
        Me.label23.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(189, 25)
        Me.label23.TabIndex = 77
        Me.label23.Text = "Audio input device"
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(360, 437)
        Me.label25.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(125, 25)
        Me.label25.TabIndex = 76
        Me.label25.Text = "Input format"
        '
        'btStart
        '
        Me.btStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStart.Location = New System.Drawing.Point(778, 790)
        Me.btStart.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btStart.Name = "btStart"
        Me.btStart.Size = New System.Drawing.Size(124, 44)
        Me.btStart.TabIndex = 61
        Me.btStart.Text = "Start"
        Me.btStart.UseVisualStyleBackColor = True
        '
        'btStop
        '
        Me.btStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btStop.Location = New System.Drawing.Point(908, 790)
        Me.btStop.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btStop.Name = "btStop"
        Me.btStop.Size = New System.Drawing.Size(124, 44)
        Me.btStop.TabIndex = 62
        Me.btStop.Text = "Stop"
        Me.btStop.UseVisualStyleBackColor = True
        '
        'tcMain
        '
        Me.tcMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Controls.Add(Me.tabPage1)
        Me.tcMain.Controls.Add(Me.tabPage2)
        Me.tcMain.Controls.Add(Me.tabPage3)
        Me.tcMain.Controls.Add(Me.tabPage5)
        Me.tcMain.Controls.Add(Me.tabPage4)
        Me.tcMain.Location = New System.Drawing.Point(6, 15)
        Me.tcMain.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(756, 827)
        Me.tcMain.TabIndex = 57
        '
        'llVideoTutorials
        '
        Me.llVideoTutorials.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llVideoTutorials.AutoSize = True
        Me.llVideoTutorials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.llVideoTutorials.Location = New System.Drawing.Point(1534, 15)
        Me.llVideoTutorials.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.llVideoTutorials.Name = "llVideoTutorials"
        Me.llVideoTutorials.Size = New System.Drawing.Size(138, 25)
        Me.llVideoTutorials.TabIndex = 92
        Me.llVideoTutorials.TabStop = True
        Me.llVideoTutorials.Text = "Video tutorial"
        '
        'label34
        '
        Me.label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(972, 15)
        Me.label34.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(433, 25)
        Me.label34.TabIndex = 103
        Me.label34.Text = "Much more features available in Main Demo"
        '
        'btSaveScreenshot
        '
        Me.btSaveScreenshot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btSaveScreenshot.Location = New System.Drawing.Point(1430, 790)
        Me.btSaveScreenshot.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btSaveScreenshot.Name = "btSaveScreenshot"
        Me.btSaveScreenshot.Size = New System.Drawing.Size(240, 44)
        Me.btSaveScreenshot.TabIndex = 112
        Me.btSaveScreenshot.Text = "Save snapshot"
        Me.btSaveScreenshot.UseVisualStyleBackColor = True
        '
        'btResume
        '
        Me.btResume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btResume.Location = New System.Drawing.Point(1234, 790)
        Me.btResume.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btResume.Name = "btResume"
        Me.btResume.Size = New System.Drawing.Size(110, 44)
        Me.btResume.TabIndex = 111
        Me.btResume.Text = "Resume"
        Me.btResume.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPause.Location = New System.Drawing.Point(1112, 790)
        Me.btPause.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(110, 44)
        Me.btPause.TabIndex = 110
        Me.btPause.Text = "Pause"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'lbTimestamp
        '
        Me.lbTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTimestamp.AutoSize = True
        Me.lbTimestamp.Location = New System.Drawing.Point(1106, 746)
        Me.lbTimestamp.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbTimestamp.Name = "lbTimestamp"
        Me.lbTimestamp.Size = New System.Drawing.Size(252, 25)
        Me.lbTimestamp.TabIndex = 109
        Me.lbTimestamp.Text = "Recording time: 00:00:00"
        '
        'rbCapture
        '
        Me.rbCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbCapture.AutoSize = True
        Me.rbCapture.Location = New System.Drawing.Point(921, 742)
        Me.rbCapture.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.rbCapture.Name = "rbCapture"
        Me.rbCapture.Size = New System.Drawing.Size(119, 29)
        Me.rbCapture.TabIndex = 108
        Me.rbCapture.Text = "Capture"
        Me.rbCapture.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(785, 742)
        Me.rbPreview.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(119, 29)
        Me.rbPreview.TabIndex = 107
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'VideoView1
        '
        Me.VideoView1.BackColor = System.Drawing.Color.Black
        Me.VideoView1.Location = New System.Drawing.Point(778, 58)
        Me.VideoView1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.VideoView1.Name = "VideoView1"
        Me.VideoView1.Size = New System.Drawing.Size(892, 646)
        Me.VideoView1.StatusOverlay = Nothing
        Me.VideoView1.TabIndex = 113
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1694, 860)
        Me.Controls.Add(Me.VideoView1)
        Me.Controls.Add(Me.btSaveScreenshot)
        Me.Controls.Add(Me.btResume)
        Me.Controls.Add(Me.btPause)
        Me.Controls.Add(Me.lbTimestamp)
        Me.Controls.Add(Me.rbCapture)
        Me.Controls.Add(Me.rbPreview)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.llVideoTutorials)
        Me.Controls.Add(Me.btStart)
        Me.Controls.Add(Me.btStop)
        Me.Controls.Add(Me.tcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form1"
        Me.Text = "Simple Video Capture Demo - Video Capture SDK .Net"
        CType(Me.tbAudAmplifyAmp,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage72.ResumeLayout(false)
        Me.tabPage72.PerformLayout
        CType(Me.tbAudEq9,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudEq0,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage3.ResumeLayout(false)
        Me.tabPage3.PerformLayout
        CType(Me.tbDarkness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbContrast,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbLightness,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbSaturation,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage71.ResumeLayout(false)
        Me.tabPage71.PerformLayout
        Me.tabControl18.ResumeLayout(false)
        Me.tabPage76.ResumeLayout(false)
        Me.tabPage76.PerformLayout
        CType(Me.tbAudTrueBass,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPage5.ResumeLayout(false)
        Me.tabPage4.ResumeLayout(false)
        Me.tabPage4.PerformLayout
        Me.tabPage2.ResumeLayout(false)
        Me.tabPage2.PerformLayout
        Me.tabPage1.ResumeLayout(false)
        Me.tabPage1.PerformLayout
        CType(Me.tbAudioBalance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tbAudioVolume,System.ComponentModel.ISupportInitialize).EndInit
        Me.tcMain.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents label231 As System.Windows.Forms.Label
    Private WithEvents cbAudEqualizerPreset As System.Windows.Forms.ComboBox
    Private WithEvents label242 As System.Windows.Forms.Label
    Private WithEvents label230 As System.Windows.Forms.Label
    Private WithEvents tbAudAmplifyAmp As System.Windows.Forms.TrackBar
    Private WithEvents label95 As System.Windows.Forms.Label
    Private WithEvents label243 As System.Windows.Forms.Label
    Private WithEvents label241 As System.Windows.Forms.Label
    Private WithEvents label240 As System.Windows.Forms.Label
    Private WithEvents label239 As System.Windows.Forms.Label
    Private WithEvents label238 As System.Windows.Forms.Label
    Private WithEvents label237 As System.Windows.Forms.Label
    Private WithEvents label236 As System.Windows.Forms.Label
    Private WithEvents label235 As System.Windows.Forms.Label
    Private WithEvents label234 As System.Windows.Forms.Label
    Private WithEvents label233 As System.Windows.Forms.Label
    Private WithEvents btAudEqRefresh As System.Windows.Forms.Button
    Private WithEvents tabPage72 As System.Windows.Forms.TabPage
    Private WithEvents label232 As System.Windows.Forms.Label
    Private WithEvents tbAudEq9 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq8 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq7 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq6 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq5 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq4 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq3 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq2 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq1 As System.Windows.Forms.TrackBar
    Private WithEvents tbAudEq0 As System.Windows.Forms.TrackBar
    Private WithEvents cbAudEqualizerEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents cbAudAmplifyEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage71 As System.Windows.Forms.TabPage
    Private WithEvents tabControl18 As System.Windows.Forms.TabControl
    Private WithEvents tabPage76 As System.Windows.Forms.TabPage
    Private WithEvents tbAudTrueBass As System.Windows.Forms.TrackBar
    Private WithEvents label254 As System.Windows.Forms.Label
    Private WithEvents cbAudTrueBassEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents fontDialog1 As System.Windows.Forms.FontDialog
    Private WithEvents openFileDialog2 As System.Windows.Forms.OpenFileDialog
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cbUseBestVideoInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents btVideoCaptureDeviceSettings As System.Windows.Forms.Button
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbVideoInputFrameRate As System.Windows.Forms.ComboBox
    Private WithEvents cbVideoInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents cbVideoInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label55 As System.Windows.Forms.Label
    Private WithEvents label54 As System.Windows.Forms.Label
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents tbAudioBalance As System.Windows.Forms.TrackBar
    Private WithEvents tbAudioVolume As System.Windows.Forms.TrackBar
    Private WithEvents cbRecordAudio As System.Windows.Forms.CheckBox
    Private WithEvents cbAudioOutputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents cbUseBestAudioInputFormat As System.Windows.Forms.CheckBox
    Private WithEvents btAudioInputDeviceSettings As System.Windows.Forms.Button
    Private WithEvents cbAudioInputLine As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputFormat As System.Windows.Forms.ComboBox
    Private WithEvents cbAudioInputDevice As System.Windows.Forms.ComboBox
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents btStart As System.Windows.Forms.Button
    Private WithEvents btStop As System.Windows.Forms.Button
    Private WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents llVideoTutorials As System.Windows.Forms.LinkLabel
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents edOutput As TextBox
    Private WithEvents lbInfo As Label
    Private WithEvents btOutputConfigure As Button
    Private WithEvents cbOutputFormat As ComboBox
    Private WithEvents label4 As Label
    Private WithEvents label7 As Label
    Private WithEvents btSelectOutput As Button
    Private WithEvents cbDebugMode As CheckBox
    Private WithEvents mmLog As TextBox
    Private WithEvents btSaveScreenshot As Button
    Private WithEvents btResume As Button
    Private WithEvents btPause As Button
    Private WithEvents lbTimestamp As Label
    Private WithEvents rbCapture As RadioButton
    Private WithEvents rbPreview As RadioButton
    Private WithEvents Label5 As Label
    Private WithEvents cbFlipY As CheckBox
    Private WithEvents cbFlipX As CheckBox
    Private WithEvents cbInvert As CheckBox
    Private WithEvents cbGreyscale As CheckBox
    Private WithEvents label201 As Label
    Private WithEvents tbDarkness As TrackBar
    Private WithEvents label200 As Label
    Private WithEvents label199 As Label
    Private WithEvents label198 As Label
    Private WithEvents tbContrast As TrackBar
    Private WithEvents tbLightness As TrackBar
    Private WithEvents tbSaturation As TrackBar
    Private WithEvents label3 As Label
    Private WithEvents btTextLogoAdd As Button
    Private WithEvents btLogoRemove As Button
    Private WithEvents btLogoEdit As Button
    Private WithEvents lbLogos As ListBox
    Private WithEvents btImageLogoAdd As Button
    Private WithEvents cbMergeTextLogos As CheckBox
    Private WithEvents cbMergeImageLogos As CheckBox
    Friend WithEvents VideoView1 As VisioForge.Core.UI.WinForms.VideoView
End Class
