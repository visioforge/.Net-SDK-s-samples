//using Android.OS;
//using AndroidX.Core.App;
//using AndroidX.Core.Content;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android;
//using Android.App;
//using Android.Content.PM;
//using Android.OS;
//using AndroidX.Core.Content;
//using AndroidX.Core.App;

//namespace SimplePlayerMVVM.Android;

//public class PermissionsHelper
//{
//    public static string[] GetRequiredPermissions()
//    {
//#if ANDROID
//        if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu) // API level 33
//        {
//            return new[]
//            {
//                Manifest.Permission.ReadMediaImages,
//                Manifest.Permission.ReadMediaVideo
//            };
//        }
//        else
//        {
//            return new[]
//            {
//                Manifest.Permission.ReadExternalStorage
//            };
//        }
//#else
//        return new string[0];
//#endif
//    }

//    public async Task<bool> RequestPermissionsAsync(Activity activity)
//    {
//        var requiredPermissions = GetRequiredPermissions();

//        var permissionsToRequest = new List<string>();

//        foreach (var permission in requiredPermissions)
//        {
//            if (ContextCompat.CheckSelfPermission(activity, permission) != Permission.Granted)
//            {
//                permissionsToRequest.Add(permission);
//            }
//        }

//        if (permissionsToRequest.Count > 0)
//        {
//            var tcs = new TaskCompletionSource<bool>();

//            ActivityCompat.RequestPermissions(activity, permissionsToRequest.ToArray(), 1000);

//            activity.PermissionRequestCompleted += (sender, args) =>
//            {
//                if (args.RequestCode == 1000)
//                {
//                    bool allGranted = true;
//                    foreach (var result in args.GrantResults)
//                    {
//                        if (result != Permission.Granted)
//                        {
//                            allGranted = false;
//                            break;
//                        }
//                    }
//                    tcs.SetResult(allGranted);
//                }
//            };

//            return await tcs.Task;
//        }
//        else
//        {
//            // Permissions already granted
//            return true;
//        }
//    }
//}
