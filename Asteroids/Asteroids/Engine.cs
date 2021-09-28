using System.Threading.Tasks;
using Asteroids.Rendering;
using Asteroids.Rendering.Abstractions;
using Asteroids.System;
using Asteroids.System.Core.Abstractions;

namespace Asteroids
{
    public class Engine
    {
        public Engine(string[] args)
        {
            RenderingProvider = RenderingProviderResolver.Resolve();
            SystemProvider = SystemProviderResolver.Resolve();
        }

        public IRenderingProvider RenderingProvider { get; }
        public ISystemProvider SystemProvider { get; }

        public async Task RunAsync()
        {
            await InitAsync();
            
            IViewport viewport = SystemProvider.ViewportManager.CreateViewport();
            IRenderer renderer = RenderingProvider.CreateRenderer();

            while (viewport.IsAlive)
            {
                viewport.Poll();
            }

            await TerminateAsync();
        }
        
        private async Task InitAsync()
        {
            // TODO
        }

        private async Task TerminateAsync()
        {
            SystemProvider.ViewportManager.DestroyAll();
        }
    }
}