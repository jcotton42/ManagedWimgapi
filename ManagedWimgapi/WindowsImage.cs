using System;
using System.Runtime.InteropServices;

namespace ManagedWimgapi {
    public sealed class WindowsImage : IDisposable {
        private readonly SafeWIMHandle handle;
        private bool disposed;

        internal WindowsImage(SafeWIMHandle wimHandle) {
            if(handle.IsInvalid) {
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            handle = wimHandle;
        }

        private void EnsureNotDisposed() {
            if(disposed) {
                throw new ObjectDisposedException(GetType().FullName, "The image has already been unloaded.");
            }
        }

        /// <summary>
        /// Applies the contents of a windows image to the specified path.
        /// </summary>
        /// <param name="path">The path to apply the image to.</param>
        /// <param name="options">The options for the application.</param>
        /// <exception cref="Exception">TODO</exception>
        /// <exception cref="ObjectDisposedException">The image has already been unloaded.</exception>
        public void Apply(string path, WimApplyOptions options) {
            EnsureNotDisposed();

            if(!NativeMethods.WIMApplyImage(handle, path, options)) {
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
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
