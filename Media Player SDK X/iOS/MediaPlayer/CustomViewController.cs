using System.Diagnostics;
using VisioForge.Core.UI.Apple;

namespace MediaPlayer;

using UIKit;
using Foundation;

/// <summary>
/// The custom view controller.
/// </summary>
public class CustomViewController : UIViewController, IUIDocumentPickerDelegate
{
    /// <summary>
    /// The document picker.
    /// </summary>
    private UIDocumentPickerViewController _documentPicker;

    /// <summary>
    /// The file picked with the document picker, kept to reuse its security-scoped URL.
    /// </summary>
    private NSUrl _pickedFileUrl;

    /// <summary>
    /// The window.
    /// </summary>
    private UIWindow _window;

    /// <summary>
    /// Gets the source field: an HLS / HTTP / RTSP URL, or the picked file.
    /// </summary>
    public UITextField SourceField { get; private set; }

    /// <summary>
    /// Gets the select button.
    /// </summary>
    public UIButton SelectButton { get; private set; }

    /// <summary>
    /// Gets the play / pause button.
    /// </summary>
    public UIButton PlayButton { get; private set; }

    /// <summary>
    /// Gets the stop button.
    /// </summary>
    public UIButton StopButton { get; private set; }

    /// <summary>
    /// Gets the position slider.
    /// </summary>
    public UISlider PositionSlider { get; private set; }

    /// <summary>
    /// Gets the position label.
    /// </summary>
    public UILabel PositionLabel { get; private set; }

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
        var rect = new CGRect(0, 0, _window.Frame.Width, _window.Frame.Height - 100);
        videoView = AddVideoView(rect);
        AddControls();
    }

    /// <summary>
    /// Open file picker.
    /// </summary>
    public void OpenFilePicker()
    {
        try
        {
            var contentTypes = new UniformTypeIdentifiers.UTType[]
            {
                UniformTypeIdentifiers.UTTypes.Content,
                UniformTypeIdentifiers.UTTypes.Item,
                UniformTypeIdentifiers.UTTypes.Data
            };
            _documentPicker = new UIDocumentPickerViewController(contentTypes, asCopy: false)
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
    /// Did pick document.
    /// </summary>
    [Export("documentPicker:didPickDocumentsAtURLs:")]
    public void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
    {
        _pickedFileUrl = urls.FirstOrDefault();
        SourceField.Text = _pickedFileUrl?.AbsoluteString;
        controller.DismissViewController(true, null);
    }

    /// <summary>
    /// Was cancelled.
    /// </summary>
    [Export("documentPickerWasCancelled:")]
    public void WasCancelled(UIDocumentPickerViewController controller)
    {
        controller.DismissViewController(true, null);
    }

    /// <summary>
    /// Add video view.
    /// </summary>
    private UIView AddVideoView(CGRect rect)
    {
        var videoView = new VideoView(rect);
        View.AddSubview(videoView);
        return videoView;
    }

    /// <summary>
    /// Creates a gray button.
    /// </summary>
    private UIButton AddButton(string title, CGRect frame)
    {
        var button = new UIButton(frame)
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.None
        };
        button.SetTitle(title, UIControlState.Normal);
        View!.AddSubview(button);
        return button;
    }

    /// <summary>
    /// Add the source field, the buttons, the position slider and label.
    /// </summary>
    private void AddControls()
    {
        nfloat width = _window.Bounds.Width;
        nfloat sourceTop = _window.Bounds.Height - 90;
        nfloat controlsTop = _window.Bounds.Height - 50;

        // source row: URL / file + file picker
        SourceField = new UITextField(new CGRect(20, sourceTop, width - 190, 30))
        {
            BorderStyle = UITextBorderStyle.RoundedRect,
            Placeholder = "HLS / HTTP / RTSP URL, or select a file",
            Text = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8",
            KeyboardType = UIKeyboardType.Url,
            AutocapitalizationType = UITextAutocapitalizationType.None,
            AutocorrectionType = UITextAutocorrectionType.No,
            ClearButtonMode = UITextFieldViewMode.WhileEditing
        };
        SourceField.ShouldReturn = field => field.ResignFirstResponder();
        View!.AddSubview(SourceField);

        SelectButton = AddButton("SELECT FILE", new CGRect(width - 160, sourceTop, 140, 30));

        // controls row: play / pause, stop, position
        PlayButton = AddButton("PLAY", new CGRect(20, controlsTop, 100, 30));
        StopButton = AddButton("STOP", new CGRect(130, controlsTop, 100, 30));

        PositionLabel = new UILabel(new CGRect(width - 190, controlsTop, 170, 30))
        {
            Text = "00:00:00 / 00:00:00",
            TextColor = UIColor.White,
            TextAlignment = UITextAlignment.Right,
            AdjustsFontSizeToFitWidth = true
        };
        View!.AddSubview(PositionLabel);

        PositionSlider = new UISlider(new CGRect(250, controlsTop, width - 460, 30))
        {
            AutoresizingMask = UIViewAutoresizing.None,
            Value = 0,
            MinValue = 0,
            MaxValue = 100,
            MaximumTrackTintColor = UIColor.LightGray
        };
        View!.AddSubview(PositionSlider);
    }

    /// <summary>
    /// Gets the URL to play: the picked file, or the URL typed into the source field.
    /// </summary>
    /// <returns>NSUrl, or null when the field is empty or not a valid URL.</returns>
    public NSUrl GetURL()
    {
        var text = SourceField.Text?.Trim();
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        if (_pickedFileUrl != null && text == _pickedFileUrl.AbsoluteString)
        {
            return _pickedFileUrl;
        }

        return NSUrl.FromString(text);
    }
}
