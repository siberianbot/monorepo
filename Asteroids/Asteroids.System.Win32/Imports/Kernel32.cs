using System;
using System.Runtime.InteropServices;

namespace Asteroids.System.Win32.Imports
{
    /// <summary>kernel32.dll imports</summary>
    internal static class Kernel32
    {
        private const string DllName = "kernel32.dll";
        private const string GetModuleHandleName = "GetModuleHandleW";

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = GetModuleHandleName, ExactSpelling = true)]
        public static extern IntPtr GetModuleHandle([In] string lpModuleName);
    }
}