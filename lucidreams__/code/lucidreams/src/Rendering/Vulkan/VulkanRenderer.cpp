#include "VulkanRenderer.hpp"

#include <vector>

#include <lucidreams/Utils/StringFormat.hpp>

#include "VulkanDeviceFactory.hpp"
#include "VulkanExports.hpp"
#include "VulkanPhysicalDevice.hpp"
#include "VulkanSurfaceFactory.hpp"
#include "../../Engine/Engine.hpp"
#include "../../System/DynamicLibraryManager.hpp"
#include "../../System/IDynamicLibraryProxy.hpp"
#include "../../Utils/Assertion.hpp"
#include "../../Utils/Log.hpp"

namespace lucidreams
{
    VulkanRenderer::VulkanRenderer() : _dllProxy(nullptr), _exports(nullptr), _surfaceFactory(nullptr), _instanceHandle(nullptr)
    {
        //
    }

    void VulkanRenderer::init()
    {
        Engine::instance().getLog()->info(this->getDisplayName(), "initialization");

        this->_dllProxy = Engine::instance().getDynamicLibraryManager()->createProxy(L"vulkan-1.dll").lock();
        this->_dllProxy->load();

        Engine::instance().getLog()->trace(this->getDisplayName(), "loading Vulkan exports");

        this->_exports = std::make_shared<VulkanExports>(this->_dllProxy);

        this->initInstance();
        this->initPhysicalDevices();

        this->_deviceFactory = std::make_shared<VulkanDeviceFactory>(this->_exports);
        this->_surfaceFactory = std::make_shared<VulkanSurfaceFactory>(this->_instanceHandle, this->_exports);
    }

    void VulkanRenderer::terminate()
    {
        Engine::instance().getLog()->info(this->getDisplayName(), "termination");

        this->_exports->vkDestroyInstance(this->_instanceHandle, nullptr);
        this->_dllProxy->unload();

        this->_instanceHandle = nullptr;
    }

    void VulkanRenderer::initInstance()
    {
        Engine::instance().getLog()->info(this->getDisplayName(), "creating Vulkan instance");

        char *extensionNames[] = {
            VK_KHR_SURFACE_EXTENSION_NAME,
            VK_KHR_WIN32_SURFACE_EXTENSION_NAME
        };

        VkApplicationInfo app_info = {
            .sType = VK_STRUCTURE_TYPE_APPLICATION_INFO,
            .pNext = nullptr,
            .pApplicationName = "lucidreams", // TODO: load name of application from application instance
            .applicationVersion = 1, // TODO: encode application version
            .pEngineName = "lucidreams",
            .engineVersion = 1, // TODO: encode engine version
            .apiVersion = VK_API_VERSION_1_2
        };

        VkInstanceCreateInfo inst_info = {
            .sType = VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO,
            .pNext = nullptr,
            .flags = 0,
            .pApplicationInfo = &app_info,
            .enabledLayerCount = 0,
            .ppEnabledLayerNames = nullptr,
            .enabledExtensionCount = 2,
            .ppEnabledExtensionNames = extensionNames
        };

        this->_exports->vkCreateInstance(&inst_info, nullptr, &this->_instanceHandle);
        engineAssert(this->_instanceHandle != nullptr, "failed to create Vulkan instance");
    }

    void VulkanRenderer::initPhysicalDevices()
    {
        Engine::instance().getLog()->info(this->getDisplayName(), "initializing physical devices");

        uint32_t count = 0;
        VkResult result;
        std::vector<VkPhysicalDevice> physicalDeviceHandles;

        result = this->_exports->vkEnumeratePhysicalDevices(this->_instanceHandle, &count, nullptr);
        engineAssert(result == VkResult::VK_SUCCESS, "failed to retrieve count of physical devices");
        engineAssert(count > 0, "no physical devices");

        physicalDeviceHandles.resize(count);
        result = this->_exports->vkEnumeratePhysicalDevices(this->_instanceHandle, &count, physicalDeviceHandles.data());
        engineAssert(result == VkResult::VK_SUCCESS, "failed to retrieve available physical devices");

        Engine::instance().getLog()->info(this->getDisplayName(), format<char>("%0 physical device(s) available", count));

        for (VkPhysicalDevice physicalDeviceHandle : physicalDeviceHandles)
        {
            std::shared_ptr<VulkanPhysicalDevice> physicalDevice = std::make_shared<VulkanPhysicalDevice>(this->_exports, physicalDeviceHandle);
            VkPhysicalDeviceProperties physicalDeviceProps = physicalDevice->getDeviceProps();

            Engine::instance().getLog()->info(this->getDisplayName(),
                                              format<char>("\tpid 0x%0 vid 0x%1: %2, driver version %3, api version %4.%5.%6",
                                                           toHexString<char>(physicalDeviceProps.vendorID), toHexString<char>(physicalDeviceProps.deviceID),
                                                           physicalDeviceProps.deviceName,
                                                           toHexString<char>(physicalDeviceProps.driverVersion),
                                                           VK_VERSION_MAJOR(physicalDeviceProps.apiVersion), VK_VERSION_MINOR(physicalDeviceProps.apiVersion),
                                                           VK_VERSION_PATCH(physicalDeviceProps.apiVersion)));

            this->_physicalDevices.push_back(physicalDevice);
        }

        // TODO: choosing of preferred device
        this->_preferredPhysicalDevice = this->_physicalDevices[0];
        Engine::instance().getLog()->info(this->getDisplayName(), format<char>("physical device %0 is choosed as preferred", this->_preferredPhysicalDevice->getDisplayName()));
    }

//    std::weak_ptr<VulkanCommandBuffer> VulkanRenderer::createCommandBuffer()
//    {
//        VkCommandBuffer cmdBufferInstance = nullptr;
//        VkCommandBufferAllocateInfo commandBufferAllocateInfo = {
//            .sType = VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO,
//            .pNext = nullptr,
//            .commandPool = this->_commandPool,
//            .commandBufferCount = 1
//        };
//
//        VkResult result = this->_exports->vkAllocateCommandBuffers(this->_logicalDevice, &commandBufferAllocateInfo, &cmdBufferInstance);
//        engineAssert(result == VkResult::VK_SUCCESS, "failed to allocate command buffer");
//
//        std::shared_ptr<VulkanCommandBuffer> cmdBuffer = std::make_shared<VulkanCommandBuffer>(cmdBufferInstance);
//
//        this->_cmdBuffers.push_back(cmdBuffer);
//
//        return cmdBuffer;
//    }
}