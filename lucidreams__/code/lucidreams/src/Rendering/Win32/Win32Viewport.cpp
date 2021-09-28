#include "Win32Viewport.hpp"

#include "../../Engine/Engine.hpp"
#include "../../Utils/Log.hpp"

namespace lucidreams
{
    Win32Viewport::Win32Viewport() : _handle(nullptr), _dc(nullptr)
    {
        //
    }

    Win32Viewport::~Win32Viewport()
    {
        if (this->isAlive())
        {
            this->destroy();
        }
    }

    void Win32Viewport::pollEvents()
    {
        if (!this->isAlive())
        {
            Engine::instance().getLog()->warn(this->getDisplayName(), "attempt to poll events for destroyed viewport");
            return;
        }

        MSG msg = {};
        while (PeekMessage(&msg, this->_handle, 0, 0, PM_REMOVE))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    void Win32Viewport::swapBuffers()
    {
        if (!this->isAlive())
        {
            Engine::instance().getLog()->warn(this->getDisplayName(), "attempt to swap buffers for destroyed viewport");
            return;
        }

        SwapBuffers(this->_dc);
    }

    void Win32Viewport::destroy()
    {
        if (!this->isAlive())
        {
            Engine::instance().getLog()->warn(this->getDisplayName(), "attempt to destroy for destroyed viewport");
            return;
        }

        Engine::instance().getLog()->trace(this->getDisplayName(), "destroying viewport");

        DestroyWindow(this->_handle);

        this->_handle = nullptr;

        IViewport::destroy();
    }

    void Win32Viewport::setVisibility(bool isVisible)
    {
        IViewport::setVisibility(isVisible);

        ShowWindow(this->_handle, isVisible ? SW_SHOW : SW_HIDE);
    }
}