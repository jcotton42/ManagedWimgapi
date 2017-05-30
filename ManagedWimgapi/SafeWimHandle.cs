using System;
using System.Runtime.InteropServices;

namespace ManagedWimgapi {
    /// <summary>
    /// Represents a wrapper class for a WIM handle.
    /// </summary>
    public sealed class SafeWIMHandle : SafeHandle {
        public SafeWIMHandle(IntPtr invalidHandleValue, bool ownsHandle) : base(invalidHandleValue, ownsHandle) { }

        protected override bool ReleaseHandle() {
            return NativeMethods.WIMCloseHandle(this);
        }

        /// <summary>Indicates whether or not the handle is invalid</summary>
        /// <returns>true if the handle value is 0; otherwise, false.</returns>
        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}
