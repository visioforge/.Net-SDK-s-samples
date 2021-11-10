// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVideoEffectsSettingsDialog.cs" company="VisioForge">
//   VisioForge (c) 2006 - 2021
// </copyright>
// <summary>
//   IVideoEffectsSettingsDialog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisioForge.Controls.UI.Dialogs.Shared.VideoEffects
{
    using VisioForge.Controls.MediaPlayer;
    using VisioForge.Controls.VideoCapture;
    using VisioForge.Controls.VideoEdit;
    using VisioForge.Types.VideoEffects;

    /// <summary>
    /// IVideoEffectsSettingsDialog interface.
    /// </summary>
    public interface IVideoEffectsSettingsDialog
    {
        /// <summary>
        /// Attaches effect.
        /// </summary>
        /// <param name="effect">
        /// Effect.
        /// </param>
        void Attach(IVideoEffect effect);

        /// <summary>
        /// Fills effect.
        /// </summary>
        /// <param name="effect">
        /// Effect.
        /// </param>
        void Fill(IVideoEffect effect);

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GenerateNewEffectName(IVideoEditCore core);

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GenerateNewEffectName(IVideoCaptureCore core);

        /// <summary>
        /// Generates new effect name.
        /// </summary>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GenerateNewEffectName(IMediaPlayerCore core);
    }
}
