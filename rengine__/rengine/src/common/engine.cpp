#include "engine.hpp"

#include <exception>

#include "./log.hpp"
#include "../rendering/renderer.hpp"
#include "../scripting/apiHost.hpp"
#include "../scripting/nethost.hpp"
#include "../utils/assert.hpp"

namespace rengine
{
    static const char *STR_VERSION = "0.1.0";

    engine &engine::instance()
    {
        static engine instance;
        return instance;
    }

    engine::engine()
    {
        log::instance().info("Powered by rengine %0", STR_VERSION);
    }

    void engine::run(const engine_runtime_params_t &params)
    {
        try
        {
            log::instance().info("Initiating engine...");

            engineAssert(glfwInit(), "GLFW: initialization failed");

            window_params_t windowParams
            {
                .width = 800,
                .height = 600,
                .title = "rengine app"
            };

            _window = std::make_shared<window>(windowParams);
            _window->makeCurrent();

            nethost::instance().init();
            apiHost::instance().init(L"rengine.Application.dll");

            renderer::instance().init();

            while (_window->isOpen())
            {
                renderer::instance().render();
                // TODO: updating code goes here

                _window->refresh();
                glfwPollEvents();
            }

            shutdown(false);
        }
        catch (std::exception &exception)
        {
            log::instance().error("An error occurred: %0", exception.what());

            shutdown(true);
        }
    }

    void engine::shutdown(bool isFailure)
    {
        log::instance().info("Terminating engine...");

        glfwTerminate();
        nethost::instance().shutdown();

        std::exit(isFailure ? 0xFF : 0x00);
    }
}