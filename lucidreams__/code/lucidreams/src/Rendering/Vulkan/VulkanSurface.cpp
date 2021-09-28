#include "VulkanSurface.hpp"

#include <lucidreams/Utils/StringFormat.hpp>

#include "VulkanExports.hpp"

namespace lucidreams
{
    VulkanSurface::VulkanSurface(const vk_surface_params_t &params)
        : ISurface(params.viewport), _instanceHandle(params.instanceHandle), _surfaceHandle(params.surfaceHandle), _exports(params.exports)
    {
        //
    }

    VulkanSurface::~VulkanSurface()
    {
        this->destroy();
    }

    void VulkanSurface::destroy()
    {
        if (!this->isAlive())
        {
            return;
        }

        this->_exports.lock()->vkDestroySurfaceKHR(this->_instanceHandle, this->_surfaceHandle, nullptr);
    }

    MbString VulkanSurface::getDisplayName() const
    {
        if (this->isAlive())
        {
            return format<char>("Vulkan surface 0x%0", toHexString<char>(this->_surfaceHandle));
        }
        else
        {
            return "Vulkan surface (dead)";
        }
    }
}