using System;
using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

namespace ManagedWimgapi {
    internal class NativeMethods {
        #region Constatns
        private const string Wimgapi = "wimgapi.dll";

        internal const uint WIM_FLAG_RESERVED = 0x00000001;
        internal const uint WIM_FLAG_VERIFY = 0x00000002;
        internal const uint WIM_FLAG_INDEX = 0x00000004;
        internal const uint WIM_FLAG_NO_APPLY = 0x00000008;
        internal const uint WIM_FLAG_NO_DIRACL = 0x00000010;
        internal const uint WIM_FLAG_NO_FILEACL = 0x00000020;
        internal const uint WIM_FLAG_SHARE_WRITE = 0x00000040;
        internal const uint WIM_FLAG_FILEINFO = 0x00000080;
        internal const uint WIM_FLAG_NO_RP_FIX = 0x00000100;
        internal const uint WIM_FLAG_MOUNT_READONLY = 0x00000200;
        internal const uint WIM_FLAG_MOUNT_FAST = 0x00000400;
        internal const uint WIM_FLAG_MOUNT_LEGACY = 0x00000800;
        internal const uint WIM_FLAG_APPLY_CI_EA = 0x00001000;
        internal const uint WIM_FLAG_WIM_BOOT = 0x00002000;
        internal const uint WIM_FLAG_APPLY_COMPACT = 0x00004000;
        internal const uint WIM_FLAG_SUPPORT_EA = 0x00008000;
        #endregion

        [DllImport(Wimgapi, SetLastError = true)]
        internal static extern bool WIMCloseHandle(
            SafeWimHandle handle
            );

        [DllImport(Wimgapi, SetLastError = true)]
        internal static extern SafeWimHandle WIMCreateFile(
            string path,
            WimAccess access,
            WimMode mode,
            WimCreationOptions options,
            WimCompressionType compressionType,
            out WimCreationResult creationResult
            );
    }
}
