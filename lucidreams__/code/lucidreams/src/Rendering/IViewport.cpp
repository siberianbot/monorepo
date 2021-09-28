#include "IViewport.hpp"

#include "../Engine/Engine.hpp"
#include "IViewportManager.hpp"

namespace lucidreams
{
    IViewport::IViewport() : _visible(false)
    {
        //
    }

    void IViewport::destroy()
    {
        Engine::instance().getViewportManager()->removeViewport(this);
    }

    void IViewport::setVisibility(bool isVisible)
    {
        this->_visible = isVisible;
    }
}