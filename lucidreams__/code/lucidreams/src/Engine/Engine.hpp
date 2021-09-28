#ifndef LUCIDREAMS_SRC_ENGINE_ENGINE_HPP
#define LUCIDREAMS_SRC_ENGINE_ENGINE_HPP

#include <memory>

#include <lucidreams/ForwardDeclarations.hpp>

namespace lucidreams
{
    class Engine
    {
    public:
        static Engine &instance();

        void init(/* initialization parameters goes here */);
        void terminate();

        void run(/* initialization parameters goes here */);

        [[nodiscard]] std::shared_ptr<Log> getLog() const { return this->_log; }
        [[nodiscard]] std::shared_ptr<DynamicLibraryManager> getDynamicLibraryManager() const { return this->_dynamicLibraryManager; }
        [[nodiscard]] std::shared_ptr<IRenderer> getRenderer() const { return this->_renderer; }
        [[nodiscard]] std::shared_ptr<IViewportManager> getViewportManager() const { return this->_viewportManager; }

    private:
        std::shared_ptr<Log> _log;
        std::shared_ptr<DynamicLibraryManager> _dynamicLibraryManager;
        std::shared_ptr<IRenderer> _renderer;
        std::shared_ptr<IViewportManager> _viewportManager;
    };
}

#endif //LUCIDREAMS_SRC_ENGINE_ENGINE_HPP
