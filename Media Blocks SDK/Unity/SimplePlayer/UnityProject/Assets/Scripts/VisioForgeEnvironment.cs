using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using VisioForge.Core;

namespace VisioForge.Unity
{
    /// <summary>
    /// One-time GStreamer/VisioForge runtime setup for Unity on Windows. Configures the
    /// native DLL search before any pipeline is built, and initializes the SDK + plugin
    /// registry. Shared by all Unity samples so the boilerplate lives in one place.
    ///
    /// The CrossPlatform NuGet package deploys the GStreamer core libs, plugins and data
    /// files flat into <c>Assets/StreamingAssets/VisioForge/x64</c> (see deploy-unity-natives.ps1).
    /// StreamingAssets is used (not Plugins/x64) so the runtime is copied verbatim into
    /// standalone player builds; <see cref="Application.streamingAssetsPath"/> resolves to a real
    /// directory in both the Editor and a standalone build, so the same path works for both.
    /// </summary>
    public static class VisioForgeEnvironment
    {
        private static bool s_envConfigured;
        private static bool s_sdkInitialized;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDllDirectoryW(string lpPathName);

        /// <summary>Absolute path to the bundled native runtime (StreamingAssets/VisioForge/x64).</summary>
        public static string NativesPath =>
            Path.Combine(Application.streamingAssetsPath, "VisioForge", "x64").Replace('\\', '/');

        /// <summary>
        /// Runs before the first scene loads: prune any system GStreamer from the process
        /// PATH, point the Win32 DLL loader at the bundled natives, and set GST_PLUGIN_PATH /
        /// SSL_CERT_FILE. Never touches the system/user PATH.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Configure()
        {
            if (s_envConfigured) return;
            s_envConfigured = true;

            // A second physical copy of gstreamer-1.0-0.dll in the process (from a system
            // GStreamer install on PATH) double-registers GLib types and hangs the pipeline.
            // Prune it from the *process* PATH so only the bundled copy is found.
            string processPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process) ?? string.Empty;
            var kept = new System.Collections.Generic.List<string>();
            int stripped = 0;
            foreach (var seg in processPath.Split(';'))
            {
                if (string.IsNullOrWhiteSpace(seg)) continue;
                if (seg.IndexOf("gstreamer", StringComparison.OrdinalIgnoreCase) >= 0) { stripped++; continue; }
                kept.Add(seg);
            }
            if (stripped > 0)
                Environment.SetEnvironmentVariable("PATH", string.Join(";", kept), EnvironmentVariableTarget.Process);

            string natives = NativesPath;
            if (!Directory.Exists(natives))
            {
                Debug.LogError($"[VisioForge] Native runtime not found at {natives}. Run deploy-unity-natives.ps1 (or, in a standalone build, ensure StreamingAssets/VisioForge/x64 was staged).");
                return;
            }

            SetDllDirectoryW(natives);

            // Prepend to the process PATH so GStreamer's LoadLibrary resolves each plugin's
            // transitive core-lib deps reliably (SetDllDirectory alone is not enough for those).
            var cur = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process) ?? string.Empty;
            if (!cur.Split(';').Any(p => string.Equals(p?.TrimEnd('/', '\\'), natives.TrimEnd('/', '\\'), StringComparison.OrdinalIgnoreCase)))
                Environment.SetEnvironmentVariable("PATH", natives + ";" + cur, EnvironmentVariableTarget.Process);

            // NuGet package is flat: core libs + plugins live together, so scan the same folder.
            Environment.SetEnvironmentVariable("GST_PLUGIN_PATH", natives);
            Environment.SetEnvironmentVariable("GST_PLUGIN_SYSTEM_PATH", natives);

            string caCerts = natives + "/ca-certificates.crt";
            if (File.Exists(caCerts))
            {
                Environment.SetEnvironmentVariable("SSL_CERT_FILE", caCerts);
                Environment.SetEnvironmentVariable("CA_CERTIFICATES", caCerts);
            }

            Debug.Log($"[VisioForge] Environment configured. Natives: {natives}");
        }

        /// <summary>
        /// Initialize the SDK and explicitly scan the bundled plugin folder. Idempotent.
        /// The explicit ScanPath is required because Unity's in-process plugin scan during
        /// gst_init does not reliably pick up GST_PLUGIN_PATH.
        /// </summary>
        public static void InitializeSdk()
        {
            if (s_sdkInitialized) return;
            s_sdkInitialized = true;

            VisioForgeX.InitSDK();

            try
            {
                Gst.Registry.Get().ScanPath(NativesPath);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[VisioForge] Plugin registry scan failed: {ex.Message}");
            }
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// Editor-only guard. The SDK runs a GLib main-loop on a dedicated background thread,
    /// blocked inside a native call that Unity cannot abort — it would hang the domain
    /// unload on every script recompile / Editor quit. Before the domain unloads we stop
    /// ONLY the main-loop thread (VisioForgeX.StopMainLoop), so the reload completes. We do
    /// NOT call DestroySDK here: gst_deinit cannot be re-initialized in the same process, so
    /// destroying it would crash the next Play. GStreamer stays initialized; the loop is
    /// rebuilt only because this guard fires on beforeAssemblyReload — the ensuing domain
    /// reload resets the init-state statics (s_sdkInitialized here, plus VisioForgeX/
    /// GstInitializer's flags), so the next InitializeSdk runs InitSDK from a clean state and
    /// recreates the loop. A plain in-domain InitSDK (no reload) would NOT recreate it.
    ///
    /// (Play/Stop itself should not reload the domain — set Enter Play Mode Options →
    /// Disable Domain Reload, which the sample's ProjectSettings already does.)
    /// </summary>
    [UnityEditor.InitializeOnLoad]
    internal static class VisioForgeEditorReloadGuard
    {
        static VisioForgeEditorReloadGuard()
        {
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += StopLoop;
            UnityEditor.EditorApplication.quitting += StopLoop;
        }

        private static void StopLoop()
        {
            try { VisioForgeX.StopMainLoop(); }
            catch (Exception ex) { Debug.LogWarning($"[VisioForge] StopMainLoop on reload failed: {ex.Message}"); }
        }
    }
#endif
}
