using System;
using System.Runtime.InteropServices;

namespace ManagedWimgapi {
    public sealed class SafeWimHandle : SafeHandle {
        public SafeWimHandle(IntPtr invalidHandleValue, bool ownsHandle) : base(invalidHandleValue, ownsHandle) { }
        protected override bool ReleaseHandle() {
            return NativeMethods.WIMCloseHandle(this);
        }

        /// <summary>Indicates whether or not the handle is invalid</summary>
        /// <returns>true if the handle value is 0; otherwise, false.</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}
