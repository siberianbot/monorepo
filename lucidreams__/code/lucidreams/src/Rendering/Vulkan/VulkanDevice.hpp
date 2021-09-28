#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICE_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICE_HPP

#include <memory>

#include <vulkan/vulkan.hpp>

#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    typedef struct VulkanDeviceParams
    {
        VkDevice deviceHandle;
        VkCommandPool commandPoolHandle;
        std::weak_ptr<VulkanExports> exports;
        std::weak_ptr<VulkanPhysicalDevice> physicalDevice;
        std::weak_ptr<ISurface> surface;
    } vk_device_params_t;

    class VulkanDevice
    {
    public:
        explicit VulkanDevice(const vk_device_params_t &params);
        ~VulkanDevice();

        [[nodiscard]] VkDevice getDeviceHandle() const { return this->_deviceHandle; }

        void destroy();

    private:
        VkDevice _deviceHandle;
        VkCommandPool _commandPoolHandle;
        std::weak_ptr<VulkanExports> _exports;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANDEVICE_HPP
