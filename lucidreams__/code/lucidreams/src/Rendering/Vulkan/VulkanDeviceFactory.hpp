#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICEFACTORY_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICEFACTORY_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    class VulkanDeviceFactory
    {
    public:
        explicit VulkanDeviceFactory(std::weak_ptr<VulkanExports> exports);

        [[nodiscard]] std::shared_ptr<VulkanDevice> create(const std::weak_ptr<VulkanPhysicalDevice> &physicalDevice, const std::weak_ptr<ISurface> &surface) const;

    private:
        std::weak_ptr<VulkanExports> _exports;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICEFACTORY_HPP
