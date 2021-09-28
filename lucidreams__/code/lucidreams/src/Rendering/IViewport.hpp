#ifndef LUCIDREAMS_SRC_RENDERING_IVIEWPORT_HPP
#define LUCIDREAMS_SRC_RENDERING_IVIEWPORT_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Interfaces/IDisplayNameProvider.hpp>

namespace lucidreams
{
    // Viewport interface.
    // It's a system window or something else which is used to contain surface for output image.
    class IViewport : public IDisplayNameProvider
    {
    public:
        explicit IViewport();
        ~IViewport() override = default;

        virtual void pollEvents() = 0;
        virtual void swapBuffers() = 0;
        virtual void destroy();

        virtual void setVisibility(bool isVisible);

        [[nodiscard]] virtual bool isAlive() const = 0;
        [[nodiscard]] virtual bool isVisible() const { return this->isAlive() && this->_visible; }

    protected:
        bool _visible;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_IVIEWPORT_HPP
