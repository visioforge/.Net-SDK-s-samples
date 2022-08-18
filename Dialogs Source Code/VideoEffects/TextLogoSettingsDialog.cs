// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextLogoSettingsDialog.cs" company="VisioForge">
//   VisioForge (c) 2006 - 2021
// </copyright>
// <summary>
//   Defines the TextLogoSettingsDialog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.VideoEdit;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.VideoEffects;

    /// <summary>
    /// Text logo settings dialog.
    /// </summary>
    public partial class TextLogoSettingsDialog : Form, IVideoEffectsSettingsDialog
    {
        private const string NAME = "TextLogo";

        private IVideoEffectTextLogo _intf;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextLogoSettingsDialog"/> class.
        /// </summary>
        public TextLogoSettingsDialog()
        {
            InitializeComponent();

            cbTextLogoAlign.SelectedIndex = 0;
            cbTextLogoAntialiasing.SelectedIndex = 0;
            cbTextLogoDrawMode.SelectedIndex = 0;
            cbTextLogoEffectrMode.SelectedIndex = 0;
            cbTextLogoGradMode.SelectedIndex = 0;
            cbTextLogoShapeType.SelectedIndex = 0;
        }

        /// <summary>
        /// Attaches video effect.
        /// </summary>
        /// <param name="effect">
        /// Effect.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void Attach(IVideoEffect effect)
        {
            _intf = effect as IVideoEffectTextLogo;
            if (_intf == null)
            {
                return;
            }

            StringFormat formatFlags = _intf.StringFormat;

            cbTextLogoVertical.Checked = (formatFlags.FormatFlags & StringFormatFlags.DirectionVertical) != 0;
            cbTextLogoRightToLeft.Checked = (formatFlags.FormatFlags & StringFormatFlags.DirectionRightToLeft) != 0;
            cbTextLogoAlign.SelectedIndex = (int)formatFlags.Alignment;
            edTextLogo.Text = _intf.Text;
            edTextLogoLeft.Text = _intf.Left.ToString();
            edTextLogoTop.Text = _intf.Top.ToString();
            fontDialog1.Font = _intf.Font;
            fontDialog1.Color = _intf.FontColor;
            cbTextLogoTranspBG.Checked = _intf.BackgroundTransparent;

            pnTextLogoBGColor.BackColor = _intf.BackgroundColor;
            cbTextLogoAntialiasing.SelectedIndex = (int)_intf.Antialiasing;
            cbTextLogoDrawMode.SelectedIndex = (int)_intf.DrawQuality;

            if (_intf.RectWidth > 0 && _intf.RectHeight > 0)
            {
                edTextLogoWidth.Text = _intf.RectWidth.ToString();
                edTextLogoHeight.Text = _intf.RectHeight.ToString();
            }
            else
            {
                edTextLogoWidth.Text = "0";
                edTextLogoHeight.Text = "0";
            }

            switch (_intf.RotationMode)
            {
                case TextRotationMode.RmNone:
                    rbTextLogoDegree0.Checked = true;
                    break;
                case TextRotationMode.Rm90:
                    rbTextLogoDegree90.Checked = true;
                    break;
                case TextRotationMode.Rm180:
                    rbTextLogoDegree180.Checked = true;
                    break;
                case TextRotationMode.Rm270:
                    rbTextLogoDegree270.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (_intf.FlipMode)
            {
                case TextFlipMode.None:
                    rbTextLogoFlipNone.Checked = true;
                    break;
                case TextFlipMode.X:
                    rbTextLogoFlipX.Checked = true;
                    break;
                case TextFlipMode.Y:
                    rbTextLogoFlipY.Checked = true;
                    break;
                case TextFlipMode.XAndY:
                    rbTextLogoFlipXY.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cbTextLogoGradientEnabled.Checked = _intf.GradientEnabled;
            cbTextLogoGradMode.SelectedIndex = (int)_intf.GradientMode;
            pnTextLogoGradColor1.BackColor = _intf.GradientColor1;
            pnTextLogoGradColor2.BackColor = _intf.GradientColor2;

            cbTextLogoEffectrMode.SelectedIndex = (int)_intf.BorderMode;
            pnTextLogoInnerColor.BackColor = _intf.BorderInnerColor;
            pnTextLogoOuterColor.BackColor = _intf.BorderOuterColor;
            edTextLogoInnerSize.Text = _intf.BorderInnerSize.ToString();
            edTextLogoOuterSize.Text = _intf.BorderOuterSize.ToString();

            cbTextLogoShapeEnabled.Checked = _intf.Shape;
            edTextLogoShapeLeft.Text = _intf.ShapeLeft.ToString();
            edTextLogoShapeTop.Text = _intf.ShapeTop.ToString();
            cbTextLogoShapeType.SelectedIndex = (int)_intf.ShapeType;
            edTextLogoShapeWidth.Text = _intf.ShapeWidth.ToString();
            edTextLogoShapeHeight.Text = _intf.ShapeHeight.ToString();
            pnTextLogoShapeColor.BackColor = _intf.ShapeColor;

            tbTextLogoTransp.Value = _intf.TransparencyLevel;

            switch (_intf.Mode)
            {
                case TextLogoMode.Text:
                    rbTextLogoDrawText.Checked = true;
                    break;
                case TextLogoMode.DateTime:
                    rbTextLogoDrawDate.Checked = true;
                    break;
                case TextLogoMode.Timestamp:
                    rbTextLogoDrawTimestamp.Checked = true;
                    break;
                case TextLogoMode.FrameNumber:
                    rbTextLogoDrawFrameNumber.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cbTextLogoFadeIn.Checked = _intf.FadeIn;
            cbTextLogoFadeOut.Checked = _intf.FadeOut;
        }

        /// <summary>
        /// Fills effect.
        /// </summary>
        /// <param name="effect">
        /// Effect.
        /// </param>
        public void Fill(IVideoEffect effect)
        {
            _intf = effect as IVideoEffectTextLogo;
            EffectUpdate(_intf);
        }

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// Returns <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Exception.
        /// </exception>
        public string GenerateNewEffectName(IVideoCaptureCore core)
        {
            if (core == null)
            {
                throw new Exception("core is null");
            }

            string name = NAME;

            var eff = core.GetCore().Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.GetCore().Video_Effects_Get(name);
                }
            }

            return name;
        }

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// Returns <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Exception.
        /// </exception>
        public string GenerateNewEffectName(IMediaPlayerCore core)
        {
            if (core == null)
            {
                throw new Exception("core is null");
            }

            string name = NAME;

            var eff = core.GetCore()?.Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.GetCore().Video_Effects_Get(name);
                }
            }

            return name;
        }

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// Returns <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Exception.
        /// </exception>
        public string GenerateNewEffectName(IVideoEditCore core)
        {
            if (core == null)
            {
                throw new Exception("core is null");
            }

            string name = NAME;

            var eff = core.GetCore()?.Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.GetCore().Video_Effects_Get(name);
                }
            }

            return name;
        }

        private void EffectUpdate(IVideoEffectTextLogo textLogo)
        {
            if (textLogo == null)
            {
                MessageBox.Show("Unable to configure text logo effect.");
                return;
            }

            TextRotationMode rotate;
            TextFlipMode flip;

            StringFormat formatFlags = new StringFormat();

            if (cbTextLogoVertical.Checked)
            {
                formatFlags.FormatFlags |= StringFormatFlags.DirectionVertical;
            }

            if (cbTextLogoRightToLeft.Checked)
            {
                formatFlags.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }

            formatFlags.Alignment = (StringAlignment)cbTextLogoAlign.SelectedIndex;

            textLogo.Enabled = true;
            textLogo.Text = edTextLogo.Text;
            textLogo.Left = Convert.ToInt32(edTextLogoLeft.Text);
            textLogo.Top = Convert.ToInt32(edTextLogoTop.Text);
            textLogo.Font = fontDialog1.Font;
            textLogo.FontColor = fontDialog1.Color;

            textLogo.BackgroundTransparent = cbTextLogoTranspBG.Checked;
            textLogo.BackgroundColor = pnTextLogoBGColor.BackColor;
            textLogo.StringFormat = formatFlags;
            textLogo.Antialiasing = (TextRenderingHint)cbTextLogoAntialiasing.SelectedIndex;
            textLogo.DrawQuality = (InterpolationMode)cbTextLogoDrawMode.SelectedIndex;

            if (cbTextLogoUseRect.Checked)
            {
                textLogo.RectWidth = Convert.ToInt32(edTextLogoWidth.Text);
                textLogo.RectHeight = Convert.ToInt32(edTextLogoHeight.Text);
            }
            else
            {
                textLogo.RectWidth = 0;
                textLogo.RectHeight = 0;
            }

            if (rbTextLogoDegree0.Checked)
            {
                rotate = TextRotationMode.RmNone;
            }
            else if (rbTextLogoDegree90.Checked)
            {
                rotate = TextRotationMode.Rm90;
            }
            else if (rbTextLogoDegree180.Checked)
            {
                rotate = TextRotationMode.Rm180;
            }
            else
            {
                rotate = TextRotationMode.Rm270;
            }

            if (rbTextLogoFlipNone.Checked)
            {
                flip = TextFlipMode.None;
            }
            else if (rbTextLogoFlipX.Checked)
            {
                flip = TextFlipMode.X;
            }
            else if (rbTextLogoFlipY.Checked)
            {
                flip = TextFlipMode.Y;
            }
            else
            {
                flip = TextFlipMode.XAndY;
            }

            textLogo.RotationMode = rotate;
            textLogo.FlipMode = flip;

            textLogo.GradientEnabled = cbTextLogoGradientEnabled.Checked;
            textLogo.GradientMode = (TextGradientMode)cbTextLogoGradMode.SelectedIndex;
            textLogo.GradientColor1 = pnTextLogoGradColor1.BackColor;
            textLogo.GradientColor2 = pnTextLogoGradColor2.BackColor;

            textLogo.BorderMode = (TextEffectMode)cbTextLogoEffectrMode.SelectedIndex;
            textLogo.BorderInnerColor = pnTextLogoInnerColor.BackColor;
            textLogo.BorderOuterColor = pnTextLogoOuterColor.BackColor;
            textLogo.BorderInnerSize = Convert.ToInt32(edTextLogoInnerSize.Text);
            textLogo.BorderOuterSize = Convert.ToInt32(edTextLogoOuterSize.Text);

            textLogo.Shape = cbTextLogoShapeEnabled.Checked;
            textLogo.ShapeLeft = Convert.ToInt32(edTextLogoShapeLeft.Text);
            textLogo.ShapeTop = Convert.ToInt32(edTextLogoShapeTop.Text);
            textLogo.ShapeType = (TextShapeType)cbTextLogoShapeType.SelectedIndex;
            textLogo.ShapeWidth = Convert.ToInt32(edTextLogoShapeWidth.Text);
            textLogo.ShapeHeight = Convert.ToInt32(edTextLogoShapeHeight.Text);
            textLogo.ShapeColor = pnTextLogoShapeColor.BackColor;

            textLogo.TransparencyLevel = tbTextLogoTransp.Value;

            if (rbTextLogoDrawText.Checked)
            {
                textLogo.Mode = TextLogoMode.Text;
            }
            else if (rbTextLogoDrawDate.Checked)
            {
                textLogo.Mode = TextLogoMode.DateTime;
                textLogo.DateTimeMask = "yyyy-MM-dd. hh:mm:ss";
            }
            else if (rbTextLogoDrawFrameNumber.Checked)
            {
                textLogo.Mode = TextLogoMode.FrameNumber;
            }
            else
            {
                textLogo.Mode = TextLogoMode.Timestamp;
            }

            if (cbTextLogoFadeIn.Checked)
            {
                textLogo.FadeIn = true;
                textLogo.FadeInDuration = TimeSpan.FromSeconds(5);
            }
            else
            {
                textLogo.FadeIn = false;
            }

            if (cbTextLogoFadeOut.Checked)
            {
                textLogo.FadeOut = true;
                textLogo.FadeOutDuration = TimeSpan.FromSeconds(5);
            }
            else
            {
                textLogo.FadeOut = false;
            }

            textLogo.Update();
        }

        private void pnTextLogoBGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoBGColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoBGColor.BackColor = colorDialog1.Color;
            }
        }

        private void pnTextLogoGradColor1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoGradColor1.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoGradColor1.BackColor = colorDialog1.Color;
            }
        }

        private void pnTextLogoGradColor2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoGradColor2.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoGradColor2.BackColor = colorDialog1.Color;
            }
        }

        private void pnTextLogoInnerColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoInnerColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoInnerColor.BackColor = colorDialog1.Color;
            }
        }

        private void pnTextLogoOuterColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoOuterColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoOuterColor.BackColor = colorDialog1.Color;
            }
        }

        private void pnTextLogoShapeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnTextLogoShapeColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextLogoShapeColor.BackColor = colorDialog1.Color;
            }
        }

        private void btFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                edTextLogo.Font = fontDialog1.Font;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (_intf != null)
            {
                EffectUpdate(_intf);
            }

            Close();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (_intf != null)
            {
                EffectUpdate(_intf);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }
}
