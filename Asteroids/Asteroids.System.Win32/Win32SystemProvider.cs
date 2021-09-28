using Asteroids.System.Core.Abstractions;

namespace Asteroids.System.Win32
{
    public sealed class Win32SystemProvider : ISystemProvider
    {
        public Win32SystemProvider()
        {
            ViewportManager = new Win32ViewportManager();
        }

        public IViewportManager ViewportManager { get; }
    }
}