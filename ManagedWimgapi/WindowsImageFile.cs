using System;

namespace ManagedWimgapi {
    /// <summary>
    /// Represents a Windows Image file (.wim).
    /// </summary>
    /// <remarks>This class is not thread-safe.</remarks>
    public sealed class WindowsImageFile : IDisposable {
        private readonly SafeWIMHandle fileHandle;
        private bool disposed;

        /// <summary>
        /// Creates or opens a Windows image at the specified path, with the specified access, mode, options, compression type, and temporary path.
        /// </summary>
        /// <param name="path">The path to the image file.</param>
        /// <param name="access">The access desired on the image file.</param>
        /// <param name="mode">Specifies which action to take on files that exist, and which action to take when files do not exist.</param>
        /// <param name="options">Specifies special actions to be take for the specified file.</param>
        /// <param name="compressionType">Specifies the compression mode to be used for a newly created image file. If the file already exists, then this parameter is ignored.</param>
        /// <param name="tempPath">Where temporary files are to be stored for operations on this file/</param>
        /// <exception cref="Exception">TODO</exception>
        public WindowsImageFile(string path, WimAccess access, WimMode mode, WimCreationOptions options,
            WimCompressionType compressionType, string tempPath) {
            fileHandle = NativeMethods.WIMCreateFile(path, access, mode, options, compressionType, out _);

            if(fileHandle.IsInvalid) {
                Utils.HandleLastError();
            }

            if(!NativeMethods.WIMSetTemporaryPath(fileHandle, tempPath)) {
                Utils.HandleLastError();
            }
        }

        /// <summary>
        /// Loads an image inside the WIM file.
        /// </summary>
        /// <param name="index">The 1-based index of the image to load.</param>
        /// <returns>A new <see cref="WindowsImage"/> representing the image.</returns>
        /// <exception cref="Exception">TODO</exception>
        public WindowsImage LoadImage(uint index) {
            EnsureNotDisposed();

            return new WindowsImage(NativeMethods.WIMLoadImage(fileHandle, index));
        }

        private void EnsureNotDisposed() {
            if(disposed) {
                throw new ObjectDisposedException(GetType().FullName, "The image has already been closed.");
            }
        }

        /// <summary>
        /// Closes the Windows Image file.
        /// </summary>
        // TODO: check the docs on the dispose pattern to see if Dispose failing is ever ok
        // if it isn't then we'll need to auto-dispose loaded images
        // if it is then the docs need to note when it can fail
        public void Dispose() {
            fileHandle.Dispose();
            disposed = true;
        }
    }
}
