using System.Diagnostics;
using VisioForge.Core.UI.Apple;

namespace MediaPlayer;

using UIKit;
using Foundation;
using MobileCoreServices;

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
    /// The source file URL.
    /// </summary>
    private NSUrl _sourceFileUrl;

    /// <summary>
    /// The window.
    /// </summary>
    private UIWindow _window;

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
        var rect = new CGRect(0, 0, _window.Frame.Width, _window.Frame.Height);
        videoView = AddVideoView(rect);
        AddButtons();
    }

        /// <summary>
        /// Open file picker.
        /// </summary>
    public void OpenFilePicker()
    {
        try
        {
            // Use UTType array for iOS 14+ compatible document picker
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
        _sourceFileUrl = urls.FirstOrDefault();
        controller.DismissViewController(true, null);
    }

    /// <summary>
    /// Was cancelled.
    /// </summary>
    [Export("documentPickerWasCancelled:")]
    public void WasCancelled(UIDocumentPickerViewController controller)
    {
        // Handle cancellation if needed
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
        /// Add buttons.
        /// </summary>
    private void AddButtons()
    {
        nfloat newTop = _window.Bounds.Height - 50;

        // select button
        SelectButton = new UIButton(new CGRect(20, newTop, 150, 30))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.None,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };

        SelectButton.SetTitle("SELECT FILE", UIControlState.Normal);

        View!.AddSubview(SelectButton);

        // play button
        PlayButton = new UIButton(new CGRect(180, newTop, 100, 30))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.None,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };

        PlayButton.SetTitle("PLAY", UIControlState.Normal);

        View!.AddSubview(PlayButton);

        // position slider
        PositionSlider = new UISlider(
            new CGRect(
                PlayButton.Frame.Right + 30,
                newTop,
                _window.Bounds.Width - SelectButton.Bounds.Width - PlayButton.Bounds.Width - 50,
                30))
        {
            AutoresizingMask = UIViewAutoresizing.None,
            Value = 0,
            MinValue = 0,
            MaxValue = 100
        };

        View!.AddSubview(PositionSlider);
    }

    /// <summary>
    /// Gets the URL of the selected file.
    /// </summary>
    /// <returns>NSUrl.</returns>
    public NSUrl GetURL()
    {
        return _sourceFileUrl;
    }
}