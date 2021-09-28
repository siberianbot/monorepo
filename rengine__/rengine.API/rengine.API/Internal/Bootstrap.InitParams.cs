using System;
using System.Runtime.InteropServices;

namespace rengine.API.Internal
{
    // ReSharper disable once UnusedType.Global
    internal static partial class Bootstrap
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct InitParams
        {
            public IntPtr AssemblyPathPtr;
        }
    }
}