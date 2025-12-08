' --------------------------------------------------------------------------------------------------------------------
' <copyright file="TextLogoSettingsDialog.vb" company="VisioForge">
'   VisioForge (c) 2006 - 2021
' </copyright>
' <summary>
'   Defines the TextLogoSettingsDialog type.
' </summary>
' --------------------------------------------------------------------------------------------------------------------

Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Imports VisioForge.Core.MediaPlayer
Imports VisioForge.Core.VideoCapture
Imports VisioForge.Core.VideoEdit
Imports VisioForge.Core.Types
Imports VisioForge.Core.Types.VideoEffects

Namespace VisioForge.Core.UI.WinForms.Dialogs.VideoEffects

    ''' <summary>
    ''' Text logo settings dialog.
    ''' </summary>
    Public Partial Class TextLogoSettingsDialog
        Inherits Form
        Implements IVideoEffectsSettingsDialog

        Private Const EFFECT_NAME As String = "TextLogo"

        Private _intf As IVideoEffectTextLogo

        ''' <summary>
        ''' Initializes a new instance of the <see cref="TextLogoSettingsDialog"/> class.
        ''' </summary>
        Public Sub New()
            InitializeComponent()

            cbTextLogoAlign.SelectedIndex = 0
            cbTextLogoAntialiasing.SelectedIndex = 4
            cbTextLogoDrawMode.SelectedIndex = 0
            cbTextLogoEffectrMode.SelectedIndex = 0
            cbTextLogoGradMode.SelectedIndex = 0
            cbTextLogoShapeType.SelectedIndex = 0
        End Sub

        ''' <summary>
        ''' Attaches video effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        ''' <exception cref="ArgumentOutOfRangeException">
        ''' ArgumentOutOfRangeException.
        ''' </exception>
        Public Sub Attach(effect As IVideoEffect) Implements IVideoEffectsSettingsDialog.Attach
            _intf = TryCast(effect, IVideoEffectTextLogo)
            If _intf Is Nothing Then
                Return
            End If

            Dim formatFlags As StringFormat = _intf.StringFormat

            cbTextLogoVertical.Checked = (formatFlags.FormatFlags And StringFormatFlags.DirectionVertical) <> 0
            cbTextLogoRightToLeft.Checked = (formatFlags.FormatFlags And StringFormatFlags.DirectionRightToLeft) <> 0
            cbTextLogoAlign.SelectedIndex = CInt(formatFlags.Alignment)
            edTextLogo.Text = _intf.Text
            edTextLogoLeft.Text = _intf.Left.ToString()
            edTextLogoTop.Text = _intf.Top.ToString()
            fontDialog1.Font = _intf.Font
            fontDialog1.Color = _intf.FontColor
            cbTextLogoTranspBG.Checked = _intf.BackgroundTransparent

            pnTextLogoBGColor.BackColor = _intf.BackgroundColor
            cbTextLogoAntialiasing.SelectedIndex = CInt(_intf.Antialiasing)
            cbTextLogoDrawMode.SelectedIndex = CInt(_intf.DrawQuality)

            If _intf.RectWidth > 0 AndAlso _intf.RectHeight > 0 Then
                edTextLogoWidth.Text = _intf.RectWidth.ToString()
                edTextLogoHeight.Text = _intf.RectHeight.ToString()
            Else
                edTextLogoWidth.Text = "0"
                edTextLogoHeight.Text = "0"
            End If

            Select Case _intf.RotationMode
                Case TextRotationMode.RmNone
                    rbTextLogoDegree0.Checked = True
                Case TextRotationMode.Rm90
                    rbTextLogoDegree90.Checked = True
                Case TextRotationMode.Rm180
                    rbTextLogoDegree180.Checked = True
                Case TextRotationMode.Rm270
                    rbTextLogoDegree270.Checked = True
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select

            Select Case _intf.FlipMode
                Case TextFlipMode.None
                    rbTextLogoFlipNone.Checked = True
                Case TextFlipMode.X
                    rbTextLogoFlipX.Checked = True
                Case TextFlipMode.Y
                    rbTextLogoFlipY.Checked = True
                Case TextFlipMode.XAndY
                    rbTextLogoFlipXY.Checked = True
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select

            cbTextLogoGradientEnabled.Checked = _intf.GradientEnabled
            cbTextLogoGradMode.SelectedIndex = CInt(_intf.GradientMode)
            pnTextLogoGradColor1.BackColor = _intf.GradientColor1
            pnTextLogoGradColor2.BackColor = _intf.GradientColor2

            cbTextLogoEffectrMode.SelectedIndex = CInt(_intf.BorderMode)
            pnTextLogoInnerColor.BackColor = _intf.BorderInnerColor
            pnTextLogoOuterColor.BackColor = _intf.BorderOuterColor
            edTextLogoInnerSize.Text = _intf.BorderInnerSize.ToString()
            edTextLogoOuterSize.Text = _intf.BorderOuterSize.ToString()

            cbTextLogoShapeEnabled.Checked = _intf.Shape
            edTextLogoShapeLeft.Text = _intf.ShapeLeft.ToString()
            edTextLogoShapeTop.Text = _intf.ShapeTop.ToString()
            cbTextLogoShapeType.SelectedIndex = CInt(_intf.ShapeType)
            edTextLogoShapeWidth.Text = _intf.ShapeWidth.ToString()
            edTextLogoShapeHeight.Text = _intf.ShapeHeight.ToString()
            pnTextLogoShapeColor.BackColor = _intf.ShapeColor

            tbTextLogoTransp.Value = _intf.TransparencyLevel

            Select Case _intf.Mode
                Case TextLogoMode.Text
                    rbTextLogoDrawText.Checked = True
                Case TextLogoMode.DateTime
                    rbTextLogoDrawDate.Checked = True
                Case TextLogoMode.Timestamp
                    rbTextLogoDrawTimestamp.Checked = True
                Case TextLogoMode.FrameNumber
                    rbTextLogoDrawFrameNumber.Checked = True
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select

            cbTextLogoFadeIn.Checked = _intf.FadeIn
            cbTextLogoFadeOut.Checked = _intf.FadeOut
        End Sub

        ''' <summary>
        ''' Fills effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        Public Sub Fill(effect As IVideoEffect) Implements IVideoEffectsSettingsDialog.Fill
            _intf = TryCast(effect, IVideoEffectTextLogo)
            EffectUpdate(_intf)
        End Sub

        ''' <summary>
        ''' Generates new effect name.
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
        Public Overloads Function GenerateNewEffectName(core As IVideoCaptureCore) As String Implements IVideoEffectsSettingsDialog.GenerateNewEffectName
            If core Is Nothing Then
                Throw New Exception("core is null")
            End If

            Dim name As String = EFFECT_NAME

            Dim eff = core.GetCore().Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{EFFECT_NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        ''' <summary>
        ''' Generates new effect name.
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

            Dim name As String = EFFECT_NAME

            Dim eff = core.GetCore()?.Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{EFFECT_NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        ''' <summary>
        ''' Generates new effect name.
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

            Dim name As String = EFFECT_NAME

            Dim eff = core.GetCore()?.Video_Effects_Get(name)
            If eff IsNot Nothing Then
                Dim k As Integer = 2
                While eff IsNot Nothing
                    name = $"{EFFECT_NAME} {k}"
                    k += 1
                    eff = core.GetCore().Video_Effects_Get(name)
                End While
            End If

            Return name
        End Function

        Private Sub EffectUpdate(textLogo As IVideoEffectTextLogo)
            If textLogo Is Nothing Then
                MessageBox.Show("Unable to configure text logo effect.")
                Return
            End If

            Dim rotate As TextRotationMode
            Dim flip As TextFlipMode

            Dim formatFlags As New StringFormat()

            If cbTextLogoVertical.Checked Then
                formatFlags.FormatFlags = formatFlags.FormatFlags Or StringFormatFlags.DirectionVertical
            End If

            If cbTextLogoRightToLeft.Checked Then
                formatFlags.FormatFlags = formatFlags.FormatFlags Or StringFormatFlags.DirectionRightToLeft
            End If

            formatFlags.Alignment = CType(cbTextLogoAlign.SelectedIndex, StringAlignment)

            textLogo.Enabled = True
            textLogo.Text = edTextLogo.Text
            textLogo.Left = Convert.ToInt32(edTextLogoLeft.Text)
            textLogo.Top = Convert.ToInt32(edTextLogoTop.Text)
            textLogo.Font = fontDialog1.Font
            textLogo.FontColor = fontDialog1.Color

            textLogo.BackgroundTransparent = cbTextLogoTranspBG.Checked
            textLogo.BackgroundColor = pnTextLogoBGColor.BackColor
            textLogo.StringFormat = formatFlags
            textLogo.Antialiasing = CType(cbTextLogoAntialiasing.SelectedIndex, TextRenderingHint)
            textLogo.DrawQuality = CType(cbTextLogoDrawMode.SelectedIndex, InterpolationMode)

            If cbTextLogoUseRect.Checked Then
                textLogo.RectWidth = Convert.ToInt32(edTextLogoWidth.Text)
                textLogo.RectHeight = Convert.ToInt32(edTextLogoHeight.Text)
            Else
                textLogo.RectWidth = 0
                textLogo.RectHeight = 0
            End If

            If rbTextLogoDegree0.Checked Then
                rotate = TextRotationMode.RmNone
            ElseIf rbTextLogoDegree90.Checked Then
                rotate = TextRotationMode.Rm90
            ElseIf rbTextLogoDegree180.Checked Then
                rotate = TextRotationMode.Rm180
            Else
                rotate = TextRotationMode.Rm270
            End If

            If rbTextLogoFlipNone.Checked Then
                flip = TextFlipMode.None
            ElseIf rbTextLogoFlipX.Checked Then
                flip = TextFlipMode.X
            ElseIf rbTextLogoFlipY.Checked Then
                flip = TextFlipMode.Y
            Else
                flip = TextFlipMode.XAndY
            End If

            textLogo.RotationMode = rotate
            textLogo.FlipMode = flip

            textLogo.GradientEnabled = cbTextLogoGradientEnabled.Checked
            textLogo.GradientMode = CType(cbTextLogoGradMode.SelectedIndex, TextGradientMode)
            textLogo.GradientColor1 = pnTextLogoGradColor1.BackColor
            textLogo.GradientColor2 = pnTextLogoGradColor2.BackColor

            textLogo.BorderMode = CType(cbTextLogoEffectrMode.SelectedIndex, TextEffectMode)
            textLogo.BorderInnerColor = pnTextLogoInnerColor.BackColor
            textLogo.BorderOuterColor = pnTextLogoOuterColor.BackColor
            textLogo.BorderInnerSize = Convert.ToInt32(edTextLogoInnerSize.Text)
            textLogo.BorderOuterSize = Convert.ToInt32(edTextLogoOuterSize.Text)

            textLogo.Shape = cbTextLogoShapeEnabled.Checked
            textLogo.ShapeLeft = Convert.ToInt32(edTextLogoShapeLeft.Text)
            textLogo.ShapeTop = Convert.ToInt32(edTextLogoShapeTop.Text)
            textLogo.ShapeType = CType(cbTextLogoShapeType.SelectedIndex, TextShapeType)
            textLogo.ShapeWidth = Convert.ToInt32(edTextLogoShapeWidth.Text)
            textLogo.ShapeHeight = Convert.ToInt32(edTextLogoShapeHeight.Text)
            textLogo.ShapeColor = pnTextLogoShapeColor.BackColor

            textLogo.TransparencyLevel = tbTextLogoTransp.Value

            If rbTextLogoDrawText.Checked Then
                textLogo.Mode = TextLogoMode.Text
            ElseIf rbTextLogoDrawDate.Checked Then
                textLogo.Mode = TextLogoMode.DateTime
                textLogo.DateTimeMask = "yyyy-MM-dd. hh:mm:ss"
            ElseIf rbTextLogoDrawFrameNumber.Checked Then
                textLogo.Mode = TextLogoMode.FrameNumber
            Else
                textLogo.Mode = TextLogoMode.Timestamp
            End If

            If cbTextLogoFadeIn.Checked Then
                textLogo.FadeIn = True
                textLogo.FadeInDuration = TimeSpan.FromSeconds(5)
            Else
                textLogo.FadeIn = False
            End If

            If cbTextLogoFadeOut.Checked Then
                textLogo.FadeOut = True
                textLogo.FadeOutDuration = TimeSpan.FromSeconds(5)
            Else
                textLogo.FadeOut = False
            End If

            textLogo.Update()
        End Sub

        Private Sub pnTextLogoBGColor_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoBGColor.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoBGColor.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub pnTextLogoGradColor1_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoGradColor1.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoGradColor1.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub pnTextLogoGradColor2_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoGradColor2.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoGradColor2.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub pnTextLogoInnerColor_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoInnerColor.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoInnerColor.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub pnTextLogoOuterColor_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoOuterColor.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoOuterColor.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub pnTextLogoShapeColor_Click(sender As Object, e As EventArgs)
            colorDialog1.Color = pnTextLogoShapeColor.BackColor

            If colorDialog1.ShowDialog() = DialogResult.OK Then
                pnTextLogoShapeColor.BackColor = colorDialog1.Color
            End If
        End Sub

        Private Sub btFont_Click(sender As Object, e As EventArgs)
            If fontDialog1.ShowDialog() = DialogResult.OK Then
                edTextLogo.Font = fontDialog1.Font
            End If
        End Sub

        Private Sub btClose_Click(sender As Object, e As EventArgs)
            If _intf IsNot Nothing Then
                EffectUpdate(_intf)
            End If

            Close()
        End Sub

        Private Sub btUpdate_Click(sender As Object, e As EventArgs)
            If _intf IsNot Nothing Then
                EffectUpdate(_intf)
            End If
        End Sub

        Private Sub linkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
            Const url As String = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code"
            Dim startInfo = New ProcessStartInfo("explorer.exe", url)
            Process.Start(startInfo)
        End Sub
    End Class
End Namespace
