#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSWAPCHAIN_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSWAPCHAIN_HPP

#include <vulkan/vulkan.hpp>

#include "../ISwapchain.hpp"

namespace lucidreams
{
    class VulkanSwapchain final : public ISwapchain
    {
    public:
        ~VulkanSwapchain() final = default;

    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSWAPCHAIN_HPP
