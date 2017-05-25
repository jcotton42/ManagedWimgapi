using System;
using System.Runtime.InteropServices;

namespace ManagedWimgapi {
    public sealed class WindowsImage : IDisposable {
        private readonly SafeWimHandle handle;
        private bool disposed;

        internal WindowsImage(SafeWimHandle wimHandle) {
            if(handle.IsInvalid) {
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            handle = wimHandle;
        }

        /// <summary>
        /// Unloads the windows image.
        /// </summary>
        public void Dispose() {
            handle.Dispose();
            disposed = true;
        }
    }
}
