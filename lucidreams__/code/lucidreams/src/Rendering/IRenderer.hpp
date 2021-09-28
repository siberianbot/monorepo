#ifndef LUCIDREAMS_SRC_RENDERING_IRENDERER_HPP
#define LUCIDREAMS_SRC_RENDERING_IRENDERER_HPP

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Interfaces/IDisplayNameProvider.hpp>

namespace lucidreams
{
    class IRenderer : public IDisplayNameProvider
    {
    public:
        ~IRenderer() override = default;

        virtual void init() = 0;
        virtual void terminate() = 0;

        [[nodiscard]] virtual std::weak_ptr<ISurfaceFactory> getSurfaceFactory() const = 0;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_IRENDERER_HPP
