#ifndef LUCIDREAMS_SRC_RENDERING_IVIEWPORTMANAGER_HPP
#define LUCIDREAMS_SRC_RENDERING_IVIEWPORTMANAGER_HPP

#include <memory>
#include <vector>

#include <lucidreams/ForwardDeclarations.hpp>
#include <lucidreams/Types.hpp>

namespace lucidreams
{
    typedef struct ViewportParams
    {
        WideString title;
        int width;
        int height;
    } viewport_params_t;

    class IViewportManager
    {
        friend class IViewport;

    public:
        virtual ~IViewportManager() = default;

        // Initializes viewport manager.
        virtual void init();

        // Terminates viewport manager.
        virtual void terminate();

        // Creates instance of viewport.
        [[nodiscard]] virtual std::weak_ptr<IViewport> createViewport(const viewport_params_t &params) = 0;

        // Refreshes all viewports.
        void refreshAll();

        // Destroys all viewports.
        void destroyAll();

    protected:
        std::vector<std::shared_ptr<IViewport>> _viewports;

        void removeViewport(const IViewport *viewport);
    };
}

#endif //LUCIDREAMS_SRC_RENDERING_IVIEWPORTMANAGER_HPP
