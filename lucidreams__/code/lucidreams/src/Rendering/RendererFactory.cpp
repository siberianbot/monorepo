#include "RendererFactory.hpp"

#include "Vulkan/VulkanRenderer.hpp"

namespace lucidreams
{
    std::shared_ptr<IRenderer> RendererFactory::create()
    {
        // TODO: more code to choose renderer
        return std::make_shared<VulkanRenderer>();
    }
}