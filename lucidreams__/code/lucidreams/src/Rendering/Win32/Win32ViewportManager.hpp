#ifndef LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORTMANAGER_HPP
#define LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORTMANAGER_HPP

#include "../IViewportManager.hpp"

namespace lucidreams
{
    class Win32ViewportManager final : public IViewportManager
    {
    public:
        explicit Win32ViewportManager() = default;
        ~Win32ViewportManager() final = default;

        void init() final;
        void terminate() final;

        [[nodiscard]] std::weak_ptr<IViewport> createViewport(const viewport_params_t &params) final;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORTMANAGER_HPP
