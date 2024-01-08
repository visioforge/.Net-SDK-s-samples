using System;
namespace SimpleVideoCapture
{
    public class VideoPickerDelegate : UIImagePickerControllerDelegate
    {
        UIViewController parent;

        public NSUrl SelectedFile;

        public VideoPickerDelegate(UIViewController parentController)
        {
            parent = parentController;
        }

        public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
        {
            var mediaType = info[UIImagePickerController.MediaType] as NSString;
            if (mediaType == "public.movie")
            {
                NSUrl videoUrl = info[UIImagePickerController.MediaURL] as NSUrl;
                if (videoUrl != null)
                {
                    SelectedFile = videoUrl;
                }
            }
            parent.DismissViewController(true, null);
        }

        public override void Canceled(UIImagePickerController picker)
        {
            parent.DismissViewController(true, null);
        }
    }

}

