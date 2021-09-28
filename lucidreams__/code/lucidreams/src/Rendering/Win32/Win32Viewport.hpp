#ifndef LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORT_HPP
#define LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORT_HPP

#include <Windows.h>

#include <lucidreams/ForwardDeclarations.hpp>

#include "../IViewport.hpp"

namespace lucidreams
{
    class Win32Viewport final : public IViewport
    {
    public:
        explicit Win32Viewport();
        ~Win32Viewport() final;

        void pollEvents() final;
        void swapBuffers() final;
        void destroy() final;

        void setVisibility(bool isVisible) final;

        [[nodiscard]] MbString getDisplayName() const final { return "Win32 viewport"; }
        [[nodiscard]] bool isAlive() const final { return this->_handle != nullptr; }

        [[nodiscard]] HWND getHandle() const { return this->_handle; }
        [[nodiscard]] HDC getDeviceContext() const { return this->_dc; }

        void setHandle(HWND handle) { this->_handle = handle; }
        void setDeviceContext(HDC dc) { this->_dc = dc; }
        void setVisibilityInternal(bool isVisible) { this->_visible = isVisible; }

    private:
        HWND _handle;
        HDC _dc;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_WIN32_WIN32VIEWPORT_HPP
