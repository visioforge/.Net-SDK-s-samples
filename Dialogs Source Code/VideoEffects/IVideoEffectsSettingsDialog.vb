' --------------------------------------------------------------------------------------------------------------------
' <copyright file="IVideoEffectsSettingsDialog.vb" company="VisioForge">
'   VisioForge (c) 2006 - 2021
' </copyright>
' <summary>
'   IVideoEffectsSettingsDialog interface.
' </summary>
' --------------------------------------------------------------------------------------------------------------------

Namespace VisioForge.Core.UI.WinForms.Dialogs.VideoEffects
    Imports VisioForge.Core.MediaPlayer
    Imports VisioForge.Core.VideoCapture
    Imports VisioForge.Core.VideoEdit
    Imports VisioForge.Core.Types.VideoEffects

    ''' <summary>
    ''' IVideoEffectsSettingsDialog interface.
    ''' </summary>
    Public Interface IVideoEffectsSettingsDialog
        ''' <summary>
        ''' Attaches effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        Sub Attach(effect As IVideoEffect)

        ''' <summary>
        ''' Fills effect.
        ''' </summary>
        ''' <param name="effect">
        ''' Effect.
        ''' </param>
        Sub Fill(effect As IVideoEffect)

        ''' <summary>
        ''' Generates new effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' The <see cref="String"/>.
        ''' </returns>
        Function GenerateNewEffectName(core As IVideoEditCore) As String

        ''' <summary>
        ''' Generates new effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' The <see cref="String"/>.
        ''' </returns>
        Function GenerateNewEffectName(core As IVideoCaptureCore) As String

        ''' <summary>
        ''' Generates new effect name.
        ''' </summary>
        ''' <param name="core">
        ''' Core.
        ''' </param>
        ''' <returns>
        ''' The <see cref="String"/>.
        ''' </returns>
        Function GenerateNewEffectName(core As IMediaPlayerCore) As String
    End Interface
End Namespace
