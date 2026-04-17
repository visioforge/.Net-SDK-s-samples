// Extension entry point. iOS uses NSExtensionMain via the Info.plist NSExtensionPrincipalClass,
// not this Main — but the C# compiler needs one to satisfy OutputType=Exe. Kept as a no-op.
namespace ScreenCaptureExtension
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}
