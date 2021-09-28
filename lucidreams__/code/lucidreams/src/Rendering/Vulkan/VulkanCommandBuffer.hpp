#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANCOMMANDBUFFER_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANCOMMANDBUFFER_HPP

#include <vulkan/vulkan.hpp>

namespace lucidreams
{
    class VulkanCommandBuffer
    {
    public:
        explicit VulkanCommandBuffer(const VkCommandBuffer &cmdBuffer);
        ~VulkanCommandBuffer() = default;

    private:
        VkCommandBuffer _cmdBuffer;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANCOMMANDBUFFER_HPP
