#include "VulkanPhysicalDevice.hpp"

#include <utility>

#include "VulkanExports.hpp"
#include "VulkanSurface.hpp"
#include "../../Utils/Assertion.hpp"

namespace lucidreams
{
    VulkanPhysicalDevice::VulkanPhysicalDevice(std::weak_ptr<VulkanExports> exports, VkPhysicalDevice const &handle)
        : _exports(std::move(exports)), _handle(handle), _deviceProps()
    {
        this->loadDeviceProps();
        this->loadFamilyProps();
    }

    MbString VulkanPhysicalDevice::getDisplayName() const
    {
        return this->_deviceProps.deviceName;
    }

    vk_queue_families_t VulkanPhysicalDevice::getQueueFamilies(const std::weak_ptr<ISurface> &surface) const
    {
        auto vulkanSurface = reinterpret_cast<VulkanSurface *>(surface.lock().get());
        vk_queue_families_t queueFamilies;

        int i = 0;
        for (const auto &props : this->_familyProps)
        {
            if (props.queueFlags & VkQueueFlagBits::VK_QUEUE_GRAPHICS_BIT)
            {
                queueFamilies.graphicsFamily = i;
            }

            VkBool32 supportsPresent = false;
            this->_exports.lock()->vkGetPhysicalDeviceSurfaceSupportKHR(this->_handle, i, vulkanSurface->getHandle(), &supportsPresent);

            if (supportsPresent)
            {
                queueFamilies.presentFamily = i;
            }

            if (queueFamilies.graphicsFamily.has_value() && queueFamilies.presentFamily.has_value())
            {
                break;
            }

            ++i;
        }

        return queueFamilies;
    }

    void VulkanPhysicalDevice::loadDeviceProps()
    {
        this->_exports.lock()->vkGetPhysicalDeviceProperties(this->_handle, &this->_deviceProps);
    }

    void VulkanPhysicalDevice::loadFamilyProps()
    {
        uint32_t count = 0;
        this->_exports.lock()->vkGetPhysicalDeviceQueueFamilyProperties(this->_handle, &count, nullptr);
        engineAssert(count > 0, "failed to retrieve queue family properties");

        this->_familyProps.resize(count);
        this->_exports.lock()->vkGetPhysicalDeviceQueueFamilyProperties(this->_handle, &count, this->_familyProps.data());
    }
}