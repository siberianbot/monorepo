#ifndef LUCIDREAMS_SRC_RENDERING_ISURFACEFACTORY_HPP
#define LUCIDREAMS_SRC_RENDERING_ISURFACEFACTORY_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    class ISurfaceFactory
    {
    public:
        virtual ~ISurfaceFactory() = default;

        virtual std::shared_ptr<ISurface> create(const std::weak_ptr<IViewport> &viewport) = 0;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_ISURFACEFACTORY_HPP
