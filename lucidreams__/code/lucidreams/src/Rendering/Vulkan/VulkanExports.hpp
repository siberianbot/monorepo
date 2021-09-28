#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANEXPORTS_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANEXPORTS_HPP

#include <memory>

#include <vulkan/vulkan.hpp>

#include <lucidreams/ForwardDeclarations.hpp>

#define FnExport(exportName) PFN_##exportName exportName

namespace lucidreams
{
    class VulkanExports
    {
    public:
        explicit VulkanExports(const std::shared_ptr<IDynamicLibraryProxy> &vulkanProxy);

        FnExport(vkCreateInstance);
        FnExport(vkDestroyInstance);
        FnExport(vkEnumeratePhysicalDevices);
        FnExport(vkGetPhysicalDeviceProperties);
        FnExport(vkGetPhysicalDeviceQueueFamilyProperties);
        FnExport(vkCreateDevice);
        FnExport(vkDestroyDevice);
        FnExport(vkCreateCommandPool);
        FnExport(vkDestroyCommandPool);
        FnExport(vkAllocateCommandBuffers);
        FnExport(vkDestroySurfaceKHR);
        FnExport(vkCreateWin32SurfaceKHR);
        FnExport(vkGetPhysicalDeviceSurfaceSupportKHR);
        FnExport(vkGetPhysicalDeviceSurfaceCapabilitiesKHR);
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANEXPORTS_HPP
