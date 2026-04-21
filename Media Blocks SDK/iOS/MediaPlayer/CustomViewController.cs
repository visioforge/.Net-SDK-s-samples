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

    // Cached play/stop glyphs so SetPlaying doesn't allocate a fresh
    // UIImageSymbolConfiguration + UIImage on every toggle — otherwise quickly flipping
    // between states leaks managed peers backed by CoreFoundation objects.
    private UIImage _playIcon;
    private UIImage _stopIcon;

    /// <summary>
    /// Gets the window.
    /// </summary>
    public UIWindow Window => _window;

    /// <summary>
    /// Gets the video view. Created in <see cref="ViewDidLoad"/> once UIKit has installed
    /// the VC's view, so callers must read this after <c>Window.MakeKeyAndVisible()</c>.
    /// </summary>
    public UIView VideoView { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomViewController"/> class.
    /// Defers view-hierarchy construction until <see cref="ViewDidLoad"/> — touching
    /// <c>View</c> here would force LoadView before the VC is attached to a window, and
    /// the initial Bounds of an orphan view is <c>CGRect.Zero</c>, which produces a
    /// 0x0 Metal drawable and can crash some drivers.
    /// </summary>
    /// <param name="window">The window.</param>
    public CustomViewController(UIWindow window)
    {
        _window = window;
    }

    /// <summary>
    /// Build the video view and controls here — by the time UIKit calls ViewDidLoad the
    /// VC's <see cref="UIViewController.View"/> has a real (non-zero) bounds rect derived
    /// from the hosting window, so VideoView / Metal layers initialise with valid size.
    /// </summary>
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        VideoView = AddVideoView();
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

        // 150pt is the *minimum*: the label + slider + 44pt buttons + inter-row gaps plus
        // bottom safe-area padding (home indicator / Dynamic Island) can exceed 150 on larger
        // devices and would otherwise clip the play button. ConstraintGreaterThanOrEqualTo
        // together with the explicit bottom-of-content constraint below lets the bar grow.
        NSLayoutConstraint.ActivateConstraints(new[]
        {
            controlBar.LeadingAnchor.ConstraintEqualTo(View!.LeadingAnchor),
            controlBar.TrailingAnchor.ConstraintEqualTo(View!.TrailingAnchor),
            controlBar.BottomAnchor.ConstraintEqualTo(View!.BottomAnchor),
            controlBar.HeightAnchor.ConstraintGreaterThanOrEqualTo(150f)
        });

        _fileLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TextColor = UIColor.White,
            Font = UIFont.SystemFontOfSize(13f, UIFontWeight.Medium),
            TextAlignment = UITextAlignment.Center,
            Text = "No file selected",
            // Allow a second line so long filenames wrap once instead of squeezing
            // the extension out of view — middle truncation on the last line still
            // keeps .mp4/.mov/etc visible when the name exceeds the two-line budget.
            Lines = 2,
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

        // Build and retain the two symbol images once; SetPlaying swaps between them
        // without allocating fresh UIImageSymbolConfiguration / UIImage peers every tap.
        var playConfig = UIImageSymbolConfiguration.Create(24f, UIImageSymbolWeight.Regular);
        _playIcon = UIImage.GetSystemImage("play.fill", playConfig);
        _stopIcon = UIImage.GetSystemImage("stop.fill", playConfig);

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
            PlayButton.HeightAnchor.ConstraintEqualTo(44f),

            // Anchor the button row to the bottom of the safe area so the bar expands
            // (via the ≥150 height constraint above) when the device's bottom inset is large.
            PlayButton.BottomAnchor.ConstraintLessThanOrEqualTo(controlBar.SafeAreaLayoutGuide.BottomAnchor, -16f),
            SelectButton.BottomAnchor.ConstraintLessThanOrEqualTo(controlBar.SafeAreaLayoutGuide.BottomAnchor, -16f)
        });
    }

    /// <summary>
    /// Update the play button's icon between play/stop states (called from AppDelegate).
    /// </summary>
    public void SetPlaying(bool playing)
    {
        PlayButton.SetImage(playing ? _stopIcon : _playIcon, UIControlState.Normal);
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
