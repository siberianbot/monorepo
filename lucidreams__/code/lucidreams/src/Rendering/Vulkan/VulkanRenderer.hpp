#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANRENDERER_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANRENDERER_HPP

#include <memory>
#include <vector>

#include <vulkan/vulkan.hpp>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Types.hpp>

#include "../IRenderer.hpp"

namespace lucidreams
{
    class VulkanRenderer final : public IRenderer
    {
    public:
        explicit VulkanRenderer();
        ~VulkanRenderer() final = default;

        void init() final;
        void terminate() final;

        [[nodiscard]] MbString getDisplayName() const final { return "Vulkan renderer"; }
        [[nodiscard]] std::weak_ptr<ISurfaceFactory> getSurfaceFactory() const final { return this->_surfaceFactory; }

        [[nodiscard]] VkInstance getInstanceHandle() const { return this->_instanceHandle; }

        [[nodiscard]] std::weak_ptr<VulkanExports> getExports() const { return this->_exports; }
        [[nodiscard]] std::weak_ptr<VulkanDeviceFactory> getDeviceFactory() const { return this->_deviceFactory; }

        [[nodiscard]] std::vector<std::shared_ptr<VulkanPhysicalDevice>> getPhysicalDevices() const { return this->_physicalDevices; }
        [[nodiscard]] std::shared_ptr<VulkanPhysicalDevice> getPreferredPhysicalDevice() const { return this->_preferredPhysicalDevice; }

    private:
        VkInstance _instanceHandle;

        std::shared_ptr<IDynamicLibraryProxy> _dllProxy;
        std::shared_ptr<VulkanExports> _exports;

        std::shared_ptr<VulkanDeviceFactory> _deviceFactory;
        std::shared_ptr<ISurfaceFactory> _surfaceFactory;

        std::vector<std::shared_ptr<VulkanPhysicalDevice>> _physicalDevices;
        std::shared_ptr<VulkanPhysicalDevice> _preferredPhysicalDevice;

        void initInstance();
        void initPhysicalDevices();
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANRENDERER_HPP
