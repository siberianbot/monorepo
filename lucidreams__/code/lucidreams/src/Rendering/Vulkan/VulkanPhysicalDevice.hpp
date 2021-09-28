#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANPHYSICALDEVICE_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANPHYSICALDEVICE_HPP

#include <memory>
#include <optional>
#include <vector>

#include <vulkan/vulkan.hpp>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Types.hpp>
#include <lucidreams/Interfaces/IDisplayNameProvider.hpp>

namespace lucidreams
{
    // Contains indices of some queue families.
    typedef struct VulkanQueueFamilies
    {
        std::optional<uint32_t> graphicsFamily;
        std::optional<uint32_t> presentFamily;
    } vk_queue_families_t;

    // Vulkan physical device wrapper.
    // Stores device handle and its properties.
    class VulkanPhysicalDevice final : IDisplayNameProvider
    {
    public:
        explicit VulkanPhysicalDevice(std::weak_ptr<VulkanExports> exports, const VkPhysicalDevice &handle);
        ~VulkanPhysicalDevice() final = default;

        [[nodiscard]] MbString getDisplayName() const final;

        [[nodiscard]] VkPhysicalDevice getHandle() const { return this->_handle; }

        [[nodiscard]] VkPhysicalDeviceProperties getDeviceProps() const { return this->_deviceProps; }
        [[nodiscard]] std::vector<VkQueueFamilyProperties> getFamilyProps() const { return this->_familyProps; }

        [[nodiscard]] vk_queue_families_t getQueueFamilies(const std::weak_ptr<ISurface> &surface) const;

    private:
        std::weak_ptr<VulkanExports> _exports;
        VkPhysicalDevice _handle;

        VkPhysicalDeviceProperties _deviceProps;
        std::vector<VkQueueFamilyProperties> _familyProps;

        void loadDeviceProps();
        void loadFamilyProps();
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANPHYSICALDEVICE_HPP
