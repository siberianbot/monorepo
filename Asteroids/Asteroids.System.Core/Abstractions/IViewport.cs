using System;

namespace Asteroids.System.Core.Abstractions
{
    public interface IViewport
    {
        public bool IsAlive { get; }

        public void Destroy();
        public void Poll();
    }
}