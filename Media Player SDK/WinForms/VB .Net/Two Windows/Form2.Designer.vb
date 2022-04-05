Imports VisioForge.Core.Types

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbLicensing = New System.Windows.Forms.CheckBox()
        Me.mmError = New System.Windows.Forms.TextBox()
        Me.pnScreen = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbLicensing)
        Me.GroupBox1.Controls.Add(Me.mmError)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 706)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(950, 225)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Errors and warnings"
        '
        'cbLicensing
        '
        Me.cbLicensing.AutoSize = True
        Me.cbLicensing.Location = New System.Drawing.Point(756, 37)
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
        Me.mmError.Size = New System.Drawing.Size(922, 129)
        Me.mmError.TabIndex = 3
        '
        'pnScreen
        '
        Me.pnScreen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnScreen.BackColor = System.Drawing.Color.Black
        Me.pnScreen.Location = New System.Drawing.Point(24, 23)
        Me.pnScreen.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pnScreen.Name = "pnScreen"
        Me.pnScreen.Size = New System.Drawing.Size(950, 671)
        Me.pnScreen.TabIndex = 2
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(998, 954)
        Me.Controls.Add(Me.pnScreen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form2"
        Me.Text = "Media Player SDK .Net - Two Windows Demo"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents mmError As System.Windows.Forms.TextBox
    Private WithEvents cbLicensing As CheckBox
    Friend WithEvents pnScreen As Panel
End Class
