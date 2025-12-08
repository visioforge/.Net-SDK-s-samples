' --------------------------------------------------------------------------------------------------------------------
' <copyright file="ImageLogoSettingsDialog.vb" company="VisioForge">
'   VisioForge (c) 2006 - 2021
' </copyright>
' <summary>
'   Image logo settings dialog.
' </summary>
' --------------------------------------------------------------------------------------------------------------------

Namespace VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
    Imports System
    Imports System.Diagnostics
    Imports System.Drawing
    Imports System.IO
    Imports System.Windows.Forms

    Imports VisioForge.Core.MediaPlayer
    Imports VisioForge.Core.VideoCapture
    Imports VisioForge.Core.VideoEdit
    Imports VisioForge.Core.Types.VideoEffects

    ''' <summary>
    ''' Image logo settings dialog.
    ''' </summary>
    Public Partial Class ImageLogoSettingsDialog
        Inherits Form
        Implements IVideoEffectsSettingsDialog

        Private Const NAME As String = "ImageLogo"

        Private _intf As IVideoEffectImageLogo

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ImageLogoSettingsDialog"/> class.
        ''' </summary>
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btUpdate_Click(sender As Object, e As EventArgs)
            If _intf IsNot Nothing Then
                EffectUpdate(_intf)
            End If
        End Sub

        Private Sub btClose_Click(sender As Object, e As EventArgs)
            If _intf IsNot Nothing Then
                EffectUpdate(_intf)
            End If

            Close()
        End Sub

        ''' <summary>
        ''' Attaches video effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        Public Sub Attach(effect As IVideoEffect) Implements IVideoEffectsSettingsDialog.Attach
            _intf = TryCast(effect, IVideoEffectImageLogo)
            If _intf Is Nothing Then
                Return
            End If

            edImageLogoFilename.Text = _intf.Filename
            edImageLogoLeft.Text = _intf.Left.ToString()
            edImageLogoTop.Text = _intf.Top.ToString()
            tbImageLogoTransp.Value = _intf.TransparencyLevel
            pnImageLogoColorKey.ForeColor = _intf.ColorKey
            cbImageLogoUseColorKey.Checked = _intf.UseColorKey
            cbImageLogoShowAlways.Checked = _intf.StartTime = TimeSpan.Zero AndAlso _intf.StopTime = TimeSpan.Zero
        End Sub

        ''' <summary>
        ''' Fills video effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        Public Sub Fill(effect As IVideoEffect) Implements IVideoEffectsSettingsDialog.Fill
            _intf = TryCast(effect, IVideoEffectImageLogo)
            EffectUpdate(_intf)
        End Sub

        ''' <summary>
        ''' Generates effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' Returns <see cref="String"/>.
        ''' </returns>
        ''' <exception cref="Exception">
        ''' Exception.
        ''' </exception>
        Public Function GenerateNewEffectName(core As IVideoCaptureCore) As String Implements IVideoEffectsSettingsDialog.GenerateNewEffectName
            If core Is Nothing Then
                Throw New Exception("core is null")
            End If

            Dim name As String = NAME

            Dim eff = core.GetCore()?.Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        ''' <summary>
        ''' Generates effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' Returns <see cref="String"/>.
        ''' </returns>
        ''' <exception cref="Exception">
        ''' Exception.
        ''' </exception>
        Public Overloads Function GenerateNewEffectName(core As IVideoEditCore) As String Implements IVideoEffectsSettingsDialog.GenerateNewEffectName
            If core Is Nothing Then
                Throw New Exception("core is null")
            End If

            Dim name As String = NAME

            Dim eff = core.GetCore()?.Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        ''' <summary>
        ''' Generates effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' Returns <see cref="String"/>.
        ''' </returns>
        ''' <exception cref="Exception">
        ''' Exception.
        ''' </exception>
        Public Overloads Function GenerateNewEffectName(core As IMediaPlayerCore) As String Implements IVideoEffectsSettingsDialog.GenerateNewEffectName
            If core Is Nothing Then
                Throw New Exception("core is null")
            End If

            Dim name As String = NAME

            Dim eff = core.GetCore()?.Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        Private Sub EffectUpdate(imageLogo As IVideoEffectImageLogo)
            If imageLogo Is Nothing Then
                MessageBox.Show("Unable to configure image logo effect.")
                Return
            End If

            If Not File.Exists(edImageLogoFilename.Text) Then
                imageLogo.Enabled = False
                Return
            End If

            imageLogo.Enabled = True
            imageLogo.Filename = edImageLogoFilename.Text
            imageLogo.Left = Convert.ToUInt32(edImageLogoLeft.Text)
            imageLogo.Top = Convert.ToUInt32(edImageLogoTop.Text)
            imageLogo.TransparencyLevel = tbImageLogoTransp.Value
            imageLogo.ColorKey = pnImageLogoColorKey.ForeColor
            imageLogo.UseColorKey = cbImageLogoUseColorKey.Checked
            imageLogo.AnimationEnabled = True

            If cbImageLogoShowAlways.Checked Then
                imageLogo.StartTime = TimeSpan.Zero
                imageLogo.StopTime = TimeSpan.Zero
            Else
                imageLogo.StartTime = TimeSpan.FromMilliseconds(Convert.ToUInt64(edImageLogoStartTime.Text))
                imageLogo.StopTime = TimeSpan.FromMilliseconds(Convert.ToUInt64(edImageLogoStopTime.Text))
            End If

            imageLogo.Update()
        End Sub

        Private Sub cbImageLogoShowAlways_CheckedChanged(sender As Object, e As EventArgs)
            edImageLogoStartTime.Enabled = Not cbImageLogoShowAlways.Checked
            edImageLogoStopTime.Enabled = Not cbImageLogoShowAlways.Checked
            lbGraphicLogoStartTime.Enabled = Not cbImageLogoShowAlways.Checked
            lbGraphicLogoStopTime.Enabled = Not cbImageLogoShowAlways.Checked
        End Sub

        Private Sub btSelectImage_Click(sender As Object, e As EventArgs)
            If openFileDialog2.ShowDialog() = DialogResult.OK Then
                edImageLogoFilename.Text = openFileDialog2.FileName
                imgPreview.Image = New Bitmap(openFileDialog2.FileName)
            End If
        End Sub

        Private Sub pnGraphicLogoColorKey_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnImageLogoColorKey.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnImageLogoColorKey.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
            Const url As String = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code"
            Dim startInfo = New ProcessStartInfo("explorer.exe", url)
            Process.Start(startInfo)
        End Sub
    End Class
End Namespace
