using System;
using Asteroids.System.Core.Abstractions;
using Asteroids.System.Win32.Imports;

namespace Asteroids.System.Win32
{
    internal partial class Win32Viewport : IViewport, IDisposable
    {
        public Win32Viewport()
        {
            //
        }

        public IntPtr Handle { get; set; }

        public bool IsAlive
        {
            get => Handle != IntPtr.Zero;
        }

        public void Destroy()
        {
            if (!IsAlive)
            {
                return;
            }

            User32.DestroyWindow(Handle);

            Handle = IntPtr.Zero;
        }

        public void Poll()
        {
            Message msg = new();
            while (User32.PeekMessage(ref msg, Handle, 0, 0, PeekMessageRemove.Remove))
            {
                User32.TranslateMessage(ref msg);
                User32.DispatchMessage(ref msg);
            }
        }

        #region IDisposable

        private bool _disposed = false;
        
        ~Win32Viewport()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            
            Destroy();

            _disposed = true;
            
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}