#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACEFACTORY_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACEFACTORY_HPP

#include <memory>

#include <vulkan/vulkan.hpp>

#include "../ISurfaceFactory.hpp"

namespace lucidreams
{
    class VulkanSurfaceFactory final : public ISurfaceFactory
    {
    public:
        explicit VulkanSurfaceFactory(const VkInstance &instanceHandle, std::weak_ptr<VulkanExports> exports);
        ~VulkanSurfaceFactory() final = default;

        [[nodiscard]] std::shared_ptr<ISurface> create(const std::weak_ptr<IViewport> &viewport) final;

    private:
        VkInstance _instanceHandle;
        std::weak_ptr<VulkanExports> _exports;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACEFACTORY_HPP
