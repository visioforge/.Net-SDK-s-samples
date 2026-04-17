using System.Diagnostics;
using VisioForge.Core.UI.Apple;

namespace MediaPlayer;

using UIKit;
using Foundation;


/// <summary>
/// Represents the custom view controller for the media player.
/// </summary>
public class CustomViewController : UIViewController, IUIDocumentPickerDelegate
{
    /// <summary>
    /// The document picker.
    /// </summary>
    private UIDocumentPickerViewController _documentPicker;

    /// <summary>
    /// The source file URL.
    /// </summary>
    private NSUrl _sourceFileUrl;

    /// <summary>
    /// The window.
    /// </summary>
    private UIWindow _window;

    /// <summary>
    /// Label showing the picked file name (above the controls).
    /// </summary>
    private UILabel _fileLabel;

    /// <summary>
    /// Gets the select button.
    /// </summary>
    public UIButton SelectButton { get; private set; }

    /// <summary>
    /// Gets the play button.
    /// </summary>
    public UIButton PlayButton { get; private set; }

    /// <summary>
    /// Gets the position slider.
    /// </summary>
    public UISlider PositionSlider { get; private set; }

    /// <summary>
    /// Gets the window.
    /// </summary>
    public UIWindow Window => _window;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomViewController"/> class.
    /// </summary>
    /// <param name="window">The window.</param>
    /// <param name="videoView">The video view.</param>
    public CustomViewController(UIWindow window, out UIView videoView)
    {
        _window = window;
        videoView = AddVideoView();
        AddButtons();
    }

    /// <summary>
    /// Opens the file picker.
    /// </summary>
    public void OpenFilePicker()
    {
        try
        {
            var allowedTypes = new[] { UniformTypeIdentifiers.UTTypes.Content, UniformTypeIdentifiers.UTTypes.Item, UniformTypeIdentifiers.UTTypes.Data };
            _documentPicker = new UIDocumentPickerViewController(allowedTypes, asCopy: false)
            {
                Delegate = this,
                ModalPresentationStyle = UIModalPresentationStyle.FullScreen
            };

            PresentViewController(_documentPicker, true, null);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Called when the document picker has picked one or more documents.
    /// </summary>
    /// <param name="controller">The document picker view controller.</param>
    /// <param name="urls">The URLs of the picked documents.</param>
    [Export("documentPicker:didPickDocumentsAtURLs:")]
    public void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
    {
        _sourceFileUrl = urls.FirstOrDefault();
        if (_fileLabel != null)
        {
            _fileLabel.Text = _sourceFileUrl?.LastPathComponent ?? string.Empty;
        }
        controller.DismissViewController(true, null);
    }

    /// <summary>
    /// Called when the document picker was cancelled.
    /// </summary>
    /// <param name="controller">The document picker view controller.</param>
    [Export("documentPickerWasCancelled:")]
    public void WasCancelled(UIDocumentPickerViewController controller)
    {
        // Handle cancellation if needed
        controller.DismissViewController(true, null);
    }

    /// <summary>
    /// Adds the Metal video view to the view hierarchy using autoresizing so it tracks
    /// container bounds through rotation. Enables vertex-buffer letterbox for
    /// rotation-stable aspect handling.
    /// </summary>
    /// <returns>The added video view.</returns>
    private UIView AddVideoView()
    {
        var videoView = new VideoView(View!.Bounds)
        {
            AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
            BackgroundColor = UIColor.Black,
            DisableAspectRatioResize = true
        };
        View!.AddSubview(videoView);
        return videoView;
    }

    /// <summary>
    /// Build a small circular icon button with an SF Symbol.
    /// </summary>
    private static UIButton MakeIconButton(string symbolName, float pointSize = 24f)
    {
        var btn = new UIButton(UIButtonType.System)
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TintColor = UIColor.White,
            BackgroundColor = UIColor.FromWhiteAlpha(1f, 0.15f)
        };
        btn.Layer.CornerRadius = 22f;

        var config = UIImageSymbolConfiguration.Create(pointSize, UIImageSymbolWeight.Regular);
        btn.SetImage(UIImage.GetSystemImage(symbolName, config), UIControlState.Normal);
        return btn;
    }

    /// <summary>
    /// Add the bottom control bar: file name label + slider + select/play icon buttons,
    /// pinned to the safe-area bottom so the home-indicator / Dynamic Island don't overlap.
    /// </summary>
    private void AddButtons()
    {
        var controlBar = new UIView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.4f)
        };
        View!.AddSubview(controlBar);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            controlBar.LeadingAnchor.ConstraintEqualTo(View!.LeadingAnchor),
            controlBar.TrailingAnchor.ConstraintEqualTo(View!.TrailingAnchor),
            controlBar.BottomAnchor.ConstraintEqualTo(View!.BottomAnchor),
            controlBar.HeightAnchor.ConstraintEqualTo(150f)
        });

        _fileLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextColor = UIColor.White,
            Font = UIFont.SystemFontOfSize(13f, UIFontWeight.Medium),
            TextAlignment = UITextAlignment.Center,
            Text = "No file selected",
            Lines = 1,
            LineBreakMode = UILineBreakMode.MiddleTruncation
        };
        controlBar.AddSubview(_fileLabel);

        PositionSlider = new UISlider
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Value = 0,
            MinValue = 0,
            MaxValue = 100
        };
        controlBar.AddSubview(PositionSlider);

        SelectButton = MakeIconButton("folder.fill");
        PlayButton = MakeIconButton("play.fill");
        PlayButton.BackgroundColor = UIColor.SystemRed.ColorWithAlpha(0.85f);

        controlBar.AddSubview(SelectButton);
        controlBar.AddSubview(PlayButton);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            // file label — topmost row of the bar
            _fileLabel.LeadingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.LeadingAnchor, 20f),
            _fileLabel.TrailingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.TrailingAnchor, -20f),
            _fileLabel.TopAnchor.ConstraintEqualTo(controlBar.TopAnchor, 10f),

            // slider — middle row
            PositionSlider.LeadingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.LeadingAnchor, 20f),
            PositionSlider.TrailingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.TrailingAnchor, -20f),
            PositionSlider.TopAnchor.ConstraintEqualTo(_fileLabel.BottomAnchor, 8f),

            // icon buttons — bottom row, centered
            SelectButton.TrailingAnchor.ConstraintEqualTo(controlBar.CenterXAnchor, -20f),
            SelectButton.TopAnchor.ConstraintEqualTo(PositionSlider.BottomAnchor, 12f),
            SelectButton.WidthAnchor.ConstraintEqualTo(44f),
            SelectButton.HeightAnchor.ConstraintEqualTo(44f),

            PlayButton.LeadingAnchor.ConstraintEqualTo(controlBar.CenterXAnchor, 20f),
            PlayButton.TopAnchor.ConstraintEqualTo(PositionSlider.BottomAnchor, 12f),
            PlayButton.WidthAnchor.ConstraintEqualTo(44f),
            PlayButton.HeightAnchor.ConstraintEqualTo(44f)
        });
    }

    /// <summary>
    /// Update the play button's icon between play/stop states (called from AppDelegate).
    /// </summary>
    public void SetPlaying(bool playing)
    {
        var config = UIImageSymbolConfiguration.Create(24f, UIImageSymbolWeight.Regular);
        PlayButton.SetImage(UIImage.GetSystemImage(playing ? "stop.fill" : "play.fill", config), UIControlState.Normal);
    }

    /// <summary>
    /// Gets the URL of the selected file.
    /// </summary>
    /// <returns>The source file URL.</returns>
    public NSUrl GetURL()
    {
        return _sourceFileUrl;
    }
}
