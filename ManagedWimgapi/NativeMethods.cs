using System;
using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

namespace ManagedWimgapi {
    internal class NativeMethods {
        private const string Wimgapi = "wimgapi.dll";'

        [DllImport(Wimgapi)]
        internal static extern bool WIMCloseHandle(SafeWimHandle handle);
    }
}
