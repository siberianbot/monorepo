#include "VulkanDeviceFactory.hpp"

#include <utility>
#include <vulkan/vulkan.hpp>

#include "VulkanDevice.hpp"
#include "VulkanExports.hpp"
#include "VulkanPhysicalDevice.hpp"
#include "../../Utils/Assertion.hpp"

namespace lucidreams
{
    VulkanDeviceFactory::VulkanDeviceFactory(std::weak_ptr<VulkanExports> exports) : _exports(std::move(exports))
    {
        //
    }

    std::shared_ptr<VulkanDevice> VulkanDeviceFactory::create(const std::weak_ptr<VulkanPhysicalDevice> &physicalDevice, const std::weak_ptr<ISurface> &surface) const
    {
        auto physicalDeviceLockedPtr = physicalDevice.lock();

        vk_queue_families_t queueFamilies = physicalDeviceLockedPtr->getQueueFamilies(surface);
        VkResult result;
        vk_device_params_t deviceParams = {
            .physicalDevice = physicalDevice,
            .surface = surface
        };

        engineAssert(queueFamilies.graphicsFamily.has_value(), "no queue family with graphics bit found");

        float queuePriorities[] = {0.0};
        VkDeviceQueueCreateInfo deviceQueueCreateInfo = {
            .sType = VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
            .pNext = nullptr,
            .flags = 0,
            .queueFamilyIndex = queueFamilies.graphicsFamily.value(),
            .queueCount = 1,
            .pQueuePriorities = queuePriorities
        };

        // TODO: move out of there?
        char *extensionNames[] = {
            VK_KHR_SWAPCHAIN_EXTENSION_NAME,
        };

        VkDeviceCreateInfo deviceCreateInfo = {
            .sType = VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO,
            .pNext = nullptr,
            .flags = 0,
            .queueCreateInfoCount = 1,
            .pQueueCreateInfos = &deviceQueueCreateInfo,
            .enabledLayerCount = 0,
            .ppEnabledLayerNames = nullptr,
            .enabledExtensionCount = 1,
            .ppEnabledExtensionNames = extensionNames,
            .pEnabledFeatures = nullptr,
        };

        result = this->_exports.lock()->vkCreateDevice(physicalDeviceLockedPtr->getHandle(), &deviceCreateInfo, nullptr, &deviceParams.deviceHandle);
        engineAssert(result == VkResult::VK_SUCCESS, "failed to create logical device");

        VkCommandPoolCreateInfo commandPoolCreateInfo = {
            .sType = VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO,
            .pNext = nullptr,
            .flags = 0,
            .queueFamilyIndex = queueFamilies.graphicsFamily.value()
        };

        result = this->_exports.lock()->vkCreateCommandPool(deviceParams.deviceHandle, &commandPoolCreateInfo, nullptr, &deviceParams.commandPoolHandle);
        engineAssert(result == VkResult::VK_SUCCESS, "failed to create command pool");

        return std::make_shared<VulkanDevice>(deviceParams);
    }
}