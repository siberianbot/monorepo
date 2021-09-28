#include "VulkanDevice.hpp"

#include "VulkanExports.hpp"

namespace lucidreams
{
    VulkanDevice::VulkanDevice(const vk_device_params_t &params)
        : _exports(params.exports), _deviceHandle(params.deviceHandle), _commandPoolHandle(params.commandPoolHandle)
    {
        //
    }

    VulkanDevice::~VulkanDevice()
    {
        this->destroy();
    }

    void VulkanDevice::destroy()
    {
        std::shared_ptr<VulkanExports> exports = this->_exports.lock();

        exports->vkDestroyCommandPool(this->_deviceHandle, this->_commandPoolHandle, nullptr);
        exports->vkDestroyDevice(this->_deviceHandle, nullptr);
    }
}