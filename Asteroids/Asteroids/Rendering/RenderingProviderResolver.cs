using Asteroids.Rendering.Abstractions;
using Asteroids.Rendering.Vulkan;

namespace Asteroids.Rendering
{
    public static class RenderingProviderResolver
    {
        public static IRenderingProvider Resolve()
        {
            return new VulkanRenderingProvider();
        }
    }
}