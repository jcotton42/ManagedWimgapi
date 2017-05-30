using System.Runtime.InteropServices;

namespace ManagedWimgapi {
    internal static class Utils {
        internal static void HandleLastError() {
            // TODO: handle the errors properly
            throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
    }
}
