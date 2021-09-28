#include "IViewportManager.hpp"

#include <algorithm>

#include "IViewport.hpp"

namespace lucidreams
{
    void IViewportManager::init()
    {
        //
    }

    void IViewportManager::terminate()
    {
        this->destroyAll();
    }

    void IViewportManager::refreshAll()
    {
        for (const auto &viewport : this->_viewports)
        {
            viewport->swapBuffers();
            viewport->pollEvents();
        }
    }

    void IViewportManager::destroyAll()
    {
        for (const auto &viewport : this->_viewports)
        {
            viewport->destroy();
        }

        this->_viewports.clear();
    }

    void IViewportManager::removeViewport(const IViewport *viewport)
    {
        this->_viewports.erase(std::remove_if(this->_viewports.begin(), this->_viewports.end(), [&viewport](const std::shared_ptr<IViewport> &item)
        {
            return item.get() == viewport;
        }), this->_viewports.end());
    }
}