using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisioForge.Controls.MediaPlayer;
using VisioForge.Controls.VideoCapture;
using VisioForge.Controls.VideoEdit;
using VisioForge.Types.VideoEffects;

namespace VisioForge.Controls.UI.Dialogs.VideoEffects
{
    public interface IVFVideoEffectsSettingsDialog
    {
        void Attach(IVFVideoEffect effect);
        void Fill(IVFVideoEffect effect);
        string GenerateNewEffectName(VideoEditCore core);
        string GenerateNewEffectName(VideoCaptureCore core);
        string GenerateNewEffectName(MediaPlayerCore core);
    }
}
