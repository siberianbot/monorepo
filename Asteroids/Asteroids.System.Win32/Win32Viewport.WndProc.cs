using System;
using Asteroids.System.Win32.Imports;

namespace Asteroids.System.Win32
{
    internal partial class Win32Viewport
    {
        public IntPtr WindowProc(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam)
        {
            switch (uMsg)
            {
                case WindowMessage.Close:
                    Destroy();
                    return User32.DefWindowProc(hWnd, uMsg, wParam, lParam);
            }
            
            return User32.DefWindowProc(hWnd, uMsg, wParam, lParam);
        }
    }
}