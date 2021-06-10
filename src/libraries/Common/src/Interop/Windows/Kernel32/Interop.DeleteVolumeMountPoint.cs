// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Kernel32
    {
        /// <summary>
        /// WARNING: This method does not implicitly handle long paths. Use DeleteVolumeMountPoint.
        /// </summary>
#if DLLIMPORTGENERATOR_ENABLED
        [GeneratedDllImport(Libraries.Kernel32, EntryPoint = "DeleteVolumeMountPointW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static partial bool DeleteVolumeMountPointPrivate(string mountPoint);
#else
        [DllImport(Libraries.Kernel32, EntryPoint = "DeleteVolumeMountPointW", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool DeleteVolumeMountPointPrivate(string mountPoint);
#endif

        internal static bool DeleteVolumeMountPoint(string mountPoint)
        {
            mountPoint = PathInternal.EnsureExtendedPrefixIfNeeded(mountPoint);
            return DeleteVolumeMountPointPrivate(mountPoint);
        }
    }
}
