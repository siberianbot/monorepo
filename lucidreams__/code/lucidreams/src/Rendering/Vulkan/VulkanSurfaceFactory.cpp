#include "VulkanSurfaceFactory.hpp"

#include <utility>

#include "VulkanExports.hpp"
#include "VulkanRenderer.hpp"
#include "VulkanSurface.hpp"
#include "../../Utils/Assertion.hpp"

#ifdef WIN32
    #include "../Win32/Win32Viewport.hpp"
#else
    #error INCOMPATIBLE
#endif

namespace lucidreams
{
    VulkanSurfaceFactory::VulkanSurfaceFactory(const VkInstance &instanceHandle, std::weak_ptr<VulkanExports> exports) : _instanceHandle(instanceHandle), _exports(std::move(exports))
    {
        //
    }

    std::shared_ptr<ISurface> VulkanSurfaceFactory::create(const std::weak_ptr<IViewport> &viewport)
    {
        vk_surface_params_t surfaceParams = {
            .instanceHandle = this->_instanceHandle,
            .surfaceHandle = 0,
            .exports = this->_exports,
            .viewport = viewport
        };

        VkResult result;
        std::shared_ptr<VulkanExports> exports = this->_exports.lock();

        #ifdef WIN32
            auto win32Viewport = reinterpret_cast<Win32Viewport*>(viewport.lock().get());
            VkWin32SurfaceCreateInfoKHR surfaceCreateInfo = {
                .sType = VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR,
                .pNext = nullptr,
                .flags = 0,
                .hinstance = GetModuleHandle(nullptr),
                .hwnd = win32Viewport->getHandle()
            };

            result = exports->vkCreateWin32SurfaceKHR(surfaceParams.instanceHandle, &surfaceCreateInfo, nullptr, &surfaceParams.surfaceHandle);
        #else
            #error INCOMPATIBLE
        #endif

        engineAssert(result == VK_SUCCESS, "failed to create surface");

        return std::make_shared<VulkanSurface>(surfaceParams);
    }
}