#ifndef LUCIDREAMS_SRC_RENDERING_VIEWPORTMANAGERFACTORY_HPP
#define LUCIDREAMS_SRC_RENDERING_VIEWPORTMANAGERFACTORY_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    class ViewportManagerFactory
    {
    public:
        [[nodiscard]] static std::shared_ptr<IViewportManager> create();
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_VIEWPORTMANAGERFACTORY_HPP
