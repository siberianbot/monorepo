#include "VulkanExports.hpp"

#include "../../System/IDynamicLibraryProxy.hpp"

#define InitializeFnExport(proxy, exportName) this->exportName = (PFN_##exportName)proxy->getProcPtr(#exportName)

namespace lucidreams
{
    VulkanExports::VulkanExports(const std::shared_ptr<IDynamicLibraryProxy> &vulkanProxy)
    {
        InitializeFnExport(vulkanProxy, vkCreateInstance);
        InitializeFnExport(vulkanProxy, vkDestroyInstance);
        InitializeFnExport(vulkanProxy, vkEnumeratePhysicalDevices);
        InitializeFnExport(vulkanProxy, vkGetPhysicalDeviceProperties);
        InitializeFnExport(vulkanProxy, vkGetPhysicalDeviceQueueFamilyProperties);
        InitializeFnExport(vulkanProxy, vkCreateDevice);
        InitializeFnExport(vulkanProxy, vkDestroyDevice);
        InitializeFnExport(vulkanProxy, vkCreateCommandPool);
        InitializeFnExport(vulkanProxy, vkDestroyCommandPool);
        InitializeFnExport(vulkanProxy, vkAllocateCommandBuffers);
        InitializeFnExport(vulkanProxy, vkDestroySurfaceKHR);
        InitializeFnExport(vulkanProxy, vkCreateWin32SurfaceKHR);
        InitializeFnExport(vulkanProxy, vkGetPhysicalDeviceSurfaceSupportKHR);
        InitializeFnExport(vulkanProxy, vkGetPhysicalDeviceSurfaceCapabilitiesKHR);
    }
}