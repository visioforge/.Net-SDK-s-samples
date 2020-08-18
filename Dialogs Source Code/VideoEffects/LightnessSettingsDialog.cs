using System;
using System.Windows.Forms;
using VisioForge.Controls.MediaPlayer;
using VisioForge.Controls.VideoCapture;
using VisioForge.Controls.VideoEdit;
using VisioForge.Types.VideoEffects;

namespace VisioForge.Controls.UI.Dialogs.VideoEffects
{
    public partial class LightnessSettingsDialog : Form, IVFVideoEffectsSettingsDialog
    {
        private const string NAME = "Lightness";

        private IVFVideoEffectLightness _intf;

        public LightnessSettingsDialog()
        {
            InitializeComponent();
        }

        public void Attach(IVFVideoEffect intf)
        {
            _intf = intf as IVFVideoEffectLightness;

            if (_intf == null)
            {
                return;
            }

            tbLightness.Value = _intf.Value;
        }

        public void Fill(IVFVideoEffect effect)
        {
            _intf = effect as IVFVideoEffectLightness;
            EffectUpdate(_intf);
        }

        private void EffectUpdate(IVFVideoEffectLightness effect)
        {
            if (effect == null)
            {
                MessageBox.Show("Unable to configure lightness effect.");
                return;
            }

            effect.Enabled = true;
            effect.Value = tbLightness.Value;
        }

        public string GenerateNewEffectName(VideoCaptureCore core)
        {
            string name = NAME;

            var eff = core?.Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.Video_Effects_Get(name);
                }
            }

            return name;
        }

        public string GenerateNewEffectName(MediaPlayerCore core)
        {
            string name = NAME;

            var eff = core?.Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.Video_Effects_Get(name);
                }
            }

            return name;
        }

        public string GenerateNewEffectName(VideoEditCore core)
        {
            string name = NAME;

            var eff = core?.Video_Effects_Get(name);
            if (eff != null)
            {
                int k = 2;
                while (eff != null)
                {
                    name = $"{NAME} {k++}";
                    eff = core.Video_Effects_Get(name);
                }
            }

            return name;
        }

        private void Lightness_Load(object sender, EventArgs e)
        {

        }

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            if (_intf != null)
            {
                _intf.Value = tbLightness.Value;
            }
        }
    }
}
