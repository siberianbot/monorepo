#ifndef LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACE_HPP
#define LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACE_HPP

#include <memory>

#include <vulkan/vulkan.hpp>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Types.hpp>

#include "../ISurface.hpp"

namespace lucidreams
{
    typedef struct VulkanSurfaceParams
    {
        VkInstance instanceHandle;
        VkSurfaceKHR surfaceHandle;
        std::weak_ptr<VulkanExports> exports;
        std::weak_ptr<IViewport> viewport;
    } vk_surface_params_t;

    class VulkanSurface final : public ISurface
    {
    public:
        explicit VulkanSurface(const vk_surface_params_t &params);
        ~VulkanSurface() final;

        void destroy() final;

        [[nodiscard]] MbString getDisplayName() const final;

        [[nodiscard]] bool isAlive() const final { return this->_surfaceHandle != 0; }
        [[nodiscard]] VkSurfaceKHR getHandle() const { return this->_surfaceHandle; }

    private:
        VkInstance _instanceHandle;
        VkSurfaceKHR _surfaceHandle;
        std::weak_ptr<VulkanExports> _exports;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VULKAN_VULKANSURFACE_HPP
