#include "Engine.hpp"

#include <lucidreams/Utils/StringFormat.hpp>

#include "../Common/EngineException.hpp"
#include "../Rendering/IRenderer.hpp"
#include "../Rendering/IViewport.hpp"
#include "../Rendering/IViewportManager.hpp"
#include "../Rendering/RendererFactory.hpp"
#include "../Rendering/ViewportManagerFactory.hpp"
#include "../System/IDynamicLibraryProxy.hpp"
#include "../System/DynamicLibraryManager.hpp"
#include "../Utils/Log.hpp"

namespace lucidreams
{
    Engine &Engine::instance()
    {
        static Engine instance;
        return instance;
    }

    void Engine::init()
    {
        this->_log->info("Engine", "initialization");

        this->_dynamicLibraryManager = std::make_shared<DynamicLibraryManager>();

        this->_viewportManager = ViewportManagerFactory::create();
        this->_viewportManager->init();

        this->_renderer = RendererFactory::create();
        this->_renderer->init();
    }

    void Engine::terminate()
    {
        this->_log->info("Engine", "termination");

        this->_renderer->terminate();
        this->_viewportManager->terminate();

        this->_dynamicLibraryManager->unloadAll();
        this->_log->flush();

        std::exit(0x00);
    }

    void Engine::run()
    {
        this->_log = std::make_shared<Log>("latest.log");
        this->_log->info("", "lucidreams");

        try
        {
            this->init();

            std::weak_ptr<IViewport> viewport = this->_viewportManager->createViewport({ L"lucidreams", 800, 600 });

            // TODO: it shouldn't be endless loop.
            while (!viewport.expired() && viewport.lock()->isAlive())
            {
                this->_viewportManager->refreshAll();
            }
        }
        catch (EngineException &exception)
        {
            this->_log->error("Engine", format<char>("UNEXPECTED ERROR OCCURRED: %0", exception.what()));
        }

        terminate();
    }
}

