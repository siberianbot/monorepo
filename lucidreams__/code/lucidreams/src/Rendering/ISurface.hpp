#ifndef LUCIDREAMS_SRC_RENDERING_ISURFACE_HPP
#define LUCIDREAMS_SRC_RENDERING_ISURFACE_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Interfaces/IDisplayNameProvider.hpp>

namespace lucidreams
{
    // Surface interface.
    // It is some surface where all rendered image goes.
    class ISurface : public IDisplayNameProvider
    {
    public:
        explicit ISurface(const std::weak_ptr<IViewport> &viewport);
        ~ISurface() override = default;

        virtual void destroy() = 0;

        [[nodiscard]] virtual bool isAlive() const = 0;
        [[nodiscard]] std::weak_ptr<IViewport> getViewport() const { return this->_viewport; }

    private:
        std::weak_ptr<IViewport> _viewport;
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_ISURFACE_HPP
