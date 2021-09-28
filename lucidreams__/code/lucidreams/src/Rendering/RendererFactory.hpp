#ifndef LUCIDREAMS_SRC_RENDERING_RENDERERFACTORY_HPP
#define LUCIDREAMS_SRC_RENDERING_RENDERERFACTORY_HPP

#include <memory>
#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    class RendererFactory
    {
    public:
        [[nodiscard]] static std::shared_ptr<IRenderer> create();
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_RENDERERFACTORY_HPP
