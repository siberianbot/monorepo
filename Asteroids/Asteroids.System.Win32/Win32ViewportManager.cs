using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Asteroids.System.Core.Abstractions;
using Asteroids.System.Win32.Imports;

namespace Asteroids.System.Win32
{
    internal sealed class Win32ViewportManager : IViewportManager
    {
        private const string WindowClass = "Asteroids";

        private readonly IList<Win32Viewport> _viewports;
        
        public Win32ViewportManager()
        {
            _viewports = new List<Win32Viewport>();
        }

        public IViewport CreateViewport()
        {
            string windowClassName = $"{WindowClass}_{Guid.NewGuid():N}";
            Win32Viewport viewport = new Win32Viewport();
            
            WndClassEx wndClassEx = new WndClassEx
            {
                cbSize = Marshal.SizeOf<WndClassEx>(),
                style = ClassStyle.OwnDC |
                        ClassStyle.HorizontalRedraw |
                        ClassStyle.VerticalRedraw,
                lpszClassName = windowClassName,
                lpfnWndProc = viewport.WindowProc,
                hInstance = Kernel32.GetModuleHandle(null)
            };

            bool result = User32.RegisterClassEx(ref wndClassEx);

            if (!result)
            {
                throw new Exception(); // TODO
            }
            
            IntPtr hInstance = Kernel32.GetModuleHandle(null);
            IntPtr hWnd = User32.CreateWindowEx(ExtendedWindowStyle.None, windowClassName, "Asteroids", WindowStyle.OverlappedWindow | WindowStyle.Visible, 100, 100, 800, 600, IntPtr.Zero, IntPtr.Zero,
                hInstance,
                IntPtr.Zero);

            if (hWnd == IntPtr.Zero)
            {
                throw new Exception(); // TODO
            }

            viewport.Handle = hWnd;
            
            _viewports.Add(viewport);

            return viewport;
        }

        public void DestroyAll()
        {
            foreach (Win32Viewport viewport in _viewports)
            {
                viewport.Dispose();
            }

            _viewports.Clear();
        }
    }
}